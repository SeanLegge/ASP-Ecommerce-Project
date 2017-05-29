using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace eCommerce
{

    public partial class Cart : System.Web.UI.Page
    {
        //Create constant variables
        const int PRODUCT_ID = 0;
        const int MANUFACTURE = 1;
        const int NAME = 2;
        const int IMAGE = 3;
        const int QUANTITY = 4;
        const int PRICE = 5;

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateCartGrid();
            CalculateTotal();
        }
		//This will create the table and populate it with the relevant information
        private void PopulateCartGrid()
        {
            //Clear the table
            tblCart.Rows.Clear();
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.CssClass = "TableHeader";
            //Add a blank cell
            headerRow.Cells.Add(new TableCell());
            //Placeholder for the image
            tblCart.Rows.Add(headerRow);
            //Cell for name
            TableCell tcheaderName = new TableCell();
            tcheaderName.Text = "Name";
            headerRow.Cells.Add(tcheaderName);
            //Cell for Quantity
            TableCell tcHeaderQuantity = new TableCell();
            tcheaderName.Text = "Quantity";
            headerRow.Cells.Add(tcHeaderQuantity);
            //Cell for Price
            TableCell tcHeaderPrice = new TableCell();
            tcHeaderPrice.Text = "Price";
            headerRow.Cells.Add(tcHeaderPrice);
            //Cell for Total
            TableCell tcHeaderTotal = new TableCell();
            tcHeaderTotal.Text = "Total";
            headerRow.Cells.Add(tcHeaderTotal);
            //Cell for Button
            headerRow.Cells.Add(new TableCell());

            //Get each item in the cart
            int i = 0;
            foreach(ArrayList productData in index.cart)
            {
                TableRow tr = new TableRow();
                tblCart.Rows.Add(tr);
                //Add the image to the row
                Image productImage = new Image();
                productImage.ImageUrl = productData[IMAGE].ToString();
                //Set the images height and width
                productImage.Height = 100;
                productImage.Width = 100;
                TableCell tcImage = new TableCell();
                tcImage.Controls.Add(productImage);
                tr.Controls.Add(tcImage);
                //Name
                TableCell tcName = new TableCell();
                tcName.Text = productData[NAME].ToString();
                tr.Cells.Add(tcName);
                //Quantity
                //Check if the value is Null
                if(productData.Count == QUANTITY)
                {
                    productData.Add(1);
                }
                //Create the textbox for the table
                TextBox txtQuantity = new TextBox();
                //Get the quantity
                int quantity = int.Parse(productData[QUANTITY].ToString());
                txtQuantity.Text = productData[QUANTITY].ToString();
                TableCell tcQuantity = new TableCell();
                tcQuantity.Controls.Add(txtQuantity);
                tr.Cells.Add(tcQuantity);
                //Price
                TableCell tcPrice = new TableCell();
                decimal price = decimal.Parse(productData[PRICE].ToString());
                tcPrice.Text = price.ToString();
                tcPrice.HorizontalAlign = HorizontalAlign.Right;
                tr.Cells.Add(tcPrice);
                //Total
                TableCell tcTotal = new TableCell();
                tcTotal.Text = (price * quantity).ToString("#,##0.00");
                tr.Cells.Add(tcTotal);
                //Remove button
                TableCell tcRemove = new TableCell();
                Button btnRemoveItem = new Button();
                btnRemoveItem.ID = "btnRemoveItem_" + i++;
                btnRemoveItem.Text = "Remove Item";
                btnRemoveItem.Click += new EventHandler(RemoveItem_Click);
                tcRemove.Controls.Add(btnRemoveItem);
                tr.Cells.Add(tcRemove);
            }
        }
        //Will remove an item from the cart
		protected void RemoveItem_Click(object sender, EventArgs e)
        {
            //Get the ID of the button that gets clicked
            string ID = ((Button)sender).ID;
            //Split the ID into two parts
            string[] IDParts = ID.Split('_');
            int rowID = int.Parse(IDParts[1]);
            //Remove the item from the cart
            index.cart.RemoveAt(rowID);
            //Rebuild the table
            PopulateCartGrid();
        }
		//Will calculate the total for the order
        private void CalculateTotal()
        {
            decimal finalTotal = 0;
            int i = 0;
            foreach(TableRow tr in tblCart.Rows)
            {
                if(tr.GetType().ToString() == "System.Web.UI.WebControls.TableRow")
                {
                    TextBox txtQuantity = (TextBox)tr.Cells[2].Controls[0];
                    int quantity = int.Parse(txtQuantity.Text);
                    //Update the Quantity
                    ArrayList cartItem = (ArrayList)index.cart[i];
                    cartItem[QUANTITY] = quantity;
                    index.cart[i] = cartItem;
                    //Get the price
                    decimal price = decimal.Parse(tr.Cells[3].Text.Replace("$", ""));
                    //Update the total
                    tr.Cells[4].Text = (quantity * price).ToString("C");
                    //Update the finalTotal
                    finalTotal += (quantity * price);
                    //increment
                    i++;
                }
                //Update label
                lblFinalTotal.Text = finalTotal.ToString("C");
            }

        }

        protected void btnReCalculateTotal_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
}