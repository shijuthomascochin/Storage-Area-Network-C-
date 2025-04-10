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
    public partial class Client_New : Form
    {
        client obj;
        public Client_New(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Client_New_Load(object sender, EventArgs e)
        {
            
            try
            {
                obj.write("SSELECT Branch FROM Branch");
                string s = obj.read();
                string[] st=s.Split(":".ToCharArray());
                for (int i = 0; i < st.Length; i++)
                {
                   string[] a = st[i].Split("-".ToCharArray());
                   for (int j = 0; j < a.Length-1; j++)
                   {
                       comboBox1.Items.Add(a[j].ToString().Trim());
                   }
                   if (comboBox1.Items.Count != 0)
                       comboBox1.SelectedIndex = 0;
                }
                obj.write("SSELECT Account FROM Account");
                string s1 = obj.read();
                string[] st1 = s1.Split(":".ToCharArray());
                for (int i = 0; i < st1.Length; i++)
                {
                    string[] a1 = st1[i].Split("-".ToCharArray());
                    for (int j = 0; j < a1.Length - 1; j++)
                    {
                        comboBox2.Items.Add(a1[j].ToString().Trim());
                    }
                    if (comboBox2.Items.Count != 0)
                        comboBox2.SelectedIndex = 0;
                }
                obj.write("SSELECT isnull(max(ano)+1,10000 ) as ano FROM Customer");
                string s2 = obj.read();
                s2=s2.Substring(0,s2.LastIndexOf("-"));
                textBox1.Text = s2.ToString();
                textBox5.Text = s2.ToString();
            }
            catch (Exception)
            { 
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern = @"(^[a-zA-Z\s]*)$";
            string pattern1 = @"(^[0-9]*)$";
            Match mt,mt1;
            mt = Regex.Match(textBox2.Text, pattern);
            mt1 = Regex.Match(textBox4.Text, pattern1);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Your Name");
                textBox2.Focus();
            }
            else if (!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Your Name");
                textBox2.Focus();
            }
            else if (textBox3.Text=="")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Enter Your Address");
                textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Your Telephone No");
                textBox4.Focus();
            }
            else if (!mt1.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Your Telephone No");
                textBox4.Focus();
            }
            else
            {
                
                obj.write("IINSERT INTO Customer (ano, aname, apin, aadd, aphone, nominee1,nominee2,stat) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "',0)");
                
                Account_Open open = new Account_Open(this,obj);
                open.Show();
                this.Hide();
            }
        }

        private void Client_New_Load_1(object sender, EventArgs e)
        {

        }

    }
}