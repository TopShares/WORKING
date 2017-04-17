using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 1332);
            server.Bind(endpoint);
            server.Listen(15);
            server.BeginAccept(new AsyncCallback(AccpCallback), server);
            Console.Read();
        }

        private static void AccpCallback(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            Socket client = server.EndAccept(ar);
            Console.WriteLine("已接受客户端{0}的连接。",client.RemoteEndPoint.ToString());

            byte[] data = Encoding.UTF8.GetBytes("您好，服务器已经连接了。");
            int len = data.Length;
            client.Send(BitConverter.GetBytes(len));
            client.Send(data);
            client.Close();
            server.BeginAccept(new AsyncCallback(AccpCallback), server);
        }
    }
}
