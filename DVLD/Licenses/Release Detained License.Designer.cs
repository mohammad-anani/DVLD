namespace DVLD
{
    partial class Release_Detained_License
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblreleasefees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblappfees = new System.Windows.Forms.Label();
            this.ctrlDrivingLicense2 = new DVLD.ctrlDrivingLicense();
            this.SuspendLayout();
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Enabled = false;
            this.linkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.linkLabel4.Location = new System.Drawing.Point(419, 24);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(257, 29);
            this.linkLabel4.TabIndex = 36;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Show License History";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Enabled = false;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.linkLabel3.Location = new System.Drawing.Point(432, 69);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(219, 29);
            this.linkLabel3.TabIndex = 35;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Show License Info";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button4.Image = global::DVLD.Properties.Resources.hand_attendance;
            this.button4.Location = new System.Drawing.Point(729, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 101);
            this.button4.TabIndex = 34;
            this.button4.Text = "Release";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::DVLD.Properties.Resources.file__4_;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(235, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 62);
            this.button3.TabIndex = 33;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox2.Location = new System.Drawing.Point(158, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 36);
            this.textBox2.TabIndex = 32;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 31;
            this.label2.Text = "License ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(39, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 37;
            this.label1.Text = "App fees:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblreleasefees
            // 
            this.lblreleasefees.AutoSize = true;
            this.lblreleasefees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblreleasefees.Location = new System.Drawing.Point(639, 544);
            this.lblreleasefees.Name = "lblreleasefees";
            this.lblreleasefees.Size = new System.Drawing.Size(55, 29);
            this.lblreleasefees.TabIndex = 38;
            this.lblreleasefees.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(457, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 29);
            this.label4.TabIndex = 39;
            this.label4.Text = "Release Fees:";
            // 
            // lblappfees
            // 
            this.lblappfees.AutoSize = true;
            this.lblappfees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblappfees.Location = new System.Drawing.Point(184, 544);
            this.lblappfees.Name = "lblappfees";
            this.lblappfees.Size = new System.Drawing.Size(55, 29);
            this.lblappfees.TabIndex = 40;
            this.lblappfees.Text = "N/A";
            // 
            // ctrlDrivingLicense2
            // 
            this.ctrlDrivingLicense2.appid = 0;
            this.ctrlDrivingLicense2.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlDrivingLicense2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlDrivingLicense2.Location = new System.Drawing.Point(2, 101);
            this.ctrlDrivingLicense2.Name = "ctrlDrivingLicense2";
            this.ctrlDrivingLicense2.Size = new System.Drawing.Size(995, 416);
            this.ctrlDrivingLicense2.TabIndex = 30;
            // 
            // Release_Detained_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(997, 582);
            this.Controls.Add(this.lblappfees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblreleasefees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlDrivingLicense2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Release_Detained_License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release_Detained_License";
            this.Load += new System.EventHandler(this.Release_Detained_License_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblreleasefees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblappfees;
    }
}