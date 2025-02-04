using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusiness;

namespace DVLD
{
    public partial class ListPersons : Form
    {
        public ListPersons()
        {
            InitializeComponent();
        }

        string where = "";
        string order = "PersonID";
       

        void RefreshPersonList()
        {
            DataTable dt = clsPerson.GetPersonList(where, order);
            lbltotal.Text= dt.Rows.Count.ToString();
            dataGridView1.DataSource =dt;
            
        }

        void FillComboBox()
        {
            DataTable dtcolumns = clsPerson.GetPersonColumns();
            for (int i = 0; i < dtcolumns.Rows.Count; i++)
            {
                comboBox1.Items.Add(dtcolumns.Rows[i][0].ToString()); }
        }
    
        private void ListPersons_Load(object sender, EventArgs e)
        {
            FillComboBox();
            comboBox1.SelectedIndex = 0;
             RefreshPersonList();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            where= textBox1.Text;
            RefreshPersonList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = comboBox1.Text;
            if(comboBox1.Text=="Gender")
            {
                textBox1.Text = "";
                textBox1.Visible = false;
                comboBox2.SelectedIndex = 0;
                comboBox2.Visible = true;
            }
            else
            {
                where = "";
                textBox1.Visible = true;
                comboBox2.Visible = false;
            }
            RefreshPersonList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            where=comboBox2.Text;
            RefreshPersonList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUpdatePerson frm = new AddUpdatePerson(-1);
            frm.OnSave += Frm_onsave;
            frm.ShowDialog();
        }

        private void Frm_onsave(object sender)
        {
            RefreshPersonList();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature Not Implemented Yet.");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature Not Implemented Yet.");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddUpdatePerson frm=new AddUpdatePerson(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            frm.OnSave += Frm_onsave1;
            frm.ShowDialog();
        }

        private void Frm_onsave1(object sender)
        {
            RefreshPersonList();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete person with ID="+ int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()),"Attention",MessageBoxButtons.YesNo)
                ==DialogResult.Yes)
            {
                if(!clsPerson.IsPersonConnected(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())))

                {
                    if (clsPerson.DeletePerson(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        RefreshPersonList();

                        MessageBox.Show("Person Deleted Successfully.");

                    } }
                else
                    MessageBox.Show("Error:Person Connected To Data.","Delete Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPersonCard form = new ShowPersonCard(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.Save += Form_Save;
            form.ShowDialog();
        }

        private void Form_Save(object sender)
        {
           RefreshPersonList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
