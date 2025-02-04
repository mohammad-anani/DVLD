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
    public partial class Show_Driving_License : Form
    {
        clsLicense license=new clsLicense();
        public Show_Driving_License(int appid)
        {
            InitializeComponent();
           ctrlDrivingLicense1.appid = appid;
            ctrlDrivingLicense1.FillInfo();

        }

        private void Show_Driving_License_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDrivingLicense1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
