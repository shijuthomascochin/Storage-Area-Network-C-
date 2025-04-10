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
    public partial class View_IpAddress : Form
    {
        CDB obj = new CDB();
        public View_IpAddress()
        {
            InitializeComponent();
        }

        private void View_IpAddress_Load(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("Select * from Ip_Address");
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr[0].ToString();
                    item.SubItems.Add(dr[1].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception)
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}