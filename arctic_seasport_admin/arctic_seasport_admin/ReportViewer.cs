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
    public partial class ReportViewer : Form
    {
        public ReportViewer(string body, int width = 750)
        {
            
            InitializeComponent();
            this.Size = new Size(width, 900);
            webBrowser1.DocumentText = body;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
