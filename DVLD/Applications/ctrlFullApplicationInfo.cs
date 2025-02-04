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
    public partial class ctrlFullApplicationInfo : UserControl
    {
        public int id = -1;
        public ctrlFullApplicationInfo()
        {
            InitializeComponent();
        }

        public void fillinfo()
        {
            clsLDLApplication ldlapp = clsLDLApplication.Find(id);
            ctrlApplicationInfo1.appid = ldlapp.appid;
            ctrlApplicationInfo1.FillControl();
            ctrlLDLApplicationInfo1.ldlid = ldlapp.id;
            ctrlLDLApplicationInfo1.fillctrl();
        }

        private void ctrlFullApplicationInfo_Load(object sender, EventArgs e)
        {
            if (id != -1)
            {

                fillinfo();
            }
        }
    }
}
