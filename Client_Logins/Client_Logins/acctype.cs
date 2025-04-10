using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client_Logins
{
    public partial class acctype : Form
    {
        client obj;
        string uname;
        int n1;
        public static string hh;
        public acctype(client c,string s,int n)
        {
            obj = c;
            uname = s;
            n1 = n;

            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            if (hh == "SavingsAccount")
            {
                if (n1 == 1)
                {
                    Amount f1 = new Amount(obj, uname);
                    f1.Show();
                }  
                else if(n1==2)
                {
                    Balance b1 = new Balance(obj, uname);
                     b1.Show();
                }
                else if (n1 == 3)
                {
                    obj.write("-rtrandet," + uname);
                    string str = obj.read();
                    //MessageBox.Show(str);
                    if (str.StartsWith("-x"))
                    {
                        str = str.Substring(2);
                        System.IO.Stream ss = System.IO.File.OpenWrite("c:\\aa.xml");
                        ss.SetLength(0);
                        byte []bb;
                        bb = new ASCIIEncoding().GetBytes(str.ToCharArray(),0,str.Length);
                        ss.Write(bb, 0, bb.Length);
                        ss.Close();
                    }
                    State t1 = new State();
                    t1.Show();
                }
                else if (n1 == 4)
                {
                    ChangePassword chh = new ChangePassword(obj, uname);
                    chh.Show();
                }
            }          
            else
            {
                MessageBox.Show("Sorry! Unmatched Account!");
                

            }

            this.Dispose();
            
         }

        private void acctype_Load(object sender, EventArgs e)
            
        {
            obj.write("SSELECT Acc_Type FROM Customer_Details WHERE ano = " + uname + "");
            string result = obj.read();
            string[] st = result.Split(":".ToCharArray());

            for (int i = 0; i < st.Length - 1; i++)
            {
                string[] a = st[i].Split("-".ToCharArray());
                hh = a[0].ToString();
                MessageBox.Show(hh);

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (hh == "CurrentAccount")
            {
                if (n1 == 1)
                {
                    Amount f1 = new Amount(obj, uname);
                    f1.Show();
                }
                else if (n1 == 2)
                {
                    Balance b1 = new Balance(obj, uname);
                    b1.Show();
                }
                else if (n1 == 3)
                {
                    obj.write("-rtrandet," + uname);
                    string str = obj.read();
                    //MessageBox.Show(str);
                    if (str.StartsWith("-x"))
                    {
                        str = str.Substring(2);
                        System.IO.Stream ss = System.IO.File.OpenWrite("c:\\aa.xml");
                        ss.SetLength(0);
                        byte[] bb;
                        bb = new ASCIIEncoding().GetBytes(str.ToCharArray(), 0, str.Length);
                        ss.Write(bb, 0, bb.Length);
                        ss.Close();
                    }
                    State t1 = new State();
                    t1.Show();
                   
                }
                else if (n1 == 4)
                {
                    ChangePassword chh = new ChangePassword(obj, uname);
                    chh.Show();
                }
            }
            else
            {
                MessageBox.Show("Unmatched Account!");
                
            }
            this.Dispose();     
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        }
    }
