using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAPConnector
{
    public partial class Main : Form
    {
        const string CONNECTON_PLACEHOLDER = "Connection Name...";
        private Config conf;

        public Main(string[] args)
        {
            conf = Config.Load();
            if (args.Length > 0)
            { //Application run with arguments, check if connection guid is provided
                try
                {
                    string guid = args[0].Split(' ')[ args[0].Split(' ').Length - 1 ];
                    Connection connection = conf.connections.First(item => item.guid == guid);
                    Connector.ConnectToSystem(conf, connection.guid);
                    Application.Exit();
                    Close();
                    return;
                }
                catch (Exception ex) {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            InitializeComponent();
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            loadConnections();
        }
        private void description_Leave(object sender, EventArgs e)
        {
            if (description.Text == "") description.Text = CONNECTON_PLACEHOLDER;
        }

        private void description_Enter(object sender, EventArgs e)
        {
            if (description.Text == CONNECTON_PLACEHOLDER) description.Text = "";
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            if (label_guid.Text == "" && description.Text != CONNECTON_PLACEHOLDER && description.Text != "")
            {
                label_guid.Text = Guid.NewGuid().ToString();
            }
            textbox_value_changed(sender, e);
        }

        private void dropdown_connection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection connection = (Connection)description.SelectedItem;
            loadConnection(connection);
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (saveConnection())
            {
                button_save.Visible = false;
            }
        }

        private void textbox_value_changed(object sender, EventArgs e)
        {
            //Check if value changed and enable save button
            if (label_guid.Text == "" || button_save.Visible || conf.connections == null) return;
            string name = "", value = "";
            name = ((Control)sender).Name;
            if (sender is TextBox)
                if (((TextBox)sender).PasswordChar == '\0')
                    value = ((TextBox)sender).Text;
                else
                    value = Security.Encrypt(((TextBox)sender).Text);
            else if (sender is NumericUpDown)
                value = ((NumericUpDown)sender).Value.ToString();
            else if (sender is ComboBox)
                value = ((ComboBox)sender).Text;
            try
            {
                button_save.Visible = !conf.connections.Any(item => item.guid == label_guid.Text
                                          && value == item.GetType().GetProperty(name).GetValue(item).ToString());
            }
            catch { }
        }


        private void clearScreen(bool clear_password = true)
        {
            description.SelectedItem = null;
            description.Text = CONNECTON_PLACEHOLDER;
            label_guid.ResetText();
            host.ResetText();
            system_id.ResetText();
            language.ResetText();
            username.ResetText();
            checkbox_save_password.Checked = false;
            if (clear_password) password.ResetText();
            instance.Value = 0;
            client.Value = 0;
        }
        private void loadConnections()
        {
            if (conf.connections.Count == 0)
            {
                button_save.Visible = true;
                return;
            }
            description.Items.Clear();
            foreach (Connection connection in conf.connections)
            {
                description.Items.Add(connection);
            }
        }
        private void loadConnection(Connection connection)
        {
            if (connection == null) return;
            description.Text = connection.description;
            label_guid.Text = connection.guid;
            host.Text = connection.host;
            system_id.Text = connection.system_id;
            language.Text = connection.language;
            username.Text = connection.username;
            if (connection.password != "")
            {
                password.Text = Security.Decrypt(connection.password);
                checkbox_save_password.Checked = true;
            }
            try
            {
                instance.Value = int.Parse(connection.instance);
            }
            catch { instance.Value = 0; }
            try
            {
                client.Value = int.Parse(connection.client);
            }
            catch { client.Value = 0; }
        }

        private bool saveConnection()
        {
            //Validation checks
            if (!isInputValid()) return false;
            Connection connection;
            try
            {
                //Update existing connection if found
                connection = conf.connections.First(item => item.guid == label_guid.Text);
                connection.description = description.Text;
                connection.host = host.Text;
                connection.system_id = system_id.Text;
                connection.language = language.Text;
                connection.instance = instance.Value.ToString();
                connection.client = client.Value.ToString();
                connection.username = username.Text;
                connection.password = ((checkbox_save_password.Checked) ? (Security.Encrypt(password.Text)) : (""));
            }
            catch
            {
                //Connection not found, create a new one
                connection = new Connection(
                    label_guid.Text,
                    description.Text,
                    host.Text,
                    system_id.Text,
                    instance.Value.ToString(),
                    client.Value.ToString(),
                    language.Text,
                    username.Text,
                    ((checkbox_save_password.Checked) ? (Security.Encrypt(password.Text)) : ("")));
                conf.connections.Add(connection);
            }
            clearScreen(checkbox_save_password.Checked);
            loadConnections();
            loadConnection(connection);
            conf.save();
            return true;
        }
        private bool isInputValid()
        {
            string[] mandatory_fields =
            {
                "description",
                "host",
                "system_id"
            };
            foreach (string s in mandatory_fields)
            {
                if (this.Controls.Find(s, true)[0].Text == "")
                {
                    System.Windows.Forms.MessageBox.Show(
                      $"Please set a {s}",
                      "Missing connection information",
                      System.Windows.Forms.MessageBoxButtons.OK,
                      System.Windows.Forms.MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (description.Text == CONNECTON_PLACEHOLDER)
            {
                System.Windows.Forms.MessageBox.Show(
                      "Please set a connection name",
                      "Missing connection information",
                      System.Windows.Forms.MessageBoxButtons.OK,
                      System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            if (language.Text == "") language.Text = "EN";
            if (label_guid.Text == "") label_guid.Text = Guid.NewGuid().ToString();
            return true;
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (!isInputValid())
            {
                return;
            }
            Connector.ConnectToSystem(conf.sapshcut,
                new Connection(
                    label_guid.Text,
                    description.Text,
                    host.Text,
                    system_id.Text,
                    instance.Value.ToString(),
                    client.Value.ToString(),
                    language.Text,
                    username.Text,
                    password.Text));
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (label_guid.Text == "") return;
            try
            {
                Connection connection = conf.connections.First(item => item.guid == label_guid.Text);
                if (MessageBox.Show(
                    $"Do you really want to delete connection '{connection.description}'?",
                    $"Delete '{connection.description}'",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                conf.connections.Remove(connection);
                clearScreen();
                loadConnections();
                conf.save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button_shortcut_Click(object sender, EventArgs e)
        {
            if (description.SelectedItem == null) return;
            if (!(description.SelectedItem is Connection)) return;
            Connection connection = (Connection)description.SelectedItem;
            Shortcut.Create(connection.description, connection.guid);
        }
    }
}