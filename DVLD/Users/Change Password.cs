using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Change_Password : Form
    {
        public clsUser user {  get; set; }
        public Change_Password(int id)
        {
            InitializeComponent();
            user = clsUser.FindUser(id);
            user.UMode = clsUser.enMode.Update;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtcurrent_TextChanged(object sender, EventArgs e)
        {

        }

        public delegate void OnSaveEvent(object sender);
        public event OnSaveEvent OnSave;

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtcurrent.Text!=user.password)
            {
                MessageBox.Show("Incorrect Password.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(txtcurrent.Text=="" || txtpassword.Text=="" || txtconfirm.Text=="")
            {
                MessageBox.Show("Missing Fields!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            user.password = txtpassword.Text;
            if(user.SaveUser())
            {
                OnSave?.Invoke(this);
                MessageBox.Show("Password Changed Successfully.");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtconfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        void fillinfo()
        {
            ctrlPersonCard1.id = user.Personid;
            ctrlPersonCard1.loadctrl();
            lblid.Text = user.id.ToString();
            lblusername.Text = user.username;
            if (user.isactive)
            {
                lblisactive.Text = "Yes";
            }
            else
                lblisactive.Text = "No";
        }

      
        private void Change_Password_Load(object sender, EventArgs e)
        {
            fillinfo();
        }

        private void txtcurrent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtpassword.Focus();
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtconfirm.Focus();
        }

        private void txtconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                button2.PerformClick();
        }

        private void txtconfirm_Validating(object sender, CancelEventArgs e)
        {
            if(txtconfirm.Text!=txtpassword.Text)
            {
                e.Cancel = true;
                txtconfirm.Focus();
                errorProvider1.SetError(txtconfirm, "Passwords Don't Match");
            }
        }
    }
}
