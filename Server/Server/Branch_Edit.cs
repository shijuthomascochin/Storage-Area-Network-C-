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
    public partial class Branch_Edit : Form
    {
        CDB obj = new CDB();
        public Branch_Edit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Branch_Edit_Load(object sender, EventArgs e)
        {
            try
            {

                obj.OpenConnection();
                DataTable dt = obj.getRecord("Select Branch_Id from Branch");
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
                if (comboBox1.Items.Count != 0)
                    comboBox1.SelectedIndex = 0;
                obj.close();
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
                DataTable dt = obj.getRecord("SELECT Branch,Bphone,Baddress,Bpass FROM Branch where Branch_Id='"+comboBox1.SelectedItem.ToString()+"'");
                if (dt.Rows.Count != 0)
                {
                    textBox2.Text = dt.Rows[0][0].ToString();
                    textBox3.Text = dt.Rows[0][1].ToString();
                    textBox4.Text = dt.Rows[0][2].ToString();
                    textBox1.Text = dt.Rows[0][3].ToString();
                    
                }
              
                obj.close();
            }
            catch (Exception)
            { }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern1 = @"(^[0-9]*)$";
            string pattern = @"(^[a-z A-Z\s\d\-\0-9]*)$";
            Match mt, mt1, mt2;
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
            else if (textBox1.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Enter Administrator's password");
                textBox1.Focus();
            }
            else
            {
                try
                {
                    obj.OpenConnection();
                    obj.nonselectquery("UPDATE Branch  SET Branch ='" + textBox2.Text + "',Bphone ='" + textBox3.Text + "',Baddress ='" + textBox4.Text + "',Bpass ='" + textBox1.Text + "' WHERE (Branch_Id = '" + comboBox1.SelectedItem + "')");
                    MessageBox.Show("successfully Updated Branch ","Storage Area Network",MessageBoxButtons.OK,MessageBoxIcon.Information);
                   

                    
                      
                  CRem obc = new CRem();
                  obc.passtoRemote("UPDATE Branch  SET Branch ='" + textBox2.Text + "',Bphone ='" + textBox3.Text + "',Baddress ='" + textBox4.Text + "',Bpass ='" + textBox1.Text + "' WHERE (Branch_Id = '" + comboBox1.SelectedItem + "')");                   
                                         
                  
                }
                catch (Exception)
                {
                } this.Dispose();
            }
        }
    }
}