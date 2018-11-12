using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Net.Mail;

namespace Fourex_Kiosk_Analytics
{
    class Database
    {
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

        public static void UpdateKioskDB(string KioskNumber, string DayEndTime, string DayStartTime)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "UPDATE fourex.errorsetup SET StopSleep = '" + DayEndTime + "'" +", StartSleep = " + "'" + DayStartTime + "'" + " WHERE KioskNumber = '" + KioskNumber + "'";

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

        public static void LoadPersistFileDetailsIntoDB()
        {
            //--- Read DB out Database 
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            for (int i = 1; i < Variables.ListArraySize; i++)
            {
                if (!(Variables.KioskNumberList[i] == null))
                {
                    string ConnectionString = FourexConnectionString;
                    con = new MySqlConnection(ConnectionString);

                    string Status = null;
                    string KioskNumber = null;

                    string query = "SELECT *FROM fourex.errorlogs WHERE KioskNumber = '" + Variables.KioskNumberList[i] + "'" + " AND (Mail like '%<< Maintenance ON >>%' OR Mail like '%<< Maintenance OFF >>%') ORDER BY TxStamp Limit 1";

                    cmd = new MySqlCommand(query);
                    cmd.Connection = con;

                    try
                    {
                        con.Open();
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string StartSleep = reader["Mail"].ToString().Substring(reader["Mail"].ToString().IndexOf("StartSleep")+13, 19);

                            string StopSleep = reader["Mail"].ToString().Substring(reader["Mail"].ToString().IndexOf("StopSleep") + 12, 19);

                            UpdateKioskDB(Variables.KioskNumberList[i], StopSleep, StartSleep);
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

                        MailAlert(KioskName + " " + "<<Alert>>,AutoMode,CreateAlert,ErrorConsole," + ErrorCode + " " + ErrorDescrition );

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

        public static int CaculateTotalMinsPerDay(int Index, int DayToday)
        {
            int Mins = 0;

            double Duration = 0;

            //--- Today Moveing Time for end time  
            if (DayToday == 0)
            {
                if (DateTime.Parse(DateTime.Now.ToString()).Subtract(DateTime.Parse(Variables.KioskStartSleep[Index])).TotalMinutes < 0)
                {
                    Duration = DateTime.Parse(DateTime.Now.ToString()).Subtract(DateTime.Parse(Variables.KioskStopSleep[Index])).TotalMinutes;
                }
                else
                {
                    Duration = DateTime.Parse(Variables.KioskStartSleep[Index]).Subtract(DateTime.Parse(Variables.KioskStopSleep[Index])).TotalMinutes;
                }
            }
            else
            {
                Duration = DateTime.Parse(Variables.KioskStartSleep[Index]).Subtract(DateTime.Parse(Variables.KioskStopSleep[Index])).TotalMinutes;
            }

            return(Convert.ToInt16(Duration));
        }

        public static void SetupExcel ()
        {
        }

        public static void CalculateDownTime (int Index, string Type, string SingleMailAddress)
        {
            int TotalMins           = 0;
            int Point               = 0;
            string StartTime        = "";
            string EndTime          = "";
            int UPTimeIndexCounter  = 0;
            int KioskIndex          = 0;

            //-- Reset Array 
            for(int l = 0;l< Variables.UPTimeArraySize;l++)
            {
                Variables.UPTime_DownTimeMins[l]    = 0;
                Variables.UPTime_UPTimeMins[l]      = 0;
                Variables.UPTime_KioskNumber[l]     = null;
                Variables.UPTime_Day[l]             = 0;
            }

            for (int i = 0; i < 7; i++)
            {
               Variables.UPTime_TotalMins[i]        = 0;
               Variables.UPTime_TotalDownMins[i]    = 0;
               Variables.UPTime_PerCentage[i]       = 0;
               Variables.UPTime_DayName[i]          = "";
            }

            //--- Read DB out Database 
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            for (int i = 1; i < Variables.ListArraySize; i++)
            {
                if (!(Variables.KioskNumberList[i] == ""))
                {
                    if ((Form1.CheckKioskStatus(Variables.KioskNumberList[i]) == "Live")||(Form1.CheckKioskStatus(Variables.KioskNumberList[i])=="OffLine"))
                    {
                        for (int Days = 0; Days < 7; Days++)
                        {
                            DateTime Date = DateTime.Now.AddDays(-Days);

                            Variables.UPTime_DayName[Days] = DateTime.Now.AddDays(-Days).DayOfWeek.ToString();

                            DateTime DateStartSleep = Convert.ToDateTime(Date.ToString("yyyy-MM-dd") + " " + Variables.KioskStartSleep[i]).AddHours(2);
                            DateTime DateStopSleep = Convert.ToDateTime(Date.ToString("yyyy-MM-dd") + " " + Variables.KioskStopSleep[i]).AddHours(2);

                            string DateStartString = DateStartSleep.ToString("yyyy-MM-dd HH:mm:ss");
                            string DateStopString = DateStopSleep.ToString("yyyy-MM-dd HH:mm:ss");

                            string ConnectionString = FourexConnectionString;
                            con = new MySqlConnection(ConnectionString);

                            if (Variables.KioskNumberList[i] == "0015")
                            {
                                int hj = 0; 
                            }


                            // '%<<--OK Access-->>%' 
                            // '%<< PROBLEM Sec PCB >> UI Interface Down%'
                            //  <<BOOT UP>>

                            // string query = "SELECT * FROM fourex.errorlogs where Mail Like '%<< Maintenance ON >>%' AND KioskNumber = '" + Variables.KioskNumberList[i] + "' AND TxStamp >= '" + DateStopString + "' AND TxStamp <= '" + DateStartString + "' order by TxStamp asc";

                            string OKAccess = "Mail Like '%<<--OK Access-->>%'";
                            string UIDown   = "Mail Like '%<< PROBLEM Sec PCB >> UI Interface Down%'";
                            string BootUp   = "Mail Like '%<<BOOT UP>>%'";
                            string MMMode   = "Mail Like '%<< Maintenance ON >>%'";

                            string query = "SELECT * FROM fourex.errorlogs where (" + MMMode + " OR " + OKAccess + " OR " + BootUp + ") AND KioskNumber = '" + Variables.KioskNumberList[i] + "' AND TxStamp >= '" + DateStopString + "' AND TxStamp <= '" + DateStartString + "' order by TxStamp asc";

                            cmd = new MySqlCommand(query);
                            cmd.Connection = con;

                            DateTime FirstTX = DateTime.Now;
                            DateTime SecondTX;

                            int TxStampCounter = 0;

                            double Duration = 0;
                            Point           = 0;
                            TotalMins       = 0;

                            int TotalKioskDownMinutes = 0;
                            int OKLogInsCounter = 0; 
                            
                            //--- Reset Array Transaction ---
                            //for(int j=0;j<100;j++)
                            //{
                            //    Variables.OKLogIns[j] ;
                            //}


                            string TempString = null; 
                            try
                            {
                                con.Open();
                                reader = cmd.ExecuteReader();

                                while (reader.Read())
                                {
                                    //---------------------------------
                                    //--- Check for Maintenace Mode ---
                                    //---------------------------------
                                    if (reader["Mail"].ToString().IndexOf("<< Maintenance ON >>") !=-1)
                                    {
                                         TempString =  reader["idErrorLogs"].ToString();

                                         if(TempString == "60748")
                                         {
                                             int hj = 0;
                                         }

                                        if (reader["KioskNumber"].ToString() == "0004")
                                        {
                                            int pp = 9;
                                        }

                                        if (Point == 0)
                                        {
                                               StartTime = reader["TxStamp"].ToString();
                                        }

                                        Point++;

                                        EndTime = reader["TxStamp"].ToString();
                                    }

                                     //---------------------------
                                    //--- Check Kioks Field MM ---
                                    //----------------------------

                                    if (reader["Mail"].ToString().IndexOf("<<--OK Access-->>") != -1)
                                    {
                                       Variables.OKLogIns[OKLogInsCounter++] = Convert.ToDateTime(reader["TxStamp"].ToString());
                                    }

                                    if (reader["Mail"].ToString().IndexOf("<<BOOT UP>>") != -1)
                                    {
                                        TotalKioskDownMinutes = TotalKioskDownMinutes + 5;
                                    }
                                }

                                if (Point > 0)
                                {
                                    //----------------------------------------------
                                    //--- Check if Kioks was in MM in Sleep mode ---
                                    //----------------------------------------------

                                    DateTime Start = Convert.ToDateTime(StartTime.ToString());
                                    string StartString = Start.ToString("yyyy-MM-dd HH:mm:ss");

                                    DateTime End = Convert.ToDateTime(EndTime.ToString());
                                    string EndString = End.ToString("yyyy-MM-dd HH:mm:ss");

                                    if (DateTime.Parse(Variables.KioskStopSleep[i]).Subtract(DateTime.Parse(StartString)).TotalMinutes < 30)
                                    {
                                        StartTime = Variables.KioskStopSleep[i];
                                    }

                                    if (DateTime.Parse(Variables.KioskStartSleep[i]).Subtract(DateTime.Parse(EndString)).TotalMinutes < 30)
                                    {
                                        EndTime = Variables.KioskStartSleep[i];
                                    }

                                    Duration = DateTime.Parse(EndString).Subtract(DateTime.Parse(StartString)).TotalMinutes;

                                    if (Duration < 0)
                                    {
                                        int jk = 0;

                                        Duration = 0;
                                    }
                                }

                                if (OKLogInsCounter > 0)
                                {
                                    if (OKLogInsCounter == 1)
                                    {
                                        TotalKioskDownMinutes = TotalKioskDownMinutes + 15;
                                    }
                                    else
                                    {
                                        for (int j = 0; j < OKLogInsCounter; j++)
                                        {
                                            if (j == 0)
                                            {
                                                TotalKioskDownMinutes = TotalKioskDownMinutes + 15;
                                            }

                                            if (j < (OKLogInsCounter - 1)) //-- Look for last record  
                                            {
                                                Double ElapseMins = ((TimeSpan)(Variables.OKLogIns[j + 1] - Variables.OKLogIns[j])).TotalMinutes;

                                                if (ElapseMins >= 15)
                                                    TotalKioskDownMinutes = TotalKioskDownMinutes + 15;
                                            }
                                        }
                                    }
                                }

                                TotalMins = CaculateTotalMinsPerDay(i,Days);

                                Variables.UPTime_Day[UPTimeIndexCounter]            = Days;
                                Variables.UPTime_DownTimeMins[UPTimeIndexCounter]   = Convert.ToInt16(Duration);
                                Variables.UPTime_UPTimeMins[UPTimeIndexCounter]     = Convert.ToInt16(TotalMins);
                                Variables.UPTime_KioskNumber[UPTimeIndexCounter]    = Variables.KioskNumberList[i];

                                UPTimeIndexCounter++;

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
            }

            for (int TotDays = 0; TotDays < 7; TotDays++)
            {
                  KioskIndex = 0;

                for (int h = 0; h < UPTimeIndexCounter; h++)
                {
                    if (Index == 0)
                    {
                        if (Variables.UPTime_Day[h] == TotDays)
                        {
                            Variables.UPTime_TotalMins[TotDays] = Variables.UPTime_TotalMins[TotDays] + Variables.UPTime_UPTimeMins[h];
                            Variables.UPTime_TotalDownMins[TotDays] = Variables.UPTime_TotalDownMins[TotDays] + Variables.UPTime_DownTimeMins[h];
                        }
                    }
                    else
                    {
                        if ((Variables.UPTime_Day[h] == TotDays)&&(Variables.UPTime_KioskNumber[h]==Variables.KioskNumberList[Index]))
                        {
                            Variables.UPTime_TotalMins[TotDays] = Variables.UPTime_TotalMins[TotDays] + Variables.UPTime_UPTimeMins[h];
                            Variables.UPTime_TotalDownMins[TotDays] = Variables.UPTime_TotalDownMins[TotDays] + Variables.UPTime_DownTimeMins[h];
                        }
                    }

                    //-- Calculate 7 Days AVE per Kiosk 

                    for (int i = 0; i < Variables.ListArraySize;i++)
                    {
                        if(Variables.KioskNumberList[i]!=null)
                        {
                            if ((Variables.UPTime_Day[h] == TotDays)&& (Variables.UPTime_KioskNumber[h] == Variables.KioskNumberList[i]))
                            {
                                Variables.UPTime_AVG_Kioks_UPTime[KioskIndex]       = Variables.UPTime_AVG_Kioks_UPTime[KioskIndex] + Variables.UPTime_UPTimeMins[h];
                                Variables.UPTime_AVG_Kiosk_DownTime[KioskIndex]     = Variables.UPTime_AVG_Kiosk_DownTime[KioskIndex] + Variables.UPTime_DownTimeMins[h];
                                
                                Variables.UPTime_AVG_KioskNumber[KioskIndex]        = Variables.KioskNumberList[i];
                                Variables.UPTime_AVG_KioskName[KioskIndex]          = Variables.KioskNameList[i];

                                KioskIndex++;
                            }
                        }
                    }
                }
            }


            for (int TotDays = 0; TotDays < 7; TotDays++)
            {
                Variables.UPTime_PerCentage[TotDays] = (100 - ((Convert.ToDouble(Variables.UPTime_TotalDownMins[TotDays]) / Convert.ToDouble(Variables.UPTime_TotalMins[TotDays])) * 100));
            }
   
            int gg = 0;

            if (Type == "Excel")
            {
                string ExcelPath = @"C:\Fourex\Fourex-Kiosk-Analytics\FouexUpTimeTemplate.xlsx";

                Microsoft.Office.Interop.Excel.Application ExcelApplication = new Microsoft.Office.Interop.Excel.Application();

                Workbook ExcelworkBook = ExcelApplication.Workbooks.Open(ExcelPath);

                ExcelApplication.Visible = true;

                //------------------------------------------------------
                //----  Load Totals Into Excel  (Last 7 days) ----------
                //------------------------------------------------------

                double LowValue = Variables.UPTime_PerCentage[0];

                for (int i = 0; i < 7; i++)
                {
                    if (LowValue > Variables.UPTime_PerCentage[i])
                    {
                        LowValue = Variables.UPTime_PerCentage[i];
                    }
                }

                // chart1.ChartAreas[0].AxisY.Maximum = 100;
                // chart1.ChartAreas[0].AxisY.Minimum = Convert.ToInt16(Value);

                int TotalXAsis = 3;
                int TotalYAsis = 9;

                Worksheet ExcelworkSheet = ExcelworkBook.Worksheets.Item[1] as Worksheet;

                ExcelworkSheet.Rows.Cells[2, 3] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                for (int WeekDay = 0; WeekDay < 7; WeekDay++)
                {
                    ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis] = DateTime.Now.AddDays(-WeekDay).DayOfWeek.ToString();

                    ExcelworkSheet.Rows.Cells[TotalXAsis++, TotalYAsis+1] = Math.Round((Convert.ToDouble(Variables.UPTime_PerCentage[WeekDay])),2);
                }

                TotalXAsis = 6;
                TotalXAsis = 24;

                double TotalsUPTimePersen = 0;
                int KioksCounted = 0;

                double tt = 0.0;
                double TotalUpTime = 0;
                double TotalDownTime = 0;

                for (int i = 0; i < Variables.ListArraySize; i++)
                {   
                    if (Variables.UPTime_AVG_KioskNumber[i] != null)
                    {
                        tt = Math.Round((100 - ((Variables.UPTime_AVG_Kiosk_DownTime[i] / Variables.UPTime_AVG_Kioks_UPTime[i]) * 100)),2);

                        TotalsUPTimePersen = TotalsUPTimePersen + tt;  
                        TotalUpTime = TotalUpTime + Variables.UPTime_AVG_Kioks_UPTime[i];
                        TotalDownTime = TotalDownTime + Variables.UPTime_AVG_Kiosk_DownTime[i];

                        string TempString = Variables.UPTime_AVG_KioskName[i];

                        ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis] = TempString;
                        ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis + 1] = tt;
                        ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis + 2] = Variables.UPTime_AVG_Kioks_UPTime[i];
                        ExcelworkSheet.Rows.Cells[TotalXAsis++, TotalYAsis + 3] = Variables.UPTime_AVG_Kiosk_DownTime[i];

                        KioksCounted++;
                    }
                }

                TotalXAsis = TotalXAsis + 4;

                ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis] = "Totals";
                ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis + 1] = Math.Round((TotalsUPTimePersen / KioksCounted),2);
                ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis + 2] = TotalUpTime;
                ExcelworkSheet.Rows.Cells[TotalXAsis, TotalYAsis + 3] = TotalDownTime;

                string AVEUpTime = Convert.ToString(Math.Round((TotalsUPTimePersen / KioksCounted), 2));

                //---------------------------------------
                //--- Now Load the days per days info ---
                //---------------------------------------

                for (int SheetNumber = 0; SheetNumber < 7; SheetNumber++)
                {
                    ExcelworkSheet = ExcelworkBook.Worksheets.Item[SheetNumber + 2] as Worksheet;

                    ExcelworkSheet.Rows.Cells[2, 3] = DateTime.Now.ToString(); 
                    ExcelworkSheet.Rows.Cells[2, 7] = "Report Date";
                    ExcelworkSheet.Rows.Cells[2, 9] = DateTime.Now.AddDays(-SheetNumber).ToString("yyyy/MM/dd");

                    int XAsis = 6;
                    int YAsis = 9;
                    //int h = 0;
                    int LocalKioskIndex     = 1;
                    int TotalDownTimeMins   = 0;
                    int TotalUpTimeMins     = 0;
                    //double TotalUPTimeAVE   = 0; 

                    while (Variables.KioskNumberList[LocalKioskIndex] != null)
                    {
                       if ((Form1.CheckKioskStatus(Variables.KioskNumberList[LocalKioskIndex]) == "Live") || (Form1.CheckKioskStatus(Variables.KioskNumberList[LocalKioskIndex]) == "OffLine"))
                          {
                            for (int i = 0; i < Variables.ListArraySize; i++)
                            {
                                if ((Variables.UPTime_Day[i] == SheetNumber) && (Variables.UPTime_KioskNumber[i] == Variables.KioskNumberList[LocalKioskIndex]))
                                {
                                    TotalDownTimeMins   = TotalDownTimeMins + Variables.UPTime_DownTimeMins[i];
                                    TotalUpTimeMins     = TotalUpTimeMins + Variables.UPTime_UPTimeMins[i];
                                    
                                    string TempString = Variables.KioskNameList[LocalKioskIndex];

                                    ExcelworkSheet.Rows.Cells[XAsis, YAsis] = TempString; 

                                    ExcelworkSheet.Rows.Cells[XAsis, YAsis + 1] = Math.Round((100-((Convert.ToDouble(Variables.UPTime_DownTimeMins[i]) / Convert.ToDouble(Variables.UPTime_UPTimeMins[i]))*100)),2);

                                    ExcelworkSheet.Rows.Cells[XAsis, YAsis + 2] = Variables.UPTime_UPTimeMins[i];
                                    ExcelworkSheet.Rows.Cells[XAsis++, YAsis + 3] = Variables.UPTime_DownTimeMins[i];
                                }
                            }   
                        }
                        LocalKioskIndex++;
                    }

                    XAsis = XAsis + 3;
                    ExcelworkSheet.Rows.Cells[XAsis, YAsis + 1] =  Math.Round((100-((Convert.ToDouble(TotalDownTimeMins) / Convert.ToDouble(TotalUpTimeMins)) * 100)),2);
                    ExcelworkSheet.Rows.Cells[XAsis, YAsis] = "Totals";
                    ExcelworkSheet.Rows.Cells[XAsis, YAsis+2] = TotalUpTimeMins;
                    ExcelworkSheet.Rows.Cells[XAsis, YAsis+3] = TotalDownTimeMins;

                    TotalUpTimeMins     = 0;
                    TotalDownTimeMins   = 0;
                }

                string FileLocation =  "C:\\Fourex\\Fourex-Kiosk-Analytics\\FouexUpTime-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";
                string Subject = "Fourex AVE Uptime-> " + AVEUpTime + " % ->"+ DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

                ExcelApplication.Application.ActiveWorkbook.SaveAs(FileLocation);
                ExcelApplication.Application.Quit();
                ExcelApplication.Quit();

                Mail(FileLocation, Subject, "Bosy", SingleMailAddress);
            }
        }

        public static void Mail(string FileLocation, string Subject, string Body, string SingleMail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.inpd.co.za");

                mail.From = new MailAddress("francois.maritz@fourex.co.za");

                if (SingleMail == "")
                {
                    mail.To.Add("francois.maritz@quescom.co.za");
                    mail.To.Add("eugene.langeveldt@quescom.co.za");
                    mail.To.Add("Jane.Wade@coino.co.uk");
                    mail.To.Add("Georgi.Mitov@coino.co.uk");

                    DateTime date = DateTime.Now;

                    string dateToday = " " + date.ToString("d");
                    DayOfWeek day = DateTime.Now.DayOfWeek;
                    string dayToday = day.ToString();

                    if ((dayToday == "Monday"))
                    {
                        mail.To.Add("anthony.rice@coino.co.uk");
                        mail.To.Add("Oliver.DuToit@coino.co.uk");
                    }
                }
                else
                {                   
                    mail.To.Add(SingleMail);
                }

                mail.Subject = Subject;
          
                mail.Attachments.Add(new Attachment(FileLocation));

                mail.Body = "<< See attached Excel for Kiosk Uptime Statistics >>" + " " + Subject;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("fourex@inpd.co.za", "1nn0_Ques2018");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void MailAlert(string Subject)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.inpd.co.za");

                mail.From = new MailAddress("francois.maritz@fourex.co.za");

                mail.To.Add("francois.maritz.gm@gmail.com");
                mail.To.Add("eugene.langeveldt@quescom.co.za");
                mail.To.Add("craig.godfrey@quescom.co.za");

                mail.Subject = Subject;

                mail.Body = "<< Auto Alert Created >>" + " " + Subject;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("fourex@inpd.co.za", "1nn0_Ques2018");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }

}
