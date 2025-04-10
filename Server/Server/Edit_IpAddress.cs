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
    public partial class Edit_IpAddress : Form
    {
        CDB obj = new CDB();
        public Edit_IpAddress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Edit_IpAddress_Load(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("SELECT Ip_No FROM Ip_Address");
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

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern = @"^(([1-9]?\d|1\d\d|2[0-4]\d|25[0-5]).){3}([1-9]?\d|1\d\d|2[0-4]\d|25[0-5])$";
            Match mt;
            mt = Regex.Match(textBox2.Text, pattern);
            if (textBox2.Text == "")
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Ip Address");
                textBox2.Focus();
            }
            else if (!mt.Success)
            {

                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Enter Ip Address");
                textBox2.Focus();

            }
            else
            {
                try
                {
                    obj.OpenConnection();
                    obj.nonselectquery("UPDATE    Ip_Address SET  Ip_Address ='"+textBox2.Text+"'  WHERE     (Ip_No = '"+comboBox1.SelectedItem+"')");
                    MessageBox.Show("Successfully Updated Ip Address", "Storage Area Network", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    
                      
                  CRem obc = new CRem();
                  obc.passtoRemote("UPDATE    Ip_Address SET  Ip_Address ='"+textBox2.Text+"'  WHERE     (Ip_No = '"+comboBox1.SelectedItem+"')");                   
                                         
                  
                }
                catch (Exception)
                {
                } this.Dispose();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                obj.OpenConnection();
                DataTable dt = obj.getRecord("select Ip_Address from Ip_Address where Ip_No='"+comboBox1.SelectedItem+"'");
                if (dt.Rows.Count != 0)
                    textBox2.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception)
            {
            } 

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}