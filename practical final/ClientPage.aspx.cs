using practical_final.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace HotelSite
{
    public partial class ClientPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 检查是否为客户
            if (!CheckRole("client"))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadClientInfo();
                LoadReservations();
            }
        }

        void LoadClientInfo()
        {
            if (Session["ClientID"] == null)
            {
                lblMessage.Text = "未找到客户信息！";
                return;
            }

            int clientId = Convert.ToInt32(Session["ClientID"]);
            string sql = "SELECT * FROM Clients WHERE ClientID = @ClientID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientID", clientId }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            gvClient.DataSource = dt;
            gvClient.DataBind();
        }

        void LoadReservations()
        {
            if (Session["ClientID"] == null) return;

            int clientId = Convert.ToInt32(Session["ClientID"]);
            string sql = "SELECT * FROM Reservations WHERE ClientID = @ClientID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientID", clientId }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            gvReservations.DataSource = dt;
            gvReservations.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}