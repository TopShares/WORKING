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

namespace Example_3
{
    public partial class Form1 : Form
    {
        private UdpClient udpClient = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int localPort = 0;
            if (!int.TryParse(txtLocalPort.Text, out localPort))
            {
                MessageBox.Show("请输入正确的本地端口。"); return;
            }

            if (udpClient != null)
            {
                udpClient.Close();
                udpClient = null;
            }

            udpClient = new UdpClient(localPort);

            groupBox1.Enabled = false;
            groupBox3.Enabled = true;
            lblMessage.Text = "本地端口已设定。";

            // 开始接收消息
            try
            {
                udpClient.BeginReceive(new AsyncCallback(ReceiveMsgCallback), null);
            }
            catch { }
        }

        private void ReceiveMsgCallback(IAsyncResult ar)
        {
            if (udpClient != null)
            {
                try
                {
                    // 远程主机
                    IPEndPoint remoteHost = new IPEndPoint(IPAddress.Any, 0);
                    // 接收数据
                    byte[] buffer = udpClient.EndReceive(ar, ref remoteHost);
                    string msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    rtbMsgs.Invoke(new Action(delegate()
                    {
                        string str = string.Format("从{0}接收到消息【{1}】。", remoteHost.ToString(), msg);
                        SetReceivedMessage(str);
                    }));
                }
                catch { }
            }

            // 继续接收数据
            if (udpClient != null)
            {
                try
                {
                    udpClient.BeginReceive(new AsyncCallback(ReceiveMsgCallback), null);
                }
                catch { }
            }
        }


        private void SetReceivedMessage(string msg)
        {
            this.rtbMsgs.Select(rtbMsgs.TextLength, 0);
            this.rtbMsgs.SelectionColor = Color.Blue;
            this.rtbMsgs.AppendText(msg + "\r\n");
        }

        private void SetSentMessage(string msg)
        {
            this.rtbMsgs.Select(rtbMsgs.TextLength, 0);
            this.rtbMsgs.SelectionColor = Color.Green;
            this.rtbMsgs.AppendText(msg + "\r\n");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtToSend.Text))
            {
                return;
            }
            int remotePort = 0;
            if (!int.TryParse(txtRemotePort.Text, out remotePort))
            {
                MessageBox.Show("请输入远程计算机的端口号。"); return;
            }
            IPAddress remoteIP;
            if (IPAddress.TryParse(txtRemoteIP.Text, out remoteIP) == false)
            {
                MessageBox.Show("请输入远程计算机的IP地址。"); return;
            }

            try
            {
                string msg = txtToSend.Text;
                byte[] data = Encoding.UTF8.GetBytes(msg);
                // 发送数据
                IPEndPoint ipe = new IPEndPoint(remoteIP, remotePort);
                udpClient.Send(data, data.Length, ipe);
                SetSentMessage(string.Format("消息【{0}】已发送。", msg));
                txtToSend.Clear();
            }
            catch
            {
            }
        }
    }
}
