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
    public partial class ShowAppDetails : Form
    {
        public ShowAppDetails(int ldlid)
        {
            InitializeComponent();
            ctrlFullApplicationInfo1.id = ldlid;
            ctrlFullApplicationInfo1.fillinfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
