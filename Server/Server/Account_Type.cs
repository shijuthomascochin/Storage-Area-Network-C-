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
    public partial class Account_Type : Form
    {
        CDB obj = new CDB();
        public Account_Type()
        {
            InitializeComponent();
        }

        private void Account_Type_Load(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT 'AID' + CONVERT(varchar, ISNULL(MAX(CONVERT(int, SUBSTRING(Account_Id, 4, LEN(Account_Id))) + 1), 1)) AS Expr1  FROM   Account WHERE (SUBSTRING(Account_Id, 1, 3) = 'AID')");
                textBox1.Text = dt.Rows[0][0].ToString();
                obj.close();
            }
            catch (Exception)
            { 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern = @"(^[a-zA-Z\s]*)$";
            Match mt;
            mt = Regex.Match(textBox2.Text.Trim(), pattern);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2,"Enter Account Type");
                textBox2.Focus();
            }
            else if(!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Account Type");
                textBox2.Focus();
            }
            else
            {
            try
            {
                obj.OpenConnection();
                obj.nonselectquery("insert into Account values('"+textBox1.Text+"','"+textBox2.Text+"') ");
                MessageBox.Show("Successfully Inserted New Account Type","Storage Area Network",MessageBoxButtons.OK,MessageBoxIcon.Information);
           
                
                      
                   CRem obc = new CRem();
                   obc.passtoRemote("insert into Account values('"+textBox1.Text+"','"+textBox2.Text+"')");                   
                    
                      
                   
            }
            catch (Exception)
            { 
            }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}