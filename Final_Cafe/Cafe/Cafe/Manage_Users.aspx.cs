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
    public partial class Manage_Users : System.Web.UI.Page
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindList();
            }
        }

        protected void ManageUserList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfID");
            DataTable dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
            using (conn)
            {
                SqlDataAdapter ad = new SqlDataAdapter(string.Format("SELECT * FROM login_account WHERE login_id = '{0}'", hf.Value), conn);
                ad.Fill(dt);
            }
            txtLoginID.Text = dt.Rows[0]["login_id"].ToString();
            txtPassword.Text = dt.Rows[0]["login_password"].ToString();
            ddlRole.SelectedValue = dt.Rows[0]["user_role"].ToString();
            ddlStatus.SelectedValue = dt.Rows[0]["user_status"].ToString();
            txtLoginID.Enabled = false;
            btnInsert.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtLoginID.Text = "";
            txtPassword.Text = "";
            ddlRole.SelectedValue = "S";
            ddlStatus.SelectedValue = "1";
            txtLoginID.Enabled = true;
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (Check_Blank("Insert") == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('All fields in detail cannot blank')", true);
                return;
            }

            try
            {
                if (sp_insert_user(txtLoginID.Text, txtPassword.Text, ddlRole.SelectedValue, Convert.ToInt32(ddlStatus.SelectedValue)) >= 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Insert Successful')", true);
                    BindList();
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Insert fail. Please contact admin.')", true);
                    return;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Insert fail. Please contact admin.')", true);
                return;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Check_Blank("Update") == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('All fields in detail cannot blank exclude login ID')", true);
                return;
            }

            try
            {
                if (sp_update_user(txtPassword.Text, ddlRole.SelectedValue, Convert.ToInt32(ddlStatus.SelectedValue), txtLoginID.Text) >= 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Update Successful')", true);
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
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM login_account", conn);
                ad.Fill(dt);
            }
            ManageUserList.DataSource = dt;
            ManageUserList.DataBind();
        }

        protected int Check_Blank(string action)
        {
            int chk = 0;

            if (action == "Insert")
            {
                if (string.IsNullOrEmpty(txtLoginID.Text) == true)
                {
                    chk = 1;
                }
            }

            if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                chk = 1;
            }

            return chk;
        }

        public int sp_update_user(string login_password, string user_role, int user_status, string login_id)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlParameter[] parms = { new SqlParameter("@login_password", login_password),
                                                new SqlParameter("@user_role", user_role),
                                                new SqlParameter("@user_status", user_status),
                                                new SqlParameter("@login_id", login_id) };
                    SqlCommand Command = new SqlCommand("sp_update_user", conn);
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

        public int sp_insert_user(string login_id, string login_password, string user_role, int user_status)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlParameter[] parms = { new SqlParameter("@login_id", login_id),
                                                new SqlParameter("@login_password", login_password),
                                                new SqlParameter("@user_role", user_role),
                                                new SqlParameter("@user_status", user_status) };
                    SqlCommand Command = new SqlCommand("sp_insert_user", conn);
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