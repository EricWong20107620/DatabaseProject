using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafe
{
    public partial class _Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_id"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblLoginID.Text = "Welcome to WY Cafe, " + Session["login_id"].ToString();
        }
    }
}