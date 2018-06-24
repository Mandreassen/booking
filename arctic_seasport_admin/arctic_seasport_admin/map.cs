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
    public partial class map : Form
    {
        private Dictionary<string, string> rentObjects;
        private Dictionary<string, string> bookings;

        public map()
        {
            InitializeComponent();
        }

        private void load_Attrebutes()
        {
            var adapter = new Database_adapter();

            rentObjects = adapter.get_Dict(@"select name, bid from rent_objects
                left join booking_lines on rent_objects.currentUser = booking_lines.blid;");

            bookings = adapter.get_Dict(@"select bid, name from customers
                natural join bookings
                natural join booking_lines
                where blid in (select currentUser from rent_objects)
                group by bid;");

            adapter.close();
        }

        private void start_Report(string rentObject)
        {
            string bid = rentObjects[rentObject];
            if (bid == null | bid == "")
            {
                return;
            }

            var report = Report.booking_Confirmation(Int32.Parse(bid));
            var viewer = new ReportViewer(report);
            viewer.ShowDialog();
        }

        private void fill_Labels()
        {
            Label box;
            string txt, bid;

            foreach (var ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    box = (Label)ctrl;

                    txt = box.Text;
                    bid = rentObjects[txt];

                    if (bid != "")
                    {
                        box.Text = txt + ": " + bookings[bid];
                    }
                    else
                    {
                        box.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        
        private void adjust_Labels()
        {
            Båt1.Left = 652 - Båt1.Size.Width;
            Båt2.Left = 642 - Båt2.Size.Width;
            Båt3.Left = 632 - Båt3.Size.Width;
            Båt4.Left = 622 - Båt4.Size.Width;
            Båt10.Left = 590 - Båt10.Size.Width;
        }

        private void map_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            load_Attrebutes();

            fill_Labels();

            adjust_Labels();

            Cursor.Current = Cursors.Default;
        }

        private void B1_Click(object sender, EventArgs e)
        {
            start_Report("B1");
        }

        private void B2_Click(object sender, EventArgs e)
        {
            start_Report("B2");
        }

        private void B7_Click(object sender, EventArgs e)
        {
            start_Report("B7");
        }

        private void B8_Click(object sender, EventArgs e)
        {
            start_Report("B8");
        }

        private void R1_Click(object sender, EventArgs e)
        {
            start_Report("R1");
        }

        private void R2_Click(object sender, EventArgs e)
        {
            start_Report("R2");
        }

        private void R3_Click(object sender, EventArgs e)
        {
            start_Report("R3");
        }

        private void C1_Click(object sender, EventArgs e)
        {
            start_Report("C1");
        }

        private void C2_Click(object sender, EventArgs e)
        {
            start_Report("C2");
        }

        private void C3_Click(object sender, EventArgs e)
        {
            start_Report("C3");
        }

        private void Båt1_Click(object sender, EventArgs e)
        {
            start_Report("Båt 1");
        }

        private void Båt2_Click(object sender, EventArgs e)
        {
            start_Report("Båt 2");
        }

        private void Båt3_Click(object sender, EventArgs e)
        {
            start_Report("Båt 3");
        }

        private void Båt4_Click(object sender, EventArgs e)
        {
            start_Report("Båt 4");
        }

        private void Båt5_Click(object sender, EventArgs e)
        {
            start_Report("Båt 5");
        }

        private void Båt6_Click(object sender, EventArgs e)
        {
            start_Report("Båt 6");
        }

        private void Båt7_Click(object sender, EventArgs e)
        {
            start_Report("Båt 7");
        }

        private void Båt9_Click(object sender, EventArgs e)
        {
            start_Report("Båt 9");
        }

        private void Båt10_Click(object sender, EventArgs e)
        {
            start_Report("Båt 10");
        }

        private void Båt11_Click(object sender, EventArgs e)
        {
            start_Report("Båt 11");
        }

        private string get_Bid_from_label(string name)
        {
            string txt = name.Split(':')[0];

            return rentObjects[txt];
                    
        }

        private void set_Highlight(string bid)
        {
            foreach (var ctrl in this.Controls)
            {
                Label box;

                if (ctrl is Label)
                {
                    box = (Label)ctrl;

                    if (bid == get_Bid_from_label(box.Text))
                    {
                        if (bid == "")
                        {
                            box.BackColor = Color.LightSeaGreen;
                        }
                        else
                        {
                            box.BackColor = Color.Yellow;
                        }                        
                    }
                }
            }
        }

        private void clear_Highlight(string bid)
        {
            foreach (var ctrl in this.Controls)
            {
                Label box;

                if (ctrl is Label)
                {
                    box = (Label)ctrl;

                    if (bid == get_Bid_from_label(box.Text))
                    {
                        if (bid != "")
                        {
                            box.BackColor = Color.White;
                        }
                        else
                        {
                            box.BackColor = Color.LightGreen;
                        }
                        
                    }
                }
            }
        }
        
        private void B1_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(B1.Text));
        }

        private void B1_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(B1.Text));
        }

        private void B2_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(B2.Text));
        }

        private void B2_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(B2.Text));
        }

        private void B7_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(B7.Text));
        }

        private void B7_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(B7.Text));
        }

        private void B8_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(B8.Text));
        }

        private void B8_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(B8.Text));
        }

        private void R1_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(R1.Text));
        }

        private void R1_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(R1.Text));
        }

        private void R2_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(R2.Text));
        }

        private void R2_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(R2.Text));
        }

        private void R3_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(R3.Text));
        }

        private void R3_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(R3.Text));
        }

        private void C1_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(C1.Text));
        }

        private void C1_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(C1.Text));
        }

        private void C2_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(C2.Text));
        }

        private void C2_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(C2.Text));
        }

        private void C3_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(C3.Text));
        }

        private void C3_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(C3.Text));
        }

        private void Båt1_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt1.Text));
        }

        private void Båt1_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt1.Text));
        }

        private void Båt2_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt2.Text));
        }

        private void Båt2_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt2.Text));
        }

        private void Båt3_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt3.Text));
        }

        private void Båt3_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt3.Text));
        }

        private void Båt4_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt4.Text));
        }

        private void Båt4_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt4.Text));
        }

        private void Båt5_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt5.Text));
        }

        private void Båt5_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt5.Text));
        }

        private void Båt6_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt6.Text));
        }

        private void Båt6_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt6.Text));
        }

        private void Båt7_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt7.Text));
        }

        private void Båt7_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt7.Text));
        }

        private void Båt9_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt9.Text));
        }

        private void Båt9_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt9.Text));
        }

        private void Båt10_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt10.Text));
        }

        private void Båt10_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt10.Text));
        }

        private void Båt11_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Båt11.Text));
        }

        private void Båt11_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Båt11.Text));
        }

        private void Bella_MouseEnter(object sender, EventArgs e)
        {
            set_Highlight(get_Bid_from_label(Bella.Text));
        }

        private void Bella_MouseLeave(object sender, EventArgs e)
        {
            clear_Highlight(get_Bid_from_label(Bella.Text));
        }
    }
}
