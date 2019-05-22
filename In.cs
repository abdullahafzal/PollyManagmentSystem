﻿using PMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMS
{
    public partial class In : Form
    {
        AutoCompleteStringCollection companyCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection itemCollection = new AutoCompleteStringCollection();


        public In()
        {
            InitializeComponent();
            LoadCompanyList();
            LoadItemList();

        }
        private void LoadCompanyList()
        {

            SqlConnection conn = new SqlConnection(inObj.GetConnection());
            string sql = "SELECT Sup_Company FROM Supplier";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                companyCollection.Add(dr.GetString(0));

            }
            textBoxCompany.AutoCompleteCustomSource = companyCollection;
            conn.Close();
        }
        private void LoadItemList()
        {

            SqlConnection conn = new SqlConnection(inObj.GetConnection());
            string sql = "SELECT Item_Name FROM Item";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                itemCollection.Add(dr.GetString(0));

            }
            textBoxItem.AutoCompleteCustomSource = itemCollection;
            conn.Close();
        }

        InClass inObj = new InClass();
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCompany_TextChanged(object sender, EventArgs e)
        {

        }

        private void InOut_Load(object sender, EventArgs e)
        {

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            Out out1 = new PMS.Out();
            out1.ShowDialog();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        string InvIDtemp = "";
        int rowindex;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            rowindex = e.RowIndex;
            try
            {
                inObj.Inv_ID = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());
                InvIDtemp = inObj.Inv_ID.ToString();
                dtpEnteryTime.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
                inObj.EnteryTime = dtpEnteryTime.Value.ToLocalTime();

                inObj.Sup_Company = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
                inObj.Item_Name = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
                if (IsAllDigits(dataGridView1.Rows[rowindex].Cells[4].Value.ToString())) {
                    inObj.Quantity = int.Parse(dataGridView1.Rows[rowindex].Cells[4].Value.ToString());
                }

                inObj.T_Price = int.Parse(dataGridView1.Rows[rowindex].Cells[5].Value.ToString());

                inObj.Comments = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            }

            catch (Exception ex) {
                MessageBox.Show("Values are incorrect"+ ex);
            }
        }
        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private Boolean btnAddEntriesChecks() {
            if (String.IsNullOrEmpty(textBoxCompany.Text) || String.IsNullOrEmpty(textBoxItem.Text) ||
        String.IsNullOrEmpty(textBoxQuantity.Text) || String.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Insertion Failed, Please Enter all the values");
                return false;
            }
            else if (!IsAllDigits(textBoxQuantity.Text) || !IsAllDigits(textBoxPrice.Text))
            {
                MessageBox.Show("Quantity & Price Should only have Numeric Values  ");
                return false;
            }

            else if (!companyCollection.Contains(textBoxCompany.Text))
            {
                MessageBox.Show("Please Enter valid Company Name");
                return false;
            }

            else if (!itemCollection.Contains(textBoxItem.Text))
            {
                MessageBox.Show("Please Enter valid Item Name");
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAddEntriesChecks())
            {
                inObj.EnteryTime = dtpEnteryTime.Value.ToLocalTime();
                inObj.Sup_Company = textBoxCompany.Text;
                inObj.Item_Name = textBoxItem.Text;
                inObj.Quantity = int.Parse(textBoxQuantity.Text);
                inObj.T_Price = int.Parse(textBoxPrice.Text);
                inObj.Comments = textBoxComment.Text;

                bool success = inObj.Insert(inObj);
                if (success == true)
                {
                    MessageBox.Show("Inserted Successfully");

                    //Show Data
                    DataTable dt = inObj.Select();
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("Insertion Failed");
                }
            }
        }
        private Boolean btnUpdateEntriesChecks()
        {
 
                if (String.IsNullOrEmpty(inObj.Sup_Company) || String.IsNullOrEmpty(inObj.Item_Name))
                {
                    MessageBox.Show("Updation Failed because of empty fields");
                    return false;
                }

                else if (!companyCollection.Contains(inObj.Sup_Company))
                {
                    MessageBox.Show("Please Update a valid Company Name");
                    return false;
                }

                else if (!itemCollection.Contains(inObj.Item_Name))
                {
                    MessageBox.Show("Please Update a valid Item Name");
                    return false;
                }
                return true;

            }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update ");

            var args = new DataGridViewCellEventArgs(0, rowindex);

            DataGridView1_CellClick(dataGridView2, args);


            bool success = inObj.Update(inObj);
                if (success == true)
                {
                    MessageBox.Show("Updated Successfully");

                    //Show Data
                    DataTable dt1 = inObj.Select();

                    dataGridView1.DataSource = dt1;

                }
                else
                {
                    MessageBox.Show("Updation Failed");
               }
            

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //Show Data
            DataTable dt = inObj.Select();
            dataGridView1.DataSource = dt;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            inObj.Inv_ID = int.Parse(InvIDtemp);

            bool success = inObj.Delete(inObj);
            if (success == true)
            {
                MessageBox.Show("Deleted Successfully");

                //Show Data
                DataTable dt = inObj.Select();
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Deletion Failed");
            }
        }

        private void DtpEnteryTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

              
            }
    }
}
