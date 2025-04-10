using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SAN
{
    public partial class View_Client : Form
    {
        client obj;
        string tem1;
        public View_Client(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void View_Client_Load(object sender, EventArgs e)
        {
            obj.write("SSELECT Customer.ano, Customer.aname, Customer.apin, Customer.aadd, Customer.aphone, Customer.abal,Customer.nominee1,Customer.stat,Customer_Details.Branch,Customer_Details.Acc_Type  FROM  Customer INNER JOIN  Customer_Details ON Customer.ano = Customer_Details.ano");
            string s = obj.read();
            string[] st = s.Split(":".ToCharArray());
            for (int i = 0; i < st.Length - 1; i++)
            {
                string[] a = st[i].Split("-".ToCharArray());

                ListViewItem item = new ListViewItem();
                item.Text = a[0].ToString();
                item.SubItems.Add(a[1].ToString());
                item.SubItems.Add(a[2].ToString());
                item.SubItems.Add(a[3].ToString());
                item.SubItems.Add(a[4].ToString());
                item.SubItems.Add(a[5].ToString());
                item.SubItems.Add(a[8].ToString());
                item.SubItems.Add(a[9].ToString());
                item.SubItems.Add(a[6].ToString());
                item.SubItems.Add(a[7].ToString());
                tem1 = a[7].ToString();
                obj.write("SSELECT doc FROM  Customer INNER JOIN  Customer_Details ON Customer.ano = Customer_Details.ano");
                string s1 = obj.read();
                string[] st1 = s1.Split(":".ToCharArray());
                item.SubItems.Add(st1[0].ToString());
                if (tem1 == "0")
                {
                    obj.write("SSELECT dot  FROM   Terminate where ano=" + a[0].ToString() + "");
                    string s2 = obj.read();
                    string[] st2 = s2.Split("-".ToCharArray());
                    item.SubItems.Add(st2[0].ToString());

                }
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}