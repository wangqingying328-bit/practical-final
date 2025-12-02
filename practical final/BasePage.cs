using System;

namespace practical_final
{
    public class BasePage : System.Web.UI.Page
    {
    
        protected bool CheckRole(string role)
        {
            if (Session["UserType"] == null)
                return false;

            return Session["UserType"].ToString().Equals(role, StringComparison.OrdinalIgnoreCase);
        }

        
        protected void RequireLogin()
        {
            if (Session["UserType"] == null)
            {
                Response.Redirect("Login.aspx");
                Response.End();
            }
        }
    }
}
