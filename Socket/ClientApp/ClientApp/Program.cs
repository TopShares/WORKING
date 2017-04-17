using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace ClientApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = "127.0.0.1";
            int POINT = 1332;
            try
            {
                client.Connect(IP, POINT);
                Console.WriteLine("成功连接服务器{0}", client.RemoteEndPoint.ToString());
                byte[] buffer = new byte[4];
                client.Receive(buffer);
                int len = BitConverter.ToInt32(buffer, 0);
                buffer = new byte[len];
                client.Receive(buffer);
                string msg = Encoding.UTF8.GetString(buffer);
                Console.WriteLine("从服务器接收到的消息：\n" + msg);
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
