using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client_Logins
{
    public partial class Administrator_Home : Form
    {
        client obj;
        string uname = "";
        public Administrator_Home(client c,string s)
        {
            obj = c;
            uname = s;
            InitializeComponent();
        }

        private void Administrator_Home_Load(object sender, EventArgs e)
        {
            
                obj.write("SSELECT Customer.aname, Customer.abal FROM Customer INNER JOIN Customer_Details ON Customer.ano = Customer_Details.ano WHERE (Customer.ano = " + uname + ")");
                string result = obj.read();
                if (result.Equals(null))
                {
                    MessageBox.Show("gssg");
                }
                else
                {
                    string[] st = result.Split(":".ToCharArray());
                    for (int i = 0; i < st.Length - 1; i++)
                    {
                        string[] a = st[i].Split("-".ToCharArray());
                        label1.Text = a[0].ToString();
                        MessageBox.Show(a[0].ToString());

                    }
                }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit(obj,uname);
            deposit.MdiParent = this;
            deposit.BringToFront();
            deposit.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw withd = new Withdraw(obj, uname);
            withd.MdiParent = this;
            withd.BringToFront();
            withd.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction tr = new Transaction(obj, uname);
            tr.MdiParent = this;
            tr.BringToFront();
            tr.Show();
           
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword chn_pass = new ChangePassword(obj,uname);
            chn_pass.MdiParent = this;
            chn_pass.BringToFront();
            chn_pass.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Mainform mf = new Mainform(obj, uname);
            mf.Show();
           mf.BringToFront();
            mf.Show();
        }
    }
}