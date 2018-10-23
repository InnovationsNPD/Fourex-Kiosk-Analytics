using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Fourex_Kiosk_Analytics
{
   public partial class OnOffLine : Form
    {
        private void LoadSaveData()
        {
            string FourexConnectionString = "Server=localhost;Database=fourex;Uid=root;Pwd=maritz2580";

            MySqlDataReader reader = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            string ConnectionString = FourexConnectionString;
            con = new MySqlConnection(ConnectionString);

            string query = "SELECT * FROM fourex.errorlogs where Mail Like '%,Swicth,%' AND  KioskName = " + "'" + Variables.KioskNameList[Variables.KioskIndex] + "'" + "ORDER BY TxStamp desc Limit 1;";

            cmd = new MySqlCommand(query);
            cmd.Connection = con;

            int i = 0;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string[] SplitMail = null;

                    SplitMail = reader["Mail"].ToString().Split(',');

                    textBox_KioskName.Text = reader["KioskName"].ToString();
                    textBox_Reason.Text = SplitMail[4].ToString();
                    textBox_DateTime.Text = reader["TxStamp"].ToString();

                    if (SplitMail[2].ToString() == "On-Line")
                    {
                        checkBox_OnOffLine.Checked = true;
                    }
                    else 
                    {
                        checkBox_OnOffLine.Checked = false;
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

        public OnOffLine()
        {
            InitializeComponent();

            LoadSaveData();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (checkBox_OnOffLine.Checked == false)
            {
                Fourex_Kiosk_Analytics.Database.AddAlert(Variables.KioskNameList[Variables.KioskIndex], Variables.KioskNumberList[Variables.KioskIndex], "<<PROBLEM>>,Swicth,Off-Line,ErrorConsole," + textBox_NewReason.Text + ",", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),"","",0);
                Database.ChangeKioskStatus(Variables.KioskNumberList[Variables.KioskIndex], "OffLine");
            }
            else
            {
                Fourex_Kiosk_Analytics.Database.AddAlert(Variables.KioskNameList[Variables.KioskIndex], Variables.KioskNumberList[Variables.KioskIndex], "<<Alert>>,Swicth,On-Line,ErrorConsole," + textBox_NewReason.Text + ",", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),"","",0);
                Database.ChangeKioskStatus(Variables.KioskNumberList[Variables.KioskIndex], "Live");
            }

            Variables.TriggerOffLineListViewUpdate = true;

            this.Close();

        }
    }
}
