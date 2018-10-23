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
    public partial class ManualAlert : Form
    {
        public ManualAlert()
        {
            InitializeComponent();

            if (Variables.AlertManagerAction == "Create")
            {
                textBox_KioskName.Text = Variables.KioskNameList[Variables.KioskIndex];
            }

            if (Variables.AlertManagerAction == "Add")
            {
                textBox_KioskName.Text = Variables.AlertManagerKioskName; 
            }

            for (int i = 0; i < Variables.AlertStatusCount; i++)
            {
                comboBox_StatusSelect.Items.Add(Variables.AlertStatus[i]);
            }

            if (Variables.AlertManagerAction == "Create")
            {
                comboBox_StatusSelect.Enabled = false;
                comboBox_StatusSelect.SelectedIndex = 1;
            }
            else
            {
                comboBox_StatusSelect.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox_StatusSelect.SelectedIndex > 1)||(Variables.AlertManagerAction=="Create"))
            {

                if (Variables.AlertManagerAction == "Create")
                {
                    Fourex_Kiosk_Analytics.Database.AddAlert(Variables.KioskNameList[Variables.KioskIndex], Variables.KioskNumberList[Variables.KioskIndex], "<<Alert>>,ManualMode,CreateAlert,ErrorConsole," + textBox_Discription.Text + ",", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Variables.AlertStatus[comboBox_StatusSelect.SelectedIndex], "Open", DateTime.Now.Ticks);
                }

                if (Variables.AlertManagerAction == "Add")
                {
                    Fourex_Kiosk_Analytics.Database.AddAlert(Variables.AlertManagerKioskName, Variables.AlertManagerKioskNumber, "<<Alert>>,InProgress,CreateAlert,ErrorConsole," + textBox_Discription.Text + "," + Variables.AlertStatus[comboBox_StatusSelect.SelectedIndex] + ',', DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Variables.AlertStatus[comboBox_StatusSelect.SelectedIndex], "Open", Variables.AlertID);
                }

                if (Variables.AlertStatus[comboBox_StatusSelect.SelectedIndex] == "Complete")
                {
                    Database.AlertManagerComplete(Variables.AlertID);
                }

                Variables.AlertManagerScreenUpdate = true;

                this.Close();
            }
            else
            {
                MessageBox.Show("Progress Selection. Incorrect selection.");
            }
        }
    }
}
