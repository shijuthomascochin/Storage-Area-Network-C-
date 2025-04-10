using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SAN
{
    public partial class Search : Form
    {
        client obj;
        public Search(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                obj.write("SSELECT Customer.ano, Customer.aname, Customer.apin, Customer.aadd, Customer.aphone, Customer.abal, Customer_Details.Branch, Customer_Details.Acc_Type FROM   Customer INNER JOIN   Customer_Details ON Customer.ano = Customer_Details.ano WHERE     (Customer.ano = " + textBox1.Text + ")");
                string s = obj.read();
                if (s == "")
                {
                    
                      
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";

                  
                }
                else
                {
                    string[] st = s.Split(":".ToCharArray());
                    for (int i = 0; i < st.Length - 1; i++)
                    {
                        string[] a = st[i].Split("-".ToCharArray());
                        textBox2.Text = a[0].ToString();
                        textBox3.Text = a[1].ToString();
                        textBox4.Text = a[2].ToString();
                        textBox5.Text = a[3].ToString();
                        textBox6.Text = a[4].ToString();
                        textBox7.Text = a[5].ToString();
                        textBox8.Text = a[6].ToString();
                        textBox9.Text = a[7].ToString();

                    }
                }

            }
            catch (Exception)
            { 
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}