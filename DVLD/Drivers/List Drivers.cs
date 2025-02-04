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
    public partial class List_Drivers : Form
    {
        string where = "", order = "";
        public List_Drivers()
        {
            InitializeComponent();
        }

        void fillcb()
        {
            foreach(string s in clsDriver.Listcolumns())
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.SelectedIndex = 0;
        }

        void RefreshList()
        {
            dataGridView1.DataSource = clsDriver.ListDrivers(where,order);
            lbltotal.Text = dataGridView1.Rows.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = comboBox1.Text;
            RefreshList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            where = textBox1.Text;
            RefreshList();
        }

        private void List_Drivers_Load(object sender, EventArgs e)
        {
            fillcb();
            RefreshList();
           
        }
    }
}
