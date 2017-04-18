using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 服务器本地端口
        /// </summary>
        private const int LOCAL_PORT = 1500;

        TcpListener listener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, LOCAL_PORT);
            // 开始监听
            listener.Start();
            AppendToTextBox("已开始监听连接。");
            // 开始接受连接
            listener.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), listener);
        }

        private void acceptCallback(IAsyncResult ar)
        {
            TcpListener lstn = (TcpListener)ar.AsyncState;
            // 开始接收数据
            TcpClient client = lstn.EndAcceptTcpClient(ar);

            Task.Run(() =>
                {
                    // 获取远程主机名
                    string host = client.Client.RemoteEndPoint.ToString();
                    // 获取流对象
                    NetworkStream stream = client.GetStream();
                    string msg = null;
                    while(true)
                    {
                        // 读取长度
                        byte[] buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        int len = BitConverter.ToInt32(buffer, 0);
                        // 读取正文
                        buffer = new byte[len];
                        stream.Read(buffer, 0, len);
                        string recMsg = Encoding.UTF8.GetString(buffer);
                        if (recMsg == "$END$")
                        {
                            string message = "客户端" + host + "发送了退出指令。";
                            txtRecMsgs.Invoke(new Action(() => AppendToTextBox(message)));
                            break; //退出
                        }
                        else
                        {
                            txtRecMsgs.Invoke((Action)delegate()
                            {
                                // 显示收到的消息
                                string message = string.Format("来自{0}的消息：{1}", host, recMsg);
                                AppendToTextBox(message);
                            });
                        }
                    }
                    client.Close();
                });
            // 继续接受连接
            lstn.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), lstn);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listener != null)
                listener.Stop(); //停止监听
        }

        private void AppendToTextBox(string msg)
        {
            txtRecMsgs.AppendText(msg + "\r\n");
        }
    }
}
