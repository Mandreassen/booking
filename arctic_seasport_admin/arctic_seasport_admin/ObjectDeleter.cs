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
    public partial class ObjectDeleter : Form
    {
        private string name;

        public ObjectDeleter(string objectName)
        {
            name = objectName;
            InitializeComponent();
        }

        private void ObjectDeleter_Load(object sender, EventArgs e)
        {

        }

        private void ObjectDeleter_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var adapter = new Database_adapter();

            var roID = adapter.get_Value(string.Format("select roID from rent_objects where name = '{0}';", name));
            var count = Int32.Parse(adapter.get_Value(string.Format("select count(name) name from rent_objects where roID = {0}", roID)));

            var dates = adapter.get_List(string.Format(@"
                select date 
                from booking_entries
                where roID = {0}
                and date >= '{1}'
                group by date
                order by date DESC; 
            ", roID, DateTime.Now.ToString("yyyy-MM-dd")));

            deleteBar.Maximum = dates.Count;
            deleteBar.Step = 1;
            deleteBar.Value = 0;

            var booked = "Could not delete object. Fully booked at:\r\n";

            var delete = true;
            foreach (var date in dates)
            {
                var bookedAtDate = adapter.get_Value(string.Format("select count(beID) from booking_entries where date = '{0}' and roID = {1};", DateTime.Parse(date).ToString("yyyy-MM-dd"), roID));

                if (count - Int32.Parse(bookedAtDate) <= 0)
                {
                    delete = false;
                    booked += DateTime.Parse(date).ToString("dd.MM.yy, ");
                }

                deleteBar.Value += 1;
            }

            Cursor.Current = Cursors.Default;

            if (delete)
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete {0}", name), "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    adapter.set(string.Format("delete from rent_objects where name = '{0}';", name));                    
                }
            }
            else
            {
                MessageBox.Show(booked);
            }

            adapter.close();
            this.Close();
        }
    }
}
