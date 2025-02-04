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
    public partial class Add_New_User : Form
    {

        public clsUser user {  get; set; }

        public Add_New_User(int id)
        {
            InitializeComponent();
            if(id==-1)
            {
                user = new clsUser();
                lbltitle.Text = "Add New User";
            }
            else
            {
                user = clsUser.FindUser(id);
                user.UMode = clsUser.enMode.Update;
                lbltitle.Text = "Update User";
                this.Text = "Update User";
                fillInfo();
                disabletabpage1();
            }
        }

        void disabletabpage1()
        {
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            
        }
        void fillInfo()
        {
           
            textBox1.Text = user.Personid.ToString();
            button4.PerformClick();
            txtusername.Text = user.username;
            txtpass.Text = user.password;
            txtconfirm.Text=user.password;
            lblid.Text = user.id.ToString() ;
            chkisactive.Checked = user.isactive;
            
        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.id = -1;
            
            comboBox1.Items.Add("Person ID");
            comboBox1.Items.Add("National NO");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
                {
                MessageBox.Show("Please Enter Value!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(comboBox1.SelectedIndex == 0)
            {
                if(!int.TryParse(textBox1.Text,out int result))
                {
                    return;
                }

                if(!clsPerson.PersonExist(int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(clsPerson.IsUser(int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("Person Exists As User!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ctrlPersonCard1.id = int.Parse(textBox1.Text);
                ctrlPersonCard1.loadctrl();
                button3.Enabled = true;
            }
           else if (comboBox1.SelectedIndex == 1)
            {
                if (!clsPerson.PersonExist(textBox1.Text))
                {
                    MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clsPerson.IsUser(textBox1.Text))
                {
                    MessageBox.Show("Person Exists As User!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ctrlPersonCard1.id = clsPerson.Find(textBox1.Text).Id;
                ctrlPersonCard1.loadctrl();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(ctrlPersonCard1.id==-1)
            {
                MessageBox.Show("Please Select Person","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tabControl1.SelectedIndex = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form = new AddUpdatePerson(-1);
            form.ShowDialog();
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtpass.Focus();
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtconfirm.Focus();
        }

        private void txtconfirm_Validating(object sender, CancelEventArgs e)
        {
            if (txtconfirm.Text != txtpass.Text)
            {
                e.Cancel = true;
                txtconfirm.Focus();
                errorProvider1.SetError(txtconfirm, "Passwords Don't Match!");
            }
            
        }

        public delegate void OnSaveEvent(object sender);
            public event OnSaveEvent OnSave;

        bool Adduser()
        {
            user.Personid=int.Parse(textBox1.Text);
            user.username = txtusername.Text;
            user.password=txtpass.Text;
            user.isactive = chkisactive.Checked;
            if(user.SaveUser())
            {
                MessageBox.Show("User Added Successfully!New User ID= " + user.id);
                lblid.Text = user.id.ToString();
                return true;
            }
            return false;
        }

        bool Updateuser()
        {
           
            user.username = txtusername.Text;
            user.password = txtpass.Text;
            user.isactive = chkisactive.Checked;
            if (user.SaveUser())
            {
                MessageBox.Show("User Updated Successfully!");
               
                return true;
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(user.Personid==-1 || txtusername.Text=="" ||  txtpass.Text=="" || txtconfirm.Text=="")
            {
                MessageBox.Show("Missing Fields!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            if(user.UMode==clsUser.enMode.Add)
         { if (Adduser())
                {
                    OnSave?.Invoke(this);
                    lbltitle.Text = "Update User";
                    this.Text = "Update User";
                }
            }
            else if(user.UMode==clsUser.enMode.Update)
            {
                if(Updateuser())
                {
                    OnSave?.Invoke(this);
                }
            }

        }
    }
}
