using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS.Classes
{
    class InClass
    {

        public DateTime EnteryTime { get; set; }
        public string Sup_Company { get; internal set; }
        public string Item_Name { get; internal set; }
        public int T_Price { get; internal set; }
        public string Comments { get; internal set; }
        public int Quantity { get; internal set; }
        public int Inv_ID { get; set; }
        static string myconnstring = ConfigurationManager.ConnectionStrings["PMS.Properties.Settings.PMSConnectionString"].ConnectionString;

        public string GetConnection()
        {
            return myconnstring;
        }

        public DataTable Select()
        {

            //Database connection

            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                //Writing SQL query
                string sql = "Select * FROM Inventory Where Inv_ID IN ( select top 20 Inv_ID from Inventory " +
                              "order by Inv_ID desc) Order By Inv_ID asc ";
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL adapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception e)
            {
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }



        //Inserting Data into Database
        public bool Insert(InClass c)
        {
            //Creating default return type and setiing its values
            bool isSuccess = false;

            //connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //create a sql query to insert
                string sql = "INSERT INTO Inventory (EnteryTime,Sup_Company,Item_Name,Quantity,T_Price,Comments)" +
                                          " VALUES (@EnteryTime,@Sup_Company,@Item_Name,@Quantity,@T_Price,@Comments)";
                //Sql command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create parameters
                //Must Declare Sclaer Variable Error

                cmd.Parameters.AddWithValue("@EnteryTime", c.EnteryTime);
                cmd.Parameters.AddWithValue("@Sup_Company", c.Sup_Company);
                cmd.Parameters.AddWithValue("@Item_Name", c.Item_Name);
                cmd.Parameters.AddWithValue("@Quantity", c.Quantity);
                cmd.Parameters.AddWithValue("@T_Price", c.T_Price);
                cmd.Parameters.AddWithValue("@Comments", c.Comments);


                //Connection opens here

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if qurey runs successfully value of rows > 0

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("OUR Exception " + e);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //Update Method 
        public bool Update(InClass c)
        {
            //Creating default return type and setiing its values
            bool isSuccess = false;

            //connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //create a sql query to Update
                string sql = "UPDATE Inventory SET EnteryTime=@EnteryTime,Sup_Company=@Sup_Company,Item_Name=@Item_Name," +
                    "Quantity=@Quantity,T_Price=@T_Price,Comments=@Comments where Inv_ID=@Inv_ID";
                //Sql command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create parameters
                cmd.Parameters.AddWithValue("@EnteryTime", c.EnteryTime);
                cmd.Parameters.AddWithValue("@Sup_Company", c.Sup_Company);
                cmd.Parameters.AddWithValue("@Item_Name", c.Item_Name);
                cmd.Parameters.AddWithValue("@Quantity", c.Quantity);
                cmd.Parameters.AddWithValue("@T_Price", c.T_Price);
                cmd.Parameters.AddWithValue("@Comments", c.Comments);
                cmd.Parameters.AddWithValue("@Inv_ID", c.Inv_ID);

                //Connection opens here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if qurey runs successfully value of rows > 0
                if (rows > 0)
                {

                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("OUR Exception " + e);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //Delete Method 
        public bool Delete(InClass c)
        {
            //Creating default return type and setiing its values
            bool isSuccess = false;

            //connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {

                //create a sql query to Update
                string sql = "Delete from Inventory where Inv_ID=@Inv_ID";
                //Sql command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create parameters
                cmd.Parameters.AddWithValue("@Inv_ID", c.Inv_ID);

                //Connection opens here
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if qurey runs successfully value of rows > 0

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("OUR Exception " + e);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

    }
}
