using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Web;
using System.Net;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using Microsoft.Office.Interop.Excel;

namespace Fourex_Kiosk_Analytics
{
    public partial class Form1 : Form
    {
        Int16 ReadCount = 0;

        string[] arr = new string[3];
        ListViewItem itm;

        ListViewItem itmRemNot;

        ListViewItem itmAlertKeyindicator; 

        int MailListViewUpdateTimer = 10;

       // string[] arrAlert = new string[2];
       // ListViewItem itmAlert;

        static System.IO.StreamWriter sw = null;
        static System.Net.Sockets.TcpClient tcpc = null;
        static System.Net.Security.SslStream ssl = null;
        static string username, password;
        static string path;
        static int bytes = -1;
        static byte[] buffer;
        static StringBuilder sb = new StringBuilder();
        static byte[] dummy;
         
        string Test = "";

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            listView_Main.View = View.Details;
            listView_Main.GridLines = true;
            listView_Main.FullRowSelect = true;

            listView_Main.Columns.Add("Time Stamp", 125);
            listView_Main.Columns.Add("Kiosk Name", 150);
            listView_Main.Columns.Add("Mail Message", 1200);

            listView_AlertCounts.View = View.Details;
            listView_AlertCounts.GridLines = true;
            listView_AlertCounts.FullRowSelect = false;

            listView_AlertCounts.Columns.Add("Kiosk Name", 140);
            listView_AlertCounts.Columns.Add("Count", 50);

            listView_OffLineKiosks.View = View.Details;
            listView_OffLineKiosks.GridLines = true;
            listView_OffLineKiosks.FullRowSelect = true;

            listView_AVE_7_Day.Columns.Add("Kiosk Name", 140);
            listView_AVE_7_Day.Columns.Add("AVE", 50);

            listView_AVE_7_Day.View = View.Details;
            listView_AVE_7_Day.GridLines = true;
            listView_AVE_7_Day.FullRowSelect = true;

            listView_Remedy.View = View.Details;
            listView_Remedy.GridLines = true;
            listView_Remedy.FullRowSelect = true;

            listView_Remedy.Columns.Add("Count", 45);
            listView_Remedy.Columns.Add("Col 1", 100);
            listView_Remedy.Columns.Add("Col 2", 100);
            listView_Remedy.Columns.Add("Col 3", 100);

            listView_Notification.View = View.Details;
            listView_Notification.GridLines = true;
            listView_Notification.FullRowSelect = true;

            listView_Notification.Columns.Add("Count", 45);
            listView_Notification.Columns.Add("Col 1", 100);
            listView_Notification.Columns.Add("Col 2", 100);
            listView_Notification.Columns.Add("Col 3", 100);

            listView_AlertsKeyIndicator.Columns.Add("Time Stamp", 120);
            listView_AlertsKeyIndicator.Columns.Add("Kiosk Name", 150);
            listView_AlertsKeyIndicator.Columns.Add("Progress",100);
            listView_AlertsKeyIndicator.Columns.Add("Hours", 40);
            listView_AlertsKeyIndicator.Columns.Add("Discription", 300);
            listView_AlertsKeyIndicator.Columns.Add("Number", 50);
            listView_AlertsKeyIndicator.Columns.Add("ID", 50);
            
            listView_AlertsKeyIndicator.View = View.Details;
            listView_AlertsKeyIndicator.GridLines = true;
            listView_AlertsKeyIndicator.FullRowSelect = true;

            radioButton_Date_Today.Checked = true;
            dateTimePicker_TimeStart.Format = DateTimePickerFormat.Time;
            dateTimePicker_TimeStart.ShowUpDown = true;
            dateTimePicker_TimeEnd.Format = DateTimePickerFormat.Time;
            dateTimePicker_TimeEnd.ShowUpDown = true;

            comboBox_UPTimeKioskSelect.Text = "All Kiosks";
            comboBox_KioskList.Text         = "All Kiosks";

            Database.LoadFromDBOffLineListView();
            PopulateOffLineListView();
            LoadAlertListView();
            UpdateRawLogsMainListView();
            PopulateAlertStatusComboBox();
            UpdateAlertKeyIndicators();

            button_Tread_ReadMails.Enabled              = false;
            button_Treads_AlertIndicator.Enabled        = false;
            button_Threads_OffLineIndicator.Enabled     = false;
            button_Treads_DownTime.Enabled              = false;

            button_Tread_ReadMails.BackColor            = Color.LightGreen;
            button_Treads_AlertIndicator.BackColor      = Color.LightGreen;
            button_Threads_OffLineIndicator.BackColor   = Color.LightGreen;
            button_Treads_DownTime.BackColor            = Color.LightGreen;
        }

        private void PopulateAlertStatusComboBox() 
        {
            Variables.AlertStatus[0] = "Auto";
            Variables.AlertStatus[1] = "Manual";
            Variables.AlertStatus[2] = "Support Attending";
            Variables.AlertStatus[3] = "Field Attending";
            Variables.AlertStatus[4] = "CPC Attending";
            Variables.AlertStatus[5] = "Complete";

            for (int i = 0; i < Variables.AlertStatusCount; i++)
            {
              //  comboBox_AlertStatus.Items.Add(Variables.AlertStatus[i]);
            }
        }

        private void UpdateAlertKeyIndicators()
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = @"SELECT * FROM fourex.errorlogs where Progress = 'Open' order by KioskName,ID,TxStamp;";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int AlertCounter = 0;

            int LineSpaceCounter = 0;
 
            listView_AlertsKeyIndicator.Items.Clear();

            for(int i=0; i<Variables.ListArraySize;i++)
            {
                Variables.AlertManager_KioskNumber[i]   = "";
                Variables.AlertManager_Status[i]        = "";
                Variables.AlertManager_Description[i]   = "";
            }

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string[] LocalArr = new string[7];

                    string[] SplitString = reader["Mail"].ToString().Split(',');

                    LocalArr[0] = TimeZone(reader["TxStamp"].ToString());
                    LocalArr[1] = reader["KioskName"].ToString();
                    LocalArr[2] = reader["Status"].ToString();

                    if ((LocalArr[2] == "Manual") || (LocalArr[2] == "Auto"))
                    {
                        DateTime NowTime = DateTime.Now;
                        DateTime StartTime = Convert.ToDateTime(reader["TxStamp"].ToString());

                        System.TimeSpan Diff = NowTime.Subtract(StartTime);

                        Int64 ElapseSec = Convert.ToInt64(Diff.TotalSeconds);

                        LocalArr[3] = Math.Round(Diff.TotalHours, 2).ToString();
                    }
                    else
                    {
                        LocalArr[3] = "----";
                    }

                    LocalArr[4] = SplitString[4].ToString();
                    LocalArr[5] = reader["KioskNumber"].ToString();
                    LocalArr[6] = reader["ID"].ToString();

                    //-- Load Memory to Check later in other Calls 
                    Variables.AlertManager_KioskNumber[AlertCounter]    = reader["KioskNumber"].ToString();
                    Variables.AlertManager_Status[AlertCounter]         = reader["Status"].ToString();
                    Variables.AlertManager_Description[AlertCounter]    = SplitString[4].ToString(); ;

                    AlertCounter++;

                    itmAlertKeyindicator = new ListViewItem(LocalArr);

                    if ((LocalArr[2] == "Manual")||(LocalArr[2] == "Auto"))
                    {
                       itmAlertKeyindicator.ForeColor = Color.Blue;

                       if (LineSpaceCounter>0)
                        listView_AlertsKeyIndicator.Items.Add("");

                       LineSpaceCounter++;
                    }

                    listView_AlertsKeyIndicator.Items.Add(itmAlertKeyindicator);
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
                MessageBox.Show("Error Reading Mail Field");
            }

        }

        private void PopulateOffLineListView()
        {
            string[] arrLocal = new string[3];
                 
            ListViewItem itmOffLine;

            groupBox_OffLineKiosk.Text = "Kiosk's in Maintenance Mode. Last Update..  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "  ";

            listView_OffLineKiosks.Items.Clear();

            for(int i=0;i<Variables.ListArraySize;i++)
            {
                System.Windows.Forms.Application.DoEvents();

                if (Variables.OffLineListKioskName[i] != null)
                {
                    DateTime NowTime = DateTime.Now;
                    DateTime StartTime = Convert.ToDateTime(Variables.OffLineListKioskDateTime[i].ToString());

                    System.TimeSpan Diff = NowTime.Subtract(StartTime);

                    Int64 ElapseSec = Convert.ToInt64(Diff.TotalSeconds);

                    arrLocal[0] = Variables.OffLineListKioskName[i];
                    arrLocal[1] = Math.Round(Diff.TotalHours,2).ToString();
                    arrLocal[2] = Variables.OffLineListKioskReason[i];

                    itmOffLine = new ListViewItem(arrLocal);
                    listView_OffLineKiosks.Items.Add(itmOffLine);

                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        private void ReadMails()
        {
            button_TriggerMail.Enabled = false;

            System.Net.WebClient objclient = new WebClient();

            string response = null;

            XmlDocument xdoc = new XmlDocument();

            XmlNode node = default(XmlNode);

            string Title = "";

           // if (checkBox_KioskFilter.Checked == false)
           // {
           //     listView_Main.Items.Clear();
           // }

            textBox_ProgressInfo.Text = "Open Gmail Account";

            try
            {
                objclient.Credentials = new System.Net.NetworkCredential("francois.maritz.gm@gmail.com", "Hayley2580");

                response = Encoding.UTF8.GetString(objclient.DownloadData("https://mail.google.com/mail/feed/atom/fourex"));

                response = response.Replace("<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\">", "<feed>");
               
                xdoc.LoadXml(response);

                node = xdoc.SelectSingleNode("/feed/fullcount");

                Variables.mailcount = Convert.ToInt16(node.InnerText);

                Int16 MailCount = 0;

                if (Variables.mailcount > 0)
                {
                    System.Windows.Forms.Application.DoEvents();

                    foreach (XmlNode node1 in xdoc.SelectNodes("feed/entry"))
                    {
                        System.Windows.Forms.Application.DoEvents();

                        Title = node1.SelectSingleNode("title").InnerText;

                        if (Title.IndexOf("Fourex") != -1)
                        {
                            textBox_ProgressInfo.Text = "Reading Mails " + MailCount++;

                            string KioskName = "";
                            string KioskNumber = "";
                            string Mail = "";

                            //-- Get Kiosk Name out n
                            int FindDash = Title.IndexOf("-");
                            int FindDashSmaller = Title.IndexOf("->");

                            Test = Title;

                            if(Title.IndexOf("0047") !=-1)
                            {
                                int ff = 778; 
                            }

                            if((FindDash>0)&&(FindDashSmaller>0))
                            {
                                KioskName = (Title.Substring(FindDash + 1, (FindDashSmaller - FindDash) - 1)).TrimStart();

                                if (Title.IndexOf("0") != -1)
                                {
                                    try
                                    {
                                        KioskNumber = KioskName.Substring(KioskName.IndexOf("0"), 4);
                                    }
                                    catch
                                    {
                                        KioskNumber = "0000";
                                    }
                                }
                                else
                                {
                                    KioskNumber = "0000";
                                }

                                Mail = (Title.Substring(FindDashSmaller + 2, (Title.Length - FindDashSmaller) - 2)).TrimStart();


                                //-- Remove Special Char

                                string NewMail = "";

                                for(int i = 0; i < Mail.Length; i++)
                                {
                                    if (Mail.Substring(i, 1) == "'")
                                    {
                                        int ff = 0; 
                                    }
                                    else
                                    {
                                        NewMail = NewMail + Mail.Substring(i, 1);
                                    }
                                }

                                Mail = "";
                                Mail = NewMail;

                                DateTime DateTimeTxStamp = Convert.ToDateTime(node1.SelectSingleNode("modified").InnerText);

                                string TxStamp = DateTimeTxStamp.ToString("yyyy-MM-dd H:mm:ss");

                                if (CheckForDuplicate(Mail, TxStamp) == false)
                                {
                                    Log(KioskName, KioskNumber, Mail, TxStamp);

                                    if (checkBox_KioskFilter.Checked == false)
                                    {
                                        
                                    }
                                }
                                else
                                {
                                  //  if (checkBox_KioskFilter.Checked == false)
                                  //  {
                                        //— Build string 

                                  //      string TempKioskName = KioskName.Substring(0,KioskName.Length).TrimStart();
                                      
                                  //      arr[0] = TxStamp;
                                  //      arr[1] = KioskName;
                                  //      arr[2] = Mail;
                                  //      itm = new ListViewItem(arr);
                                  //      listView_Main.Items.Add(itm);
                                  // }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reading Gmail Through the Error >>- " + ex.Message);
            }

            objclient.Dispose();

            textBox_ProgressInfo.Text = "Last Mail read. " + DateTime.Now +  " Done Reading Waiting.." ;

            button_TriggerMail.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadMails();
        }

        static public void Log(string KioskName, string KioskNumber, string Mail , string TxStamp)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlConnection connection = new MySqlConnection(FourexConnectionString);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO errorlogs (KioskName,KioskNumber,Mail,TxStamp)VALUES(@KioskName,@KioskNumber,@Mail,@TxStamp)";
                cmd.Parameters.AddWithValue("@TxStamp", TxStamp);
                cmd.Parameters.AddWithValue("@KioskName", KioskName);
                cmd.Parameters.AddWithValue("@KioskNumber", KioskNumber);
                cmd.Parameters.AddWithValue("@Mail", Mail);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Writing Log Error: ", ex.Message);
            }  
        }

        static public bool CheckForDuplicate (string Mail, string TxStamp)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);
            //string query = "SELECT * FROM `fourex`.`config` WHERE Tx";
            string query = "SELECT * FROM fourex.errorlogs where TxStamp = '" + TxStamp + "'" + " AND Mail = '" + Mail + "';";

            //string query = "SELECT * FROM fourex.errorlogs where TxStamp = '" + TxStamp + "';";
            
            
            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            bool FoundFlag = false;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FoundFlag = true;
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
                MessageBox.Show("Database Look for Dublicate Error", ex.Message);

                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }

            if (FoundFlag == true)

                return (true);
            else
                return (false);         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button_Tread_ReadMails.BackColor = Color.Red;
            System.Windows.Forms.Application.DoEvents();

            timer1.Enabled = false;
            ReadMails();
            PopMail();
            timer1.Enabled = true;

            System.Windows.Forms.Application.DoEvents();
            button_Tread_ReadMails.BackColor = Color.LightGreen;
        }

       private void LoadKioskComboList()
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);
         
            string query = "SELECT * FROM fourex.errorsetup Order By KioskName;";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int i = 0;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                comboBox_KioskList.Items.Add("All Kiosks");
                comboBox_UPTimeKioskSelect.Items.Add("All Kiosks");

                Variables.KioskNameList[i] = null;
                Variables.KioskNumberList[i] = null;
                i++;

                while (reader.Read())
                {
                    System.Windows.Forms.Application.DoEvents();

                    comboBox_KioskList.Items.Add(reader["KioskName"].ToString());
                    comboBox_UPTimeKioskSelect.Items.Add(reader["KioskName"].ToString());

                    Variables.KioskNameList[i]      = reader["KioskName"].ToString();
                    Variables.KioskNumberList[i]    = reader["KioskNumber"].ToString();
                    Variables.KioskStatus[i]        = reader["Status"].ToString();

                    DateTime StartSleep = Convert.ToDateTime(reader["StartSleep"].ToString());
                    Variables.KioskStartSleep[i] = StartSleep.ToString("HH:mm:ss");

                    DateTime StopSleep = Convert.ToDateTime(reader["StopSleep"].ToString());
                    Variables.KioskStopSleep[i] = StopSleep.ToString("HH:mm:ss");    

                    i++;
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
                MessageBox.Show("Error Reading Database", ex.Message);

                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadKioskComboList();
            Database.LoadSetup();
            UpdateUPTimeChart(0);
            Database.LoadPersistFileDetailsIntoDB();
            comboBox_KioskList.SelectedIndex            = 0;
            comboBox_UPTimeKioskSelect.SelectedIndex    = 0;
        }

        public void UpdateUPTimeChart(int Index)
        {
            groupBox_UPTime.Text = "Minute By Minute Uptime for Estate. Last Update " + DateTime.Now.ToShortTimeString() + "  ";

           // if(DateTime.Now>=) Setup Time to send email 

            Database.CalculateDownTime(Index,null,null);

            chart1.Series["Series1"].Points.Clear();

            chart1.Series["Series1"].IsVisibleInLegend = false;

            chart1.Series["Series1"].IsValueShownAsLabel = true;

            chart1.Series["Series2"].Points.Clear();

            chart1.Series["Series2"].IsVisibleInLegend = false;

            chart1.Series["Series2"].IsValueShownAsLabel = true;

            //-- Find Min Value to Set Chraph Low point

            double Value = Variables.UPTime_PerCentage[0];

            for (int i = 0; i < 7; i++)
            {
                if (Value > Variables.UPTime_PerCentage[i])
                {
                    Value = Variables.UPTime_PerCentage[i];
                }
            }

            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = Convert.ToInt16(Value-2);

            double FieldMMPer = 0.0; 

            if (Index == 0)
            {
                for (int i = 0; i < 7; i++)
                {                  
                    chart1.Series["Series1"].Points.AddXY(Variables.UPTime_DayName[i], Math.Round(Variables.UPTime_PerCentage[i], 2));
                    chart1.Series["Series2"].Points.AddXY(Variables.UPTime_DayName[i], Math.Round(Variables.UPTime_PerCentage__FieldMM[i], 2));
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    chart1.Series["Series2"].Points.AddXY(Variables.UPTime_DayName[i], Math.Round(Variables.UPTime_PerCentage[i], 2));
                    chart1.Series["Series2"].Points.AddXY(Variables.UPTime_DayName[i], Math.Round(Variables.UPTime_PerCentage__FieldMM[i], 2));
                }
            }

            chart1.Update();
        }

        private int CountChekeded()
        {
            int Count = 0;

           if(checkBox_Failures_BV.Checked == true)         Count++;
           if(checkBox_Failures_CD_GBP1.Checked == true)    Count++;
           if(checkBox_Failures_CD_GBP2.Checked == true)    Count++;
           if(checkBox_Failures_CD_EUR.Checked == true)     Count++;
           if(checkBox_Failures_CD_USD.Checked ==true)      Count++;
           if(checkBox_Failures_ND_GBP.Checked ==true)      Count++;
           if(checkBox_Failures_ND_EUR.Checked ==true)      Count++;
           if (checkBox_Failures_ND_USD.Checked == true)    Count++;

           return (Count);
        }

        private string SwitchCheckBoxes()
        {
            if ((checkBox_Failures_BV.Checked == true) ||
                (checkBox_Failures_CD_GBP1.Checked == true)||
                (checkBox_Failures_CD_GBP2.Checked == true)||
                (checkBox_Failures_CD_EUR.Checked == true)||
                (checkBox_Failures_CD_USD.Checked ==true)||
                (checkBox_Failures_ND_GBP.Checked ==true)||
                (checkBox_Failures_ND_EUR.Checked ==true)||
                (checkBox_Failures_ND_USD.Checked==true))

            {
                checkBox_Alerts.Checked         = false;
                checkBox_MMode.Checked          = false;
                checkBox_MModeON.Checked        = false;
                checkBox_NoteDispenser.Checked  = false;
                checkBox_Notification.Checked   = false;
                checkBox_Remedy.Checked         = false;
                checkBox_CoinDispenser.Checked  = false;

                return("HeartBeat");
            }

            return("Filter");
        }

        private string SQLSelect()
        {
             string SQLQ =  "";
             string CoinDispenser   = null;
             string NoteDispenser   = null;
             string Notification    = null;
             string Remedy          = null;
             string MMode           = null;
             string MModeON         = null; 
             string Alerts          = null;
             int ORCount = 0;
             int ANDCount = 0;
             int TickCount = 0;

             string Fail_BV         = null;
             string Fail_CD_GBP1    = null;
             string Fail_CD_GBP2    = null;
             string Fail_CD_EUR     = null;
             string Fail_CD_USD     = null;
             string Fail_ND_GBP     = null;
             string Fail_ND_EUR     = null;
             string Fail_ND_USD     = null;

            string FrontString = " AND ( ";
            string EndString = " ) ";
             // SELECT * FROM fourex.errorlogs where Mail Like '<<PROBLEMS>>%BV=Fail%' order by TxStamp desc;


             if (SwitchCheckBoxes() == "HeartBeat")
             {
                 if (checkBox_Failures_BV.Checked == true)
                 {
                     Fail_BV = "Mail Like '<<PROBLEMS>>%BV=Fail%'";
                 }

                 if (checkBox_Failures_CD_GBP1.Checked == true)
                 {
                     Fail_CD_GBP1 = "Mail Like '<<PROBLEMS>>%CD-GBP1=Fail%'";
                 }

                 if (checkBox_Failures_CD_GBP2.Checked == true)
                 {
                     Fail_CD_GBP2 = "Mail Like '<<PROBLEMS>>%CD-GBP2=Fail%'";
                 }

                 if (checkBox_Failures_CD_EUR.Checked == true)
                 {
                     Fail_CD_EUR = "Mail Like '<<PROBLEMS>>%CD-EUR=Fail%'"; 
                 }

                 if (checkBox_Failures_CD_USD.Checked == true)
                 {
                     Fail_CD_USD = "Mail Like '<<PROBLEMS>>%CD-USD=Fail%'"; 
                 }

                 //--- Note Dispensers  ---

                 if (checkBox_Failures_ND_GBP.Checked == true)
                 {
                     Fail_ND_GBP = "Mail Like '<<PROBLEMS>>%ND-GBP=Fail%'"; 
                 }

                 if (checkBox_Failures_ND_EUR.Checked == true)
                 {
                     Fail_ND_EUR = "Mail Like '<<PROBLEMS>>%ND-EUR=Fail%'";
                 }

                 if (checkBox_Failures_ND_USD.Checked == true)
                 {
                     Fail_ND_USD = "Mail Like '<<PROBLEMS>>%ND-USD=Fail%'";
                 }

                 SQLQ = FrontString;

                 int TickCoint = CountChekeded();

                 if(Fail_BV != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_BV;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_BV + " OR ";
                         TickCoint--;
                     }
                 }

                 if (Fail_CD_GBP1 != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_CD_GBP1;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_CD_GBP1 + " OR ";
                         TickCoint--;
                     }
                 }

                 if (Fail_CD_GBP2 != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_CD_GBP2;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_CD_GBP2 + " OR ";
                         TickCoint--;
                     }
                 }

                 if (Fail_CD_EUR != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_CD_EUR;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_CD_EUR + " OR ";
                         TickCoint--;
                     }
                 }

                 if (Fail_CD_USD != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_CD_USD;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_CD_USD + " OR ";
                         TickCoint--;
                     }
                 }

                 if (Fail_ND_GBP != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_ND_GBP;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_ND_GBP + " OR ";
                         TickCoint--;
                     }
                 }

                 if (Fail_ND_EUR != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_ND_EUR;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_ND_EUR + " OR ";
                         TickCoint--;
                     }
                 }

                 if (Fail_ND_USD != null)
                 {
                     if (TickCoint == 1)
                     {
                         SQLQ = SQLQ + Fail_ND_USD;
                     }
                     else
                     {
                         SQLQ = SQLQ + Fail_ND_USD + " OR ";
                         TickCoint--;
                     }
                 }


                 SQLQ = SQLQ + EndString;
             }
             else
             {

                 if (checkBox_CoinDispenser.Checked == true)
                 {
                     CoinDispenser = "Mail like '%CoinDi%'";
                     ANDCount++;
                 }

                 if (checkBox_Notification.Checked == true)
                 {
                     Notification = "Mail Like '%NOTIFICATION%'";
                     ANDCount++;
                 }

                 if (checkBox_Remedy.Checked == true)
                 {
                     Remedy = "Mail Like '%REMEDY%'";
                     ANDCount++;
                 }

                 if (checkBox_NoteDispenser.Checked == true)
                 {
                     NoteDispenser = "Mail Like '%NoteDispenser%'";
                     ANDCount++;
                 }

                 if (checkBox_MMode.Checked == true)
                 {
                     MMode = "Mail Like '%Maintenance%'";
                     ANDCount++;
                 }

                 if (checkBox_MModeON.Checked == true)
                 {
                     MModeON = "Mail Like '%Maintenance ON%'";
                     ANDCount++;
                 }

                 if (checkBox_Alerts.Checked == true)
                 {
                     Alerts = "Mail Like '<<Alert>>,%'";
                     ANDCount++;
                 }

                 //--------------------
                 //--- Complete qry ---
                 //--------------------

                 if (ANDCount > 0)
                 {
                     SQLQ = " AND (";
                 }

                 if (CoinDispenser != null)
                 {
                     SQLQ = SQLQ + CoinDispenser;

                     ORCount++;
                 }

                 if (NoteDispenser != null)
                 {
                     if (ORCount > 0)
                     {
                         SQLQ = SQLQ + " OR " + NoteDispenser;
                     }
                     else
                     {
                         SQLQ = SQLQ + NoteDispenser;
                         ORCount++;
                     }
                 }

                 if (Notification != null)
                 {
                     if (ORCount > 0)
                     {
                         SQLQ = SQLQ + " OR " + Notification;
                     }
                     else
                     {
                         SQLQ = SQLQ + Notification;
                         ORCount++;
                     }
                 }

                 if (Remedy != null)
                 {
                     if (ORCount > 0)
                     {
                         SQLQ = SQLQ + " OR " + Remedy;
                     }
                     else
                     {
                         SQLQ = SQLQ + Remedy;
                         ORCount++;
                     }
                 }

                 if (MMode != null)
                 {
                     if (ORCount > 0)
                     {
                         SQLQ = SQLQ + " OR " + MMode;
                     }
                     else
                     {
                         SQLQ = SQLQ + MMode;
                         ORCount++;
                     }
                 }

                 if (MModeON != null)
                 {
                     if (ORCount > 0)
                     {
                         SQLQ = SQLQ + " OR " + MModeON;
                     }
                     else
                     {
                         SQLQ = SQLQ + MModeON;
                         ORCount++;
                     }
                 }

                 if (Alerts != null)
                 {
                     if (ORCount > 0)
                     {
                         SQLQ = SQLQ + " OR " + Alerts;
                     }
                     else
                     {
                         SQLQ = SQLQ + Alerts;
                         ORCount++;
                     }
                 }

                 if (ANDCount > 0)
                 {
                     SQLQ = SQLQ + ")";
                 }

             }

            return (SQLQ);
        }

        public string TimeZone(string DateTimeString)
        {
            DateTime LocalDateTime = Convert.ToDateTime(DateTimeString);

            string DateString =  LocalDateTime.AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss");

            return (DateString);
        }

        private void DoLookDBUp()
        {
            textBox_ProgressInfo.Text = "Please Wait Running Database Qry..";
         
            Cursor.Current = Cursors.WaitCursor;

            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "SELECT * FROM fourex.errorlogs WHERE KioskNumber = " + "'" + Variables.KioskNumberList[Variables.KioskIndex] + "'" + " order by TxStamp desc;" + ";";
            
            string KioskNumber = @"KioskNumber = " + "'" + Variables.KioskNumberList[Variables.KioskIndex]+ "'";

            string rr = Convert.ToDateTime(DateTime.Today).ToString("yyyy-MM-dd HH:mm:ss");
            string ff = Convert.ToString(Convert.ToDateTime(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")));

            string CustomStartDate  = dateTimePicker_DateStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string CustomStartTime  = dateTimePicker_TimeStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string CustomEndDate    = dateTimePicker_DateEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string CustomEndTime    = dateTimePicker_TimeEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
 
            string StringStartTime  = "'" + String.Format("{0:yyyy/mm/dd 00:00:00}", rr) + "'";
            string StringEndTime    = "'" + String.Format("{0:yyyy/mm/dd 00:00:00}", rr) + "'";
            string StringYesterday  = "'" + String.Format("{0:yyyy/mm/dd 00:00:00}", ff) + "'";

            // string DateString = DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd HH:mm:ss");

            StringEndTime =  "'" + StringEndTime.Substring(12,7)    + "23:59:59"        + "'";
            
            string StartDT = "'" + CustomStartDate.Substring(0, 10) + " " + CustomStartTime.Substring(11,8)   + "'";
            string EndDT = "'" + CustomEndDate.Substring(0, 10) + " " + CustomEndTime.Substring(11, 8) + "'";

            if (radioButton_DateAll.Checked == true)
            {
                if (Variables.KioskIndex == 0)
                {                
                    query = "SELECT * FROM fourex.errorlogs WHERE " + SQLSelect() + " order by TxStamp desc;" + ";";

                     // Need to remove the AND out of the SQL 
                   // string hh = query.Substring(query.IndexOf("AND"), 3); 
                }
                else
                {
                    query = "SELECT * FROM fourex.errorlogs WHERE " + KioskNumber + SQLSelect() + " order by TxStamp desc;" + ";";
                }
            }

            if (radioButton_Date_Today.Checked == true)
            {
                if (Variables.KioskIndex == 0)
                {
                    query = "SELECT * FROM fourex.errorlogs WHERE TxStamp >= " + StringStartTime + SQLSelect() + " order by TxStamp desc;" + ";";
                }
                else
                {
                    query = "SELECT * FROM fourex.errorlogs WHERE " + KioskNumber + "AND" + " TxStamp >= " + StringStartTime + SQLSelect() + " order by TxStamp desc;" + ";";
                }
            }

            if (radioButton_FromYesterday.Checked == true)

                if (Variables.KioskIndex == 0)
                {
                    query = "SELECT * FROM fourex.errorlogs WHERE TxStamp >= " + StringYesterday + SQLSelect() + " order by TxStamp desc;";
                }
                else
                {
                    query = "SELECT * FROM fourex.errorlogs WHERE " + KioskNumber + "AND" + " TxStamp >= " + StringYesterday + SQLSelect() + " order by TxStamp desc;";
                }

            if (radioButton_Custom.Checked == true)
            {
                if (Variables.KioskIndex == 0)
                {    
                    query = "SELECT * FROM fourex.errorlogs WHERE TxStamp >= " + StartDT + " AND " + " TXStamp <= " + EndDT + SQLSelect() + " order by TxStamp desc;";
                }
                else
                {
                    query = "SELECT * FROM fourex.errorlogs WHERE " + KioskNumber + "AND" + " TxStamp >= " + StartDT + " AND " + " TXStamp <= " + EndDT + SQLSelect() + " order by TxStamp desc;";
                }
            }

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int i = 0;

            listView_Main.Items.Clear();

            int DoEventCounterSet = 50;
            int DoEventCounter = DoEventCounterSet;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    if (DoEventCounter == 0)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        DoEventCounter = DoEventCounterSet;
                    }

                    DoEventCounter--;

                    arr[0] = TimeZone(reader["TxStamp"].ToString());
                    arr[1] = reader["KioskName"].ToString();
                    arr[2] = reader["Mail"].ToString();
                    itm = new ListViewItem(arr);
                    listView_Main.Items.Add(itm);

                    i++;
                }

               // MessageBox.Show("Done DB Load");

                System.Windows.Forms.Application.DoEvents();

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
               // MessageBox.Show("Database Look for Dublicate Error", ex.Message);

                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
            textBox_ProgressInfo.Text ="Completed Running Database Qry..";

            Cursor.Current = Cursors.Default;
        }

        private void comboBox_KioskList_SelectedIndexChanged(object sender, EventArgs e)
        {
           Variables.KioskIndex = Convert.ToInt16(comboBox_KioskList.SelectedIndex);
           DoLookDBUp(); 
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_ListView.Text = listView_Main.SelectedItems[0].SubItems[0].Text + " " + listView_Main.SelectedItems[0].SubItems[1].Text + " " + listView_Main.SelectedItems[0].SubItems[2].Text;

                listView_Main.Refresh();
            }
            catch
            {}   
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            DoLookDBUp(); 
        }

        public static string CheckKioskStatus(string KioskNumber)
        {
            string KioksStatus = null;

            for (int i = 0; i< Variables.ListArraySize;i++)
            {
                if(KioskNumber==Variables.KioskNumberList[i])
                {
                    KioksStatus = Variables.KioskStatus[i];
                }
            }

            return (KioksStatus);
        }

        private void LoadAlertListView()
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string DateString = DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd HH:mm:ss");

            string query = @"SELECT KioskName, KioskNumber, COUNT(*) FROM fourex.errorlogs WHERE TxStamp >= '" + DateString + "' GROUP BY KioskNumber order by COUNT(*) desc";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int i = 0;

            groupBox_Alert.Text = "(Last 24 Hours Alerts) Last Update.. " + DateTime.Now.ToShortTimeString() + "  ";

            listView_AlertCounts.Items.Clear();

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //comboBox_KioskList.Items.Add(reader["KioskName"].ToString());
                    string tt = reader["KioskName"].ToString();
                    string gg = reader["KioskNumber"].ToString();
                    string hh = reader["COUNT(*)"].ToString();

                    int KoiskNumber = Convert.ToInt16(gg);
                    int AlertCount = Convert.ToInt16(hh);

                    if (CheckKioskStatus(gg) == "Live")
                    {
                        string[] arrAlert = new string[2];

                        arrAlert[0] = tt;

                        arrAlert[1] = hh;

                        Variables.AlertListKioskCount[KoiskNumber] = AlertCount; 

                        ListViewItem itmAlert;

                        listView_AlertCounts.Refresh();

                        itmAlert = new ListViewItem(arrAlert);

                        if ((Convert.ToInt16(hh) > 50))
                            itmAlert.ForeColor = Color.Red;

                        if (((Convert.ToInt16(hh) < 50)) && ((Convert.ToInt16(hh) > 20)))
                            itmAlert.ForeColor = Color.Orange;

                        if (((Convert.ToInt16(hh) <= 50)) && ((Convert.ToInt16(hh) > 20)))
                            itmAlert.ForeColor = Color.Orange;

                        if (((Convert.ToInt16(hh) <= 20)))
                            itmAlert.ForeColor = Color.Green;

                        listView_AlertCounts.Items.Add(itmAlert);
                    }
                    i++;
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

        private void timer2_Tick(object sender, EventArgs e)
        {

            LoadAlertListView();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button_OnOffLine_Click(object sender, EventArgs e)
        {
            OnOffLine OnOffLineForm = new OnOffLine();

            if (Variables.KioskIndex == 0)
            {
                MessageBox.Show("Select Kioks Before proceeding.");
                OnOffLineForm.Close();
                return;
            }
            
             OnOffLineForm.Show();          
        }

        public void OffLineListViewUpdate_Tick(object sender, EventArgs e)
        {
            button_Threads_OffLineIndicator.BackColor = Color.Red;
            System.Windows.Forms.Application.DoEvents();

            Database.LoadFromDBOffLineListView();
            PopulateOffLineListView();

            System.Windows.Forms.Application.DoEvents();
            button_Threads_OffLineIndicator.BackColor = Color.LightGreen;
        }

        private void MainHouseKeeping_Tick(object sender, EventArgs e)
        {
            button_Treads_AlertIndicator.BackColor = Color.Red;

            System.Windows.Forms.Application.DoEvents();

            if (Variables.AlertManagerScreenUpdate == true)
            {
                UpdateAlertKeyIndicators();  
                Variables.AlertManagerScreenUpdate = false;
            }

            button_Treads_AlertIndicator.BackColor = Color.LightGreen;
            System.Windows.Forms.Application.DoEvents();

            AutoMailTrigger();

        }

        private void POPMail_Tick(object sender, EventArgs e)
        {
          
        }

        private void UpdateRawLogsMainListView()
        {

            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "SELECT * FROM fourex.errorlogs Order By TxStamp desc LIMIT 25";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int i = 0;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                listView_Main.Items.Clear();

                while (reader.Read())
                {
                    if (checkBox_KioskFilter.Checked == false)
                    {
                        //— Build string 

                        //string TempKioskName = KioskName.Substring(0, KioskName.Length).TrimStart();

                        string TempKioksName = reader["KioskName"].ToString().Substring(0, reader["KioskName"].ToString().Length).TrimStart();

                        arr[0] = TimeZone(reader["TxStamp"].ToString());
                        arr[1] = reader["KioskName"].ToString();
                        arr[2] = reader["Mail"].ToString();
                        itm = new ListViewItem(arr);
                        listView_Main.Items.Add(itm);
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
                MessageBox.Show("Error Reading Database", ex.Message);

                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
           }
        }

        private void checkBox_KioskFilter_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_KioskFilter.Checked == false)
                MailListViewUpdateTimer = 1 ;

            textBox_ImportStatus.Text = "" + Variables.ImportCount;
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (Variables.TriggerOffLineListViewUpdate == true)
            {
                Variables.TriggerOffLineListViewUpdate = false;
                Database.LoadFromDBOffLineListView();
                PopulateOffLineListView();
                DoLookDBUp();
            }

            MailListViewUpdateTimer--;

            if ((MailListViewUpdateTimer == 0) && (checkBox_KioskFilter.Checked == false))
            {
                UpdateRawLogsMainListView();
                MailListViewUpdateTimer = 10;
            }

            textBox_POPMail.Text = Variables.POPMailResponse;
        }

        public static Decimal ExtractDecimalFromString(string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str.Where(c => c == '.' || Char.IsDigit(c)))
            {
                sb.Append(c);
            }
            return Convert.ToDecimal(sb.ToString());
        }

        private void PopulateMailIntopDB(string MailMessage)
        {
            if (MailMessage.IndexOf("Fourex") != -1)
            {
                string KioskName = "";
                string KioskNumber = "";
                string Mail = "";

                //-- Get Kiosk Name out n
                int FindDash = MailMessage.IndexOf("-");
                int FindDashSmaller = MailMessage.IndexOf("->");

                // Test = MailMessage ;

                if (MailMessage.IndexOf("0047") != -1)
                {
                    int ff = 778;
                }

                if ((FindDash > 0) && (FindDashSmaller > 0))
                {
                    KioskName = (MailMessage.Substring(FindDash + 1, (FindDashSmaller - FindDash) - 1)).TrimStart();

                    if (MailMessage.IndexOf("0") != -1)
                    {
                        try
                        {
                            KioskNumber = KioskName.Substring(KioskName.IndexOf("0"), 4);
                        }
                        catch
                        {
                            KioskNumber = "0000";
                        }
                    }
                    else
                    {
                        KioskNumber = "0000";
                    }

                    Mail = (MailMessage.Substring(FindDashSmaller + 2, (MailMessage.Length - FindDashSmaller) - 2)).TrimStart();

                    //-- Remove Special Char

                    string NewMail = "";

                    for (int i = 0; i < Mail.Length; i++)
                    {
                        if (Mail.Substring(i, 1) == "'")
                        {
                            int ff = 0;
                        }
                        else
                        {
                            NewMail = NewMail + Mail.Substring(i, 1);
                        }
                    }

                    Mail = "";
                    Mail = NewMail;

                    DateTime DateTimeTxStamp = DateTime.Now;
                   
                    string TxStamp = DateTimeTxStamp.ToString("yyyy-MM-dd H:mm:ss");
                    Log(KioskName, KioskNumber, Mail, TxStamp);
                }
            }
        }

        private void PopMail()
        {
            Decimal MailCount = 0;
    
            try

            {           
                Variables.POPMailResponse = "Last Read.. " + DateTime.Now.ToString();

                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect("pop.inpd.co.za", 110);

                NetworkStream netStream = tcpClient.GetStream();
                System.IO.StreamReader strReader = new System.IO.StreamReader(netStream);
                string lit_Status;
                lit_Status = strReader.ReadLine() + "<br />";

                byte[] WriteBuffer = new byte[1024];
                ASCIIEncoding enc = new System.Text.ASCIIEncoding();

                WriteBuffer = enc.GetBytes("USER " + Variables.Setup_EmailAddress01 + "\r\n");
                netStream.Write(WriteBuffer, 0, WriteBuffer.Length);
                lit_Status += strReader.ReadLine() + "<br />";

                WriteBuffer = enc.GetBytes("PASS " + Variables.Setup_Password01 + "\r\n");
                netStream.Write(WriteBuffer, 0, WriteBuffer.Length);
                lit_Status += strReader.ReadLine() + "<br />";

                System.Windows.Forms.Application.DoEvents();

                //--- List Message count ---

                WriteBuffer = enc.GetBytes("LIST\r\n");
                netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                String ListMessage;
                int FirstLine = 0;
                int LocalMessArraySize = 1000;
                string[] MessArray = new string[LocalMessArraySize];
                int ArrayPointer = 0;

                ListMessage = "";
                
                while (true)
                {
                    System.Windows.Forms.Application.DoEvents();

                    ListMessage = strReader.ReadLine();

                    if (FirstLine == 0)
                    {
                        MailCount = ExtractDecimalFromString(ListMessage);
                        FirstLine++;
                    }

                    MessArray[ArrayPointer++] = ListMessage;

                    if (ListMessage == ".")
                    {
                        break;
                    }
                    else
                    {
                        lit_Status += ListMessage + "<br />";
                    }
                }

                //--- Read Message 1 ---

                for (int k = 1; k <= MailCount; k++)
                {
                    for (int z = 0; z < LocalMessArraySize; z++)
                    {
                        MessArray[z] = null;
                    }

                    WriteBuffer = enc.GetBytes("RETR " + k.ToString() + "\r\n");
                    netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                    ListMessage = "";

                    int ArrayTempPointer = 0;

                    while (true)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        
                        ListMessage = strReader.ReadLine();

                        MessArray[ArrayTempPointer++] = ListMessage;

                        if (ListMessage == ".")
                        {
                            break;
                        }
                        else
                        {
                            lit_Status += ListMessage + "<br />";
                        }
                    }

                    //  get Message out 

                    string MailSubject = "";
                    bool FoundSubjectFlag = false;
                    int j = 0;

                    while (MessArray[j] != null)
                    {
                        if (FoundSubjectFlag == true)
                        {
                            if (((MessArray[j].IndexOf("Content-Type:") != -1)) || (MessArray[j].IndexOf("Message-Id") != -1))
                            {
                                FoundSubjectFlag = false;
                            }
                            else
                            {
                                MailSubject = MailSubject + MessArray[j];
                            }
                        }

                        if ((MessArray[j].IndexOf("Subject") != -1))
                        {
                            MailSubject = MessArray[j];
                            FoundSubjectFlag = true;
                        }
                        j++;
                    }

                    PopulateMailIntopDB(MailSubject);

                    Variables.POPMailResponse = MailSubject;

                    WriteBuffer = enc.GetBytes("DELE " + k.ToString() + "\r\n");
                    netStream.Write(WriteBuffer, 0, WriteBuffer.Length);

                    ListMessage = strReader.ReadLine();
                    lit_Status += ListMessage + "<br />";
                }
                string mess = lit_Status;

                WriteBuffer = enc.GetBytes("QUIT\r\n");
                netStream.Write(WriteBuffer, 0, WriteBuffer.Length);
                lit_Status += strReader.ReadLine() + "<br />";

            }
            catch (Exception ex)
            {
                Variables.POPMailResponse = " TCP Client Read Error";
            }
        }

        private void RunImportProcess()
        {
            button_InportREMNOT.Enabled = false;
            Database.ImportRemedyNotification();
            button_InportREMNOT.Enabled = true;

            //MessageBox.Show("Imported " + Variables.ImportCount + " Records");

            textBox_ImportStatus.Text = Variables.ImportCount.ToString();      
        }

        private void button_InportREMNOT_Click(object sender, EventArgs e)
        {
            RunImportProcess();
        }

        private void UpdateRemedyListView(string Type)
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "";

            //string rr = Convert.ToDateTime(DateTime.Today).ToString();
            string DateFilter = Convert.ToString(Convert.ToDateTime(DateTime.Today.AddDays(-7).ToString()));


            groupBox_Notification.Text  = "Notification's (Last 7 Days). Last Update..  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "  ";
            groupBox_Remedy.Text = "Remedy's (Last 7 Days). Last Update..  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "  ";

            if (Type == "REMEDY")
            {
               query = "SELECT Type, Field01, Field02, Field03, COUNT(*) FROM fourex.errorlogs " +
                                "WHERE TxStamp >= '" + DateFilter +  "' AND Type = 'REMEDY' " +
                                "GROUP BY Field01,Field02,Field03 order by COUNT(*) desc;";
            }

            if (Type == "NOTIFICATION")
            {
                query = "SELECT Type, Field01, Field02, Field03, COUNT(*) FROM fourex.errorlogs " +
                                 "WHERE TxStamp >= '" + DateFilter + "' AND Type = 'NOTIFICATION' " +
                                 "GROUP BY Field01,Field02,Field03 order by COUNT(*) desc;";
            }

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            string[] arrRemedy = new string[4];

            ListViewItem itmRemedy;
            ListViewItem itmNotification;

            if (Type == "NOTIFICATION")
            {
                listView_Notification.Refresh();
            }

            if (Type == "REMEDY")
            {
                listView_Remedy.Refresh();
            }
            
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    arrRemedy[0] = reader["COUNT(*)"].ToString();
                    arrRemedy[1] = reader["Field01"].ToString();
                    arrRemedy[2] = reader["Field02"].ToString();
                    arrRemedy[3] = reader["Field03"].ToString();

                    if (Type == "REMEDY")
                    {
                        itmRemedy = new ListViewItem(arrRemedy);
                        listView_Remedy.Items.Add(itmRemedy);
                    }

                    if (Type == "NOTIFICATION")
                    {
                        itmNotification = new ListViewItem(arrRemedy);
                        listView_Notification.Items.Add(itmNotification);
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
                MessageBox.Show("Error Reading Database", ex.Message);

                cmd.Connection.Close();
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }
        }

        private void button_UpdateRemNot_Click(object sender, EventArgs e)
        {
            UpdateRemedyListView("REMEDY");

            UpdateRemedyListView("NOTIFICATION");
        }

        private void timer_updateListView_Rem_Not_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();

            RunImportProcess();

            System.Windows.Forms.Application.DoEvents();

            UpdateRemedyListView("REMEDY");

            System.Windows.Forms.Application.DoEvents();

            UpdateRemedyListView("NOTIFICATION");

            System.Windows.Forms.Application.DoEvents();

            UpdateAlertKeyIndicators();

            System.Windows.Forms.Application.DoEvents();

            RunAutoAlertManager();
        }

        private void button_MaunualAlrest_Click(object sender, EventArgs e)
        {
            Variables.AlertManagerAction = "Create";

            ManualAlert ManualAlertForm = new ManualAlert();

            if ((Variables.KioskIndex == 0)&&(Variables.AlertManagerAction=="Create"))
            {
                MessageBox.Show("Select Kioks Before proceeding.");
                ManualAlertForm.Close();
            }
            else
            {
              
                ManualAlertForm.Show();
            }
        }

        private void contextMenuStrip_AlertManager_Opening(object sender, CancelEventArgs e)
        {

            Variables.AlertManagerAction = "Add";

            try
            {
                if (listView_AlertsKeyIndicator.SelectedItems[0].SubItems[2].Text != "")
                {
                    Variables.AlertManagerKioskName = listView_AlertsKeyIndicator.SelectedItems[0].SubItems[1].Text.ToString();
                    Variables.AlertManagerKioskNumber = listView_AlertsKeyIndicator.SelectedItems[0].SubItems[5].Text.ToString(); 

                    Variables.AlertID = Convert.ToDecimal(listView_AlertsKeyIndicator.SelectedItems[0].SubItems[6].Text.ToString()); 

                    ManualAlert ManualAlertForm = new ManualAlert();

                    if ((Variables.KioskIndex == 0)&&(Variables.AlertManagerAction=="Create"))
                    {
                        MessageBox.Show("Select Kioks Before proceeding.");
                        ManualAlertForm.Close();
                    }
                    else
                    {         
                        ManualAlertForm.Show();
                    }
                }
            }
            catch 
            { 
            }
        }

        private void RunAutoAlertManager()
        {
            groupBox_AlertManager.Text = "Check Alert to be activated."; 

            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("Hopper Coin Jam<-->Hopper Coin Jam%",                        "EC(0001)", "Coin Jam Detection Activated");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("<< PROBLEM Sec PCB >> Periferial Interface Down%",           "EC(0002)", "Periferial Interface Down");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("%<<PROBLEMS>> BV=%",                                         "EC(0003)", "Heartbeat Failure");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("<< PROBLEM Sec PCB >> Hopper Console Interface Down%",       "EC(0004)", "Hopper Console Down");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("<<Fail>>NoteDispenser%",                                     "EC(0005)", "Note Dispenser Failed to Payout"); 
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("Kill Hopper Threads",                                        "EC(0006)", "Hopper Console Down");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("<< PROBLEM Sec PCB >> UI Interface Down%",                   "EC(0007)", "UI Interface Down");
            System.Windows.Forms.Application.DoEvents();        
            Database.AutoAlertManager("<<Fail>>CoinDispenser%",                                     "EC(0008)", "Coin Dispenser Failed to payout");
            System.Windows.Forms.Application.DoEvents();        
            Database.AutoAlertManager("<< PROBLEM Sec PCB >>,PersistError%",                        "EC(0009)", "Persist File Corrupt");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("<< PROBLEM Security PCB >>,IPError,%",                       "EC(0010)","Security PCB IP Error");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("<< PROBLEM Security PCB >>, <<--UNAUTHORISED ACCESS-->>%",   "EC(0011)", "Unauthorized Access");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("%Search for suitable coins fail%",                           "EC(0012)", "Suitable coins fail");
            System.Windows.Forms.Application.DoEvents();
            Database.AutoAlertManager("<<High Value Transaction%",                                  "EC(0013)", "High Value Transaction");

            groupBox_AlertManager.Text = "Check Alert done. Last Update.. " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + " "; 
        }

        private void AutoMailTrigger()
        {
            DateTime CurrentTime = DateTime.Now;

            if ((CurrentTime >= (Convert.ToDateTime("06:00:00"))) && (CurrentTime <= (Convert.ToDateTime("06:00:10"))))
            {
                AutoDialyMail();
            }
        }

        private void AutoDialyMail()
        {
            button_SendMail.Enabled = false;
            button_SendMail.Text = "Wait Please Sending Mail..";
            button_Treads_DownTime.BackColor = Color.Red;

            System.Windows.Forms.Application.DoEvents();

            Database.CalculateDownTime(0, "Excel", textBox_MailAddress.Text);

            UpdateAVE7ListView();
            button_Treads_DownTime.BackColor = Color.LightGreen;
            button_SendMail.Text = "Send Mail";
            button_SendMail.Enabled = true;
            textBox_MailAddress.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AutoDialyMail();
        }

        private void checkBox_Failures_BV_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
        }

        private void checkBox_Failures_CD_GBP1_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
        }

        private void checkBox_Failures_CD_GBP2_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
        }

        private void checkBox_Failures_CD_EUR_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
        }

        private void checkBox_Failures_CD_USD_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
        }

        private void checkBox_Failures_ND_GBP_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
        }

        private void checkBox_Failures_ND_EUR_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
        }

        private void checkBox_Failures_ND_USD_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBoxes();
            
        }

        private void comboBox_UPTimeKioskSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_UPTimeKioskSelect.SelectedIndex >= 0)
            {
                timer_UPTimeUpdate.Interval = 60000;

                button_Treads_DownTime.BackColor = Color.Red;
                System.Windows.Forms.Application.DoEvents();

                UpdateUPTimeChart(comboBox_UPTimeKioskSelect.SelectedIndex);

                button_Treads_DownTime.BackColor = Color.LightGreen;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void timer_UPTimeUpdate_Tick(object sender, EventArgs e)
        {
            comboBox_UPTimeKioskSelect.SelectedIndex = 0;

            UpdateUPTimeChart(comboBox_UPTimeKioskSelect.SelectedIndex);

            UpdateAVE7ListView();

            timer_UPTimeUpdate.Interval = 300000;
        }

        private void button_KioskAVE_UPTime_Click(object sender, EventArgs e)
        {
            OnOffLine OnOffLineForm = new OnOffLine();

            KiosksGUPTime KioskUPTime = new KiosksGUPTime();

            KioskUPTime.Show();
        }

        private void UpdateAVE7ListView()
        {
            int TotalKioslCount = 0;
            int Below100Persent = 0;
            double TotalAVE     = 0;

            listView_AVE_7_Day.Items.Clear();

            for (int i = 0; i < Variables.ListArraySize; i++)
            {
                if (Variables.UPTime_AVG_KioskNumber[i] != null)
                {
                    string[] arrAVE = new string[2];

                    arrAVE[0] = Variables.UPTime_AVG_KioskName[i];

                    //-- Cal Ave now 

                    double tt = (100-((Variables.UPTime_AVG_Kiosk_DownTime[i] / Variables.UPTime_AVG_Kioks_UPTime[i]) * 100));

                    double RoundVal = Math.Round(tt,2);

                    arrAVE[1] = Convert.ToString(RoundVal);

                    ListViewItem itmAVE;

                    listView_AVE_7_Day.Refresh();

                    itmAVE = new ListViewItem(arrAVE);

                    if (RoundVal < 98.00)
                        itmAVE.ForeColor = Color.Red;

                    if((RoundVal<=99.00)&&(RoundVal>=98.00))
                        itmAVE.ForeColor = Color.Orange;

                    if(RoundVal == 100.00)
                        itmAVE.ForeColor = Color.Green;

                    TotalKioslCount++;

                    TotalAVE = TotalAVE + RoundVal;

                    if(RoundVal<100.00)
                        Below100Persent++;

                    listView_AVE_7_Day.Items.Add(itmAVE);
                }
            }

          //  double AVEKiosk7Days =(100- (Convert.ToDouble(Below100Persent) / Convert.ToDouble(TotalKioslCount) * 100));

            groupBox_KioskAVEUPTime.Text = "Last 7 Days AVE UpTime " + Math.Round(TotalAVE/TotalKioslCount,2) + "% " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "  ";
        }

        private void AppendExcelTemplate()
        {
            string ExcelPath = @"C:\Fourex\Fourex-Kiosk-Analytics\FouexUpTimeTemplate.xlsx";

            Microsoft.Office.Interop.Excel.Application ExcelApplication = new Microsoft.Office.Interop.Excel.Application();

            Workbook ExcelworkBook = ExcelApplication.Workbooks.Open(ExcelPath);

            Worksheet ExcelworkSheet = ExcelworkBook.Worksheets.Item[2] as Worksheet;

            ExcelworkSheet.Rows.Cells[1, 1] = "Test";

            ExcelApplication.Application.ActiveWorkbook.SaveAs(@"C:\Fourex\Fourex-Kiosk-Analytics\FouexUpTime2018-11-01-01.xlsx");
            ExcelApplication.Application.Quit();
            ExcelApplication.Quit();
     
        }

        private void button_Treads_DownTime_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
