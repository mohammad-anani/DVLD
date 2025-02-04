using DVLD.Properties;
using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlAddUpdatePerson : UserControl
    {

        private clsPerson _person =new clsPerson();

        public event Action OnCLose;

        protected virtual void Close()
        {
            Action Handler = OnCLose;
            if (Handler != null)
            {
                OnCLose();
            }
        }

        public event Action OnSave;

        protected virtual void save()
        {
            Action Handler = OnSave;
            if (Handler != null)
            {
                OnSave();
            }
        }

        public int id { get; set; }
        public ctrlAddUpdatePerson()
        {
            InitializeComponent();


        }

        void FillPersonInfo()
        {
            lblid.Text = _person.Id.ToString();
            txtfirst.Text = _person.FirstName;
            txtlast.Text = _person.LastName;
            txtsecond.Text = _person.SecondName;
            txtthird.Text = _person.ThirdName;
            txtphone.Text = _person.Phone;
            txtemail.Text = _person.Email;
            txtaddress.Text = _person.Address;
            dateTimePicker1.Value = _person.DateOfBirth;
            cbcountries.Text = _person.Country;
            txtnationalno.Text = _person.NationalNO;
            if (_person.ImagePath != "")
            {
                pbpicture.Image = Image.FromFile(_person.ImagePath);
                imagepath = _person.ImagePath;
            }
            if (_person.Gender == "Male")
            {
                rbmale.Checked = true;
            }
            else if (_person.Gender == "Female")
            {
                rbfemale.Checked = true;
            }
        }


        string gender = "Unknown";
        string imagepath = "";

        void AddPerson()
        {
            if (!CheckEmptyFields())
            {
                MessageBox.Show("Missing Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _person.FirstName = txtfirst.Text;
            _person.LastName = txtlast.Text;
            _person.Email = txtemail.Text;
            _person.Phone = txtphone.Text;
            _person.SecondName = txtsecond.Text;
            _person.ThirdName = txtthird.Text;
            _person.DateOfBirth = dateTimePicker1.Value;
            _person.Country = cbcountries.Text;
            _person.NationalNO = txtnationalno.Text;
            _person.Gender = gender;
            _person.Address = txtaddress.Text;
            _person.ImagePath = imagepath;

            if (_person.Save())
            {

                MessageBox.Show("Person Added Successfully!New ID=" + _person.Id);
                lblid.Text = _person.Id.ToString();


                if (OnSave != null)
                {
                    OnSave();
                }
            }

        }

        void UpdatePerson()
        {
            if (!CheckEmptyFields())
            {
                MessageBox.Show("Missing Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _person.FirstName = txtfirst.Text;
            _person.LastName = txtlast.Text;
            _person.Email = txtemail.Text;
            _person.Phone = txtphone.Text;
            _person.SecondName = txtsecond.Text;
            _person.ThirdName = txtthird.Text;
            _person.DateOfBirth = dateTimePicker1.Value;
            _person.Country = cbcountries.Text;
            _person.NationalNO = txtnationalno.Text;
            _person.Gender = gender;
            _person.Address = txtaddress.Text;
            _person.ImagePath = imagepath;

            if (_person.Save())
            {

                MessageBox.Show("Person Updated Successfully!");



                if (OnSave != null)
                {
                    OnSave();
                }
            }

        }
    
        
        private void btnsave_Click(object sender, EventArgs e)
        {
            if(_person.Mode==clsPerson.enMode.Add)
            {
                AddPerson();
                lbladdupdate.Text = "Update Person";
            }
            else if(_person.Mode==clsPerson.enMode.Update)
            {
                UpdatePerson();
               
            }

           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if(OnCLose != null)
                { OnCLose(); }
        }

        void fillcbCountries()
        {
            DataTable dtcountries=clsCountry.GetCountriesList();
            for(int i = 0;i<dtcountries.Rows.Count;i++)
            {
                cbcountries.Items.Add(dtcountries.Rows[i][0].ToString());
            }
        }

        bool CheckEmptyFields()
        {
            return (txtfirst.Text == "" ? false : (txtsecond.Text == "" ? false : (txtthird.Text == "" ? false :
                (txtlast.Text == "" ? false : (txtnationalno.Text == "" ? false :
                (txtphone.Text == "" ? false : (txtaddress.Text == "" ? false : true)))))));
        }
        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {
            id = AddUpdatePerson.ID;
            if (id == -1)
            {
                lbladdupdate.Text = "Add New Person";
               
                _person = new clsPerson();
            }
            else
            {
                lbladdupdate.Text = "Update Person";
               
                _person = clsPerson.Find(id);
                FillPersonInfo();
            }

            fillcbCountries();
            dateTimePicker1.MaxDate=DateTime.Now.AddYears(-18);
            cbcountries.SelectedIndex = 0;
            rbmale.Checked = true;

        }

        private void rbmale_CheckedChanged(object sender, EventArgs e)
        {
            gender=rbmale.Text;
            if(imagepath=="")
            {
                pbpicture.Image = Resources.male;
            }
        }

        private void rbfemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = rbfemale.Text;
            if (imagepath == "")
            {
                pbpicture.Image = Resources.female;
            }
        }

        void SelectImage()
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            openFileDialog1.Title = "Select Person Image";
            openFileDialog1.Filter = "Pictures |*.png;*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagepath = openFileDialog1.FileName;
                pbpicture.Image = Image.FromFile(openFileDialog1.FileName);
                llremove.Visible = true;
            }
        }
        private void llsetimage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           SelectImage();
        }

        private void txtfirst_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                txtsecond.Focus();
        }

        private void txtsecond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtthird.Focus();
        }

        private void txtthird_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtlast.Focus();
        }

        private void txtnationalno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtphone.Focus();
        }

        private void txtlast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtnationalno.Focus();
        }

        private void txtphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtemail.Focus();
        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtaddress.Focus();
        }

        private void txtnationalno_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.PersonExist(txtnationalno.Text))
            {
                e.Cancel = true;
                txtnationalno.Focus();
                errorProvider1.SetError(txtnationalno, "National ID already taken.Choose Another One");

            }
        }

        private void txtemail_Validating(object sender, CancelEventArgs e)
        {
            if (!txtemail.Text.Contains("@gmail.com") && txtemail.Text.Length>0)
            {
                e.Cancel = true;
                txtnationalno.Focus();
                errorProvider1.SetError(txtemail, "Invalid Email Format!");
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        void ResetImage()
        {

            if (rbmale.Checked)
            {
                pbpicture.Image = Resources.male;
            }
            else if (rbfemale.Checked)
            {
                pbpicture.Image = Resources.female;
            }

            imagepath = "";
        }
        private void llremove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetImage();
        }
    }
}
