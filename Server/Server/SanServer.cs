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
    public partial class SanServer : Form
    {
        public SanServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            setting.Show();
        }
        Server.CServer obj;
        private void btnStart_Click(object sender, EventArgs e)
        {
            obj = new CServer();
            this.label2.Enabled = true;
            this.btnStop.Show();
            //menuItem2.Enabled = false;
            //menuItem3.Enabled = true;
            //if (System.DateTime.Now.Day.ToString() == "10") 
            //{
            //    CDB obj1 = new CDB();
            //    obj1.OpenConnection();
              
            //    CRem obc = new CRem();
            //    DataTable dt = obj1.getRecord("SELECT Customer.ano,Customer.abal FROM   Customer INNER JOIN   Customer_Details ON Customer.ano = Customer_Details.ano where Customer_Details.Acc_Type='SavingsAccount'");
            //    foreach (DataRow dr in dt.Rows)
            //           {
            //        obj1.nonselectquery("Update sav_interest set bal =" + dr[1].ToString() + "where ano=" + dr[0].ToString() + "");


            //        obc.passtoRemote("Update sav_interest set bal =" + dr[1].ToString() + "where ano=" + dr[0].ToString() + "");
            //    }
            //}

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
DialogResult result = MessageBox.Show("Are you sure you want to shut down Main server..? ", "Confirm Server Shut Down", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
if (result.ToString().Equals("Yes"))
{
    
    obj.stop();
    this.label2.Enabled = false;
    btnStop.Hide();
    btnStart.Show();
}
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            Administrator adm = new Administrator();
            adm.Show();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            obj = new CServer();
            this.label2.Enabled = true;
            this.btnStop.Show();
            //menuItem2.Enabled = false;
            //menuItem3.Enabled = true;
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj = new CServer();
            this.label2.Enabled = true;
            this.btnStop.Show();
            //menuItem2.Enabled = false;
            //menuItem3.Enabled = true;
        }

        private void stopServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to shut down Main server..? ", "Confirm Server Shut Down", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result.ToString().Equals("Yes"))
            {

                obj.stop();
                this.label2.Enabled = false;
                btnStop.Hide();
                btnStart.Show();
            }
        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrator adm = new Administrator();
            adm.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            setting.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sss");
        }

        private void sanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SAN");
        }
    }
}