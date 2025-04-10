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
    public partial class IPtable_Add : Form
    {
        CDB obj = new CDB();
        public IPtable_Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //@"(^[a-zA-Z\s]*)$"
            string pattern = @"^(([1-9]?\d|1\d\d|2[0-4]\d|25[0-5]).){3}([1-9]?\d|1\d\d|2[0-4]\d|25[0-5])$";
            Match mt;
            mt = Regex.Match(textBox2.Text, pattern);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2,"Enter Ip Address");
                textBox2.Focus();
            }
            else if (!mt.Success)
            {

                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Ip Address");
                textBox2.Focus();

            }
            else
            {
                try
                {
                    obj.OpenConnection();
                    obj.nonselectquery("insert into  Ip_Address values('"+textBox1.Text+"','"+textBox2.Text+"')");
                    obj.close();
                    MessageBox.Show("Successfully Inserted Ip Address","Storage Area Network",MessageBoxButtons.OK,MessageBoxIcon.Information);      
                    obj.close();
                    
                    
                      
                    CRem obc = new CRem();
                    obc.passtoRemote("insert into  Ip_Address values('" + textBox1.Text + "','" + textBox2.Text + "')");                   
                    
                      
                    
                    
                }
                catch (Exception)
                {
                } this.Dispose();
            }

        }

        private void IPtable_Add_Load(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT 'IPT' + CONVERT(varchar, ISNULL(MAX(CONVERT(int, SUBSTRING(Ip_No, 4, LEN(Ip_No))) + 1), 1)) AS Expr1 FROM Ip_Address  WHERE (SUBSTRING(Ip_No, 1, 3) = 'IPT')");
                textBox1.Text = dt.Rows[0][0].ToString();

            }
            catch (Exception)
            { 
            }
        }
    }
}