using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Fourex_Kiosk_Analytics
{
    class Database
    {
        static string Temp1 = null;
        static string Temp2 = null;

        public static void LoadFromDBOffLineListView()
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

           // string query = "SELECT * FROM(SELECT * FROM fourex.errorlogs WHERE Mail Like '%,Swicth,%' ORDER By TxStamp desc) AS sub GROUP BY KioskName";
            string query = "SELECT * FROM (SELECT * FROM fourex.errorlogs WHERE Mail Like '%,Swicth,%' group by TxStamp DESC) tabtemp GROUP BY KioskName";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int i = 0;

            for (int j = 0; j < Variables.ListArraySize; j++)
            {
                Variables.OffLineListKioskName[j] = null;
                Variables.OffLineListKioskReason[j] = null;
                Variables.OffLineListKioskDateTime[j] = null;
            }

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Mail"].ToString().IndexOf(",Off-Line,") != -1)
                    {
                        string[] SplitMail = null;

                        SplitMail = reader["Mail"].ToString().Split(',');

                        Variables.OffLineListKioskName[i] = reader["KioskName"].ToString();
                        Variables.OffLineListKioskReason[i] = SplitMail[4].ToString();
                        Variables.OffLineListKioskDateTime[i] = reader["TxStamp"].ToString();
                        i++;

                        System.Windows.Forms.Application.DoEvents();
                    }
                }

                reader.Close();
                reader.Dispose();
                con.Dispose();
                con.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Dispose();

            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }

        static public void AddAlert(string KioskName, string KioskNumber, string Mail, string TxStamp, string Status, string Progress, decimal ID)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlConnection connection = new MySqlConnection(FourexConnectionString);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO errorlogs (KioskName,KioskNumber,Mail,TxStamp,Status,Progress,ID)VALUES(@KioskName,@KioskNumber,@Mail,@TxStamp,@Status,@Progress,@ID)";
                cmd.Parameters.AddWithValue("@TxStamp", TxStamp);
                cmd.Parameters.AddWithValue("@KioskName", KioskName);
                cmd.Parameters.AddWithValue("@KioskNumber", KioskNumber);
                cmd.Parameters.AddWithValue("@Mail", Mail);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Progress", Progress);
                cmd.Parameters.AddWithValue("@ID",ID);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Writing Log Error: ", ex.Message);
            }
        }

        public static void ChangeKioskStatus(string KioskNumber, string Status)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "UPDATE fourex.errorsetup SET Status = '" + Status + "' WHERE KioskNumber = '" + KioskNumber + "'";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                reader.Close();
                reader.Dispose();
                con.Dispose();
                con.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Dispose();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }

           //-- Update Memory List now 

            for (int i = 0; i < Variables.ListArraySize; i++)
            {
                if (Variables.KioskNumberList[i] == KioskNumber)
                {
                    Variables.KioskStatus[i] = Status;
                }
            }
        }

        public static void AlertManagerComplete(decimal ID)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "UPDATE fourex.errorlogs SET Progress = 'Complete' WHERE ID = '" + ID + "'";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                reader.Close();
                reader.Dispose();
                con.Dispose();
                con.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Dispose();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }

        }

        public static void LoadSetup()
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "SELECT * FROM fourex.errorconsolesetup;";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                        Variables.Setup_EmailAddress01  = reader["MailAddress01"].ToString();
                        Variables.Setup_Password01      = reader["Password01"].ToString();

                        Variables.Setup_EmailAddress02  = reader["MailAddress02"].ToString();
                        Variables.Setup_Password02      = reader["Password02"].ToString();

                        Variables.Setup_EmailAddress03  = reader["MailAddress03"].ToString();
                        Variables.Setup_Password03      = reader["Password03"].ToString();
                }

                reader.Close();
                reader.Dispose();
                con.Dispose();
                con.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Dispose();

            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }

        public static void LoadPersistFileDetailsIntoDB()
        {
            //--- Read DB out Database 
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

         //   for (int i = 0; i < KioskNumberList[i]; i++)
            {
                string ConnectionString = FourexConnectionString;
                con = new MySqlConnection(ConnectionString);

                string Status = null;
                string KioskNumber = null;

                string query = "UPDATE fourex.errorlogs WHERE KioskNumber  = '" + "' WHERE KioskNumber = '" + KioskNumber + "'";

                cmd = new MySqlCommand(query);
                cmd.Connection = con;

                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();

                    reader.Close();
                    reader.Dispose();
                    con.Dispose();
                    con.Close();
                    cmd.Connection.Close();
                    cmd.Dispose();
                    cmd.Connection.Dispose();
                }
                catch (Exception ex)
                {
                    cmd.Connection.Close();
                    con.Close();
                    cmd.Dispose();
                    con.Dispose();
                }
            }
        }

        public static string BuildSQL(double id, string[] Field, string Time)
        {
            string query = null;
        
            string EndString = " ";

            if (Field.Length > 5)
            {
                for (int i = 6; i < Field.Length; i++)
                {
                    EndString = EndString + Field[i];
                }

                for (int j = 0; j < Field.Length; j++)
                {
                    if (Field[j] == "")
                        Field[j] = " ";
                }

                query = "UPDATE fourex.errorlogs SET Type = " + "'" + Field[0] + "'," +

                   " Field01 = " + "'" + Field[1] + "'," +
                   " Field02 = " + "'" + Field[2] + "'," +
                   " Field03 = " + "'" + Field[3] + "'," +
                   " Field04 = " + "'" + Field[4] + "'," +
                   " Field05 = " + "'" + Field[5] + "'," +
                   " Field06 = " + "'" + EndString + "'," +
                   " Time = " + "'" + Time + "'" +

                   " WHERE idErrorLogs  = '" + id + "'";
            }
            else
            {
                for (int j = 0; j < Field.Length; j++)
                {
                    if (Field[j] == "")
                        Field[j] = " ";
                }

                if (Field.Length == 5)
                {
                    query = "UPDATE fourex.errorlogs SET Type = " + "'" + Field[0] + "'," +

                      " Field01 = " + "'" + Field[1] + "'," +
                      " Field02 = " + "'" + Field[2] + "'," +
                      " Field03 = " + "'" + Field[3] + "'," +
                      " Field04 = " + "'" + Field[4] + "'," +
                      " Time = " + "'" + Time + "'" +

                      " WHERE idErrorLogs  = '" + id + "'";
                }

                if (Field.Length == 4)
                {
                    query = "UPDATE fourex.errorlogs SET Type = " + "'" + Field[0] + "'," +

                      " Field01 = " + "'" + Field[1] + "'," +
                      " Field02 = " + "'" + Field[2] + "'," +
                      " Field03 = " + "'" + Field[3] + "'," +
                      " Time = " + "'" + Time + "'" +

                      " WHERE idErrorLogs  = '" + id + "'";
                }

                if (Field.Length == 3)
                {
                    query = "UPDATE fourex.errorlogs SET Type = " + "'" + Field[0] + "'," +

                      " Field01 = " + "'" + Field[1] + "'," +
                      " Field02 = " + "'" + Field[2] + "'," +
                      " Time = " + "'" + Time + "'" +

                      " WHERE idErrorLogs  = '" + id + "'";
                }
            }
        
            return (query);
        }

        public static void InsertRemedyNotificationIntoDB (double id, string[] Field, string Time )
        {
            //--- Read DB out Database 
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader Insertreader = null;
            MySqlConnection Insertcon = null;
            MySqlCommand Insertcmd = null;

                string ConnectionString = FourexConnectionString;
                Insertcon = new MySqlConnection(ConnectionString);

                string Status = null;
                string KioskNumber = null;

                string query = BuildSQL(id,Field, Time);

                Variables.DebugString = query;
            
                Insertcmd = new MySqlCommand(query);
                Insertcmd.Connection = Insertcon;

                try
                {
                    Insertcon.Open();
                    Insertreader = Insertcmd.ExecuteReader();

                    Insertreader.Close();
                    Insertreader.Dispose();
                    Insertcon.Dispose();
                    Insertcon.Close();
                    Insertcmd.Connection.Close();
                    Insertcmd.Dispose();
                    Insertcmd.Connection.Dispose();
                }
                catch (Exception ex)
                {
                    Insertcmd.Connection.Close();
                    Insertcon.Close();
                    Insertcmd.Dispose();
                    Insertcon.Dispose();
                }          
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ',')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static void ImportRemedyNotification()
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "SELECT * FROM fourex.errorlogs WHERE (Mail like '%NOTIFICATION%' OR  Mail like '%REMEDY%') AND Type IS NULL order by TxStamp desc";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int Count = 0;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                string Time = "None";

                Variables.ImportCount = 0;

                while (reader.Read())
                {
                    System.Windows.Forms.Application.DoEvents();

                    //-- Clean mail from Special Chars 
                   string TempMail = RemoveSpecialCharacters(reader["Mail"].ToString());

                   string[] Split =  TempMail.ToString().Split(',');

                    string Mail = reader["Mail"].ToString();

                    Time = "None";

                    if (Mail.IndexOf("time=") != -1)
                    {
                        int StartPos = Mail.IndexOf("time");

                        try
                        {
                            Time = Mail.Substring(StartPos, 13);
                        }
                        catch(Exception ex)
                        {
                            int gg =9;
                        }
                    }

                   double id = Convert.ToInt64(reader["idErrorLogs"].ToString());

                   Variables.RecordID = id;

                   if (id == 2209)
                   {
                       int u = 88;
                   }

                   if (Variables.ImportCount > 51)
                   {
                       int ff = 0;
                   }

                   InsertRemedyNotificationIntoDB(id, Split, Time);
                   Variables.ImportCount++;                                 
                }

                Variables.POPMailResponse = "Import  >- " + Count;

                reader.Close();
                reader.Dispose();
                con.Dispose();
                con.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Dispose();
            }
            catch (Exception ex)
            {             
                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }

        public static bool CheckKioskLiveStatus(string KioskNumber)
        {
            for (int i = 0; i <  Variables.ListArraySize; i++)
            {
                if (KioskNumber == Variables.KioskNumberList[i])
                {
                    if (Variables.KioskStatus[i] == "Live")
                        return (true);
                }
            }

            return (false);
        }

        public static bool CheckForActiveAlert(string KioskNumber, string ErrorCode)
        {
            for (int i = 0; i < Variables.ListArraySize; i++)
            {
                if (KioskNumber == Variables.AlertManager_KioskNumber[i])
                {
                    if (Variables.AlertManager_Description[i].IndexOf(ErrorCode) != -1)
                    {
                        return (false);
                    }
                }
            }

            return (true);
        }

        public static void AutoAlertManager(string Type, string ErrorCode, string ErrorDescrition)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string TimeSearch = DateTime.Now.AddMinutes(-3).ToString("yyyy-MM-dd HH:mm:ss");

            string query = "SELECT * FROM fourex.errorlogs WHERE Mail Like '" + Type + "' AND TxStamp >= '" + TimeSearch + "' GROUP BY KioskNumber Order by TxStamp desc";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string KioskNumber  = reader["KioskNumber"].ToString();
                    string KioskName    = reader["KioskName"].ToString();

                    if ((CheckKioskLiveStatus(KioskNumber) == true)&&(CheckForActiveAlert(KioskNumber,ErrorCode) == true))
                    {
                        Fourex_Kiosk_Analytics.Database.AddAlert(KioskName, KioskNumber, "<<Alert>>,AutoMode,CreateAlert,ErrorConsole," + ErrorCode + " " + ErrorDescrition  + ",", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Auto", "Open", DateTime.Now.Ticks);

                        Variables.AlertManagerScreenUpdate = true;
                    }
                }

                reader.Close();
                reader.Dispose();
                con.Dispose();
                con.Close();
                cmd.Connection.Close();
                cmd.Dispose();
                cmd.Connection.Dispose();

            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }
    }
}
