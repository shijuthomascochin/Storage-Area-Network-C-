using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using Cinter;
using ConDbLib;
namespace Server
{
    
    public class oneclient
    {
        Socket s;
        ThreadStart ts;
        Thread t;
        CDB obj = new CDB();
        public oneclient(Socket ss)
        {
            s = ss;
            ts = new ThreadStart(this.processmessage);
            t = new Thread(ts);
            t.Start();
        }
        public void processmessage()
        {
          
            for (; ; )
            {
                string str = read();
                if (str.Equals("quit")) break;
                parsemessage(str);
            }
        }
        public void parsemessage(string str)
        {
          
            if (str.StartsWith("C"))
            {
                str = str.Substring(1);
                processLogin(str);
            }
            else if(str.StartsWith("S"))
            {
                str = str.Substring(1);
                processSelect(str);
            }
            else if (str.StartsWith("I"))
            {
                str = str.Substring(1);
                processInsert(str);
            }
            else if (str.StartsWith("U"))
            {
                str = str.Substring(1);
                processUpdate(str);
            }
            else if (str.StartsWith("-r"))
            {
                str = str.Substring(2);
                processReport(str);
            }
            
        }
        public void processReport(string str)
        {
            str = str.Trim();
            string[] ss = str.Split(",".ToCharArray());
            System.Data.SqlClient.SqlConnection con;
            con = new SqlConnection();
            System.Data.SqlClient.SqlCommand cmd = new SqlCommand();
            System.Data.SqlClient.SqlDataAdapter ad;
            ad = new SqlDataAdapter();

            con.ConnectionString = "Data Source=.;Initial Catalog=SAN;Integrated Security=true;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Windows.Forms.MessageBox.Show(ss[0]);
            cmd.CommandText = ss[0];
            cmd.Parameters.Add(new SqlParameter("@ano",SqlDbType.Int,0,"ano"));
            cmd.Parameters["@ano"].Value = ss[1];

            ad.SelectCommand = cmd;
            DataSet ds = new DataSet();
            ad.Fill(ds);
            ds.WriteXml("c:\\test.xml");

            System.IO.Stream sss;
            sss = System.IO.File.OpenRead("c:\\test.xml");
            byte[] bbb = new byte[sss.Length];

            sss.Read(bbb, 0, (int)sss.Length);

            sss.Close();
            string strr = new ASCIIEncoding().GetString(bbb, 0, bbb.Length);
            strr = "-x" + strr;
            System.Windows.Forms.MessageBox.Show(strr);
            write(strr);

        }
        public string read()
        {
            string str = "";
            try
            {
                byte[] b = new byte[10000];
                int n;
                ASCIIEncoding obj = new ASCIIEncoding();
                n = s.Receive(b, 0, 10000, 0);
                str = obj.GetString(b, 0, n);
            }
            catch (Exception ex)
            { }
            return str;
        }
        public void write(string str)
        {
            try
            {
                byte[] b = new byte[str.Length];
                ASCIIEncoding obj = new ASCIIEncoding();
                b = obj.GetBytes(str.ToCharArray(), 0, str.Length);
                s.Send(b, 0, str.Length, 0);
            }
            catch (Exception)
            { 
            }
        }
        public void processLogin(string str)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord(str);
                if (dt.Rows.Count != 0)
                    write("Yes");
                else
                    write("No");
                obj.close();
            }
            catch (Exception)
            { 
            }
        
        
        }
        public void processSelect(string str)
        {
            string result="";
            try
            {
                obj.OpenConnection();
                DataTable dt = new DataTable();
                dt = obj.getRecord(str);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        result = result.Trim() + dt.Rows[i][j].ToString().Trim() + "-";
                    }
                    result = result.Trim() + ":";
                
                }
                obj.close();

            }
            catch (Exception)
            { 
            }
            write(result);
        }
        public void processInsert(string str)
        {
            
            try
            {
                obj.OpenConnection();
                obj.nonselectquery(str);

                ///// Linux connectivity

                //LinClient lcobj = new LinClient();
                //lcobj.connect();
                //lcobj.sendmessage("W" + str);
                //lcobj.close();


                /////
               
                try
                {
                    HttpChannel c = new HttpChannel();
                    ChannelServices.RegisterChannel(c);
                }
                catch (Exception)
                {

                }

                I1 obj1;
                DataTable dt = obj.getRecord("SELECT Ip_Address  FROM Ip_Address");
                foreach (DataRow dr in dt.Rows)
                {
                    obj1 = (I1)Activator.GetObject(typeof(I1), "http://"+dr[0].ToString()+":1234/rem");
                    obj1.insert(str);
                }
                obj.close();
            }
            catch (Exception)
            {
            }
          
        }

        public void processUpdate(string str)
        {

            try
            {
                obj.OpenConnection();
                obj.nonselectquery(str);
                
                ///////


                //LinClient lcobj = new LinClient();
                //lcobj.connect();
                //lcobj.sendmessage("W" + str);
                //lcobj.close();



                ///////
                try
                {
                    HttpChannel c = new HttpChannel();
                    ChannelServices.RegisterChannel(c);
                }
                catch (Exception)
                {

                }
                
                I1 obj1;
                DataTable dt = obj.getRecord("SELECT Ip_Address  FROM Ip_Address");
                foreach (DataRow dr in dt.Rows)
                {
                    obj1 = (I1)Activator.GetObject(typeof(I1), "http://" + dr[0].ToString() + ":1234/rem");
                    obj1.insert(str);
                }
                obj.close();
            }
            catch (Exception ex)
            {
            }
            write("T");

        }
   

    }
}
