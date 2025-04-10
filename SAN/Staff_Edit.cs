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
    public partial class Staff_Edit : Form
    {
        client obj;
        string bname,pname;
        Boolean f;
        public Staff_Edit(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void Staff_Edit_Load(object sender, EventArgs e)
        {
            
            try
            {
                label10.Visible = false;
                dateTimePicker3.Visible = false;
                if (checkBox1.Checked == true)
                {
                    label10.Visible = true;
                    dateTimePicker3.Visible = true;


                }
                else
                {
                    label10.Visible = false;
                    dateTimePicker3.Visible = false;
                }

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
                obj.write("SSELECT staff_id FROM staff where Branch_id='"+obj.un+"'");
                string s2 = obj.read();
                string[] st2 = s2.Split(":".ToCharArray());
                for (int i = 0; i < st2.Length; i++)
                {
                    string[] a2 = st2[i].Split("-".ToCharArray());
                    for (int j = 0; j < a2.Length - 1; j++)
                    {
                        comboBox3.Items.Add(a2[j].ToString().Trim());
                    }
                    if (comboBox3.Items.Count != 0)
                        comboBox3.SelectedIndex = 0;
                }

                obj.write("SSELECT Branch FROM Branch");
                string s3 = obj.read();
                string[] st3 = s3.Split(":".ToCharArray());
                for (int i = 0; i < st1.Length; i++)
                {
                    string[] a3 = st3[i].Split("-".ToCharArray());
                    for (int j = 0; j < a3.Length - 1; j++)
                    {
                        comboBox1.Items.Add(a3[j].ToString().Trim());
                    }
                    if (comboBox1.Items.Count != 0)
                        comboBox1.SelectedIndex = 0;
                }
                obj.write("SSELECT  Branch FROM Branch where Branch_id='" + obj.un + "'");

                string s4 = obj.read();

                string[] st4 = s4.Split(":".ToCharArray());
                for (int j = 0; j < st4.Length - 1; j++)
                {
                    string[] a4 = st4[j].Split("-".ToCharArray());
                    comboBox1.SelectedItem = a4[0].ToString();

                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                f = false;
                obj.write("SSELECT staff_name,address, staff_pass,contactno,status,post_id,Branch_id FROM   Staff where staff_id=" + comboBox3.SelectedItem + "");
                string s = obj.read();
                
                string[] st = s.Split(":".ToCharArray());
                for (int i = 0; i < st.Length - 1; i++)
                {
                    string[] a = st[i].Split("-".ToCharArray());
                    
                    textBox2.Text = a[0].ToString();
                    textBox3.Text = a[1].ToString();
                    textBox1.Text = a[2].ToString();
                    textBox4.Text = a[3].ToString();
                    textBox4.Text = a[3].ToString();

                    //   a[5].ToString());
                    //  dateTimePicker2.Value = DateTime.Parse(a[6].ToString());



                    if (a[4].ToString() == "Working")
                    {
                        
                        checkBox1.Checked=false;
                    }
                    else
                    {
                        f = true;
                        checkBox1.Checked= true;
                    }

                    
                    obj.write("SSELECT  post_name FROM Position where post_id='" + a[5].ToString()+ "'");
                    
                  string s1 = obj.read();
                 
                string[] st1 = s1.Split(":".ToCharArray());
                for (int j = 0; j < st1.Length - 1; j++)
                {
                    string[] a1 = st1[j].Split("-".ToCharArray());
                    comboBox2.SelectedItem = a1[0].ToString(); 

                }

                }
              /*  DateTime d1 = Convert.ToDateTime(dateTimePicker1.Value.ToString);
                DateTime d2 = Convert.ToDateTime(dateTimePicker2.Value.ToString);
                TimeSpan t1 = d2.Subtract(d1);
                int total=(int)t1.TotalDays;*/
                obj.write("SSELECT staff_dob,join_date  FROM   Staff where staff_id=" + comboBox3.SelectedItem + "");
                string s2 = obj.read();
               
                string[] st2 = s2.Split("-".ToCharArray());
                                
                
                  dateTimePicker1.Value = DateTime.Parse(st2[0].ToString());
                  dateTimePicker2.Value = DateTime.Parse(st2[1].ToString());

                  if (checkBox1.Checked == true)
                  {
                      obj.write("SSELECT resigndate  FROM   Resign where staff_id=" + comboBox3.SelectedItem + "");
                      string s3 = obj.read();
                    
                      string[] st3 = s3.Split("-".ToCharArray());

                 
                      dateTimePicker3.Value = DateTime.Parse(st3[0].ToString());
                  }
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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

            else if (textBox1.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Enter Staff's Login Password");
                textBox3.Focus();
            }
            else if (dateTimePicker3.Visible == true && this.dateTimePicker3.Value.Date > DateTime.Now.Date)
            {
                    errorProvider1.Clear();
                    errorProvider1.SetError(dateTimePicker3, "Invalid date");
                    dateTimePicker3.Focus();
              
            }
            else
            {

                obj.write("SSELECT  post_id FROM Position where post_name='" + comboBox2.SelectedItem + "'");

                string s1 = obj.read();

                string[] st1 = s1.Split(":".ToCharArray());
                for (int j = 0; j < st1.Length - 1; j++)
                {
                    string[] a1 = st1[j].Split("-".ToCharArray());
                    pname = a1[0].ToString();
                }

                obj.write("SSELECT  Branch_id FROM Branch where Branch='" + comboBox1.SelectedItem + "'");

                string s = obj.read();

                string[] st = s.Split(":".ToCharArray());
                for (int j = 0; j < st.Length - 1; j++)
                {
                    string[] a = st[j].Split("-".ToCharArray());
                    bname = a[0].ToString();
                }
                if (checkBox1.Checked == true)
                {
                    obj.write("IUPDATE Staff SET staff_name ='" + textBox2.Text + "', staff_dob ='" + dateTimePicker1.Value.ToShortDateString() + "', address ='" + textBox3.Text + "', contactno ='" + textBox4.Text + "', join_date ='" + dateTimePicker2.Value.ToShortDateString() + "', post_id ='" + pname + "',staff_pass ='" + textBox1.Text + "',status='Resigned', Branch_id ='" + bname + "'  WHERE staff_id = '" + comboBox3.SelectedItem + "'");
                    MessageBox.Show("Successfully Updated Staff ID " + comboBox3.SelectedItem + "", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (f == true)
                    {
                        obj.write("IUPDATE Resign SET resigndate='" + dateTimePicker3.Value.ToShortDateString() + "' WHERE staff_id = '" + comboBox3.SelectedItem + "'");
                    }
                    else
                    {

                        obj.write("IINSERT INTO Resign (staff_id,resigndate) VALUES('" + comboBox3.SelectedItem + "','" + dateTimePicker3.Value.ToShortDateString() + "')");
                    }
                    this.Dispose();
                }
                else
                {
                    obj.write("IUPDATE Staff SET staff_name ='" + textBox2.Text + "', staff_dob ='" + dateTimePicker1.Value.ToShortDateString() + "', address ='" + textBox3.Text + "', contactno ='" + textBox4.Text + "', join_date ='" + dateTimePicker2.Value.ToShortDateString() + "', post_id ='" + pname + "',staff_pass ='" + textBox1.Text + "',status='Working', Branch_id ='" + bname + "'  WHERE staff_id = '" + comboBox3.SelectedItem + "'");
                    MessageBox.Show("Successfully Updated Staff Id " + comboBox3.SelectedItem + "", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj.write("IDELETE Resign where staff_id ='" + comboBox3.SelectedItem + "'");

                    this.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label10.Visible = true;
                dateTimePicker3.Visible = true;


            }
            else
            {
                label10.Visible = false;
                dateTimePicker3.Visible = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}