using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using Microsoft.Win32;
namespace Server
{
    public class CServer
    {
        TcpListener ls;
        ThreadStart ts;
        Thread t;
        public CServer()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("software");
                RegistryKey rsk = rk.OpenSubKey("sanServer");
                string prt = rsk.GetValue("pt").ToString();
                int port = int.Parse(prt);
                //int port = readfromregistry();
                ls = new TcpListener(port);
                ls.Start();
                createthread();
            }
            catch (Exception)
            {
            }
        }
        public void createthread()
        {
            ts = new ThreadStart(acceptconnection);
            t = new Thread(ts);
            t.Start();
        }
        public void stop()
        {
            t.Abort();
        }
        public void acceptconnection()
        {
            for (; ; )
            {
                Socket asoc = ls.AcceptSocket();
                oneclient obj = new oneclient(asoc);
            }
        }

    }
}
