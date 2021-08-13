
namespace ClearCache
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_formFolder = new System.Windows.Forms.Button();
            this.textBox_formFolder = new System.Windows.Forms.TextBox();
            this.checkBox_enabled = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox_cacheFolder = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_formFolder
            // 
            this.button_formFolder.Location = new System.Drawing.Point(12, 36);
            this.button_formFolder.Name = "button_formFolder";
            this.button_formFolder.Size = new System.Drawing.Size(83, 23);
            this.button_formFolder.TabIndex = 0;
            this.button_formFolder.Text = "Form folder";
            this.button_formFolder.UseVisualStyleBackColor = true;
            this.button_formFolder.Click += new System.EventHandler(this.Button_formFolder_Click);
            // 
            // textBox_formFolder
            // 
            this.textBox_formFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_formFolder.Location = new System.Drawing.Point(101, 37);
            this.textBox_formFolder.Name = "textBox_formFolder";
            this.textBox_formFolder.Size = new System.Drawing.Size(327, 23);
            this.textBox_formFolder.TabIndex = 1;
            this.textBox_formFolder.Leave += new System.EventHandler(this.TextBox_formFolder_Leave);
            // 
            // checkBox_enabled
            // 
            this.checkBox_enabled.AutoSize = true;
            this.checkBox_enabled.Enabled = false;
            this.checkBox_enabled.Location = new System.Drawing.Point(12, 12);
            this.checkBox_enabled.Name = "checkBox_enabled";
            this.checkBox_enabled.Size = new System.Drawing.Size(68, 19);
            this.checkBox_enabled.TabIndex = 2;
            this.checkBox_enabled.Text = "Enabled";
            this.checkBox_enabled.UseVisualStyleBackColor = true;
            this.checkBox_enabled.CheckedChanged += new System.EventHandler(this.CheckBox_enabled_CheckedChanged);
            // 
            // textBox_cacheFolder
            // 
            this.textBox_cacheFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cacheFolder.Location = new System.Drawing.Point(101, 66);
            this.textBox_cacheFolder.Name = "textBox_cacheFolder";
            this.textBox_cacheFolder.ReadOnly = true;
            this.textBox_cacheFolder.Size = new System.Drawing.Size(327, 23);
            this.textBox_cacheFolder.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Inactive";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cache folder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 99);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_enabled);
            this.Controls.Add(this.textBox_cacheFolder);
            this.Controls.Add(this.textBox_formFolder);
            this.Controls.Add(this.button_formFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ClearCache";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_formFolder;
        private System.Windows.Forms.TextBox textBox_formFolder;
        private System.Windows.Forms.CheckBox checkBox_enabled;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox_cacheFolder;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
    }
}

