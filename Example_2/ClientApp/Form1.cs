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

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient client = null;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string serverName = string.Empty ;
            int serverPort = 0;
            if (txtServer.Text == "")
            {
                return;
            }
            if (!int.TryParse(txtPort.Text,out serverPort))
            {
                return;
            }
            if (client != null)
            {
                if (client.Connected)
                    client.Close();
            }
            // 创建TcpClient实例并进行连接
            try
            {
                client = new TcpClient(serverName, serverPort);
                lblTip.Text = "已连接。";
                btnConnect.Enabled = false;
                btnClose.Enabled = true;
            }
            catch (SocketException ex)
            {
                lblTip.Text = ex.Message;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭连接
            if ( client != null )
            {
                if (client.Connected)
                {
                    // 发送关闭消息
                    SendMessage("$END$");
                    client.Close();
                }
                client = null;
            }
            btnClose.Enabled = false;
            btnConnect.Enabled = true;
            lblTip.Text = "连接已关闭。";
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendMessage(string msg)
        {
            if (client == null) return;
            if (client.Connected == false) return;

            byte[] data = Encoding.UTF8.GetBytes(msg);
            // 发送长度
            int len = data.Length;
            byte[] buffer = BitConverter.GetBytes(len);
            client.GetStream().Write(buffer, 0, 4);
            // 发送内容
            client.GetStream().Write(data, 0, data.Length);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMsg.Text);
            txtMsg.Clear();
        }
    }
}
