using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client_Logins
{
    public partial class Transaction : Form
    {
        client obj;
        string uname = "";
        public Transaction(client c,string s)
        {
            uname = s;
            obj = c;

            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            obj.write("SSELECT     tid, ano, amount, CONVERT(varchar, dt, 101) AS Expr1, f FROM Transactions where ano=" + uname + "");
            string s = obj.read();
            if (s != "")
            {
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
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No Transaction Were Done  ", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}