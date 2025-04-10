using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Cinter;
using ConDbLib;
using System.Data;
using System.Windows.Forms;


namespace Server
{
    class CRem
    {
        public void passtoRemote(string str)
        {
            try
            {
                HttpChannel c = new HttpChannel();
                ChannelServices.RegisterChannel(c);
            }
            catch (Exception)
            {

            }

            I1 obj1;
            CDB obj = new CDB();
            obj.OpenConnection();
            DataTable dt = obj.getRecord("SELECT Ip_Address  FROM Ip_Address");
            foreach (DataRow dr in dt.Rows)
            {
                MessageBox.Show(dr[0].ToString());
                string ss = "http://" + dr[0].ToString() + ":1234/rem";
                MessageBox.Show(ss);
                MessageBox.Show(str);
                obj1 = (I1)Activator.GetObject(typeof(I1), ss);
                obj1.insert(str);
            }
        }
    }
}
