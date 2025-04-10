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
    public partial class Edit_Job : Form
    {
        CDB obj = new CDB();
        public Edit_Job()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
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
                        obj.nonselectquery("UPDATE    Position SET  post_name ='" + textBox2.Text + "',post_salary ='" + textBox3.Text + "',privilege=1   WHERE     (post_id = '" + comboBox1.SelectedItem + "')");
                        MessageBox.Show("Successfully Updated Job Category", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        CRem obc = new CRem();
                        obc.passtoRemote("UPDATE    Position SET  post_name ='" + textBox2.Text + "',post_salary ='" + textBox3.Text + "',privilege=1  WHERE     (post_id = '" + comboBox1.SelectedItem + "')");

                    }
                    else
                    {
                        obj.OpenConnection();
                        obj.nonselectquery("UPDATE    Position SET  post_name ='" + textBox2.Text + "',post_salary ='" + textBox3.Text + "',privilege=0   WHERE     (post_id = '" + comboBox1.SelectedItem + "')");
                        MessageBox.Show("Successfully Updated Job Category", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        CRem obc = new CRem();
                        obc.passtoRemote("UPDATE    Position SET  post_name ='" + textBox2.Text + "',post_salary ='" + textBox3.Text + "',privilege=0   WHERE     (post_id = '" + comboBox1.SelectedItem + "')");

                    }

                }
                catch (Exception)
                {
                }
            }
                this.Dispose();
        }

        private void Edit_Job_Load(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT post_id FROM position");
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
                DataTable dt = obj.getRecord("select post_name,post_salary,privilege from position where post_id='" + comboBox1.SelectedItem + "'");
                if (dt.Rows.Count != 0)
                    textBox2.Text = dt.Rows[0][0].ToString();
                    textBox3.Text = dt.Rows[0][1].ToString();
                    if ( dt.Rows[0][2].ToString()== "1")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
            }
            catch (Exception)
            {
            }

        }
    }
}