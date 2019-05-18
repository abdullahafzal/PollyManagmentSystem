using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer adddrop = new PMS.Customer();
            adddrop.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.ShowDialog();
        }
    }
}
