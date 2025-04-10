using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConDbLib;
using System.Text.RegularExpressions;


namespace Server
{
    public partial class ChangePassword : Form
    {
        CDB obj = new CDB();
        string un;
        public ChangePassword(string s)
        {
             un = s;
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
                MessageBox.Show("Enter Re Password");
                textBox3.Text = "";
                textBox3.Focus();
            }
            else if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("Re Password Not Matching");
                textBox3.Text = "";
                textBox2.Text = "";
                textBox2.Focus();
            }
            else
            {
                
             try
             {
                 string cc="";
                 obj.OpenConnection();
                 DataTable dt = obj.getRecord("select Password from Administrator_Server where Administrator='" + un + "'");
                 if (dt.Rows.Count != 0)
                     cc = dt.Rows[0][0].ToString();
                 if (cc == textBox1.Text)
                    {

                       
                        obj.nonselectquery("UPDATE    Administrator_Server set Password='" + textBox3.Text + "' where Administrator='admin' and password='" + textBox1.Text + "'");
                        MessageBox.Show("Successfully Updated ", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        CRem obc = new CRem();
                        obc.passtoRemote("UPDATE    Administrator_Server set Password='" + textBox3.Text + "' where Administrator='admin' and password='" + textBox1.Text + "'");

                        this.Dispose();
                    }
                   else
                    {
                        MessageBox.Show("Check Old Password", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       textBox1.Focus();
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}