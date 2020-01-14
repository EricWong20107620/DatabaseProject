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
    public partial class Login : System.Web.UI.Page
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginID.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Please enter your Login ID')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Please enter your password')", true);
                return;
            }

            if (sp_login().Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Login ID or password is not correct')", true);
                return;
            }
            else
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cafe"].ConnectionString);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM orders_cart WHERE login_id = '{0}'", Session["login_id"].ToString()), conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginID.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Please enter your Login ID')", true);
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Please enter your password')", true);
                return;
            }

            if (sp_register(txtLoginID.Text, txtPassword.Text) >= 1)
            { 
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Register successful. You can login now')", true);
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('This login ID already used')", true);
                return;
            }
        }

        public DataTable sp_login()
        {
            using (conn)
            {
                SqlCommand myCommand = new SqlCommand("sp_login", conn);

                myCommand.Parameters.Add(new SqlParameter("@login_id", SqlDbType.VarChar));
                myCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar));

                myCommand.Parameters["@login_id"].Value = txtLoginID.Text;
                myCommand.Parameters["@password"].Value = txtPassword.Text;

                myCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(myCommand);

                DataTable dt = new DataTable();
                sqlAdapter.Fill(dt);
                conn.Close();
                myCommand.Dispose();

                if (dt.Rows.Count > 0)
                {
                    Session["login_id"] = dt.Rows[0].Field<string>("login_id");
                    Session["user_role"] = dt.Rows[0].Field<string>("user_role");
                }

                return dt;
            }
        }

        public int sp_register(string login_id, string password)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlParameter[] parms = { new SqlParameter("@login_id", login_id),
                                                new SqlParameter("@password", password) };
                    SqlCommand Command = new SqlCommand("sp_register", conn);
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