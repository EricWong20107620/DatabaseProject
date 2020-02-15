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
    public partial class Manage_Snacks : System.Web.UI.Page
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindList();
            }
        }

        protected void ManageSnackList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfID");
            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter(string.Format("SELECT * FROM snacks WHERE snack_id = {0}", hf.Value), conn);
                ad.Fill(dt);
            }
            txtFoodID.Text = dt.Rows[0]["snack_id"].ToString();
            txtFoodName.Text = dt.Rows[0]["snack_name"].ToString();
            txtPath.Text = dt.Rows[0]["picture_path"].ToString();
            txtCategory.Text = dt.Rows[0]["category"].ToString();
            txtPrice.Text = dt.Rows[0]["price"].ToString();
            ddlStatus.SelectedValue = dt.Rows[0]["item_status"].ToString();
            btnInsert.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtFoodID.Text = "";
            txtFoodName.Text = "";
            txtPath.Text = "";
            txtCategory.Text = "";
            txtPrice.Text = "";
            ddlStatus.SelectedValue = "1";
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (Check_Blank("Insert") == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('All fields in detail cannot blank exclude snack ID')", true);
                return;
            }

            try
            {
                if (sp_insert_snack(txtFoodName.Text, txtPath.Text, txtCategory.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(ddlStatus.SelectedValue)) >= 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Created Successful')", true);
                    BindList();
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Create fail. Please contact admin.')", true);
                    return;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Create fail. Please contact admin.')", true);
                return;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Check_Blank("Update") == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('All fields in detail cannot blank')", true);
                return;
            }

            try
            {
                if (sp_update_snack(txtFoodName.Text, txtPath.Text, txtCategory.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(ddlStatus.SelectedValue), Convert.ToInt32(txtFoodID.Text)) >= 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Updated Successful')", true);
                    BindList();
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Update fail. Please contact admin.')", true);
                    return;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Update fail. Please contact admin.')", true);
                return;
            }
        }

        protected void BindList()
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM snacks", conn);
                ad.Fill(dt);
            }
            ManageSnackList.DataSource = dt;
            ManageSnackList.DataBind();
        }

        protected int Check_Blank(string action)
        {
            int chk = 0;

            if (action == "Update")
            {
                if (string.IsNullOrEmpty(txtFoodID.Text) == true)
                {
                    chk = 1;
                }
            }

            if (string.IsNullOrEmpty(txtFoodName.Text) == true)
            {
                chk = 1;
            }

            if (string.IsNullOrEmpty(txtPath.Text) == true)
            {
                chk = 1;
            }

            if (string.IsNullOrEmpty(txtCategory.Text) == true)
            {
                chk = 1;
            }

            if (string.IsNullOrEmpty(txtPrice.Text) == true)
            {
                chk = 1;
            }

            return chk;
        }

        public int sp_update_snack(string snack_name, string path, string category, int price, int status, int snack_id)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlParameter[] parms = { new SqlParameter("@snack_name", snack_name),
                                                new SqlParameter("@path", path),
                                                new SqlParameter("@category", category),
                                                new SqlParameter("@price", price),
                                                new SqlParameter("@status", status),
                                                new SqlParameter("@snack_id", snack_id) };
                    SqlCommand Command = new SqlCommand("sp_update_snack", conn);
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

        public int sp_insert_snack(string snack_name, string path, string category, int price, int status)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlParameter[] parms = { new SqlParameter("@snack_name", snack_name),
                                                new SqlParameter("@path", path),
                                                new SqlParameter("@category", category),
                                                new SqlParameter("@price", price),
                                                new SqlParameter("@status", status) };
                    SqlCommand Command = new SqlCommand("sp_insert_snack", conn);
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