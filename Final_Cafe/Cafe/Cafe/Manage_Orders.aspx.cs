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
    public partial class Manage_Orders : System.Web.UI.Page
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindList();
            }
        }

        protected void BindList()
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM orders_master", conn);
                ad.Fill(dt);
            }
            OrderMasterList.DataSource = dt;
            OrderMasterList.DataBind();
        }

        protected void BindList2(int order_id)
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter(string.Format("SELECT * FROM sum_orders_detail WHERE order_id = {0}", order_id), conn);
                ad.Fill(dt);
            }
            OrderDetailList.DataSource = dt;
            OrderDetailList.DataBind();
        }

        protected void OrderDetailList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfOrderID2");
            HiddenField hf2 = (HiddenField)e.Item.FindControl("hfFoodID");
            HiddenField hf3 = (HiddenField)e.Item.FindControl("hfType");
            HiddenField hf4 = (HiddenField)e.Item.FindControl("hfStatus");

            if (hf4.Value == "C")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('The order already closed. You cannot edit the order.')", true);
                return;
            }

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE orders_detail SET price = (price / quantity) * (quantity - 1), quantity = quantity - 1 WHERE order_id = {0} AND food_id = {1} AND item_type = '{2}'", hf.Value, hf2.Value, hf3.Value), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd = new SqlCommand(string.Format("DELETE orders_detail WHERE order_id = {0} AND quantity = 0", hf.Value), conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                BindList2(Convert.ToInt32(hf.Value));
                return;
            }
        }

        protected void OrderMasterList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfOrderID");

            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter(string.Format("SELECT * FROM sum_orders_detail WHERE order_id = {0}", hf.Value), conn);
                ad.Fill(dt);
            }
            OrderDetailList.DataSource = dt;
            OrderDetailList.DataBind();
        }
    }
}