using practical_final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Web.UI.WebControls;

namespace HotelSite
{
    public partial class ReceptionistPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 检查是否为前台
            if (!CheckRole("receptionist"))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "欢迎，前台管理员：" + Session["Username"];
                LoadClients();
                LoadReservations();
                LoadClientDropdown();
            }
        }

        // ============================
        //  加载客户列表
        // ============================
        void LoadClients()
        {
            string sql = "SELECT * FROM Clients ORDER BY ClientID";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            gvClients.DataSource = dt;
            gvClients.DataBind();
        }

        // ============================
        //  加载所有预订
        // ============================
        void LoadReservations()
        {
            string sql = @"SELECT r.*, c.Name as ClientName 
                          FROM Reservations r 
                          LEFT JOIN Clients c ON r.ClientID = c.ClientID 
                          ORDER BY r.ReservationID";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            gvReservations.DataSource = dt;
            gvReservations.DataBind();
        }

        // ============================
        //  加载客户下拉列表
        // ============================
        void LoadClientDropdown()
        {
            string sql = "SELECT ClientID, Name FROM Clients ORDER BY Name";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            ddlClient.DataSource = dt;
            ddlClient.DataTextField = "Name";
            ddlClient.DataValueField = "ClientID";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("--选择客户--", "0"));
        }

        // ============================
        //  添加客户
        // ============================
        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Clients(Name, DOB, Address, Mobile) VALUES (@Name, @DOB, @Address, @Mobile)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Name", txtName.Text.Trim() },
                { "@DOB", txtDOB.Text.Trim() },
                { "@Address", txtAddress.Text.Trim() },
                { "@Mobile", txtMobile.Text.Trim() }
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    lblMessage.Text = "客户添加成功！";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "添加失败：" + ex.Message;
            }
        }

        // ============================
        //  修改客户
        // ============================
        protected void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClientID.Value))
            {
                lblMessage.Text = "请先选择要修改的客户！";
                return;
            }

            string sql = @"UPDATE Clients SET Name=@Name, DOB=@DOB, 
                          Address=@Address, Mobile=@Mobile 
                          WHERE ClientID=@ClientID";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientID", Convert.ToInt32(txtClientID.Value) },
                { "@Name", txtName.Text.Trim() },
                { "@DOB", txtDOB.Text.Trim() },
                { "@Address", txtAddress.Text.Trim() },
                { "@Mobile", txtMobile.Text.Trim() }
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    lblMessage.Text = "客户信息更新成功！";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "更新失败：" + ex.Message;
            }
        }

        // ============================
        //  删除客户
        // ============================
        protected void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClientID.Value))
            {
                lblMessage.Text = "请先选择要删除的客户！";
                return;
            }

            string sql = "DELETE FROM Clients WHERE ClientID=@ClientID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientID", Convert.ToInt32(txtClientID.Value) }
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    lblMessage.Text = "客户删除成功！";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "删除失败：" + ex.Message;
            }
        }

        // ============================
        //  添加预订
        // ============================
        protected void btnAddRes_Click(object sender, EventArgs e)
        {
            if (ddlClient.SelectedValue == "0")
            {
                lblResMessage.Text = "请选择客户！";
                return;
            }

            string sql = @"INSERT INTO Reservations(ClientID, Arrival, Departure, RoomType) 
                          VALUES (@ClientID, @Arrival, @Departure, @RoomType)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ClientID", Convert.ToInt32(ddlClient.SelectedValue) },
                { "@Arrival", txtArrival.Text.Trim() },
                { "@Departure", txtDeparture.Text.Trim() },
                { "@RoomType", txtRoomType.Text.Trim() }
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    lblResMessage.Text = "预订添加成功！";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "添加失败：" + ex.Message;
            }
        }

        // ============================
        //  修改预订
        // ============================
        protected void btnUpdateRes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReservationID.Value))
            {
                lblResMessage.Text = "请先选择要修改的预订！";
                return;
            }

            string sql = @"UPDATE Reservations SET ClientID=@ClientID, Arrival=@Arrival, 
                          Departure=@Departure, RoomType=@RoomType 
                          WHERE ReservationID=@ReservationID";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ReservationID", Convert.ToInt32(txtReservationID.Value) },
                { "@ClientID", Convert.ToInt32(ddlClient.SelectedValue) },
                { "@Arrival", txtArrival.Text.Trim() },
                { "@Departure", txtDeparture.Text.Trim() },
                { "@RoomType", txtRoomType.Text.Trim() }
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    lblResMessage.Text = "预订更新成功！";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "更新失败：" + ex.Message;
            }
        }

        // ============================
        //  删除预订
        // ============================
        protected void btnDeleteRes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReservationID.Value))
            {
                lblResMessage.Text = "请先选择要删除的预订！";
                return;
            }

            string sql = "DELETE FROM Reservations WHERE ReservationID=@ReservationID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ReservationID", Convert.ToInt32(txtReservationID.Value) }
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (result > 0)
                {
                    lblResMessage.Text = "预订删除成功！";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "删除失败：" + ex.Message;
            }
        }

        // ============================
        //  搜索客户
        // ============================
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT c.*, 
                          (SELECT COUNT(*) FROM Reservations WHERE ClientID = c.ClientID) as ReservationCount 
                          FROM Clients c 
                          WHERE c.Name LIKE @SearchText OR c.Mobile LIKE @SearchText";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@SearchText", "%" + txtSearch.Text.Trim() + "%" }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            gvSearch.DataSource = dt;
            gvSearch.DataBind();
        }

        // ============================
        //  客户选择事件
        // ============================
        protected void gvClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvClients.SelectedRow;
            txtClientID.Value = gvClients.DataKeys[row.RowIndex].Value.ToString();
            txtName.Text = row.Cells[2].Text; // 根据实际列调整
            txtDOB.Text = row.Cells[3].Text;
            txtAddress.Text = row.Cells[4].Text;
            txtMobile.Text = row.Cells[5].Text;
        }

        // ============================
        //  预订选择事件
        // ============================
        protected void gvReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvReservations.SelectedRow;
            txtReservationID.Value = gvReservations.DataKeys[row.RowIndex].Value.ToString();
            txtArrival.Text = row.Cells[2].Text; // 根据实际列调整
            txtDeparture.Text = row.Cells[3].Text;
            txtRoomType.Text = row.Cells[4].Text;

            // 设置客户下拉列表
            string clientId = row.Cells[1].Text;
            ddlClient.SelectedValue = clientId;
        }

        // ============================
        //  清空客户字段
        // ============================
        void ClearClientFields()
        {
            txtClientID.Value = "";
            txtName.Text = "";
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
        }

        // ============================
        //  清空预订字段
        // ============================
        void ClearReservationFields()
        {
            txtReservationID.Value = "";
            txtArrival.Text = "";
            txtDeparture.Text = "";
            txtRoomType.Text = "";
            ddlClient.SelectedIndex = 0;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}