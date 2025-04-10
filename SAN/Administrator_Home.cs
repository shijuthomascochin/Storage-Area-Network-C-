using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SAN
{
    public partial class Administrator_Home : Form
    {
        client obj;
        int p;
        public Administrator_Home(client c,int n)
        {
            p = n;
            obj = c;

            InitializeComponent();
        }

        private void Administrator_Home_Load(object sender, EventArgs e)
        {
            if (p == 2)
                staffToolStripMenuItem1.Visible = false;
            else
                staffToolStripMenuItem1.Visible = true;


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Client_New cli_new = new Client_New(obj);
            New_Client cli_new = new New_Client(obj);
            cli_new.MdiParent = this;
            cli_new.BringToFront();
            cli_new.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Client edit_client = new Edit_Client(obj);
            edit_client.MdiParent = this;
            edit_client.BringToFront();
            edit_client.Show();

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Client view_item = new View_Client(obj);
            view_item.MdiParent = this;
            view_item.BringToFront();
            view_item.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search ser = new Search(obj);
            ser.MdiParent = this;
            ser.BringToFront();
            ser.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword chn_pass = new ChangePassword(obj,p);
            chn_pass.MdiParent = this;
            chn_pass.BringToFront();
            chn_pass.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit(obj);
            deposit.MdiParent = this;
            deposit.BringToFront();
            deposit.Show();
        }

        private void withdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw withd = new Withdraw(obj);
            withd.MdiParent = this;
            withd.BringToFront();
            withd.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Staff_New staffn = new Staff_New(obj);
           staffn.MdiParent = this;
            staffn.BringToFront();
            staffn.Show();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Staff_Edit staffe = new Staff_Edit(obj);
            staffe.MdiParent = this;
            staffe.BringToFront();
            staffe.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View_Staff staffv = new View_Staff(obj);
            staffv.MdiParent = this;
            staffv.BringToFront();
            staffv.Show();

        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void staffToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}