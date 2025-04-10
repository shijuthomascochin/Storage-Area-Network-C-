using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConDbLib;
namespace Server
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Enter Administrator ID");
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
                CDB obj = new CDB();
                int flag = 0;
                obj.OpenConnection();
                DataTable dt = obj.getRecord("Select * from Administrator_Server where Administrator='" + textBox1.Text + "' and Password='" + textBox2.Text + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    flag = 1;
                }
                if (flag == 1)
                {
                    Administrator_Home al = new Administrator_Home(textBox1.Text);
                    al.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Check User Name And Password", "RAIDSOFT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";

                }


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void Administrator_Load(object sender, EventArgs e)
        {

        }
    }
}