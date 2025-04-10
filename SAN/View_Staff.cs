using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SAN
{
    public partial class View_Staff : Form
    {
        client obj;
        string tem;
        public View_Staff(client c)
        {
            obj = c;
            InitializeComponent();
        }

        private void View_Staff_Load(object sender, EventArgs e)
        {
            obj.write("SSELECT staff_id,staff_name,address, staff_pass,contactno,status,post_id,Branch_id FROM Staff where Branch_id='"+obj.un+"' ");
            string s = obj.read();

            string[] st = s.Split(":".ToCharArray());
            for (int i = 0; i < st.Length - 1; i++)
            {
                string[] a = st[i].Split("-".ToCharArray());
                ListViewItem item = new ListViewItem();
                item.Text = a[0].ToString();
                item.SubItems.Add(a[1].ToString());
                item.SubItems.Add(a[2].ToString());
                item.SubItems.Add(a[3].ToString());
                item.SubItems.Add(a[4].ToString());
                item.SubItems.Add(a[5].ToString());
                tem = a[5].ToString();
                  
                    obj.write("SSELECT  post_name FROM Position where post_id='" + a[6].ToString()+ "'");
                    
                  string s1 = obj.read();
                 
                string[] st1 = s1.Split(":".ToCharArray());
                for (int j = 0; j < st1.Length - 1; j++)
                {
                    string[] a1 = st1[j].Split("-".ToCharArray());
                   item.SubItems.Add(a1[0].ToString()); 

                }
                obj.write("SSELECT  Branch FROM Branch where Branch_id='" + a[7].ToString() + "'");

                string s4 = obj.read();

                string[] st4 = s4.Split(":".ToCharArray());
                for (int j = 0; j < st4.Length - 1; j++)
                {
                    string[] a4 = st4[j].Split("-".ToCharArray());
                    item.SubItems.Add(a4[0].ToString()); 
                }
                obj.write("SSELECT staff_dob,join_date  FROM   Staff where staff_id=" + a[0].ToString() + "");
                string s3 = obj.read();
                string[] st3 = s3.Split("-".ToCharArray());
                item.SubItems.Add(st3[0].ToString());
                item.SubItems.Add(st3[1].ToString());
                if (tem == "Resigned")
                {
                    obj.write("SSELECT resigndate  FROM   Resign where staff_id=" + a[0].ToString() + "");
                    string s2 = obj.read();
                    string[] st2 = s2.Split("-".ToCharArray());
                    item.SubItems.Add(st2[0].ToString());
                                        
                }
                listView1.Items.Add(item);
            }
        }

       
        

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    
        }
    }
