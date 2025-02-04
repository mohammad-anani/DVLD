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
    public partial class List_Test_Types : Form
    {
        public List_Test_Types()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void RefreshList()
        {
            dataGridView1.DataSource = clsTestType.GetTypesList();
            lbltotal.Text=dataGridView1.Rows.Count.ToString();
        }
        private void List_Test_Types_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Test_Type frm = new Edit_Test_Type(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            frm.Save += Frm_Save;
            frm.ShowDialog();
        }

        private void Frm_Save(object sender)
        {
            RefreshList();
        }
    }
}
