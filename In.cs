using PMS.Classes;
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
        public int RowHeadersVisible { get; set; }
        public EventHandler dtpEnteryTime_CloseUp { get; private set; }
        public EventHandler dtpEnteryTime_OnTextChange { get; private set; }

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
                inObj.EnteryTime = dtpEnteryTime.Value;

                inObj.Sup_Company = dataGridView1.Rows[rowindex].Cells[2].Value.ToString().ToUpper();
                inObj.Item_Name = dataGridView1.Rows[rowindex].Cells[3].Value.ToString().ToUpper();
                inObj.Quantity = int.Parse(dataGridView1.Rows[rowindex].Cells[4].Value.ToString());         
                inObj.T_Price = int.Parse(dataGridView1.Rows[rowindex].Cells[5].Value.ToString());
                inObj.Comments = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();

                // If any cell is clicked on the Second column which is our date Column  
                if (e.ColumnIndex == 1)
                {
                    //Initialized a new DateTimePicker Control  
                    dtpEnteryTime = new DateTimePicker();

                    //Adding DateTimePicker control into DataGridView   
                    dataGridView1.Controls.Add(dtpEnteryTime);

                    // Setting the format (i.e. 2014-10-10)  
                    dtpEnteryTime.Format = DateTimePickerFormat.Short;

                    // It returns the retangular area that represents the Display area for a cell  
                    Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    //Setting area for DateTimePicker Control  
                    dtpEnteryTime.Size = new Size(oRectangle.Width, oRectangle.Height);
                    
                    // Setting Location  
                    dtpEnteryTime.Location = new Point(oRectangle.X, oRectangle.Y);

                    // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                    dtpEnteryTime.CloseUp += new EventHandler(dtpEnteryTime_CloseUp);

                    // An event attached to dateTimePicker Control which is fired when any date is selected  
                    dtpEnteryTime.TextChanged += new EventHandler(dtpEnteryTime_OnTextChange);

                    // Now make it visible  
                    dtpEnteryTime.Visible = true;
                }
            }

            catch (Exception ex) {
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

            else if (!companyCollection.Contains(textBoxCompany.Text.ToUpper()))
            {
                MessageBox.Show("Please Enter valid Company Name");
                return false;
            }

            else if (!itemCollection.Contains(textBoxItem.Text.ToUpper()))
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
                inObj.EnteryTime = dtpEnteryTime.Value;
                inObj.Sup_Company = textBoxCompany.Text.ToUpper();
                inObj.Item_Name = textBoxItem.Text.ToUpper();
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
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
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

            var args = new DataGridViewCellEventArgs(0, rowindex);

            DataGridView1_CellClick(dataGridView1, args);
            //Show Data
            DataTable dt = inObj.Select();
            dataGridView1.DataSource = dt;

            if (btnUpdateEntriesChecks())
            {
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
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            //Show Data
            DataTable dt = inObj.Select();
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;


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

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error happened values must be according to their types");

            /* 
                     catch (Exception ex) {

                     }
              if (anError.Context == DataGridViewDataErrorContexts.Commit)
                 {
                     MessageBox.Show("Commit error");
                 }
                 if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
                 {
                     MessageBox.Show("Cell change");
                 }
                 if (anError.Context == DataGridViewDataErrorContexts.Parsing)
                 {
                     MessageBox.Show("parsing error");
                 }
                 if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
                 {
                     MessageBox.Show("leave control error");
                 }

                 if ((anError.Exception) is ConstraintException)
                 {
                     DataGridView view = (DataGridView)sender;
                     view.Rows[anError.RowIndex].ErrorText = "an error";
                     view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                     anError.ThrowException = false;
                 }
                  */
        }


    }
}
