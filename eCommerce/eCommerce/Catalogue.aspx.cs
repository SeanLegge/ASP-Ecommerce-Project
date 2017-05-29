using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace eCommerce
{
    public partial class Catalogue : System.Web.UI.Page
    {
        //Create Constant variables
        const int PRODUCT_ID = 0;
        const int MANUFACTURE = 1;
        const int NAME = 2;
        const int IMAGE = 3;
        const int QUANTITY = 4;
        const int PRICE = 5;
        //Get the file path
     
       public static string dbConnect = @"integrated security=True;data source=(localdb)\Projects;persist security info=False;initial catalog=ECommerce";
       System.Collections.ArrayList productFiles = new System.Collections.ArrayList();  

       
        protected void Page_Load(object sender, EventArgs e)
        {           
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = new DataSet();
            SqlConnection connectFill = new SqlConnection(dbConnect);
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;
            string sqlString = "";
            //Get all the files from the data folder
            //Getting the number of products in the product table
            int ProductCount = 0;                 
            sqlString  = "SELECT * FROM Products";
            scmd = new SqlCommand(sqlString, connectFill);
            sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = scmd;
            sqlDataAdapter.Fill(ds, "Products");
            //Converting to an int
            ProductCount = Convert.ToInt32(ds.Tables["Products"].Rows.Count);
            int k = 0;
            int b = 0;
            //populate the table
            foreach (DataRow dr in ds.Tables["Products"].Rows)
            {
                productFiles.Clear();
                 b = Convert.ToInt32(ds.Tables["Products"].Rows[0][0].ToString());       
                 productFiles.Add(dr["ID"].ToString());
                 productFiles.Add(dr["ManufacCode"].ToString());
                 productFiles.Add(dr["Description"].ToString());
                 productFiles.Add(dr["Picture"].ToString());
                 productFiles.Add(dr["QtyOnHand"].ToString());
                 productFiles.Add(dr["Price"].ToString());
                //add the row to the table
                tblBooks.Rows.Add(GetProductRow(productFiles, b));
                k++;
            }
        }
        private ArrayList GetProduct(int id)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = new DataSet();
            SqlConnection connectFill = new SqlConnection(dbConnect);
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;
            string sqlString = "";
            //Get all the files from the data folder
            //Getting the number of products in the product table
            int ProductCount = 0;
            sqlString = "SELECT * FROM Products";
            scmd = new SqlCommand(sqlString, connectFill);
            sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = scmd;
            sqlDataAdapter.Fill(ds, "Products");
            //Converting to an int
            ProductCount = Convert.ToInt32(ds.Tables[0].Rows.Count);
            productFiles.Clear();
            foreach (DataRow dr in ds.Tables["Products"].Rows)
            {
                if (Convert.ToInt32(dr["ID"].ToString()) == id)
                {
                    
                    productFiles.Add(dr["ID"].ToString());
                    productFiles.Add(dr["ManufacCode"].ToString());
                    productFiles.Add(dr["Description"].ToString());
                    productFiles.Add(dr["Picture"].ToString());
                    productFiles.Add(dr["QtyOnHand"].ToString());
                    productFiles.Add(dr["Price"].ToString());
                }
                
            }
            return productFiles;
        }
        private TableRow GetProductRow(ArrayList fileName, int index)
        {
            ArrayList productData = fileName;
            //Create a row
            TableRow tr = new TableRow();
            tr.CssClass = "row" + (index % 2).ToString();

            //add the image to the row
            TableCell tcImage = new TableCell();
            Image bookImage = new Image();
            bookImage.ImageUrl = productData[IMAGE].ToString();
            bookImage.Height = 100;
            bookImage.Width = 100;
            tcImage.Controls.Add(bookImage);
            tr.Cells.Add(tcImage);

            //Cell for the ProductID
            TableCell tcProdID = new TableCell();
            tcProdID.Text = productData[PRODUCT_ID].ToString();
            tr.Cells.Add(tcProdID);

            //Cell for Manufacturors number
            TableCell tcManuID = new TableCell();
            tcManuID.Text = productData[MANUFACTURE].ToString();
            tr.Cells.Add(tcManuID);

            //Cell for the Name
            TableCell tcName = new TableCell();
            tcName.Text = productData[NAME].ToString();
            tr.Cells.Add(tcName);

            //Cell for Price
            TableCell tcPrice = new TableCell();
            float price = float.Parse(productData[PRICE].ToString().Trim());
            tcPrice.Text = price.ToString("#,##0.00");
            tcPrice.HorizontalAlign = HorizontalAlign.Right;
            tr.Cells.Add(tcPrice);

            //Add a button that adds that item to the cart
            TableCell tcButton = new TableCell();
            Button btnAddBookToCart = new Button();
            btnAddBookToCart.ID = "btnAddBookToCart_" + productData[PRODUCT_ID].ToString();
            btnAddBookToCart.Text = "Add Book to Cart";
            btnAddBookToCart.Click += new EventHandler(btnAddBookToCart_Click);
            tcButton.Controls.Add(btnAddBookToCart);
            tr.Cells.Add(tcButton);

            return tr;
        }
        protected void btnAddBookToCart_Click(object sender, EventArgs e)
        {
            //Find the button that was click
            Button clicked = (Button)sender;
            string id = clicked.ID;
            string[] idPart = id.Split('_');
            id = idPart[1];

            ArrayList productData = GetProduct(Convert.ToInt32(id));
            index.cart.Add(productData);
            //lblOutput.Text = string.Format("{0} has been added to your cart.", productData[NAME]);
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

    }
}