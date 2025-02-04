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
    public partial class ctrlFindPerson : UserControl
    {

        public event Action<int> OnFindPerson;

        protected virtual void FindPerson(int obj)
        {
            Action<int> handler = OnFindPerson;
            if (handler != null)
            {
                OnFindPerson(obj);
            }
        }
        public ctrlFindPerson()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form = new AddUpdatePerson(-1);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Enter Value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                if (!int.TryParse(textBox1.Text, out int result))
                {
                    return;
                }

                if (!clsPerson.PersonExist(int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                ctrlPersonCard1.id = int.Parse(textBox1.Text);
                ctrlPersonCard1.loadctrl();

                if (OnFindPerson != null)
                {
                    OnFindPerson(int.Parse(textBox1.Text));
                }

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                if (!clsPerson.PersonExist(textBox1.Text))
                {
                    MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                int id = clsPerson.Find(textBox1.Text).Id;
                ctrlPersonCard1.id = id;
                ctrlPersonCard1.loadctrl();

                if (OnFindPerson != null)
                {
                    OnFindPerson(id);
                }
            }
        }

        private void ctrlFindPerson_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.id = -1;

            comboBox1.Items.Add("Person ID");
            comboBox1.Items.Add("National NO");
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                {
                    button4.PerformClick();
                }
            }
        }
    }
}