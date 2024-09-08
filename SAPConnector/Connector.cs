using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPConnector
{
    class Connector
    {
        public static void ConnectToSystem(Config conf, string guid)
        { //Connect to SAP system
            //Check configuration for sapshcut.exe path
            if (!System.IO.File.Exists(conf.sapshcut))
            {
                Config.Initialize(conf);
            }
            if (!System.IO.File.Exists(conf.sapshcut))
            {
                System.Windows.Forms.Application.Exit();
                return;
            }
            //Gather connection information
            Connection connection = getConnectionInfo(conf.connections, guid);
            if (connection == null) return; //Failed to get connection info
            //Execute sapshcut.exe with connection arguments
            ConnectToSystem(conf.sapshcut, connection);
        }
        public static void ConnectToSystem(string sapshcut, Connection connection)
        {
            //Fix arguments formating
            while (connection.instance.Length < 2) connection.instance = "0" + connection.instance;
            while (connection.client.Length < 3) connection.client = "0" + connection.client;

            //Execute sapshcut
            execute(sapshcut, $"-max -guiparm=\"{connection.host} {connection.instance}\" " +
                                   $"-system={connection.system_id} " +
                                   $"-client={connection.client} " +
                                   $"-l={connection.language}" +
                                   ((connection.username != "") ?
                                    ($" -user={connection.username} " +
                                     $"-pw={connection.password}") : ("")));
        }
        private static void execute(string executable, string arguments)
        { //Execute a process with specified arguments
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo start_info = new System.Diagnostics.ProcessStartInfo();
            start_info.FileName = executable;
            start_info.Arguments = arguments;
            process.StartInfo = start_info;
            process.Start();
        }
        private static Connection getConnectionInfo(IList<Connection> connections, string guid)
        { //Get connection information
            Connection connection;
            try
            {
                connection = connections.First(item => item.guid == guid);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                      "Connection information not found for the selected system",
                      "Missing connection information",
                      System.Windows.Forms.MessageBoxButtons.OK,
                      System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            if (connection.password == "")
            {
                //If password is not saved, ask for user input
                PasswordInput password_input = new PasswordInput();
                if (password_input.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return null;
                connection.password = password_input.password.Text;
            }
            else
            {
                connection.password = Security.Decrypt(connection.password);
            }
            return connection;
        }
    }
}