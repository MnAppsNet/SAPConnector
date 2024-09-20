using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPConnector
{
    using IWshRuntimeLibrary;
    public class Shortcut
    {
        public const string ICON_FILE = "shortcut_icon.ico";
        public const string EXECUTABLE_FILE = "SAPConnector.exe";
        public static void Create(string description, string guid)
        {
            if (!exportIcon()) return;
            if (!copyExecutable()) return;

            string app_data = System.Environment.GetFolderPath(Config.APP_DATA_PATH);
            string executable_path = System.IO.Path.Combine(app_data, Config.APP_FOLDER, EXECUTABLE_FILE);
            string icon_path = System.IO.Path.Combine(app_data, Config.APP_FOLDER, ICON_FILE);
            string shortcut_path = "";
            System.Windows.Forms.SaveFileDialog save_file_dialog = new System.Windows.Forms.SaveFileDialog();
            save_file_dialog.Title = "Choose where do you want to save the connection shortcut";
            save_file_dialog.Filter = "*.lnk|*.lnk";
            if (save_file_dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK || 
                save_file_dialog.FileName == "")
                return; //User canceled the process...
            shortcut_path = save_file_dialog.FileName;

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcut_path);
            shortcut.Description = $"SAPConnector - {description}";
            shortcut.IconLocation = icon_path;
            shortcut.TargetPath = executable_path;
            shortcut.Arguments = guid;
            shortcut.Save();

            string script = @"
                $WshShell = New-Object -comObject WScript.Shell
                $Shortcut = $WshShell.CreateShortcut('" + shortcut_path + @"')
                $Shortcut.TargetPath = '" + executable_path + @"'
                $Shortcut.Arguments = '" + guid + @"'
                $Shortcut.IconLocation = '" + icon_path + @"'
                $Shortcut.Save()";

            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -Command \"{script}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = System.Diagnostics.Process.Start(startInfo))
            {
                process.WaitForExit();
            }
        }
        private static bool exportIcon()
        {
            try
            {
                string app_data = System.Environment.GetFolderPath(Config.APP_DATA_PATH);
                string icon_path = System.IO.Path.Combine(app_data, Config.APP_FOLDER, ICON_FILE);
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(icon_path));
                if (!System.IO.File.Exists(icon_path))
                    using (System.IO.FileStream file_stream = new System.IO.FileStream(icon_path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    {
                        Properties.Resources.icon_shortcut.Save(file_stream);
                    }
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(
                       e.Message,
                       "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Error);
                System.Windows.Forms.MessageBox.Show(
                       "Failed to copy SAPConnector icon to application data",
                       "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
        private static bool copyExecutable()
        {
            try
            {
                string current_executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string app_data = System.Environment.GetFolderPath(Config.APP_DATA_PATH);
                string executable_path = System.IO.Path.Combine(app_data, Config.APP_FOLDER, EXECUTABLE_FILE);
                if (System.IO.File.Exists(executable_path))
                    System.IO.File.Delete(executable_path);
                System.IO.File.Copy(current_executable, executable_path);
                return true;
            }catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(
                       e.Message,
                       "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Error);
                System.Windows.Forms.MessageBox.Show(
                       "Failed to copy SAPConnector to application data",
                       "Error",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}