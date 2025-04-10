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
    public partial class Account_Edit : Form
    {
        CDB obj = new CDB();
        public Account_Edit()
        {
            InitializeComponent();
        }

        private void Account_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT Account_Id  FROM Account");
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
                obj.close();
                if(comboBox1.Items.Count!=0)
                    comboBox1.SelectedIndex=0;
            }
            catch (Exception)
            { 
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT Account,minbal,ded  FROM Account where Account_Id  ='" + comboBox1.SelectedItem + "'");
                if (dt.Rows.Count != 0)
                {
                    textBox2.Text = dt.Rows[0][0].ToString();
                    textBox1.Text = dt.Rows[0][1].ToString();
                    textBox3.Text = dt.Rows[0][2].ToString();
                }
            }
            catch (Exception)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern = @"(^[0-9]*)$";
            Match mt,mt1;
            mt = Regex.Match(textBox1.Text, pattern);
            mt1 = Regex.Match(textBox3.Text, pattern);
            if (textBox1.Text == "")
            {
               
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Enter Minimum Balance");
                textBox1.Focus();
            }
            else if (!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Minimum Balance should be integer");
                textBox1.Focus();
            }
            else if (textBox3.Text == "")
            {
               
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Enter the fine charged");
                textBox3.Focus();
            }
            else if (!mt1.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Charge should be numeric");
                textBox3.Focus();
            }
            else
            {
                try
                {
                    obj.OpenConnection();
                    obj.nonselectquery("UPDATE    Account  SET Account ='" + textBox2.Text + "',minbal =" + textBox1.Text + ",ded="+textBox3.Text+" WHERE (Account_Id = '" + comboBox1.SelectedItem + "')");
                    MessageBox.Show("Successfully Updated Account Type", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    
                      
                    CRem obc = new CRem();
                    obc.passtoRemote("UPDATE   Account  SET Account ='" + textBox2.Text + "',minbal =" + textBox1.Text + ",ded=" + textBox3.Text + "  WHERE (Account_Id = '" + comboBox1.SelectedItem + "')");


                    
                }
                catch (Exception)
                {
                }
                this.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}