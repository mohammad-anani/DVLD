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
    public partial class ShowPersonCard : Form
    {
        public static int ID {  get; set; }
        public ShowPersonCard(int id)
        {
            InitializeComponent();
            ID = id;
            ctrlPersonCard1.id = ID;
        }

        private void ShowPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void OnSave(object sender);
        public event OnSave Save;

        private void ctrlPersonCard1_OnSaveEvent()
        {
            Save?.Invoke(this);
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
