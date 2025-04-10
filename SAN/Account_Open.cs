using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConDbLib;
using System.Text.RegularExpressions;
namespace SAN
{
    public partial class Account_Open : Form
    {
        client obj;
       
        New_Client client;
        public Account_Open(New_Client c,client s)
        {
            obj = s;
            client = c;
            InitializeComponent();
        }

        private void Account_Open_Load(object sender, EventArgs e)
        {
            textBox1.Text = client.textBox1.Text;
            textBox2.Text = client.textBox6.Text;
            textBox3.Text = client.comboBox1.SelectedItem.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                errorProvider1.SetError(textBox4, "Enter Your Amount as 0.00 ");
                textBox4.Focus();
            }
           // else if (n < 500)
          //  {
          //      errorProvider1.Clear();
          //      errorProvider1.SetError(textBox4, "Minimum balance is 500 ");
          //      textBox4.Focus();
            //   } float n=float.Parse(textBox4.Text);
            else
            {
                
                obj.write("IUpdate Customer set abal=" + textBox4.Text + " where ano=" + textBox1.Text + "");
                //MessageBox.Show("step3");
                MessageBox.Show("Successfully Created A New Account", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                obj.write("IINSERT INTO Customer_Details (ano, Branch, Acc_Type,doc) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + System.DateTime.Now.ToShortDateString() + "')");
                this.Dispose();
            }
        }
    }
}