using DVLD_Business;
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
    public partial class License_History : Form
    {
       int personid {  get; set; }
        public License_History(int person)
        {
            InitializeComponent();
            
            personid=person;
            ctrlPersonCard1.id = personid;
        }

        void List()
        {
            dataGridView3.DataSource = clsLicense.Listlicenses(personid);
            dataGridView2.DataSource=clsIntLIcense.Listlicenses(personid);
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void License_History_Load(object sender, EventArgs e)
        {
            List();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Show_Driving_License(int.Parse(dataGridView3.SelectedRows[0].Cells[1].Value.ToString()));
            form.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = new International_License_Details(int.Parse(dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
            form.ShowDialog();
        }
    }
}
