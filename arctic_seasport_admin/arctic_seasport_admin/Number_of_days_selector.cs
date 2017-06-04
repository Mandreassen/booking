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
    public partial class Number_of_days_selector : Form
    {
        public int count = 4;

        public Number_of_days_selector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Number_of_days_selector_Load(object sender, EventArgs e)
        {
            numericUpDown.Value = 4;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            count = (int) numericUpDown.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count = -1;
            this.Close();
        }
    }
}
