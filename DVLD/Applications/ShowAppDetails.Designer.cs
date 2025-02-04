namespace DVLD
{
    partial class ShowAppDetails
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
            this.ctrlFullApplicationInfo1 = new DVLD.ctrlFullApplicationInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlFullApplicationInfo1
            // 
            this.ctrlFullApplicationInfo1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlFullApplicationInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFullApplicationInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlFullApplicationInfo1.Name = "ctrlFullApplicationInfo1";
            this.ctrlFullApplicationInfo1.Size = new System.Drawing.Size(1065, 557);
            this.ctrlFullApplicationInfo1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Image = global::DVLD.Properties.Resources.error__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(917, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 68);
            this.button1.TabIndex = 25;
            this.button1.Text = "Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowAppDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1065, 557);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlFullApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowAppDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowAppDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlFullApplicationInfo ctrlFullApplicationInfo1;
        private System.Windows.Forms.Button button1;
    }
}