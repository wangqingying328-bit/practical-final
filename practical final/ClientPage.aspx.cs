using practical_final.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace practical_final
{
    public partial class ClientPage : BasePage  //继承BasePage 直接使用 CheckRole()、RequireLogin()
                                                //you can directly use CheckRole() and RequireLogin().
    {
        protected void Page_Load(object sender, EventArgs e)  //Page loading entry页面加载入口
        {
            
            if (!CheckRole("client"))  //If you are not a client, redirect to the login page
            {
                Response.Redirect("Login.aspx");  
            }

            if (!IsPostBack)
            {
                LoadClientInfo();
                LoadReservations();
            }
        }

        void LoadClientInfo()  //加载客户信息 Load client information
        {
            if (Session["ClientID"] == null) //Determine if it is a client
            {
                lblMessage.Text = "No customer information found！";
                return;
            }
            //Retrieve the information of the currently logged-in client from the database.
            int clientId = Convert.ToInt32(Session["ClientID"]);//object change to int
            string sql = "SELECT * FROM Clients WHERE ClientID = @ClientID";  //SQL for retrieving customer information  查询客户信息的 SQL
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientID", clientId }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters); //Execute the SQL query to obtain the DataTable.
            gvClient.DataSource = dt;
            gvClient.DataBind();
        }

        void LoadReservations() //Load client booking list
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
            gvReservations.DataBind(); //It is ultimately displayed on the GridView of the page. 最终显示在页面的 GridView 上
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}