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
    public partial class AddUpdatePerson : Form
    {
        public delegate void OnSaveEvent(object sender);
        public event OnSaveEvent OnSave;

        public static int ID { get; set; }
        public AddUpdatePerson(int id)
        {
            InitializeComponent();
            ID = id;
        }

       

        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddUpdatePerson1_OnCLose()
        {
            this.Close();
        }

        private void ctrlAddUpdatePerson1_OnSave()
        {
            OnSave?.Invoke(this);
        }

        private void ctrlAddUpdatePerson1_Load(object sender, EventArgs e)
        {

        }
    }
}
