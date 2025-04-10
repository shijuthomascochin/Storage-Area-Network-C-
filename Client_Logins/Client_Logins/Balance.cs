using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client_Logins
{
    public partial class Balance : Form
    {
        client obj;
        string uname;
        public Balance(client c, string s)
        {   obj = c;
            uname = s;
            InitializeComponent();
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            try
            {
                obj.write("SSELECT Customer.aname, Customer.abal FROM Customer INNER JOIN Customer_Details ON Customer.ano = Customer_Details.ano WHERE (Customer.ano = " + uname + ")");
                string result = obj.read();
                if(result.Equals(null))
                {
                    MessageBox.Show("gssg");
                }
                else{
                string[] st = result.Split(":".ToCharArray());
                for (int i = 0; i < st.Length - 1; i++)
                {
                    string[] a = st[i].Split("-".ToCharArray());
                    textBox1.Text = a[1].ToString();


                }
            }}
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        this.Dispose();
        }
        }
    }
