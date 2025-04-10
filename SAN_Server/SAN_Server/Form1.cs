using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using Cinter;
using ConDbLib;
namespace SAN_Server
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to shut down SAN Server..? ", "Confirm Server Shut Down", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.ToString().Equals("Yes"))
            {

                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpChannel c = new HttpChannel(1234);
                ChannelServices.RegisterChannel(c, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(Cremote), "rem", WellKnownObjectMode.Singleton);
                MessageBox.Show("SAN Server is starting", "Storage Area System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Visible = false;
                button3.Visible = true;
            }
            catch (Exception)
            {
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    [Serializable]
    class Cremote : MarshalByRefObject, Cinter.I1
    {

        public void insert(string s1)
        {
            try
            {
                CDB obj = new CDB();
                obj.OpenConnection();
                MessageBox.Show(s1);
                obj.nonselectquery(s1);
                obj.close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        public DataTable select(string s1)
        {
            DataTable dt = null;
            try
            {
                CDB obj = new CDB();

                obj.OpenConnection();
                dt = obj.getRecord(s1);
                obj.close();

            }
            catch (Exception)
            {
            }
            return dt;
        }

    }
}