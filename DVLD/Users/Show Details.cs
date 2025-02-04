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
    public partial class Show_Details : Form
    {

        public clsUser user {  get; set; }
        public Show_Details(int id)
        {
            InitializeComponent();
            user = clsUser.FindUser(id);

        }

        private void Show_Details_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
