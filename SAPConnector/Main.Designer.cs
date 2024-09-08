
namespace SAPConnector
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.description = new System.Windows.Forms.ComboBox();
            this.label_host = new System.Windows.Forms.Label();
            this.label_system_id = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.TextBox();
            this.system_id = new System.Windows.Forms.TextBox();
            this.label_instance = new System.Windows.Forms.Label();
            this.instance = new System.Windows.Forms.NumericUpDown();
            this.client = new System.Windows.Forms.NumericUpDown();
            this.label_client = new System.Windows.Forms.Label();
            this.label_language = new System.Windows.Forms.Label();
            this.language = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.checkbox_save_password = new System.Windows.Forms.CheckBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label_guid = new System.Windows.Forms.Label();
            this.button_new = new System.Windows.Forms.Button();
            this.button_shortcut = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.instance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.client)).BeginInit();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.description.FormattingEnabled = true;
            this.description.Location = new System.Drawing.Point(10, 12);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(234, 27);
            this.description.TabIndex = 0;
            this.description.Text = "Connection Name...";
            this.description.SelectedIndexChanged += new System.EventHandler(this.dropdown_connection_SelectedIndexChanged);
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            this.description.Enter += new System.EventHandler(this.description_Enter);
            this.description.Leave += new System.EventHandler(this.description_Leave);
            // 
            // label_host
            // 
            this.label_host.AutoSize = true;
            this.label_host.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label_host.Location = new System.Drawing.Point(8, 46);
            this.label_host.Name = "label_host";
            this.label_host.Size = new System.Drawing.Size(41, 19);
            this.label_host.TabIndex = 1;
            this.label_host.Text = "Host";
            // 
            // label_system_id
            // 
            this.label_system_id.AutoSize = true;
            this.label_system_id.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label_system_id.Location = new System.Drawing.Point(8, 74);
            this.label_system_id.Name = "label_system_id";
            this.label_system_id.Size = new System.Drawing.Size(85, 19);
            this.label_system_id.TabIndex = 2;
            this.label_system_id.Text = "System ID";
            // 
            // host
            // 
            this.host.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.host.Location = new System.Drawing.Point(64, 46);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(250, 22);
            this.host.TabIndex = 3;
            this.host.TextChanged += new System.EventHandler(this.textbox_value_changed);
            // 
            // system_id
            // 
            this.system_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.system_id.Location = new System.Drawing.Point(99, 74);
            this.system_id.MaxLength = 3;
            this.system_id.Name = "system_id";
            this.system_id.Size = new System.Drawing.Size(68, 22);
            this.system_id.TabIndex = 4;
            this.system_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.system_id.TextChanged += new System.EventHandler(this.textbox_value_changed);
            // 
            // label_instance
            // 
            this.label_instance.AutoSize = true;
            this.label_instance.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label_instance.Location = new System.Drawing.Point(173, 74);
            this.label_instance.Name = "label_instance";
            this.label_instance.Size = new System.Drawing.Size(71, 19);
            this.label_instance.TabIndex = 5;
            this.label_instance.Text = "Instance";
            // 
            // instance
            // 
            this.instance.Location = new System.Drawing.Point(250, 74);
            this.instance.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.instance.Name = "instance";
            this.instance.Size = new System.Drawing.Size(64, 22);
            this.instance.TabIndex = 6;
            this.instance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.instance.ValueChanged += new System.EventHandler(this.textbox_value_changed);
            // 
            // client
            // 
            this.client.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.client.Location = new System.Drawing.Point(250, 102);
            this.client.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(64, 22);
            this.client.TabIndex = 8;
            this.client.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.client.ValueChanged += new System.EventHandler(this.textbox_value_changed);
            // 
            // label_client
            // 
            this.label_client.AutoSize = true;
            this.label_client.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label_client.Location = new System.Drawing.Point(194, 102);
            this.label_client.Name = "label_client";
            this.label_client.Size = new System.Drawing.Size(50, 19);
            this.label_client.TabIndex = 7;
            this.label_client.Text = "Client";
            // 
            // label_language
            // 
            this.label_language.AutoSize = true;
            this.label_language.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label_language.Location = new System.Drawing.Point(12, 102);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(81, 19);
            this.label_language.TabIndex = 9;
            this.label_language.Text = "Language";
            // 
            // language
            // 
            this.language.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.language.Location = new System.Drawing.Point(99, 102);
            this.language.MaxLength = 2;
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(68, 22);
            this.language.TabIndex = 10;
            this.language.Text = "EN";
            this.language.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.language.TextChanged += new System.EventHandler(this.textbox_value_changed);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label_username.Location = new System.Drawing.Point(10, 133);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(83, 19);
            this.label_username.TabIndex = 11;
            this.label_username.Text = "Username";
            // 
            // username
            // 
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Location = new System.Drawing.Point(99, 130);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(215, 22);
            this.username.TabIndex = 12;
            this.username.TextChanged += new System.EventHandler(this.textbox_value_changed);
            // 
            // password
            // 
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Location = new System.Drawing.Point(99, 158);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(215, 22);
            this.password.TabIndex = 13;
            this.password.TextChanged += new System.EventHandler(this.textbox_value_changed);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label_password.Location = new System.Drawing.Point(10, 158);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(80, 19);
            this.label_password.TabIndex = 14;
            this.label_password.Text = "Password";
            // 
            // checkbox_save_password
            // 
            this.checkbox_save_password.AutoSize = true;
            this.checkbox_save_password.Location = new System.Drawing.Point(105, 186);
            this.checkbox_save_password.Name = "checkbox_save_password";
            this.checkbox_save_password.Size = new System.Drawing.Size(209, 20);
            this.checkbox_save_password.TabIndex = 15;
            this.checkbox_save_password.Text = "Save Password [Not Secure]";
            this.checkbox_save_password.UseVisualStyleBackColor = true;
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_connect.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button_connect.Location = new System.Drawing.Point(42, 253);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(274, 28);
            this.button_connect.TabIndex = 16;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button_save.Location = new System.Drawing.Point(10, 219);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(306, 28);
            this.button_save.TabIndex = 17;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Visible = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_guid
            // 
            this.label_guid.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_guid.Location = new System.Drawing.Point(12, 283);
            this.label_guid.Name = "label_guid";
            this.label_guid.Size = new System.Drawing.Size(302, 10);
            this.label_guid.TabIndex = 19;
            this.label_guid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_new
            // 
            this.button_new.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_new.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button_new.Location = new System.Drawing.Point(250, 12);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(29, 28);
            this.button_new.TabIndex = 20;
            this.button_new.Text = "+";
            this.button_new.UseVisualStyleBackColor = false;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // button_shortcut
            // 
            this.button_shortcut.BackColor = System.Drawing.Color.White;
            this.button_shortcut.BackgroundImage = global::SAPConnector.Properties.Resources.shortcut_icon;
            this.button_shortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_shortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_shortcut.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button_shortcut.ForeColor = System.Drawing.Color.White;
            this.button_shortcut.Location = new System.Drawing.Point(10, 254);
            this.button_shortcut.Name = "button_shortcut";
            this.button_shortcut.Size = new System.Drawing.Size(26, 26);
            this.button_shortcut.TabIndex = 18;
            this.button_shortcut.UseVisualStyleBackColor = false;
            this.button_shortcut.Click += new System.EventHandler(this.button_shortcut_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.LightCoral;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.button_delete.Location = new System.Drawing.Point(285, 12);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(29, 28);
            this.button_delete.TabIndex = 21;
            this.button_delete.Text = "-";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(326, 293);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_new);
            this.Controls.Add(this.label_guid);
            this.Controls.Add(this.button_shortcut);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.checkbox_save_password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.language);
            this.Controls.Add(this.label_language);
            this.Controls.Add(this.client);
            this.Controls.Add(this.label_client);
            this.Controls.Add(this.instance);
            this.Controls.Add(this.label_instance);
            this.Controls.Add(this.system_id);
            this.Controls.Add(this.host);
            this.Controls.Add(this.label_system_id);
            this.Controls.Add(this.label_host);
            this.Controls.Add(this.description);
            this.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "SAPConnector";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.instance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.client)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox description;
        private System.Windows.Forms.Label label_host;
        private System.Windows.Forms.Label label_system_id;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.TextBox system_id;
        private System.Windows.Forms.Label label_instance;
        private System.Windows.Forms.NumericUpDown instance;
        private System.Windows.Forms.NumericUpDown client;
        private System.Windows.Forms.Label label_client;
        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.TextBox language;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.CheckBox checkbox_save_password;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_shortcut;
        private System.Windows.Forms.Label label_guid;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_delete;
    }
}

