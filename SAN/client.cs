using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace SAN
{
   public class client
    {
        Stream s;
        TcpClient tc;
        
        public string un;
        public client()
        {
            
        }
        public void connect(string ip, string port)
        {
            int prt = int.Parse(port.ToString());
            try
            {
                tc = new TcpClient(ip,prt);
                s = tc.GetStream();
            }
            catch (Exception )
            { 
            }
        }
        public string read()
        {
            string str="";
            try
            {
                byte[] b = new byte[10000];
                int n;
                ASCIIEncoding obj = new ASCIIEncoding();
                n = s.Read(b, 0, 10000);
                 str = obj.GetString(b, 0, n);
            }
            catch(Exception )
            {}
            return str;
        }
        public void write(string str)
        {
            try
            {
                byte[] b = new byte[str.Length];
                 ASCIIEncoding obj = new ASCIIEncoding();
                b = obj.GetBytes(str.ToCharArray(), 0, str.Length);
                s.Write(b, 0, str.Length);
            }
            catch (Exception)
            { 
            }
        }

    }
}
