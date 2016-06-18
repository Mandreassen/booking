using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace arctic_seasport_admin
{
    static class Report
    {
        static public void new_Booking(int bid)
        {
            var adapter = new Database_adapter();

            string bDate   = adapter.get_Value(string.Format("select bookingDate from bookings where bid = {0}", bid));
            string name    = adapter.get_Value(string.Format("select name from bookings natural join customers where bid = {0};", bid));
            string email   = adapter.get_Value(string.Format("select email from bookings natural join customers where bid = {0};", bid));
            string tlf     = adapter.get_Value(string.Format("select phone from bookings natural join customers where bid = {0};", bid));
            string country = adapter.get_Value(string.Format("select country from bookings natural join customers where bid = {0};", bid));
            string note    = adapter.get_Value(string.Format("select notes from bookings where bid = {0};", bid)).Replace("\n", "<br>");
            string price   = adapter.get_Value(string.Format("select sum(price) from booking_lines natural join booking_entries natural join rent_object_types where bid = {0};", bid));

            DataSet details = adapter.get_DataSet(string.Format("select description, startDate, endDate from booking_lines natural join booking_entries natural join rent_object_types where bid = {0} group by blid;", bid));

            // BEGIN REPORT
            var report = string.Format(@"
                <!DOCTYPE html>
                <html>
                <body>              

                <img src=""http://www.arctic-seasport.no/img/LOGO.gif"" alt=""Logo"" style=""width:300px;height:111px;"">
                    <br>
                <font size=""6""> Booking confirmation </font>    

                <br>
                <br
                <br>           

                <font size=""4"">
                    Date: {0} <br>
                    Booking reference: {1} <br>
                    {2} <br>
                    {3} <br>
                    {4} <br>
                    {5} <br>
                </font>            

                <br>
            
                <font size=""5"">
                    Details
                </font>
               
                ", DateTime.Parse(bDate).ToString("dd.MM.yyy"), bid.ToString(), name, email, tlf, country);
            

            // Booking lines
            report += @"
                    <style>
                    table {
                        width:100%;
                    }
                    table, th, td {
                        border-collapse: collapse;
                    }

                    th, td {
                        padding: 5px;
                        text-align: left;
                    }

                    table th {
                        border-bottom: 1px solid black;
                    }

                    </style>


                    <table>
                      <tr>
                        <th>Object</th>
                        <th>From</th>
                        <th>To</th>
                      </tr>                    
            ";

            DataTable table = details.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                report += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> </tr>", row[0], ((DateTime) row[1]).ToString("dd.MM.yyyy"), ((DateTime)row[2]).ToString("dd.MM.yyyy"));              
            }

            report += "</table>";

            
            // Notes and footer
            report += string.Format(@"                
                <br>                 

                <font size=""4"">                  
                    <div align=""left""> SUM: NOK {0},- </div>
                </font>                      

                <br>
                <br>                      

                <font size=""5"">
                    Notes
                </font>

                <hr>                      

                <font size=""4"">
                    {1}
                </font>

                <br>
                <br>
                <br>                       

                <font size=""4"">
                    Arctic Seasport AS <br>
                    Naurstad <br>
                    8050 Tverlandet<br>
                    info@arctic-seasport.no <br>
                    +47 97666598
                </font>

                </body>
                </html>
            ", price, note);
            // END REPORT


            adapter.close();

            ReportViewer view = new ReportViewer(report);
            view.ShowDialog();
            

            //FileStream f = File.Open("C:\\Users\\manau\\Desktop\\test.html", FileMode.CreateNew);
            //var plain = new UTF8Encoding(true).GetBytes(report);
            //f.Write(plain, 0, plain.Length);
            //f.Close();   
        }


        
        static public void arrivals()
        {
            var adapter = new Database_adapter();
            
            var report = @"
                <!DOCTYPE html>
                <html>
                <body>

                <img src=""http://www.arctic-seasport.no/img/LOGO.gif"" alt=""Logo"" style=""width:300px;height:111px;"">

                <br>

                <font size=""6""> Arrivals </font>

                    <style>
                    table {
                        width:100%;
                    }
                    table, th, td {
                        border-collapse: collapse;
                    }

                    th, td {
                        padding: 5px;
                        text-align: left;
                    }

                    table th {
                        border-bottom: 1px solid black;
                    }
                    </style>
            ";

            DateTime date = DateTime.Now;
            for (int i = 0; i < 4; i++)
            {
                report += string.Format(@"
                    <br>
                    <br>

                    <font size='4'> Date: {0} </font>

                    <table id='t01'>
                      <tr>
                        <th>BID</th>
                        <th>Description</th>
                        <th>Name</th>
                        <th>Phone</th>
                        <th>Country</th> 
                        <th>Notes</th>                       
                      </tr>
                ", date.AddDays(i).ToString("dd.MM.yyy"));

                var lines = adapter.get_DataSet(string.Format(@"
                    select startDate, bid, description, name, phone, country, notes
                    from customers
                    natural join bookings
                    natural join booking_lines
                    natural join booking_entries
                    natural join rent_object_types
                    group by blid
                    having startDate = '{0}'
                    order by bid
                    ;", date.AddDays(i).ToString("yyyy-MM-dd")));

                DataTable table = lines.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    report += string.Format(@"<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> <td> {4} </td> <td> {5} </td> </tr>
                                                ", row[1], row[2], row[3], row[4], row[5], row[6].ToString().Replace("\n", "<br>"));
                }

                report += "</table>";
            }

            report += @"
                </body>
                </html>
            ";

            adapter.close();

            ReportViewer view = new ReportViewer(report);
            view.ShowDialog();
        }
        
    }
}
