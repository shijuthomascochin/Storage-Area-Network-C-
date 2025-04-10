using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client_Logins
{
    public partial class Mainform : Form
    {
        client obj;
        string uname = "";
        public Mainform(client c, string s)
        {
            obj = c;
            uname = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Amount f1 = new Amount(obj, uname);
            //f1.Show();
            acctype f2 = new acctype(obj, uname,1);
            f2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Balance b1 = new Balance(obj, uname);
           // b1.Show();
            acctype f2 = new acctype(obj, uname,2);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Transaction t1 = new Transaction(obj, uname);
            //State t1 = new State();
          //  t1.Show();
            acctype f2 = new acctype(obj, uname,3);
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            acctype f2 = new acctype(obj, uname,4);
            f2.Show();
        }
    }
}