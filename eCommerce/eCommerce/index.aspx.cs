using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
namespace eCommerce
{
    public partial class index : System.Web.UI.Page
    {
        public static string dbConnect = @"integrated security=True;data source=(localdb)\Projects;persist security info=False;initial catalog=ECommerce";
        public static ArrayList cart = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void rdlFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            generalFrame.Attributes.Add("src", rdlFrames.SelectedValue);
        }
    }
}