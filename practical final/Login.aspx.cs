using practical_final.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace practical_final
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["UserType"] != null)
            {
                string userType = Session["UserType"].ToString();
                if (userType == "client")
                    Response.Redirect("ClientPage.aspx");
                else if (userType == "receptionist")
                    Response.Redirect("ReceptionistPage.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            
            string sql = "SELECT Role FROM Users WHERE Username = @User AND Password = @Pass";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@User", user },
                { "@Pass", pass }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                string role = dt.Rows[0]["Role"].ToString();
                Session["Username"] = user;
                Session["UserType"] = role;

                if (role == "client")
                {
                    sql = "SELECT ClientID FROM Clients WHERE Name = @Name";
                    parameters = new Dictionary<string, object>
                    {
                        { "@Name", user }
                    };
                    object clientId = DatabaseHelper.ExecuteScalar(sql, parameters);
                    if (clientId != null)
                    {
                        Session["ClientID"] = Convert.ToInt32(clientId);
                    }
                }

                if (role == "client")
                    Response.Redirect("ClientPage.aspx");
                else if (role == "receptionist")
                    Response.Redirect("ReceptionistPage.aspx");
            }
            else
            {
                lblError.Text = "Incorrect username or password!";
                lblError.Visible = true;
            }
        }
    }
}