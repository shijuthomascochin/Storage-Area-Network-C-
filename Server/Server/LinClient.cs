using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Data;

namespace Server
{
    class LinClient
    {
        System.Net.Sockets.TcpClient cs;
        System.IO.Stream io;

        public void connect()
        {
            cs = new System.Net.Sockets.TcpClient("192.168.1.2", 5500);
            io = cs.GetStream();
        }
        public void sendmessage(string str)
        {
            System.Text.ASCIIEncoding obj = new ASCIIEncoding();
            byte []b = new byte[str.Length];
            b = obj.GetBytes(str.ToCharArray(), 0, str.Length);
            io.Write(b, 0, b.Length);
        }
        public void close()
        {
            io.Close();
            cs.Close();
        }
    }
}
