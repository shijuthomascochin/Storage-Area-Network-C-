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
    public partial class Administrator_Login : Form
    {
        client c;
        public Administrator_Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1,"Enter Administrator Name");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Administrator Password");
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
                    c.write("CSelect * from Branch where Branch_id='"+textBox1.Text+"' and Bpass='"+textBox2.Text+"'");
                    string s = c.read();
                    if (s.Equals("Yes"))
                    {
                        c.un = textBox1.Text;
                        int n=1;
                        Administrator_Home obj = new Administrator_Home(c,n);
                        obj.Show();
                        this.Hide();
                        //MessageBox.Show("Login Success", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(s.Equals("No"))
                    {
                    MessageBox.Show("Login Failed Check Username And Password","Storage Area Network",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" " + ex);
                }
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            setting.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff_Login slogin = new Staff_Login();
            slogin.Show();
            
        }
    }
}