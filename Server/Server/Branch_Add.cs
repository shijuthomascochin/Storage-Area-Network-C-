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
    public partial class Branch_Add : Form
    {
        CDB obj = new CDB();
        public Branch_Add()
        {
            InitializeComponent();
        }

        private void Branch_Add_Load(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT 'BID' + CONVERT(varchar, ISNULL(MAX(CONVERT(int, SUBSTRING(Branch_Id, 4, LEN(Branch_Id))) + 1), 1)) AS Expr1  FROM   Branch WHERE     (SUBSTRING(Branch_Id, 1, 3) = 'BID')");
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox5.Text = dt.Rows[0][0].ToString();

                obj.close();
            }
            catch (Exception)
            { 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern1 = @"(^[0-9]*)$";
            string pattern = @"(^[a-z A-Z\s\d\-\0-9]*)$";
            Match mt, mt1,mt2;
            mt = Regex.Match(textBox2.Text, pattern);
            mt1 = Regex.Match(textBox3.Text, pattern1);
            mt2 = Regex.Match(textBox4.Text, pattern);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Branch Name");
                textBox2.Focus();
            }
                 else if (!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Valid Branch Name");
                textBox2.Focus();
            }

            else if (textBox3.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Enter Phone Number");
                textBox3.Focus();
            }
            else if (!mt1.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Phone number should be numeric");
                textBox3.Focus();
            }

            else if (textBox4.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Branch Address");
                textBox4.Focus();
            }
                 else if (!mt2.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Valid Address");
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Enter Administrator's password");
                textBox5.Focus();
            }
            else
            {
                try
                {
                    obj.OpenConnection();
                    obj.nonselectquery("insert into Branch values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                    MessageBox.Show("Successfully Inserted New Branch  " + textBox2.Text + "", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                      
                   CRem obc = new CRem();
                   obc.passtoRemote("insert into Branch values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox1.Text + "')");                   
                                         
                   

                    this.Dispose();
                }
                catch (Exception)
                {

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}