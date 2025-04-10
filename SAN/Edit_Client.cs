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
    public partial class Edit_Client : Form
    {
        client obj;
        Boolean f;
        public Edit_Client(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void Edit_Client_Load(object sender, EventArgs e)
        {  
            try
            {
                label11.Visible = false;
                dateTimePicker1.Visible = false;
                if (checkBox1.Checked == true)
                {
                    label11.Visible = true;
                    dateTimePicker1.Visible = true;


                }
                else
                {
                    label11.Visible = false;
                    dateTimePicker1.Visible = false;
                }
                comboBox2.Items.Add("SavingsAccount");
                comboBox2.Items.Add("CurrentAccount");
               
           
                obj.write("SSELECT Branch FROM Branch");
                string s = obj.read();
                string[] st = s.Split(":".ToCharArray());
                for (int i = 0; i < st.Length; i++)
                {
                    string[] a = st[i].Split("-".ToCharArray());
                    for (int j = 0; j < a.Length - 1; j++)
                    {
                        comboBox1.Items.Add(a[j].ToString().Trim());
                    }
                    if (comboBox1.Items.Count != 0)
                        comboBox1.SelectedIndex = 0;
                }
                //obj.write("SSELECT  Branch FROM Branch where Branch_id='" + obj.un + "'");

                //string s4 = obj.read();

                //string[] st4 = s4.Split(":".ToCharArray());
                //for (int j = 0; j < st4.Length - 1; j++)
                //{
                //    string[] a4 = st4[j].Split("-".ToCharArray());
                //    comboBox1.SelectedItem = a4[0].ToString();

                //}

                

                obj.write("SSELECT Customer.ano  FROM  Customer INNER JOIN  Customer_Details ON Customer.ano = Customer_Details.ano ");
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
            }
            catch (Exception)
            {
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                f = false;
                obj.write("SSELECT Customer.aname, Customer.apin, Customer.aadd, Customer.aphone, Customer.abal,Customer.nominee1 ,Customer.stat,Customer_Details.Branch,Customer_Details.Acc_Type FROM  Customer INNER JOIN  Customer_Details ON Customer.ano = Customer_Details.ano where Customer.ano=" + comboBox3.SelectedItem + "");
                string s = obj.read();
                
                string[] st = s.Split(":".ToCharArray());
                for (int i = 0; i < st.Length - 1; i++)
                {
                    string[] a = st[i].Split("-".ToCharArray());
                    
                    textBox2.Text = a[0].ToString();
                    textBox5.Text = a[1].ToString();
                    textBox3.Text = a[2].ToString();
                    textBox4.Text = a[3].ToString();
                    textBox6.Text = a[4].ToString();
                    textBox1.Text = a[5].ToString();

                   

                    if (a[6].ToString() == "1")
                    {
                        
                        checkBox1.Checked=false;
                    }
                    else
                    {
                        f = true;
                        checkBox1.Checked= true;
                    }

                  
                    comboBox1.SelectedItem = a[7].ToString();
                    comboBox2.SelectedItem = a[8].ToString();
                    
                   
                

                }
              /*  DateTime d1 = Convert.ToDateTime(dateTimePicker1.Value.ToString);
                DateTime d2 = Convert.ToDateTime(dateTimePicker2.Value.ToString);
                TimeSpan t1 = d2.Subtract(d1);
                int total=(int)t1.TotalDays;*/
                obj.write("SSELECT doc  FROM   Customer_Details where ano=" + comboBox3.SelectedItem + "");
                string s2 = obj.read();
               
                string[] st2 = s2.Split("-".ToCharArray());
                MessageBox.Show(st2[0]);
                dateTimePicker2.Value = DateTime.Parse(st2[0].ToString());
                
                  if (checkBox1.Checked == true)
                  {
                      obj.write("SSELECT dot  FROM   Terminate where ano=" + comboBox3.SelectedItem + "");
                      string s3 = obj.read();
                    
                      string[] st3 = s3.Split("-".ToCharArray());

                      MessageBox.Show(st3[0]);
                      dateTimePicker1.Value = DateTime.Parse(st3[0].ToString());
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
            string pattern3 = @"(^[0-9]*[.][0-9][0-9])$";
            Match mt, mt1, mt2,mt3,mt4,mt5;
            mt = Regex.Match(textBox2.Text, pattern);
            mt1 = Regex.Match(textBox4.Text, pattern1);
            mt2 = Regex.Match(textBox3.Text, pattern2);
            mt3 = Regex.Match(textBox5.Text, pattern1);
            mt4 = Regex.Match(textBox1.Text, pattern2);
            mt5 = Regex.Match(textBox6.Text, pattern3);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Client's Name");
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
                errorProvider1.SetError(textBox3, "Enter the Client's address");
                textBox3.Focus();
            }
            else if (!mt2.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Invalid address");
                textBox3.Focus();

            }
            else if (!mt4.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Invalid Nominee address");
                textBox1.Focus();

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
            else if (textBox5.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Enter Client's Pin Number");
                textBox5.Focus();
            }
            else if (!mt3.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Pin number should be numeric");
                textBox5.Focus();
            }

            else if (textBox6.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox6, "Enter the Account Balance as 0.00");
                textBox6.Focus();
            }
            else if (!mt5.Success)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox6, "Enter the Account Balance as 0.00");
                textBox6.Focus();
            }
           


            else if (dateTimePicker1.Visible == true && this.dateTimePicker2.Value.Date > this.dateTimePicker1.Value.Date)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(dateTimePicker1, "Invalid Termination Date");
                dateTimePicker1.Focus();

            }
           
            else
            {
                if (checkBox1.Checked == true)
                {
                    obj.write("IUPDATE Customer SET aname ='" + textBox2.Text + "', apin ='" + textBox5.Text + "', aadd ='" + textBox3.Text + "', aphone ='" + textBox4.Text + "', abal ='" + textBox6.Text + "', nominee1 ='" + textBox1.Text + "',stat ='0'  WHERE ano = '" + comboBox3.SelectedItem + "'");
                  
                    obj.write("IUPDATE Customer_Details SET Branch ='" + comboBox1.SelectedItem + "', Acc_Type ='" + comboBox2.SelectedItem + "', doc ='" + dateTimePicker2.Value.ToShortDateString() + "'  WHERE ano = '" + comboBox3.SelectedItem + "'");
                    
                    MessageBox.Show("Successfully Updated Account No " + comboBox3.SelectedItem + "", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (f == true)
                    {
                        for (int y = 0; y < 2000; y++)
                        {
                        }
                        obj.write("IUPDATE Terminate SET dot='" + dateTimePicker1.Value.ToShortDateString() + "' WHERE ano = '" + comboBox3.SelectedItem + "'");
                        
                    }
                    else
                    {

                        obj.write("IINSERT INTO Terminate (ano,dot) VALUES('" + comboBox3.SelectedItem + "','" + dateTimePicker1.Value.ToShortDateString() + "')");
                    }
                    this.Dispose();
                }
                else
                {
                    obj.write("IUPDATE Customer SET aname ='" + textBox2.Text + "', apin ='" + textBox5.Text + "', aadd ='" + textBox3.Text + "', aphone ='" + textBox4.Text + "', abal ='" + textBox6.Text + "', nominee1 ='" + textBox1.Text + "',stat ='1'  WHERE ano = '" + comboBox3.SelectedItem + "'");
                    //string s = obj.read();
                    //if (s == "T")
                    //{
                    //}
                    MessageBox.Show("Successfully Updated Account No " + comboBox3.SelectedItem + "", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj.write("IUPDATE Customer_Details SET Branch ='" + comboBox1.SelectedItem + "', Acc_Type ='" + comboBox2.SelectedItem + "', doc ='" + dateTimePicker2.Value.ToShortDateString() + "'  WHERE ano = '" + comboBox3.SelectedItem + "'");
                    //string s1 = obj.read();
                    //if (s1 == "T")
                    //{
                    //}
                    
                    obj.write("IDELETE Terminate where ano ='" + comboBox3.SelectedItem + "'");

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
                label11.Visible = true;
                dateTimePicker1.Visible = true;


            }
            else
            {
                label11.Visible = false;
                dateTimePicker1.Visible = false;
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}