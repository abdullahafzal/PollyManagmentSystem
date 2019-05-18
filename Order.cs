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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;
            this.label10.Visible = true;
            this.btnAddOrder.Visible = true;
            this.textBoxBrand.Visible = true;
            this.textBoxDate.Visible = true;
            this.textBoxQuantity.Visible = true;
            this.textBoxSize.Visible = true;
            this.textBoxWeight.Visible = true;
            this.textBoxParty.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.ShowDialog();
        }
    }
}
