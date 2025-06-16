using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLDBusiness;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class Login_Screen : Form
    {
        public Login_Screen()
        {
            InitializeComponent();
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {
            string text = File.ReadAllText(@"..\..\Login.txt");
            if (text!="")
            {
                txtusername.Text = text.Substring(0, text.IndexOf(' '));
                txtpassword.Text = text.Substring(text.IndexOf(' ') + 1);
                chkrememberme.Checked = true;
            }
        }

        void ClearFile()
        {
            File.WriteAllText(@"..\..\Login.txt","");
        }
        void SaveToFile()
        {
            string text = txtusername.Text + " " + txtpassword.Text;
            File.WriteAllText(@"..\..\Login.txt", text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtusername.Text)|| string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Missing Fields!","Attention",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(!clsUser.Exists(txtusername.Text,txtpassword.Text))
            {
                txtpassword.Text = "";
                txtusername.Text = "";
                MessageBox.Show("Invalid Username/Password.Try Again","User Not Found",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            clsUser user = clsUser.Find(txtusername.Text, txtpassword.Text);
            if(!user.isactive)
            {
                MessageBox.Show("User Not Active.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if(chkrememberme.Checked)
          { SaveToFile(); }
            else
            {
                ClearFile();
            }
            clsGlobalcs.CurrentUser = user;
            Form form=new Main_Menu(user);
            form.ShowDialog();

        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnlogin.PerformClick();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
