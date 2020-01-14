using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafe
{
    public partial class Confirmed_Order : System.Web.UI.Page
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_id"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter(string.Format("SELECT * FROM sum_confirmed_order WHERE login_id = '{0}'", Session["login_id"].ToString()), conn);
                ad.Fill(dt);
            }
            ConfirmedOrderList.DataSource = dt;
            ConfirmedOrderList.DataBind();
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE orders_master SET ord_status = 'C' WHERE order_id = (SELECT MAX(order_id) FROM orders_master WHERE login_id = '{0}')", Session["login_id"].ToString()), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Check Out Successful')", true);
                return;
            }
        }
    }
}