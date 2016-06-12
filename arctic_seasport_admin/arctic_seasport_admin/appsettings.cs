using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arctic_seasport_admin
{
    public partial class appsettings : Form
    {
        public appsettings()
        {
            InitializeComponent();
        }

        private void appsettings_Load(object sender, EventArgs e)
        {
            uidBox.Text = Properties.Settings.Default.UserID;
            passBox.Text = Properties.Settings.Default.Password;
            serverBox.Text = Properties.Settings.Default.Server;
            portBox.Text = Properties.Settings.Default.Port;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserID = uidBox.Text;
            Properties.Settings.Default.Password = passBox.Text;
            Properties.Settings.Default.Server = serverBox.Text;
            Properties.Settings.Default.Port = portBox.Text;
            Properties.Settings.Default.Save();
            Config.connString = "Server=" + Properties.Settings.Default.Server + ";Port=" + Properties.Settings.Default.Port + ";Database=" + Properties.Settings.Default.Database + ";Uid=" + Properties.Settings.Default.UserID + ";password=" + Properties.Settings.Default.Password + ";";
            this.Close();
        }
    }
}
