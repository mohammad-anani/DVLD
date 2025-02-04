namespace DVLD
{
    partial class Schedule_Test
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlscheduletest2 = new DVLD.ctrlscheduletest();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbltitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button2.Image = global::DVLD.Properties.Resources.error__1_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(263, 758);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 68);
            this.button2.TabIndex = 54;
            this.button2.Text = "Close";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Image = global::DVLD.Properties.Resources.diskette__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(532, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 68);
            this.button1.TabIndex = 55;
            this.button1.Text = "Save";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlscheduletest2
            // 
            this.ctrlscheduletest2.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlscheduletest2.Location = new System.Drawing.Point(-9, 126);
            this.ctrlscheduletest2.Name = "ctrlscheduletest2";
            this.ctrlscheduletest2.Size = new System.Drawing.Size(700, 608);
            this.ctrlscheduletest2.TabIndex = 0;
            this.ctrlscheduletest2.OnSaveEvent += new System.Action<DVLDBusiness.clstestappointment>(this.ctrlscheduletest2_OnSaveEvent);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button4.Image = global::DVLD.Properties.Resources.diskette__1_;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(545, 561);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 77);
            this.button4.TabIndex = 25;
            this.button4.Text = "Save";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.eyetest;
            this.pictureBox1.Location = new System.Drawing.Point(283, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lbltitle.ForeColor = System.Drawing.Color.Maroon;
            this.lbltitle.Location = new System.Drawing.Point(53, 65);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(345, 58);
            this.lbltitle.TabIndex = 41;
            this.lbltitle.Text = "Schedule Test";
            // 
            // Schedule_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(682, 663);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ctrlscheduletest2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Schedule_Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.Schedule_Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlscheduletest ctrlscheduletest1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private ctrlscheduletest ctrlscheduletest2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbltitle;
    }
}