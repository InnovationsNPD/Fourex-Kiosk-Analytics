using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fourex_Kiosk_Analytics
{
    class Variables
    {
        //-- MySQl Date format "yyyy-MM-dd HH:mm:ss"

        public static string[] emailfrom = new string[2];

        public static string[] email_Message = new string[2];

        public static string DebugString = null;

        public static Int16 tempcounter = 0;

        public static Int16 mailcount = 0;

        public static int ImportCount = 0;

        public static double RecordID = 0;

        public static int ListArraySize = 500;

        public static string[] KioskNameList                = new string[ListArraySize];
        public static string[] KioskNumberList              = new string[ListArraySize];
        public static string[] KioskStatus                  = new string[ListArraySize];
        
        public static string[] OffLineListKioskName         = new string[ListArraySize];
        public static string[] OffLineListKioskReason       = new string[ListArraySize];
        public static string[] OffLineListKioskDateTime     = new string[ListArraySize];

        public static string[] AlertListKioskNumber         = new string[ListArraySize];
        public static int[] AlertListKioskCount             = new int[ListArraySize];

        public static string[] AlertManager_KioskNumber     = new string[ListArraySize];
        public static string[] AlertManager_Status          = new string[ListArraySize];
        public static string[] AlertManager_Description     = new string[ListArraySize];

        public static bool UpdateAlertKeyIndicatorsFlag = false;

        public static int KioskIndex = 0;

        public static bool TriggerOffLineListViewUpdate = false;

        public static string POPMailResponse = "";

        public static int AlertStatusCount = 6; 
        public static string[] AlertStatus = new string [AlertStatusCount];

        public static string AlertManagerAction = "";
        public static decimal AlertID = 0;
        public static bool AlertManagerScreenUpdate = false;
        public static string AlertManagerKioskName = "";
        public static string AlertManagerKioskNumber = "";

        public static string Setup_EmailAddress01 = "";
        public static string Setup_EmailAddress02 = "";
        public static string Setup_EmailAddress03 = "";

        public static string Setup_Password01 = "";
        public static string Setup_Password02 = "";
        public static string Setup_Password03 = "";

        public static int UPTimeArraySize = 1000;

        public static int[] UPTime_UPTimeMins       = new int[UPTimeArraySize];
        public static int[] UPTime_DownTimeMins     = new int[UPTimeArraySize];
        public static string[] UPTime_KioskNumber   = new string[UPTimeArraySize];
        public static int[] UPTime_Day              = new int[UPTimeArraySize];      
    }
}

