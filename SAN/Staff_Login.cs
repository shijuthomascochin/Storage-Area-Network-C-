using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConDbLib;
using Microsoft.Win32;
namespace SAN
{
    public partial class Staff_Login : Form
    {
        client c;
        public static string stid;
        public Staff_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Enter Staff ID");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Staff Password");
                textBox2.Focus();
            }
            else
            {
                //int ip=0, port=0;
                //Taking values from registry
                try
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey("software");
                    RegistryKey rsk = rk.OpenSubKey("sanClient");
                    string prt = rsk.GetValue("port").ToString();
                    string ip = rsk.GetValue("IPAddress").ToString();

                    c = new client();
                    c.connect(ip, prt);
                    c.write("CSelect * from Staff where staff_id='" + textBox1.Text + "' and staff_pass='" + textBox2.Text + "'");
                    string s = c.read();
                    if (s.Equals("Yes"))
                    {
                        //MessageBox.Show("jjjj");
                        stid = textBox1.Text;
                        c.write("SSelect Branch_id from Staff where staff_id='" + textBox1.Text + "'");
                        string s1 = c.read();

                        string[] st = s1.Split(":".ToCharArray());

                        //for (int i = 0; i < st.Length - 1; i++)
                        //{
                            string[] a = st[0].Split("-".ToCharArray());
                            c.un = a[0].ToString();


                        //}

                        int n = 2;

                        Administrator_Home obj = new Administrator_Home(c, n);
                        obj.Show();
                        this.Hide();
                        //MessageBox.Show("Login Success", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (s.Equals("No"))
                    {
                        MessageBox.Show("Login Failed Check Username And Password", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Staff_Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}