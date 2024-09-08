using System.Text.Json;
using System.Collections.Generic;

namespace SAPConnector
{
    [System.Serializable]
    public class Connection
    {
        public Connection() { }
        public Connection(string guid, string description, 
                    string host, string system_id, string instance,
                    string client, string language, 
                    string username, string password = "") { 
            this.guid = guid; 
            this.description = description; 
            this.host = host; 
            this.system_id = system_id; 
            this.instance = instance; 
            this.client = client; 
            this.language = language; 
            this.username = username; 
            this.password = password; 
        }
        public string guid { get; set; }
        public string description { get; set; }
        public string host { get; set; }
        public string system_id { get; set; }
        public string instance { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return description;
        }
        public override bool Equals(object obj)
        {
            if (obj is Connection) 
                return this.guid == ((Connection)obj).guid;
            if (obj is string)
                return this.guid == (string)obj;
            return false;         
        }
        public override int GetHashCode()
        {
            return System.BitConverter.ToInt32(System.Text.UTF8Encoding.UTF8.GetBytes(this.guid), 0);
        }
    }
    [System.Serializable]
    public class Config
    {
        public const string APP_FOLDER = "SAPConnector";
        public const string CONFIG_FILE = "config.json";
        public const System.Environment.SpecialFolder APP_DATA_PATH = System.Environment.SpecialFolder.LocalApplicationData;
        public string sapshcut { get; set; }
        public IList<Connection> connections { get; set; }
        public void save()
        {
            Config.Save(this);
        }
        public static Config Initialize(Config conf = null)
        {
            if (conf == null)
                conf = new Config();
            //Look for sapshcut location
            string[] search_paths =
            {
                    @"C:\Program Files\SAP\FrontEnd\SAPGUI\sapshcut.exe",
                    @"C:\Program Files (x86)\SAP\FrontEnd\SAPGUI\sapshcut.exe"
                };
            conf.sapshcut = "";
            foreach (string path in search_paths)
            {
                if (System.IO.File.Exists(path))
                {
                    conf.sapshcut = path;
                    break;
                }
            }
            if (conf.sapshcut == "")
            {
                System.Windows.Forms.MessageBox.Show(
                       "Please choose the path to sapshcut.exe.\nIt should be somewhere in the installation folder of SAP GUI.",
                       "Choose the path to sapshcut.exe",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Information);
                System.Windows.Forms.OpenFileDialog file_dialog = new System.Windows.Forms.OpenFileDialog();
                file_dialog.Title = "Choose the path to sapshcut.exe";
                file_dialog.Filter = "sapshcut.exe|sapshcut.exe|*.exe|*.exe";
                if (file_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    conf.sapshcut = file_dialog.FileName;
                }
            }
            if (conf.sapshcut == "")
            {
                System.Windows.Forms.MessageBox.Show(
                       "Failed to determine the path to sapshcut.exe",
                       "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Information);
                System.Windows.Forms.Application.Exit();
                return null;
            }
            Save(conf);
            return conf;
        }
        public static Config Load()
        {
            string app_data = System.Environment.GetFolderPath(APP_DATA_PATH);
            string json_path = System.IO.Path.Combine(app_data, APP_FOLDER, CONFIG_FILE);
            Config conf;
            if (!System.IO.File.Exists(json_path))
            {
                //No config to load...
                conf = Initialize();
            }
            string json = System.IO.File.ReadAllText(json_path);
            conf = JsonSerializer.Deserialize<Config>(json);
            if (conf.connections == null)
            {
                conf.connections = new List<Connection>();
            }
            return conf;
        }
        public static void Save(Config conf)
        {
            string app_data = System.Environment.GetFolderPath(APP_DATA_PATH);
            string json_path = System.IO.Path.Combine(app_data, APP_FOLDER, CONFIG_FILE);
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(json_path));

            string json = JsonSerializer.Serialize(conf);
            try
            {
                System.IO.File.WriteAllText(json_path, json);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(
                       e.Message,
                       "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Error);
                System.Windows.Forms.MessageBox.Show(
                       "Failed to save configuration",
                       "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
