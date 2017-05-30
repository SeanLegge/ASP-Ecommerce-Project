using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
/*
By: Sean Legge
Version: 0.1
Date Created: June 2014
Description: This handles the any creation, update, delete or find functionality for customers inside of the database.
Last Updated: May 29th 2017
Reasons for Update: 
	May 29th 2017: Added more informative comments to the file.
*/
namespace eCommerce
{
    public partial class Customers : System.Web.UI.Page
    {
        //Create the path
        public static string dbConnect = @"integrated security=True;data source=(localdb)\Projects;persist security info=False;initial catalog=ECommerce";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblOutput.Text = "";
        }
		//Create a new customer in the database
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
				//Create phoneregex check to make sure the phone number entered is valid.
                String PhoneRegex = @"^(?:\([2-9]\d{2}\)\ ?|[2-9]\d{2}(?:\-?|\ ?))[2-9]\d{2}[- ]?\d{4}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, PhoneRegex))
                {
                    lblOutput.Text = "The phone number is not in a proper format.";
                }
				//Trim the users input to make sure there are no extra characters 
                else if(txtCustomerID.Text.Trim().Length == 0
                    || txtFirstName.Text.Trim().Length == 0
                    || txtLastName.Text.Trim().Length == 0
                    || txtAddress.Text.Trim().Length == 0
                    || txtCity.Text.Trim().Length == 0
                    || txtProvince.Text.Trim().Length == 0
                    || txtPostalCode.Text.Trim().Length == 0
                    || txtPhone.Text.Trim().Length == 0
                    || txtEmail.Text.Trim().Length == 0)
                {
					//Prompt the user to let them know they didn't fill out all of the textboxes
                    lblOutput.Text = "You missed some important data. Please provide it so the information can be saved.";
                }
                SqlDataAdapter sqlDataAdapter = null;
                DataSet ds = null;
                SqlConnection connectFill = null;
                SqlConnection connectCmd = null;
                SqlCommand cmd = null;
                SqlCommand scmd = null;

                connectCmd = new SqlConnection(dbConnect);
                connectCmd.Open();
				//Insert into the database
                string sqlString = "INSERT INTO Customers (FirstName, LastName, Address, City, Province, PostalCode, Telephone, Email) VALUES (@FirstName, @LastName, @Address, @City, @Province, @PostalCode, @Telephone, @Email)";

                try
                {
                    cmd = new SqlCommand(sqlString, connectCmd);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                    cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                    cmd.Parameters.AddWithValue("@Telephone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                }

                // get the primary key identity just inserted
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd = new SqlCommand("SELECT IDENT_CURRENT('Customers') FROM Customers", connectCmd);
                txtCustomerID.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();

                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                lblOutput.Text = "Thank you for entering new customer information!";
              
            }
            catch(Exception ex)
            {
                ErrorStorage(ex);
            }
        }
		//Update Customer information in the database
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();
			//Create a string and Update the customers information
            string sqlString = "UPDATE Customers SET FirstName=@FirstName, LastName=@LastName, Address=@Address, City=@City, Province=@Province, PostalCode=@PostalCode, Telephone=@Telephone, Email=@Email WHERE ID=@ID";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                cmd.Parameters.AddWithValue("@Telephone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ID", txtCustomerID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
           }
		 //Delete an existing customer from the database
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string sqlString = "DELETE FROM Customers WHERE ID=@ID";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ID", txtCustomerID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);

            // optionally clear the client fields
            txtCustomerID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtPostalCode.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
        }
        private void ErrorStorage(Exception ex)
        {
            lblOutput.Text = "An unexpected error has occured. Our wokrers are looking into it. Thank you for your patience. Sorry for the inconvenience";

        } 

        private static void DisposeResources(ref SqlDataAdapter sqlDataAdapter,
            ref DataSet ds,
            ref SqlConnection connectFill,
            ref SqlConnection connectCmd,
            ref SqlCommand cmd,
            ref SqlCommand scmd)
        {
            if (sqlDataAdapter != null)
                sqlDataAdapter.Dispose();
            if (ds != null)
                ds.Dispose();
            if (connectFill != null)
                connectFill.Dispose();
            if (connectCmd != null)
                connectCmd.Dispose();
            if (cmd != null)
                cmd.Dispose();
            if (scmd != null)
                scmd.Dispose();
        }
		//Find an existing customer
        protected void btnFind_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            string sqlString = "";

            try
            {
                ds = new DataSet();
                connectFill = new SqlConnection(dbConnect);

                sqlString = "SELECT * FROM Customers WHERE ID = @ID";
                scmd = new SqlCommand(sqlString, connectFill);
                scmd.Parameters.AddWithValue("@ID", txtCustomerID.Text);

                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Customers");
            }
            catch (Exception ex)
            {
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            if (ds.Tables["Customers"].Rows.Count == 1)
            {
                txtFirstName.Text = ds.Tables["Customers"].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables["Customers"].Rows[0]["LastName"].ToString();
                txtAddress.Text = ds.Tables["Customers"].Rows[0]["Address"].ToString();
                txtCity.Text = ds.Tables["Customers"].Rows[0]["City"].ToString();
                txtProvince.Text = ds.Tables["Customers"].Rows[0]["Province"].ToString();
                txtPostalCode.Text = ds.Tables["Customers"].Rows[0]["PostalCode"].ToString();
                txtPhone.Text = ds.Tables["Customers"].Rows[0]["Telephone"].ToString();
                txtEmail.Text = ds.Tables["Customers"].Rows[0]["Email"].ToString();
            }

            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }
    
    }
}