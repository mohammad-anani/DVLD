namespace DVLD
{
    partial class AddUpdatePerson
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
            this.ctrlAddUpdatePerson1 = new DVLD.ctrlAddUpdatePerson();
            this.SuspendLayout();
            // 
            // ctrlAddUpdatePerson1
            // 
            this.ctrlAddUpdatePerson1.id = 0;
            this.ctrlAddUpdatePerson1.Location = new System.Drawing.Point(-1, -2);
            this.ctrlAddUpdatePerson1.Name = "ctrlAddUpdatePerson1";
            this.ctrlAddUpdatePerson1.Size = new System.Drawing.Size(971, 533);
            this.ctrlAddUpdatePerson1.TabIndex = 0;
            this.ctrlAddUpdatePerson1.OnCLose += new System.Action(this.ctrlAddUpdatePerson1_OnCLose);
            this.ctrlAddUpdatePerson1.OnSave += new System.Action(this.ctrlAddUpdatePerson1_OnSave);
            this.ctrlAddUpdatePerson1.Load += new System.EventHandler(this.ctrlAddUpdatePerson1_Load);
            // 
            // AddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 523);
            this.Controls.Add(this.ctrlAddUpdatePerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddUpdatePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUpdatePerson";
            this.Load += new System.EventHandler(this.AddUpdatePerson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAddUpdatePerson ctrlAddUpdatePerson1;
    }
}