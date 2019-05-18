using PMS.Classes;
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
    public partial class Tapeline : Form
    {
        public Tapeline()
        {
            InitializeComponent();
        }
        TapelineClass c = new TapelineClass();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //Get the value from input fields
            c.Denier = int.Parse(txtDenier.Text);
            c.Color = cmbColor.Text;
            c.PP = int.Parse(txtPP.Text);
            c.Calpet = int.Parse(txtCalpet.Text);
            c.RC = int.Parse(txtRC.Text);
            c.ColorKG = int.Parse(txtColorKG.Text);


            bool success = c.Insert(c);
            if (success == true)
            {
                MessageBox.Show("New Tape Created");
            }
            else
            {
                MessageBox.Show("Not Created");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtRC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtColorKG_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new PMS.Main();
            main.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Tapeline_Load(object sender, EventArgs e)
        {

        }
    }
}
