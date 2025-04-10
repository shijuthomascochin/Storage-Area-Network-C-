using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConDbLib;
namespace Server
{
    public partial class View_Branch : Form
    {
        CDB obj = new CDB();
        public View_Branch()
        {
            InitializeComponent();
        }

        private void View_Branch_Load(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("Select * from Branch");
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr[0].ToString();
                    item.SubItems.Add(dr[1].ToString());
                    item.SubItems.Add(dr[2].ToString());
                    item.SubItems.Add(dr[3].ToString());
                    item.SubItems.Add(dr[4].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception)
            { 
            
            }

        }
    }
}