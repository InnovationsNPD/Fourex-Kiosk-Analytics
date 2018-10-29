using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fourex_Kiosk_Analytics
{
    public partial class KiosksGUPTime : Form
    {
        public KiosksGUPTime()
        {
            InitializeComponent();
        }

        private void KiosksGUPTime_Load(object sender, EventArgs e)
        {
            int count = 0;

            chart1.Series["Series1"].Points.Clear();

          //  chart1.ChartAreas[0].AxisX.Interval = 20;
          //  chart1.ChartAreas[0].AxisY.Interval = 20;

            chart1.Series["Series1"].IsVisibleInLegend = false;

            chart1.Series["Series1"].IsValueShownAsLabel = true;

            chart1.Series["Series1"].SmartLabelStyle.Enabled = true;

            //chart_UPTime_KioskUPtime.ChartAreas[0].AxisY.Maximum = 100;
            //chart_UPTime_KioskUPtime.ChartAreas[0].AxisY.Minimum = 0;

            //chart_UPTime_KioskUPtime.ChartAreas[0].AxisX.Maximum = 100;
            //chart_UPTime_KioskUPtime.ChartAreas[0].AxisX.Minimum = 0;


            for(int i=0; i <Variables.ListArraySize;i++)
            {
                if( (Variables.KioskNameList[i] != null)&&(count<10))
                {
                    // radChart1.PlotArea.XAxis[0].TextBlock.Text = "Mon";

                 //   chart1.Series["Series1"].Points[0].AxisLabel = "Label";
                    chart1.Series["Series1"].Points.AddXY(Variables.KioskNameList[i], i);
                    count++;
                }
            }

       
        }

        private void chart_UPTime_KioskUPtime_Click(object sender, EventArgs e)
        {

        }
    }
}
