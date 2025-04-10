using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace SAN
{
    public partial class Withdraw : Form
    {
        client obj;
        Boolean f;
        public Withdraw(client c)
        {
            obj = c;
            
            InitializeComponent();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            obj.write("SSELECT Customer.ano FROM   Customer INNER JOIN   Customer_Details ON Customer.ano = Customer_Details.ano");
            string s = obj.read();
            MessageBox.Show(s);
             string[] st = s.Split(":".ToCharArray());
             for (int i = 0; i < st.Length - 1; i++)
             {
                 string[] a = st[i].Split("-".ToCharArray());
                 for (int j = 0; j < a.Length - 1; j++)
                 {
                     comboBox1.Items.Add(a[j].ToString().Trim());
                 }
                 if (comboBox1.Items.Count != 0)
                     comboBox1.SelectedIndex = 0;
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox2.Text);
            float mbal=0.0F, deduct=0.0F;
             obj.write("SSELECT minbal,ded FROM  Account where Account='" + textBox2.Text + "'");
                string s1 = obj.read();
                
                MessageBox.Show(s1);

                string[] st = s1.Split(":".ToCharArray());
                for (int i = 0; i < st.Length - 1; i++)
                {
                    string[] a = st[i].Split("-".ToCharArray());
                    
                    mbal = float.Parse(a[0].ToString());
                    deduct = float.Parse(a[1].ToString());
                }
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
            else if (float.Parse(textBox3.Text) < float.Parse(textBox4.Text))
            {
                MessageBox.Show("Your account doesnt have the sufficient balance");
                errorProvider1.Clear();
                textBox4.Text = "";
                textBox4.Focus();
            }

            else
            {
                f = false;
                try
                {
                    if ((float.Parse(textBox3.Text) - float.Parse(textBox4.Text)) < mbal)
                    {
                        f = true;
                    }

                    //getting max no of transaction No 
                    obj.write("SSELECT ISNULL(MAX(tid) + 1, 1) AS tid  FROM Transactions");
                    string trno = obj.read();
                    MessageBox.Show(trno);
                    trno = trno.Substring(0, trno.LastIndexOf("-"));

                    obj.write("Uupdate   Customer set abal=abal-" + textBox4.Text + " where ano=" + comboBox1.SelectedItem.ToString() + "");
                    string s = obj.read();

                    if (s == "T")
                    {
                        obj.write("Iinsert into Transactions values(" + trno + "," + comboBox1.SelectedItem.ToString() + "," + textBox4.Text + ",'" + System.DateTime.Now.ToShortDateString() + "','W')");
                        MessageBox.Show("Successfully Withdrawn an Amount " + textBox4.Text + " ", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    if (f == true)
                    {
                        obj.write("Uupdate  Customer set abal=abal-" + deduct + " where ano=" + comboBox1.SelectedItem.ToString() + "");
                        MessageBox.Show("Rs." + deduct + " would be deducted from your current balance");
                        string s2 = obj.read();
                        if (s2== "T")
                        {
                        }
         
                    }
                    this.Dispose();
                }
                catch (Exception)
                {
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                obj.write("SSELECT Customer.ano, Customer.aname, Customer.abal, Customer_Details.Branch, Customer_Details.Acc_Type FROM   Customer INNER JOIN   Customer_Details ON Customer.ano = Customer_Details.ano WHERE     (Customer.ano = " + comboBox1.SelectedItem.ToString() + ")");
                string s = obj.read();
                if (s == "")
                {


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";

                }
                else
                {
                    string[] st = s.Split(":".ToCharArray());
                    for (int i = 0; i < st.Length - 1; i++)
                    {
                        string[] a = st[i].Split("-".ToCharArray());
                        textBox1.Text = a[1].ToString();
                        textBox2.Text = a[4].ToString();
                        textBox3.Text = a[2].ToString();
                        textBox5.Text = a[3].ToString();


                    }
                }

            }
            catch (Exception)
            {
            }
        }
    }
}