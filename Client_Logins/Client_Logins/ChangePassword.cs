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
    public partial class ChangePassword : Form
    {
        client f1;
        string uname="";
        public ChangePassword(client f,string s)
        {
            f1 = f;
            uname = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // update();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Old Pin Number");
                textBox1.Text = "";
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter New Pin Number");
                textBox2.Text = "";
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Re enter New Pin Number");
                textBox3.Text = "";
                textBox3.Focus();
            }
            else if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("New Pin Numbers are not matching");
                textBox3.Text = "";
                textBox2.Text = "";
                textBox2.Focus();
            }
            else
            {
                string cc = "";
               f1.write("SSELECT apin FROM Customer WHERE ano = " + uname + "");
            string result = f1.read();
            string[] st = result.Split(":".ToCharArray());

            for (int i = 0; i < st.Length - 1; i++)
            {
                string[] a = st[i].Split("-".ToCharArray());
                cc = a[0].ToString();
            }
                if (cc == textBox1.Text)
                {
                    f1.write("Iupdate Customer set apin='" + textBox3.Text + "' where ano="+uname+" and apin='" + textBox1.Text + "'");
                    MessageBox.Show("Successfully Updated", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                   
                }
                else
                {
                    MessageBox.Show("Check Old Pin Number", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
            }

        }

       

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //if (textBox1.Text != f1.textBox2.Text)
            //{
            //    MessageBox.Show("Old Password Not Matching");
            //    textBox1.Focus();
            //    textBox1.Text = "";
            //}
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}