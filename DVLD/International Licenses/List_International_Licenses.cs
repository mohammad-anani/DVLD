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
    public partial class List_International_Licenses : Form
    {
        public List_International_Licenses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string where = "", order = "";
        
        void fillcb()
        {
            foreach(string s in clsIntLIcense.ListColumns())
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.SelectedIndex = 0;
        }


        void RefreshList()
        {
            dataGridView1.DataSource = clsIntLIcense.ListLicenses(where,order);
            lbltotal.Text=dataGridView1.Rows.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            order=comboBox1.Text;
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            where = textBox1.Text;
            RefreshList();
        }

        private void List_International_Licenses_Load(object sender, EventArgs e)
        {
            fillcb();
            RefreshList();
        }

        private void showLicenseDerailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new International_License_Details(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ShowPersonCard(clsDriver.FindByID(int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())).personid);
            form.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new License_History(clsDriver.FindByID(int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())).personid);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form =new New_International_License_Application();
            form.ShowDialog();
            RefreshList();
        }
    }
}
