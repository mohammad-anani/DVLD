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
    public partial class Edit_Application_Types : Form
    {
        public clsApplicationTypes apptype {  get; set; }
        public Edit_Application_Types(int id)
        {
            InitializeComponent();
            if (id != -1)
            { apptype = clsApplicationTypes.Find(id); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Application_Types_Load(object sender, EventArgs e)
        {
            lblid.Text = apptype.id.ToString();
            textBox1.Text = apptype.title;
            textBox2.Text = apptype.fees.ToString();
        }

        public delegate void OnSaveEvent(object sender);
        public event OnSaveEvent OnSave;

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            apptype.fees = double.Parse(textBox2.Text);
            apptype.title = textBox1.Text;
            
            if(apptype.UpdateType())
            {
                MessageBox.Show("Application Type Updated Successfully.");
                OnSave?.Invoke(this);
            }
        }
    }
}
