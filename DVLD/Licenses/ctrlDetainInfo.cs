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
    public partial class ctrlDetainInfo : UserControl
    {
        public int licenseid {  get; set; }
        public int detainid {  get; set; }

        public double fees = -1;
        
        public ctrlDetainInfo()
        {
            InitializeComponent();
            lbldate.Text=DateTime.Now.ToShortDateString();
            if(clsGlobalcs.CurrentUser!=null)
            {
                lblusername.Text = clsGlobalcs.CurrentUser.username;
            }

            
        }

        public void FillLicense()
        {
            lbllicenseid.Text=licenseid.ToString();
        }

        public void FillDetain()
        {
            lbldetainid.Text = detainid.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length==0)
            {
                fees = -1;
                return;
            }
            fees=double.Parse(textBox1.Text);
        }
    }
}
