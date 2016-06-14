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

            string name    = adapter.get_Value(string.Format("select name from bookings natural join customers where bid = {0};", bid));
            string email   = adapter.get_Value(string.Format("select email from bookings natural join customers where bid = {0};", bid));
            string tlf     = adapter.get_Value(string.Format("select phone from bookings natural join customers where bid = {0};", bid));
            string country = adapter.get_Value(string.Format("select country from bookings natural join customers where bid = {0};", bid));
            string note    = adapter.get_Value(string.Format("select notes from bookings where bid = {0};", bid)).Replace("\n", "<br> &nbsp; ");
            string price   = adapter.get_Value(string.Format("select sum(Price) from booking_lines natural join rent_object_types where bid = {0};", bid));

            DataSet details = adapter.get_DataSet(string.Format("select description, date, price from booking_lines natural join rent_object_types where bid = {0};", bid));

            // BEGIN REPORT
            var report = string.Format(@"
                <!DOCTYPE html>
                <html>
                <body>                

                <img src=""http://www.arctic-seasport.no/img/LOGO.gif"" alt=""Logo"" style=""width:300px;height:111px;"">
                    <br>
                <font size=""6""> &nbsp;Booking confirmation </font>    

                <br>
                <br
                <br>           

                <font size=""4"">
                    &nbsp; Date: {0} <br>
                    &nbsp; Booking reference: {1} <br>
                    &nbsp; {2} <br>
                    &nbsp; {3} <br>
                    &nbsp; {4} <br>
                    &nbsp; {5} <br>
                </font>            

                <br>
            
                <font size=""5"">
                    &nbsp; Details
                </font>

                <hr>
                
                ", DateTime.Now.ToString("dd.MM.yyyy"), bid.ToString(), name, email, tlf, country);

            // Booking lines
            DataTable table = details.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                var rowstring = string.Format("{0} &nbsp;&nbsp; {1} &nbsp;&nbsp; NOK {2},-", row[0], ((DateTime) row[1]).ToString("dd.MM.yyy"), row[2]);
               
                report += string.Format("&nbsp;&nbsp; {0} <br>", rowstring);
            }

            report += string.Format(@"
                <br>                 

                <font size=""4"">                  
                    <div align=""left""> &nbsp; SUM: NOK {0},- </div>
                </font>                      

                <br>
                <br>                      

                <font size=""5"">
                    &nbsp; Notes
                </font>

                <hr>                      

                <font size=""4"">
                    &nbsp; {1}
                </font>

                <br>
                <br>
                <br>                       

                <font size=""4"">
                    &nbsp; Arctic Seasport AS <br>
                    &nbsp; Naurstad <br>
                    &nbsp; 8050 Tverlandet<br>
                    &nbsp; info@arctic-seasport.no <br>
                    &nbsp; +47 97666598
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

                table#t01 tr:nth-child(even) {
                    background-color: #eee;
                }

                table#t01 tr:nth-child(odd) {
                   background-color: #fff;
                }

                table#t01 th {
                    border-bottom: 1px solid black;
                }

                </style>
                </head>
                <body>
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
                        <th>Type</th>
                        <th>Depature</th>
                        <th>Notes</th>
                      </tr>
                      <tr>
                        <td>31</td>
                        <td>Captains cabin(25sqm.)</td>
                        <td>15.06.16</td>
                        <td>Sen ankomst <br> har bil <br> </td>
                      </tr>
                      <tr>
                        <td>32</td>
                        <td>Rorbu(50sqm.)</td>
                        <td>14.06.16</td>
                        <td>Sen ankomst <br> har bil <br> </td>
                      </tr>
                      <tr>
                        <td>32</td>
                        <td>Uttern S56 (60hp)</td>
                        <td>19.06.16</td>
                        <td>Sen ankomst <br> har bil <br> </td>
                      </tr>
                    </table>
                ", date.AddDays(i).ToString("dd.MM.yyy"));
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
