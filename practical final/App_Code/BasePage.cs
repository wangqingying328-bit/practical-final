using System;

namespace HotelSite
{
    public class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 检查用户角色是否匹配
        /// </summary>
        protected bool CheckRole(string role)
        {
            if (Session["UserType"] == null)
                return false;

            return Session["UserType"].ToString().Equals(role, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 如果没有登录则跳回 Login
        /// </summary>
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
