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
    public partial class Manage_Application_Types : Form
    {
        public Manage_Application_Types()
        {
            InitializeComponent();
        }

        void RefreshList()
        {
            dataGridView1.DataSource = clsApplicationTypes.GetTypesList();
            lbltotal.Text=dataGridView1.Rows.Count.ToString();
        }

        private void Manage_Application_Types_Load(object sender, EventArgs e)
        {
           RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Application_Types frm = new Edit_Application_Types(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            frm.OnSave += Frm_OnSave;
            frm.ShowDialog();
        }

        private void Frm_OnSave(object sender)
        {
            RefreshList();
        }
    }
}
