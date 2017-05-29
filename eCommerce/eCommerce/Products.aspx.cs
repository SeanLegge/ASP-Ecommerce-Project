using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace eCommerce
{
    public partial class Products : System.Web.UI.Page
    {
        public static string dbConnect = @"integrated security=True;data source=(localdb)\Projects;persist security info=False;initial catalog=ECommerce";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOutput.Text = "";
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {         
                 String MoneyRegex = @"^([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
                
                    if (!System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, MoneyRegex))
                    {
                       lblOutput.Text = "The price is not in a proper format.";
                    }
                    else if (
                    txtProductID.Text.Trim().Length == 0
                    || txtManuCode.Text.Trim().Length == 0
                    || txtDescription.Text.Trim().Length == 0
                    || txtQuantity.Text.Trim().Length == 0
                    || txtPrice.Text.Trim().Length == 0)
                    {
                        lblOutput.Text = "You missed some important data. Please provide it so the information can be saved.";
                    }
                    else
                    {
                        if (fuImage.HasFile)
                        {                         
                            SqlDataAdapter sqlDataAdapter = null;
                            DataSet ds = null;
                            SqlConnection connectFill = null;
                            SqlConnection connectCmd = null;
                            SqlCommand cmd = null;
                            SqlCommand scmd = null;

                            connectCmd = new SqlConnection(dbConnect);
                            connectCmd.Open();

                            string sqlString = "INSERT INTO Products (ManufacCode, Description, Picture, QtyOnHand, Price) VALUES (@ManufacCode, @Description, @Picture, @QtyOnHand, @Price)";

                            try
                            {
                                cmd = new SqlCommand(sqlString, connectCmd);
                                cmd.Parameters.AddWithValue("@ManufacCode", txtManuCode.Text);
                                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                                cmd.Parameters.AddWithValue("@Picture", "/images/" + fuImage.FileName);
                                cmd.Parameters.AddWithValue("@QtyOnHand", txtQuantity.Text);
                                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                            }

                            // get the primary key identity just inserted
                            cmd = new SqlCommand(sqlString, connectCmd);
                            cmd = new SqlCommand("SELECT IDENT_CURRENT('Products') FROM Products", connectCmd);
                            txtProductID.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();

                            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                     }                                      
                }                      
            }
            catch (Exception ex)
            {
               ErrorStorage(ex);
            }   
        }  
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

            string sqlString = "UPDATE Products SET ManufacCode=@ManufacCode, Description=@Description, Picture=@Picture, QtyOnHand=@QtyOnHand, Price=@Price WHERE ID=@ID";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ManufacCode", txtManuCode.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Picture", "/images/" + fuImage.FileName);
                cmd.Parameters.AddWithValue("@QtyOnHand", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@ID", txtProductID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (btnDelete.Text == "Delete")
            //    {
            //        //Calls the Load button event handler
            //        btnUpdate_Click(sender, e);
            //        if (txtProductID.Text != "")
            //        {
            //            btnDelete.Text = "Confirm";
            //        }
            //    }
            //    else
            //    {
            //        //Calls the delete customer method
            //        lblOutput.Text = DeleteProduct(int.Parse(txtProductID.Text));
            //        btnDelete.Text = "Delete";
            //    }

            //}
            //catch (Exception ex)
            //{
            //    ErrorStorage(ex);
            //}
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string sqlString = "DELETE FROM Products WHERE ID=@ID";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ID", txtProductID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);

            // optionally clear the client fields
            txtManuCode.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
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

                sqlString = "SELECT * FROM Products WHERE ID = @ID";
                scmd = new SqlCommand(sqlString, connectFill);
                scmd.Parameters.AddWithValue("@ID", txtProductID.Text);

                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            if (ds.Tables["Products"].Rows.Count == 1)
            {
                txtManuCode.Text = ds.Tables["Products"].Rows[0]["ManufacCode"].ToString();
                txtDescription.Text = ds.Tables["Products"].Rows[0]["Description"].ToString();
                txtQuantity.Text = ds.Tables["Products"].Rows[0]["QtyOnHand"].ToString();
                txtPrice.Text = ds.Tables["Products"].Rows[0]["Price"].ToString();
            }
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }       
    }
}