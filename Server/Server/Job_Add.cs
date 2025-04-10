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
    public partial class Job_Add : Form
    {CDB obj = new CDB();
        public Job_Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
        private void Job_Add_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string pattern = @"(^[a-zA-Z\s]*)$";
            string pattern1 = @"(^[0-9]*)$";
            Match mt,mt1;
            mt = Regex.Match(textBox2.Text, pattern);
            mt1 = Regex.Match(textBox3.Text, pattern1);

           if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2,"Enter Job name");
                textBox2.Focus();
            }
            else if (!mt.Success)
            {

                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Job name should be alphabetic");
                textBox2.Focus();

            }
            else if (textBox3.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Enter Basic Salary");
                textBox3.Focus();
            }
            else if (!mt1.Success)
            {

                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Basic Salary should be numeric");
                textBox3.Focus();

            }
            else
            {
                try
                {
                    if (checkBox1.Checked == true)
                    {
                        obj.OpenConnection();
                        obj.nonselectquery("insert into  Position values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",1)");
                        obj.close();
                        MessageBox.Show("Successfully Inserted Job category", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obj.close();


                        CRem obc = new CRem();
                        obc.passtoRemote("insert into  Position values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",1)");
                    }
                
                else
                {

                    obj.OpenConnection();
                    obj.nonselectquery("insert into  Position values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",0)");
                    obj.close();
                    MessageBox.Show("Successfully Inserted Job category", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj.close();


                    CRem obc = new CRem();
                    obc.passtoRemote("insert into  Position values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",0)");
                }
                    
                }
                catch (Exception)
                {
                } this.Dispose();
            }
            }
        private void Job_Add_Load_1(object sender, EventArgs e)
        {

            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT 'JID' + CONVERT(varchar, ISNULL(MAX(CONVERT(int, SUBSTRING(post_id, 4, LEN(post_id))) + 1), 1)) AS Expr1 FROM Position  WHERE (SUBSTRING(post_id, 1, 3) = 'JID')");
                textBox1.Text = dt.Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

            
        }
    }
