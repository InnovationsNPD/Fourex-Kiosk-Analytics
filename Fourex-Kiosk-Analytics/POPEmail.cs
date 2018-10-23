using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace Fourex_Kiosk_Analytics
{
    class POPEmail
    {
        static System.IO.StreamWriter sw = null;
        static System.Net.Sockets.TcpClient tcpc = null;
        static System.Net.Security.SslStream ssl = null;
        static string username, password;
        static string path;
        static int bytes = -1;
        static byte[] buffer;
        static StringBuilder sb = new StringBuilder();
        static byte[] dummy;
      

        
    }
}
