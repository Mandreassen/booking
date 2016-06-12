using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace arctic_seasport_admin
{
    class Database_adapter
    {
        private MySqlConnection conn;

        public Database_adapter()
        {
            conn = new MySqlConnection(Config.connString);
        }

        public void close()
        {
            conn.Close();
        }


        /* Gets single value from database.
         * Value is returned as a string.
         * Query must request a single value.
         * If error, null is returned */
        public string get_Value(string query)
        {            
            MySqlCommand command = conn.CreateCommand();
            MySqlDataReader reader;
            command.CommandText = query;
            string retval;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; // Error
            }

            try
            {
                reader = command.ExecuteReader();
                reader.Read();
                retval = reader[0].ToString();
                reader.Close();
            }
            catch
            {
                retval = null;
            }

            conn.Close();

            return retval; // Success
        }


        /* Put data into database
         * Returns:
         * - true if success
         * - false if error */
        public bool set(string query)
        {
            
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // Error
            }

            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                conn.Close();
                return false; // Error
            }

            conn.Close();

            return true; // Success
        }


        public bool book_dates(List<DateTime> dates, string bid, string roID)
        {
            MySqlCommand command = conn.CreateCommand();
            MySqlDataReader reader;
            string count;
            //command.CommandText = query;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // Error
            }

            MySqlTransaction trans = conn.BeginTransaction();

            // insert bookings into database
            foreach (var date in dates)
            {
                try
                {
                    // Set database
                    command.CommandText = string.Format("insert into booking_lines values (NULL, {0}, {1}, \'{2}\');", bid, roID, date.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();

                    // Get validation count
                    command.CommandText = string.Format("select count(roID) - (select count(roID) from booking_lines natural join rent_object_types where roID = {0} and Date = \'{1}\') from rent_objects natural join rent_object_types where roID = {0};", roID, date.ToString("yyyy-MM-dd"));
                    reader = command.ExecuteReader();
                    reader.Read();
                    count = reader[0].ToString();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                    conn.Close();
                    return false; // Error
                }

                // Validate insert
                if (Int32.Parse(count) < 0)
                {
                    trans.Rollback();
                    conn.Close();
                    return false; // Error
                }

            }

            trans.Commit();

            conn.Close();

            return true; // Success
        }


        /* Generate DataSet from multi column select */
        public DataSet get_DataSet(string query)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null; // Error
            }

            try
            {
                da.Fill(ds, "data");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return null; // Error
            }

            conn.Close();

            return ds; // Success
        }


        /* Generate list from single column select */
        public List<string> get_List(string query)
        {
            List<string> list = new List<string>();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; // Error
            }

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }

            conn.Close();

            list.Sort();

            return list; // Success
        }


        /* Generate dict from double column select */
        public Dictionary<string, string> get_Dict(string query)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; // Error
            }

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dict.Add(reader[0].ToString(), reader[1].ToString());
            }

            conn.Close();

            return dict; // Success
        }
    }
}
