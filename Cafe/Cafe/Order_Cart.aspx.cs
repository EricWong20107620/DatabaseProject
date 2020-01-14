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
    public partial class Order_Cart : System.Web.UI.Page
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

                BindList();
            }
        }

        protected void OrderCartList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfID");
            HiddenField hf2 = (HiddenField)e.Item.FindControl("hfType");

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(string.Format("DELETE TOP(1) FROM orders_cart WHERE login_id = '{0}' AND item_type = '{1}' AND food_id = {2}", Session["login_id"].ToString(), hf2.Value, hf.Value), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                BindList();
                return;
            }
        }

        protected void BindList()
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter(string.Format("SELECT * FROM sum_order_cart WHERE login_id = '{0}'", Session["login_id"].ToString()), conn);
                ad.Fill(dt);
            }
            OrderCartList.DataSource = dt;
            OrderCartList.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int result_count = sp_confirm_order(Session["login_id"].ToString());
            if (result_count >= 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Order Confirmed')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Fail to confirm order. Please contact admin.')", true);
            }
            BindList();
        }

        public int sp_confirm_order(string login_id)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlParameter[] parms = { new SqlParameter("@login_id", login_id) };
                    SqlCommand Command = new SqlCommand("sp_confirm_order", conn);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddRange(parms);
                    return Command.ExecuteNonQuery();
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}