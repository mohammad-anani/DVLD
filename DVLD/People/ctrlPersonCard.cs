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
    public partial class ctrlPersonCard : UserControl
    {
        public event Action OnSaveEvent;
        protected virtual void OnSave()
        {
            Action action = OnSaveEvent;
            if (action != null)
            {
                OnSaveEvent();
            }
        }
        public int id {  get; set; }
        public clsPerson person { get; set; }
        public ctrlPersonCard()
        {
            InitializeComponent();
           
        }

        void fillPersonInfo()
        {
            
            lblid.Text = person.Id.ToString();
            lblname.Text = person.FullName();
            lblemail.Text = person.Email;
            lblgender.Text = person.Gender;
            lblnationalno.Text = person.NationalNO;
            lbladdress.Text = person.Address;
            if (person.ImagePath != "")
            {
                pbpicture.Image = Image.FromFile(person.ImagePath);
            }
            lbldateofbirth.Text = person.DateOfBirth.ToString().Substring(0,9);
            lblphone.Text = person.Phone;
            lblcountry.Text = person.Country;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
        public void loadctrl()
        {
            person = clsPerson.Find(id);
            if (person != null)
            { fillPersonInfo(); }
        }
        private void ctrlPersonCard_Load_1(object sender, EventArgs e)
        {
            person = clsPerson.Find(id);
            if(person!=null)
            { fillPersonInfo(); }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdatePerson form = new AddUpdatePerson(person.Id);
            form.OnSave += Form_OnSave;
            form.ShowDialog();
        }

        private void Form_OnSave(object sender)
        {
            person=clsPerson.Find(person.Id);
            fillPersonInfo();
            if(OnSaveEvent!=null)
            {
                OnSaveEvent();
            }
        }
    }
}
