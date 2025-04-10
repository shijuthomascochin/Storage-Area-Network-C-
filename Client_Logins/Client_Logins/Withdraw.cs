using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Client_Logins
{
    public partial class Withdraw : Form
    {
        client obj;
        string uname;
        public Withdraw(client c, string s)
        {
            obj = c;
            uname = s;
            InitializeComponent();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            label6.Text = uname.ToString();
            obj.write("SSELECT Customer.aname, Customer_Details.Branch, Customer_Details.Acc_Type, Customer.abal FROM Customer INNER JOIN Customer_Details ON Customer.ano = Customer_Details.ano WHERE (Customer.ano = " + uname + ")");
            string result = obj.read();
            string[] st = result.Split(":".ToCharArray());
            for (int i = 0; i < st.Length - 1; i++)
            {
                string[] a = st[i].Split("-".ToCharArray());
                textBox1.Text = a[0].ToString();
                textBox5.Text = a[1].ToString();
                textBox2.Text = a[2].ToString();
                textBox3.Text = a[3].ToString();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern = @"(^[0-9]*[.][0-9][0-9])$";
            Match mt;
            mt = Regex.Match(textBox4.Text, pattern);
            if (textBox4.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Your Amount as 0.00");
                textBox4.Focus();
            }
            else if (!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Your Amount 0.00 ");
                textBox4.Focus();
            }
            else
            {
                try
                {
                    //getting max no of transaction No 
                    obj.write("SSELECT ISNULL(MAX(tid) + 1, 1) AS tid  FROM Transactions");
                    string trno = obj.read();
                    trno = trno.Substring(0, trno.LastIndexOf("-"));
                    obj.write("Uupdate   Customer set abal=abal-" + textBox4.Text + " where ano=" + uname + "");
                    string s = obj.read();
                    if (s == "T")
                    {
                        obj.write("Iinsert into Transactions values(" + trno + "," + uname + "," + textBox4.Text + ",'" + System.DateTime.Now.ToShortDateString() + "','W')");
                        MessageBox.Show("Successfully Withdraw an Amount " + textBox4.Text + " ", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}