using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConDbLib;


namespace SAN
{
    public partial class ChangePassword : Form
    {
        client f1;
        int p;
        public ChangePassword(client f, int n)
        {
            f1 = f;
            p = n;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Old Password");
                textBox1.Text = "";
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter New Password");
                textBox2.Text = "";
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Re enter New Password");
                textBox3.Text = "";
                textBox3.Focus();
            }
            else if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("New Passwords are not matching");
                textBox3.Text = "";
                textBox2.Text = "";
                textBox2.Focus();
            }
            else
            {
            if (p == 2)
            {
                string cc1 = "";
                MessageBox.Show(f1.un);
                f1.write("SSELECT staff_pass FROM Staff WHERE staff_id = '" + Staff_Login.stid + "'");
                string result = f1.read();
               // MessageBox.Show(result);
                string[] st = result.Split(":".ToCharArray());

                for (int i = 0; i < st.Length - 1; i++)
                {
                    string[] a = st[i].Split("-".ToCharArray());
                    cc1 = a[0].ToString();
                }
                if (cc1 == textBox1.Text)
                {
                    f1.write("Iupdate Staff set staff_pass='" + textBox3.Text + "' where staff_id='" + Staff_Login.stid + "' and staff_pass='" + textBox1.Text + "'");
                    MessageBox.Show("Successfully Updated", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Check Old Password", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                } 

            }
            else
            {
                    string cc = "";
                    MessageBox.Show(f1.un);
                    f1.write("SSELECT Bpass FROM Branch WHERE Branch_Id = '" + f1.un + "'");
                    string result = f1.read();
                    MessageBox.Show(result);
                    string[] st = result.Split(":".ToCharArray());

                    for (int i = 0; i < st.Length - 1; i++)
                    {
                        string[] a = st[i].Split("-".ToCharArray());
                        cc = a[0].ToString();
                    }
                    if (cc == textBox1.Text)
                    {
                        f1.write("Iupdate Branch set Bpass='" + textBox3.Text + "' where Branch_Id='" + f1.un + "' and Bpass='" + textBox1.Text + "'");
                        MessageBox.Show("Successfully Updated", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Check Old Password", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Focus();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
       