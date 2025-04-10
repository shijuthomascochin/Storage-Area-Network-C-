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
    public partial class New_Client : Form
    {
        client obj;
        public New_Client(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern2 = @"(^[a-z A-Z\s\d\-\,\.]*)$";
            string pattern = @"(^[a-zA-Z\s]*)$";
            string pattern1 = @"(^[0-9]*)$";
            Match mt, mt1, mt2, mt3, mt4;
            mt = Regex.Match(textBox2.Text, pattern);
            mt1 = Regex.Match(textBox4.Text, pattern1);
            mt2 = Regex.Match(textBox3.Text, pattern2);
            mt3 = Regex.Match(textBox7.Text, pattern1);
            mt4 = Regex.Match(textBox5.Text, pattern2);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Client's Name");
                textBox2.Focus();
            }
            else if (!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Inavlid Name");
                textBox2.Focus();
            }

            else if (textBox3.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Enter the Client's address");
                textBox3.Focus();
            }
            else if (!mt2.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Invalid address");
                textBox3.Focus();

            }
            else if (textBox4.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Contact number");
                textBox4.Focus();
            }
            else if (!mt1.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Contact number should be numeric");
                textBox4.Focus();
            }


            else if (textBox7.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox7, "Enter Client's Pin Number");
                textBox3.Focus();
            }
            else if (!mt3.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox7, "Pin number should be numeric");
                textBox7.Focus();
            }
            else if (!mt4.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Invalid Nominee address");
                textBox5.Focus();

            }
            else
            {
                obj.write("IINSERT INTO Customer (ano, aname, apin, aadd, aphone, nominee1,stat) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox7.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + textBox5.Text + "',1)");

                Account_Open open = new Account_Open(this, obj);
                open.Show();
                this.Hide();
            }
        }

        private void New_Client_Load(object sender, EventArgs e)
        {
            try
            {
                        comboBox1.Items.Add("SavingsAccount");
                        comboBox1.Items.Add("CurrentAccount");
                comboBox1.SelectedIndex=0;
                  
                   
                obj.write("SSELECT Branch FROM Branch where Branch_id='" + obj.un + "'");
                string s3 = obj.read();
                string[] st3 = s3.Split(":".ToCharArray());
                //for (int i = 0; i < st3.Length; i++)
                //{
                    string[] a3 = st3[0].Split("-".ToCharArray());

                    textBox6.Text = a3[0].ToString().Trim();
                      
                   
                //}
                obj.write("SSELECT isnull(max(ano)+1,10000 ) as ano FROM Customer");
                string s2 = obj.read();
                s2 = s2.Substring(0, s2.LastIndexOf("-"));
                textBox1.Text = s2.ToString();
                textBox7.Text = s2.ToString();

            }
            catch (Exception)
            {
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}