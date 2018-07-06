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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void loginSettingsButton_Click(object sender, EventArgs e)
        {
            appsettings form = new appsettings();
            form.ShowDialog();
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            string path = string.Format("C:\\DB_Backup\\{0}.sql", DateTime.Now.ToString("ddMMyy"));
            Database.backup_Database(path);
        }
    }
}
