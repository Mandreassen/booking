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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* New booking */
        private void button1_Click(object sender, EventArgs e)
        {
            new_booking form = new new_booking(-1);
            form.ShowDialog(this);
        }

        /* Settings */
        private void button3_Click(object sender, EventArgs e)
        {
            appsettings form = new appsettings();
            form.ShowDialog();
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            var form = new Transfers_view();
            form.ShowDialog();
        }

        private void bookingsButton_Click(object sender, EventArgs e)
        {
            var form = new Manage_bookings();
            form.ShowDialog();
        }
    }
}
