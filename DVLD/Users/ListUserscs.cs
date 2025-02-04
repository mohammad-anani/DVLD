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
    public partial class ListUserscs : Form
    {
        public ListUserscs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = comboBox1.Text;
            if (comboBox1.Text.ToLower()=="isactive")
            {
                textBox1.Visible = false;
                comboBox2.Visible = true;
                comboBox2.SelectedIndex = 0;
               
            }
            else
            {
                textBox1.Visible = true;
                comboBox2.Visible = false;
            }

            RefreshUsersList();
            
        }

        string where = "", order="";
        void RefreshUsersList()
        {
            DataTable dtusers = clsUser.ListUsers(where, order);
            dataGridView1.DataSource = dtusers;
            lbltotal.Text=dtusers.Rows.Count.ToString();
        }

        void FillFilter()
        {
            foreach(DataRow row in clsUser.GetUserColumns().Rows)
            {
                comboBox1.Items.Add(row[0].ToString());
            }
            comboBox2.Items.Add("Active");
            comboBox2.Items.Add("Inactive");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Active")
            {
                where = 1.ToString();
            }
            else if (comboBox2.Text == "Inactive")
            {
                where = 0.ToString();
            }
            else
                where = "";
            RefreshUsersList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            where = textBox1.Text;
            RefreshUsersList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_New_User frm= new Add_New_User(-1);
            frm.OnSave += Frm_OnSave;
            frm.ShowDialog();
        }

        private void Frm_OnSave(object sender)
        {
            RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_New_User form = new Add_New_User(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.OnSave += Form_OnSave;
            form.ShowDialog();
        }

        private void Form_OnSave(object sender)
        {
            RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            if (id == clsGlobalcs.CurrentUser.id)
            {
                MessageBox.Show("Cannot Delete Current User.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (clsUser.HasData(id))
            {
                MessageBox.Show("User Has Data Connected To Him.","Delete Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

                if (MessageBox.Show("Are You Sure You Want To Delete User With ID=" + id+"?","Attention",
                MessageBoxButtons.YesNo)==DialogResult.Yes)
{            if (clsUser.Deleteuser(id))
                {
                    MessageBox.Show("User Deleted Successfully.");
                    RefreshUsersList();
            } }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Password form = new Change_Password(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.OnSave += Form_OnSave1;
            form.ShowDialog();
        }

        private void Form_OnSave1(object sender)
        {
            RefreshUsersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Show_Details(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            form.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet");
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet");
        }

        private void ListUserscs_Load(object sender, EventArgs e)
        {
            FillFilter();
            RefreshUsersList();
          

        }
    }
}
