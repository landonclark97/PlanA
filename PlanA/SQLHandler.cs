//https://components.xamarin.com/view/mysql-plugin


using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using I18N.West;

namespace PlanA
{
    public class SQLHandler
    {
        string connectionString;
        MySqlConnection sqlconn;

        public SQLHandler(string ip, string port, string db, string userID, string password)
        {
            connectionString = "Server=" + ip + ";Port=" + port + ";database=" + db + ";User Id=" + userID + ";Password=" + password + ";charset = utf8";
            new CP1250();
            sqlconn = new MySqlConnection(connectionString);
            sqlconn.Open();
            sqlconn.Close();
        }

        public bool GetLogin(string un, string pw)
        {
            bool success = false;
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                List<string> cred = new List<string>();
                cred.Add(null);
                DataSet user = new DataSet();
                string queryString = "select username from Users where username='" + un + "' and password='" + pw + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(user, "Users");
                foreach (DataRow row in user.Tables["Users"].Rows)
                {
                    cred[0] = row[0].ToString();
                }
                if (cred[0] != null)
                {
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                sqlconn.Close();
            }
            return success;
        }

        public bool CreateAccount(string un, string pw, string email, string fn, string ln)
        {
            bool success = false;
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                List<string> cred = new List<string>();
                cred.Add(null);
                DataSet user = new DataSet();
                string queryString = "select username from Users where username='" + un + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(user, "Users");
                foreach (DataRow row in user.Tables["Users"].Rows)
                {
                    cred[0] = row[0].ToString();
                }
                if (cred[0] != null)
                {
                    success = false;
                }
                else
                {
                    MySqlCommand command = new MySqlCommand("insert into Users (username,password,email,First,Last) values (@user,@pass,@email,@First,@Last);", sqlconn);
                    command.Parameters.AddWithValue("@user", un);
                    command.Parameters.AddWithValue("@pass", pw);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@First", fn);
                    command.Parameters.AddWithValue("@Last", ln);
                    command.ExecuteNonQuery();
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                sqlconn.Close();
            }
            return success;
        }

        public string[,] getCreatedEvents(string username)
        {
            string[,] names = null;


            if(sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                string queryString = "select eventName from Events where username='" + username + "'";
                MySqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = queryString;

                MySqlDataReader reader = cmd.ExecuteReader();

                string[,] output = new string[30,3];

                int i = 0;

                while(reader.Read())
                {
                    output[i,0] = reader.GetString("eventName");
                    i++;
                }

                sqlconn.Close();
                sqlconn.Open();

                string queryString2 = "select eventID from Events where username='" + username + "'";
                MySqlCommand cmd2 = sqlconn.CreateCommand();
                cmd2.CommandText = queryString2;

                MySqlDataReader newReader = cmd2.ExecuteReader();

                i = 0;

                while (newReader.Read())
                {
                    output[i, 1] = newReader.GetString("eventID");
                    i++;
                }

                sqlconn.Close();
                sqlconn.Open();

                string queryString3 = "select open from Events where username='" + username + "'";
                MySqlCommand cmd3 = sqlconn.CreateCommand();
                cmd3.CommandText = queryString3;

                MySqlDataReader reader3 = cmd3.ExecuteReader();

                i = 0;

                while (reader3.Read())
                {
                    output[i, 2] = reader3.GetString("open");
                    i++;
                }

                names = output;

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return names;
        }

        public string[] getEventInfo(string eventID)
        {
            string[] info = new string[7];
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                string queryString = "select * from Events where eventID='" + eventID + "'";
                MySqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = queryString;

                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    info[0] = reader.GetString("username");
                    info[1] = reader.GetString("eventID");
                    info[2] = reader.GetString("eventName");
                    info[3] = reader.GetString("description");
                    info[4] = reader.GetString("location");
                    info[5] = reader.GetString("datetime");
                    info[6] = reader.GetString("open");
                }

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return info;
        }

        public bool createEvent(string username, string eventName, string description, string location, List<string> times)
        {
            bool success = false;
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                MySqlCommand command = new MySqlCommand("insert into Events (username,eventName,description,location,open) values (@username,@eventName,@description,@location,@open);", sqlconn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@eventName", eventName);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@open", "0");
                command.ExecuteNonQuery();

                System.Diagnostics.Debug.WriteLine("Executed insert statement");

                sqlconn.Close();

                sqlconn.Open();

                string queryString = "select max(eventID) from Events";
                System.Diagnostics.Debug.WriteLine("Selected eventID performed");
                MySqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = queryString;

                MySqlDataReader reader = cmd.ExecuteReader();

                string eventID = "";

                while (reader.Read())
                {
                    System.Diagnostics.Debug.WriteLine("Iterating through reader");
                    eventID = reader.GetString("max(eventID)");
                    System.Diagnostics.Debug.WriteLine("Should have recieved eventID");
                }

                System.Diagnostics.Debug.WriteLine(eventID);

                sqlconn.Close();
                       
                for (int i = 0; i < times.Count; i++)
                {
                    sqlconn.Open();

                    System.Diagnostics.Debug.WriteLine("Inserting from times list");

                    MySqlCommand command2 = new MySqlCommand("insert into TimeOptions (eventID,timeOption) values (@eventID,@timeOption);", sqlconn);
                    command2.Parameters.AddWithValue("@eventID", eventID);
                    command2.Parameters.AddWithValue("@timeOption", times[i]);
                    command2.ExecuteNonQuery();

                    sqlconn.Close();
                }

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                sqlconn.Close();
            }
            return success;
        }

        public string[,] getAllEvents()
        {
            string[,] names = null;


            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                string queryString = "select eventName from Events";
                MySqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = queryString;

                MySqlDataReader reader = cmd.ExecuteReader();

                string[,] output = new string[100, 3];

                int i = 0;

                while (reader.Read())
                {
                    output[i, 0] = reader.GetString("eventName");
                    i++;
                }

                sqlconn.Close();
                sqlconn.Open();

                string queryString2 = "select eventID from Events";
                MySqlCommand cmd2 = sqlconn.CreateCommand();
                cmd2.CommandText = queryString2;

                MySqlDataReader newReader = cmd2.ExecuteReader();

                i = 0;

                while (newReader.Read())
                {
                    output[i, 1] = newReader.GetString("eventID");
                    i++;
                }

                sqlconn.Close();
                sqlconn.Open();

                string queryString3 = "select open from Events";
                MySqlCommand cmd3 = sqlconn.CreateCommand();
                cmd3.CommandText = queryString3;

                MySqlDataReader reader3 = cmd3.ExecuteReader();

                i = 0;

                while (reader3.Read())
                {
                    output[i, 2] = reader3.GetString("open");
                    i++;
                }

                names = output;

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return names;
        }

        public List<string> getEventTimes(string eventID)
        {
            List<string> times = new List<string>();
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                string queryString = "select timeOption from TimeOptions where eventID='" + eventID + "'";
                MySqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = queryString;

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    times.Add(reader.GetString("timeOption"));
                }

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return times;
        }

        public bool closeEvent(string eventID, string username)
        {
            bool success = false;
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
            }
            try
            {
                MySqlCommand command = new MySqlCommand("update Events set open = 1 where eventID ='" + eventID + "' and username='" + username + "';", sqlconn);
                command.ExecuteNonQuery();

                sqlconn.Close();

                sqlconn.Open();

                string queryString = "select open from Events where eventID='" + eventID + "'";
                MySqlCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = queryString;

                MySqlDataReader reader = cmd.ExecuteReader();

                string result = "";

                while (reader.Read())
                {
                    result = reader.GetString("open");
                }

                if(result.Equals("0"))
                {
                    return false;
                }
                else if(result.Equals("1"))
                {
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
            finally
            {
                sqlconn.Close();
            }

            return success;
        }
    }
}
