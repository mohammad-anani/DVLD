namespace DVLD
{
    partial class ctrlFullApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlApplicationInfo1 = new DVLD.ctrlApplicationInfo();
            this.ctrlLDLApplicationInfo1 = new DVLD.ctrlLDLApplicationInfo();
            this.SuspendLayout();
            // 
            // ctrlApplicationInfo1
            // 
            this.ctrlApplicationInfo1.appid = 0;
            this.ctrlApplicationInfo1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlApplicationInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlApplicationInfo1.Location = new System.Drawing.Point(11, 184);
            this.ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            this.ctrlApplicationInfo1.Size = new System.Drawing.Size(1054, 310);
            this.ctrlApplicationInfo1.TabIndex = 1;
            // 
            // ctrlLDLApplicationInfo1
            // 
            this.ctrlLDLApplicationInfo1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlLDLApplicationInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlLDLApplicationInfo1.ldlid = 0;
            this.ctrlLDLApplicationInfo1.Location = new System.Drawing.Point(11, 15);
            this.ctrlLDLApplicationInfo1.Name = "ctrlLDLApplicationInfo1";
            this.ctrlLDLApplicationInfo1.Size = new System.Drawing.Size(1054, 163);
            this.ctrlLDLApplicationInfo1.TabIndex = 0;
            // 
            // ctrlFullApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ctrlApplicationInfo1);
            this.Controls.Add(this.ctrlLDLApplicationInfo1);
            this.Name = "ctrlFullApplicationInfo";
            this.Size = new System.Drawing.Size(1078, 507);
            this.Load += new System.EventHandler(this.ctrlFullApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLDLApplicationInfo ctrlLDLApplicationInfo1;
        private ctrlApplicationInfo ctrlApplicationInfo1;
    }
}
