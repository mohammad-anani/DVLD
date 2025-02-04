namespace DVLD
{
    partial class TakeTest
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
            this.pbpic = new System.Windows.Forms.PictureBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbfail = new System.Windows.Forms.RadioButton();
            this.rbpass = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlTakeTest1 = new DVLD.ctrlTakeTest();
            ((System.ComponentModel.ISupportInitialize)(this.pbpic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbpic
            // 
            this.pbpic.Image = global::DVLD.Properties.Resources.eyetest;
            this.pbpic.Location = new System.Drawing.Point(123, 3);
            this.pbpic.Name = "pbpic";
            this.pbpic.Size = new System.Drawing.Size(98, 64);
            this.pbpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbpic.TabIndex = 25;
            this.pbpic.TabStop = false;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lbltitle.ForeColor = System.Drawing.Color.Maroon;
            this.lbltitle.Location = new System.Drawing.Point(236, 9);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(272, 58);
            this.lbltitle.TabIndex = 24;
            this.lbltitle.Text = "Vision Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(34, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "Result:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbfail);
            this.panel1.Controls.Add(this.rbpass);
            this.panel1.Location = new System.Drawing.Point(148, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 53);
            this.panel1.TabIndex = 27;
            // 
            // rbfail
            // 
            this.rbfail.AutoSize = true;
            this.rbfail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbfail.Location = new System.Drawing.Point(119, 17);
            this.rbfail.Name = "rbfail";
            this.rbfail.Size = new System.Drawing.Size(57, 24);
            this.rbfail.TabIndex = 29;
            this.rbfail.TabStop = true;
            this.rbfail.Text = "Fail";
            this.rbfail.UseVisualStyleBackColor = true;
            // 
            // rbpass
            // 
            this.rbpass.AutoSize = true;
            this.rbpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbpass.Location = new System.Drawing.Point(3, 16);
            this.rbpass.Name = "rbpass";
            this.rbpass.Size = new System.Drawing.Size(68, 24);
            this.rbpass.TabIndex = 28;
            this.rbpass.TabStop = true;
            this.rbpass.Text = "Pass";
            this.rbpass.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(40, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "Notes:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox1.Location = new System.Drawing.Point(148, 496);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(534, 36);
            this.textBox1.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Image = global::DVLD.Properties.Resources.diskette__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(541, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 68);
            this.button1.TabIndex = 30;
            this.button1.Text = "Save";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlTakeTest1
            // 
            this.ctrlTakeTest1.apptid = 0;
            this.ctrlTakeTest1.BackColor = System.Drawing.Color.Gainsboro;
            this.ctrlTakeTest1.ldlappid = 0;
            this.ctrlTakeTest1.Location = new System.Drawing.Point(-2, 77);
            this.ctrlTakeTest1.Name = "ctrlTakeTest1";
            this.ctrlTakeTest1.Size = new System.Drawing.Size(684, 332);
            this.ctrlTakeTest1.TabIndex = 31;
            this.ctrlTakeTest1.testtypeid = 0;
            // 
            // TakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(694, 642);
            this.Controls.Add(this.ctrlTakeTest1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbpic);
            this.Controls.Add(this.lbltitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TakeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TakeTest";
            this.Load += new System.EventHandler(this.TakeTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbpic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbpic;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbfail;
        private System.Windows.Forms.RadioButton rbpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private ctrlTakeTest ctrlTakeTest1;
    }
}