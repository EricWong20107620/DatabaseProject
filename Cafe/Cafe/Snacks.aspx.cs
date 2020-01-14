using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Snacks : Page
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["login_id"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                using (conn)
                {
                    SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM snacks WHERE item_status = 1", conn);
                    ad.Fill(dt);
                    ad = new SqlDataAdapter("SELECT category FROM snacks WHERE item_status = 1 GROUP BY category", conn);
                    ad.Fill(dt2);
                }
                SnackList.DataSource = dt;
                SnackList.DataBind();
                ddlCategory.DataSource = dt2;
                ddlCategory.DataBind();
            }
        }

        protected void SnackList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfID");
            HiddenField hf2 = (HiddenField)e.Item.FindControl("hfType");
            System.Web.UI.WebControls.Label lb = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblPrice2");

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO orders_cart VALUES ('{0}', {1}, '{2}', 1, {3})", Session["login_id"].ToString(), hf.Value, hf2.Value, lb.Text), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Added to the cart')", true);
                return;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter(string.Format("SELECT * FROM snacks WHERE item_status = 1 AND category LIKE '{0}'", ddlCategory.SelectedItem.Value.ToString()), conn);
                ad.Fill(dt);
            }
            SnackList.DataSource = dt;
            SnackList.DataBind();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM snacks WHERE item_status = 1", conn);
                ad.Fill(dt);
            }
            SnackList.DataSource = dt;
            SnackList.DataBind();
        }
    }
}