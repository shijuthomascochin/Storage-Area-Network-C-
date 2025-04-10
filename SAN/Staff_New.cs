using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SAN
{
    public partial class Staff_New : Form
    {
        client obj;
        public Staff_New(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void Staff_New_Load(object sender, EventArgs e)
        {
            try
            {
                obj.write("SSELECT post_name FROM Position");
                string s1 = obj.read();
                string[] st1 = s1.Split(":".ToCharArray());
                for (int i = 0; i < st1.Length; i++)
                {
                    string[] a1 = st1[i].Split("-".ToCharArray());
                    for (int j = 0; j < a1.Length - 1; j++)
                    {
                        comboBox2.Items.Add(a1[j].ToString().Trim());
                    }
                    if (comboBox2.Items.Count != 0)
                        comboBox2.SelectedIndex = 0;
                }
                obj.write("SSELECT Branch FROM Branch where Branch_id='" + obj.un + "'");
                string s3 = obj.read();
                string[] st3 = s3.Split(":".ToCharArray());
                for (int i = 0; i < st3.Length; i++)
                {
                    string[] a3 = st3[i].Split("-".ToCharArray());
                    for (int j = 0; j < a3.Length - 1; j++)
                    {
                        textBox6.Text = a3[j].ToString().Trim();
                    }
                }
                obj.write("SSELECT isnull(max(staff_id)+1,10000 ) as staff_id FROM Staff");
                string s2 = obj.read();
                s2 = s2.Substring(0, s2.LastIndexOf("-"));
                textBox1.Text = s2.ToString();
                textBox5.Text = s2.ToString();
                
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // DateTime d1 = Convert.ToDateTime(dateTimePicker1.Value.ToString);
             //   DateTime d2 = Convert.ToDateTime(dateTimePicker2.Value.ToString);
               //TimeSpan t1 = d2.Subtract(d1);
              // int total = (int)t1.TotalDays;
             //   TimeSpan t1 = d2.Year - d1.Year;
             //   int total = (int)t1.TotalDays
          //  MessageBox.Show(
            string pattern2 = @"(^[a-z A-Z\s\d\-\,\.]*)$";
            string pattern = @"(^[a-zA-Z\s]*)$";
            string pattern1 = @"(^[0-9]*)$";
            Match mt, mt1,mt2;
            mt = Regex.Match(textBox2.Text, pattern);
            mt1 = Regex.Match(textBox4.Text, pattern1);
            mt2 = Regex.Match(textBox3.Text, pattern2);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Staff's Name");
                textBox2.Focus();
            }
            else if (!mt.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Inavlid Name");
                textBox2.Focus();
            }
   
            else if (textBox3.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Enter the staff address");
                textBox3.Focus();
            }
            else if (!mt2.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Invalid address");
                textBox3.Focus();

            }
            else if (textBox4.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Enter Contact number");
                textBox4.Focus();
            }
            else if (!mt1.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Contact number should be numeric");
                textBox4.Focus();
            }
           
            else if (this.dateTimePicker1.Value.Date >= DateTime.Now.Date)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(dateTimePicker1, "Invalid date");
                dateTimePicker1.Focus();
            }
            else if (this.dateTimePicker2.Value.Date > DateTime.Now.Date)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(dateTimePicker2, "Invalid date");
                dateTimePicker2.Focus();
            }

            else if (textBox5.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Enter Staff's Login Password");
                textBox3.Focus();
            }
           
            else
            {
            obj.write("SSELECT post_id from Position where post_name='" + comboBox2.SelectedItem + "'");
            string s2 = obj.read();
            s2 = s2.Substring(0, s2.LastIndexOf("-"));
           string s3= s2.ToString();
            
           
                        obj.write("IINSERT INTO Staff (staff_id, staff_name, staff_dob, address,contactno, join_date, post_id,staff_pass,status,Branch_id) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + dateTimePicker2.Value.ToShortDateString() + "','" + s2.ToString() + "','" + textBox5.Text + "','Working','" +obj.un+"')");
                    
                this.Hide();
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}