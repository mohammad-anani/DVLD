namespace DVLD
{
    partial class International_License_Details
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
            this.ctrlIntLicense1 = new DVLD.ctrlIntLicense();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlIntLicense1
            // 
            this.ctrlIntLicense1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlIntLicense1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ctrlIntLicense1.id = 0;
            this.ctrlIntLicense1.Location = new System.Drawing.Point(-1, 132);
            this.ctrlIntLicense1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlIntLicense1.Name = "ctrlIntLicense1";
            this.ctrlIntLicense1.Size = new System.Drawing.Size(970, 379);
            this.ctrlIntLicense1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(153, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(654, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License Details";
            // 
            // International_License_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(976, 518);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlIntLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "International_License_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International License Details";
            this.Load += new System.EventHandler(this.International_License_Details_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlIntLicense ctrlIntLicense1;
        private System.Windows.Forms.Label label1;
    }
}