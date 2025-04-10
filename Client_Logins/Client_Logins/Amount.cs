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
    public partial class Amount : Form
    {
        client obj;
        string uname;
        Boolean f;
        public Amount(client c,string s)
        {
            obj = c;
            uname = s;

            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            float fl = 0.0f;
            string ss="";
            obj.write("SSELECT Customer.aname, Customer.abal,Customer_Details.Acc_Type FROM Customer INNER JOIN Customer_Details ON Customer.ano = Customer_Details.ano WHERE (Customer.ano = " + uname + ")");
            string result = obj.read();
            if (result.Equals(null))
            {
                MessageBox.Show("gssg");
            }
            else
            {
                string[] st1 = result.Split(":".ToCharArray());
                for (int i = 0; i < st1.Length - 1; i++)
                {
                    string[] a = st1[i].Split("-".ToCharArray());
                    fl = float.Parse(a[1].ToString());
                    ss = a[2].ToString();


                }
            }
            float mbal = 0.0F, deduct = 0.0F;
            obj.write("SSELECT minbal,ded FROM  Account where Account='" + ss + "'");
            string s1 = obj.read();

            MessageBox.Show(s1);

            string[] st = s1.Split(":".ToCharArray());
            for (int i = 0; i < st.Length - 1; i++)
            {
                string[] a = st[i].Split("-".ToCharArray());

                mbal = float.Parse(a[0].ToString());
                deduct = float.Parse(a[1].ToString());
            }
            string pattern = @"(^[0-9]*[0][0])$";
            Match mt;
            mt = Regex.Match(textBox1.Text, pattern);
            if (textBox1.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Enter Your Amount");
                textBox1.Focus();
            }
            else if (!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Enter Your Amount as denominations of 100 ");
                textBox1.Focus();
            }
            else if (fl < float.Parse(textBox1.Text))
            {
                MessageBox.Show("Your account doesnt have the sufficient balance");
                errorProvider1.Clear();
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
            {
                f = false;
               
                try
                {
                   

                    if ((fl - float.Parse(textBox1.Text)) < mbal)
                    {
                        f = true;
                    }
                   
                        obj.write("SSELECT ISNULL(MAX(tid) + 1, 1) AS tid  FROM Transactions");
                        string trno = obj.read();
                        trno = trno.Substring(0, trno.LastIndexOf("-"));
                        obj.write("Uupdate   Customer set abal=abal-" + textBox1.Text + " where ano=" + uname + "");
                        string s = obj.read();
                        if (s == "T")
                        {
                            obj.write("Iinsert into Transactions values(" + trno + "," + uname + "," + textBox1.Text + ",'" + System.DateTime.Now.ToShortDateString() + "','W')");
                            MessageBox.Show("Successfully Withdraw an Amount " + textBox1.Text + " ", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        if (f == true)
                        {
                            obj.write("Uupdate  Customer set abal=abal-" + deduct + " where ano=" + uname + "");
                            MessageBox.Show("Rs." + deduct + " would be deducted from your current balance");
                            string s2 = obj.read();
                            if (s2 == "T")
                            {
                            }
                            this.Dispose();
                        }

                    }
                    catch (Exception)
                    {
                    }
                }
           
        }

        private void Amount_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        }
    }
