namespace DVLD
{
    partial class Show_Driving_License
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlDrivingLicense1 = new DVLD.ctrlDrivingLicense();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Image = global::DVLD.Properties.Resources.error__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(799, 697);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 68);
            this.button1.TabIndex = 25;
            this.button1.Text = "Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(139, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 76);
            this.label1.TabIndex = 26;
            this.label1.Text = "Show License Details";
            // 
            // ctrlDrivingLicense1
            // 
            this.ctrlDrivingLicense1.appid = 0;
            this.ctrlDrivingLicense1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlDrivingLicense1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlDrivingLicense1.Location = new System.Drawing.Point(12, 153);
            this.ctrlDrivingLicense1.Name = "ctrlDrivingLicense1";
            this.ctrlDrivingLicense1.Size = new System.Drawing.Size(987, 538);
            this.ctrlDrivingLicense1.TabIndex = 0;
            this.ctrlDrivingLicense1.Load += new System.EventHandler(this.ctrlDrivingLicense1_Load);
            // 
            // Show_Driving_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1011, 777);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlDrivingLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Show_Driving_License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show_Driving_License";
            this.Load += new System.EventHandler(this.Show_Driving_License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDrivingLicense ctrlDrivingLicense1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}