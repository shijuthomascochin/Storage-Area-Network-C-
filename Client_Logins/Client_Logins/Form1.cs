using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Client_Logins
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
                errorProvider1.SetError(textBox1,"Enter Account No");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Account Pin No");
                textBox2.Focus();
            }
            else
            {
                //int ip=0, port=0;
                //Taking values from registry
                try
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey("software");
                    RegistryKey rsk = rk.OpenSubKey("sanClient1");
                    string prt = rsk.GetValue("port").ToString();
                    string ip = rsk.GetValue("IPAddress").ToString();
                    
                    c = new client();
                    c.connect(ip, prt);
                    c.write("CSELECT ano, apin  FROM Customer where ano="+textBox1.Text+" and apin='"+textBox2.Text+"'");
                    string s = c.read();
                    if (s.Equals("Yes"))
                    {
                        
                        Administrator_Home obj = new Administrator_Home(c,textBox1.Text);
                        obj.Show();
                        this.Hide();
                        //MessageBox.Show("Login Success", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(s.Equals("No"))
                    {
                    MessageBox.Show("Login Failed Check Username And Password","Storage Area Network",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
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
            Application.ExitThread();
            Application.Exit();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}