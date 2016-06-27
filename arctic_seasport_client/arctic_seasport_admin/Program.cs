using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arctic_seasport_admin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public static class Config
    {        
        public static string connString = "Server="+ Properties.Settings.Default.Server +";Port=" + Properties.Settings.Default.Port + ";Database="+ Properties.Settings.Default.Database + ";Uid="+ Properties.Settings.Default.UserID + ";password="+ Properties.Settings.Default.Password + ";";
    }     

}
