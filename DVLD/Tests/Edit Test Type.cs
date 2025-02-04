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
    public partial class Edit_Test_Type : Form
    {
        public clsTestType type {  get; set; }
        public Edit_Test_Type(int id)
        {
            InitializeComponent();
            if(id!=-1)
            {
                type = clsTestType.Find(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Test_Type_Load(object sender, EventArgs e)
        {
            lblid.Text = type.id.ToString();
            textBox1.Text = type.title;
            textBox3.Text = type.description;
            textBox2.Text = type.fees.ToString();
        }

        public delegate void Edit_Test_Type_Save(object sender);
        public event Edit_Test_Type_Save Save;

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text)||string.IsNullOrEmpty(textBox2.Text)||string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Missing Fields.");
                return;
            }

            type.title = textBox1.Text;
            type.description = textBox3.Text;
            type.fees=double.Parse(textBox2.Text);
            if(type.UpdateType())
            {
                MessageBox.Show("Test Type Successfully Updated.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Save?.Invoke(this);
            }
        }
    }
}
