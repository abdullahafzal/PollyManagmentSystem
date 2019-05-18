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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnTapeline_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tapeline tapeline = new PMS.Tapeline();
            tapeline.ShowDialog();
        }

        private void btnInOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            In in1= new PMS.In();
            in1.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order order= new PMS.Order();
            order.ShowDialog();
        }

        private void btnLoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            Looms looms = new PMS.Looms();
            looms.ShowDialog();
        }

        private void btnAddDrop_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer= new PMS.Customer();
            customer.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inventory = new PMS.Inventory();
            inventory.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users users = new PMS.Users();
            users.ShowDialog();
        }
    }
}
