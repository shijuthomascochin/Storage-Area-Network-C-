using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Administrator_Home : Form
    {

        string un;
        public Administrator_Home(string s)
                {
                    un = s;
            InitializeComponent();
        }

        private void Administrator_Home_Load(object sender, EventArgs e)
        {


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Branch_Add b_add = new Branch_Add();
            b_add.MdiParent = this;
            b_add.BringToFront();
            b_add.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Branch_Edit b_edit = new Branch_Edit();
            b_edit.MdiParent = this;
            b_edit.BringToFront();
            b_edit.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Branch v_branch = new View_Branch();
            v_branch.MdiParent = this;
            v_branch.BringToFront();
            v_branch.Show();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Account_Type acc_type = new Account_Type();
            acc_type.MdiParent = this;
            acc_type.BringToFront();
            acc_type.Show();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Account_Edit acc_edit = new Account_Edit();
            acc_edit.MdiParent = this;
            acc_edit.BringToFront();
            acc_edit.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View_Account view_acc = new View_Account();
            view_acc.MdiParent = this;
            view_acc.BringToFront();
            view_acc.Show();
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            IPtable_Add ip_add = new IPtable_Add();
            ip_add.MdiParent = this;
            ip_add.BringToFront();
            ip_add.Show();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Edit_IpAddress ip_edit = new Edit_IpAddress();
            ip_edit.MdiParent = this;
            ip_edit.BringToFront();
            ip_edit.Show();
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            View_IpAddress view_ip = new View_IpAddress();
            view_ip.MdiParent = this;
            view_ip.BringToFront();
            view_ip.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
           Job_Add add_job = new Job_Add();
            add_job.MdiParent = this;
            add_job.BringToFront();
            add_job.Show();
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Edit_Job e_job = new Edit_Job();
            e_job.MdiParent = this;
            e_job.BringToFront();
            e_job.Show();
        }

        private void viewToolStripMenuItem3_Click(object sender, EventArgs e)
        {
           View_Job v_job = new View_Job();
            v_job.MdiParent = this;
            v_job.BringToFront();
            v_job.Show();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword ChPass = new ChangePassword(un);
            ChPass.MdiParent = this;
            ChPass.BringToFront();
            ChPass.Show();
        }
    }
}