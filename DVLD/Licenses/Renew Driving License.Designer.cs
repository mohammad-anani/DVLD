namespace DVLD
{
    partial class Renew_Driving_License
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
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ctrlRenewApplication1 = new DVLD.ctrlRenewApplication();
            this.ctrlDrivingLicense2 = new DVLD.ctrlDrivingLicense();
            this.SuspendLayout();
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Enabled = false;
            this.linkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.linkLabel4.Location = new System.Drawing.Point(418, 18);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(257, 29);
            this.linkLabel4.TabIndex = 14;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Show License History";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Enabled = false;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.linkLabel3.Location = new System.Drawing.Point(431, 63);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(228, 29);
            this.linkLabel3.TabIndex = 13;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Show New License";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox2.Location = new System.Drawing.Point(157, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 36);
            this.textBox2.TabIndex = 10;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "License ID:";
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button4.Image = global::DVLD.Properties.Resources.file__1_;
            this.button4.Location = new System.Drawing.Point(757, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(206, 101);
            this.button4.TabIndex = 12;
            this.button4.Text = "Renew";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::DVLD.Properties.Resources.file__4_;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(234, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 62);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlRenewApplication1
            // 
            this.ctrlRenewApplication1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlRenewApplication1.Location = new System.Drawing.Point(1, 511);
            this.ctrlRenewApplication1.Name = "ctrlRenewApplication1";
            this.ctrlRenewApplication1.newlicenseid = 0;
            this.ctrlRenewApplication1.oldlicenseid = 0;
            this.ctrlRenewApplication1.Size = new System.Drawing.Size(984, 350);
            this.ctrlRenewApplication1.TabIndex = 15;
            // 
            // ctrlDrivingLicense2
            // 
            this.ctrlDrivingLicense2.appid = 0;
            this.ctrlDrivingLicense2.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlDrivingLicense2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlDrivingLicense2.Location = new System.Drawing.Point(1, 95);
            this.ctrlDrivingLicense2.Name = "ctrlDrivingLicense2";
            this.ctrlDrivingLicense2.Size = new System.Drawing.Size(984, 449);
            this.ctrlDrivingLicense2.TabIndex = 8;
            // 
            // Renew_Driving_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 853);
            this.Controls.Add(this.ctrlRenewApplication1);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlDrivingLicense2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Renew_Driving_License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Driving License";
            this.Load += new System.EventHandler(this.Renew_Driving_License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private ctrlDrivingLicense ctrlDrivingLicense2;
        private ctrlRenewApplication ctrlRenewApplication1;
    }
}