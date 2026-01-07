using practical_final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace practical_final
{
    public partial class ReceptionistPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CheckRole("receptionist"))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "Welcome, Front Desk Administrator: " +
                                  Convert.ToString(Session["Username"]);

                LoadClients();
                LoadClientDropdown();
                LoadReservations();
            }
        }

       

        private void LoadClients()
        {
            string sql = "SELECT ClientID, Name, DOB, Address, Mobile FROM Clients ORDER BY ClientID";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);

            gvClients.DataSource = dt; //Give data to GridView 把数据给 GridView
            gvClients.DataBind();  //Showing on the reservation page 显示在预订页面上
        }

        private void LoadClientDropdown()   //DropDownList
        {
            string sql = "SELECT ClientID, Name FROM Clients ORDER BY Name";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);

            ddlClient.DataSource = dt;
            ddlClient.DataTextField = "Name";
            ddlClient.DataValueField = "ClientID";
            ddlClient.DataBind();

            ddlClient.Items.Insert(0, new ListItem("--Select Customers--", "0"));
        }

        private void LoadReservations()
        {
            string sql = @"SELECT r.*, c.Name AS ClientName
                           FROM Reservations r
                           LEFT JOIN Clients c ON r.ClientID = c.ClientID
                           ORDER BY r.ReservationID";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);

            gvReservations.DataSource = dt;
            gvReservations.DataBind();
        }

        

        protected void btnAddClient_Click(object sender, EventArgs e) //Add customer 添加客户按钮
        {
            string sql = @"INSERT INTO Clients(Name, DOB, Address, Mobile)
                           VALUES (@Name, @DOB, @Address, @Mobile)";

            var p = new Dictionary<string, object>
            {
                { "@Name", txtName.Text.Trim() },
                { "@DOB", txtDOB.Text.Trim() },
                { "@Address", txtAddress.Text.Trim() },
                { "@Mobile", txtMobile.Text.Trim() }
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(sql, p);//Execute SQL 执行SQL     Insert a record into the database 向数据库插入一条记录 
                if (rows > 0) // 如果成功插入数据
                {
                    lblMessage.Text = "Customer added successfully!";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Addition failed: " + ex.Message; // 插入失败时显示错误信息
            }
        }

        protected void btnUpdateClient_Click(object sender, EventArgs e)  //更新客户 Update customer information
        {
            if (string.IsNullOrEmpty(txtClientID.Value))
            {
                lblMessage.Text = "Please select a customer first!";
                return;
            }

            string sql = @"UPDATE Clients
                           SET Name=@Name, DOB=@DOB, Address=@Address, Mobile=@Mobile
                           WHERE ClientID=@ClientID";

            var p = new Dictionary<string, object>
            {
                { "@ClientID", Convert.ToInt32(txtClientID.Value) },
                { "@Name", txtName.Text.Trim() },
                { "@DOB", txtDOB.Text.Trim() },
                { "@Address", txtAddress.Text.Trim() },
                { "@Mobile", txtMobile.Text.Trim() }
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(sql, p);
                if (rows > 0)
                {
                    lblMessage.Text = "Customer updated successfully!";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Update failed: " + ex.Message;
            }
        }

        protected void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClientID.Value))
            {
                lblMessage.Text = "Please select a customer to delete!";
                return;
            }

            string sql = "DELETE FROM Clients WHERE ClientID=@ClientID";

            var p = new Dictionary<string, object>
            {
                { "@ClientID", Convert.ToInt32(txtClientID.Value) }
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(sql, p);
                if (rows > 0)
                {
                    lblMessage.Text = "Customer deleted successfully!";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                    LoadReservations(); 
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Deletion failed: " + ex.Message;
            }
        }


        protected void btnAddRes_Click(object sender, EventArgs e) //Add reservation 添加预约
        {
            if (ddlClient.SelectedValue == "0")
            {
                lblResMessage.Text = "Please select a customer!";
                return;
            }

            string sql = @"INSERT INTO Reservations(ClientID, Arrival, Departure, RoomType)
                           VALUES (@ClientID, @Arrival, @Departure, @RoomType)";

            var p = new Dictionary<string, object>
            {
                { "@ClientID", Convert.ToInt32(ddlClient.SelectedValue) },
                { "@Arrival", txtArrival.Text.Trim() },
                { "@Departure", txtDeparture.Text.Trim() },
                { "@RoomType", txtRoomType.Text.Trim() }
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(sql, p);
                if (rows > 0)
                {
                    lblResMessage.Text = "Reservation added successfully!";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "Addition failed: " + ex.Message;
            }
        }

        protected void btnUpdateRes_Click(object sender, EventArgs e) //Update reservation 更新预约
        {
            if (string.IsNullOrEmpty(txtReservationID.Value))
            {
                lblResMessage.Text = "Please select a reservation first!";
                return;
            }

            string sql = @"UPDATE Reservations
                           SET ClientID=@ClientID, Arrival=@Arrival,
                               Departure=@Departure, RoomType=@RoomType
                           WHERE ReservationID=@ReservationID";

            var p = new Dictionary<string, object>
            {
                { "@ReservationID", Convert.ToInt32(txtReservationID.Value) },
                { "@ClientID", Convert.ToInt32(ddlClient.SelectedValue) },
                { "@Arrival", txtArrival.Text.Trim() },
                { "@Departure", txtDeparture.Text.Trim() },
                { "@RoomType", txtRoomType.Text.Trim() }
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(sql, p);
                if (rows > 0)
                {
                    lblResMessage.Text = "Reservation updated successfully!";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "Update failed: " + ex.Message;
            }
        }

        protected void btnDeleteRes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReservationID.Value))
            {
                lblResMessage.Text = "Please select a reservation to delete!";
                return;
            }

            string sql = "DELETE FROM Reservations WHERE ReservationID=@ReservationID";

            var p = new Dictionary<string, object>
            {
                { "@ReservationID", Convert.ToInt32(txtReservationID.Value) }
            };

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(sql, p);
                if (rows > 0)
                {
                    lblResMessage.Text = "Reservation cancelled successfully!";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "Deletion failed: " + ex.Message;
            }
        }

       

        protected void btnSearch_Click(object sender, EventArgs e) //Search clients 搜索客户   按名称或手机号搜索客户
        {
            string sql = @"SELECT c.*,
                           (SELECT COUNT(*) FROM Reservations r
                            WHERE r.ClientID = c.ClientID) AS ReservationCount
                           FROM Clients c
                           WHERE c.Name LIKE @Search OR c.Mobile LIKE @Search";

            var p = new Dictionary<string, object>
            {
                { "@Search", "%" + txtSearch.Text.Trim() + "%" }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            gvSearch.DataSource = dt;
            gvSearch.DataBind();
        }

        

        protected void gvClients_SelectedIndexChanged(object sender, EventArgs e)//点击Customer list中的某一行的choose时触发  Triggered when clicking the "choose" button in a row of the Customer list.
        {
            GridViewRow row = gvClients.SelectedRow;

            txtClientID.Value = gvClients.DataKeys[row.RowIndex].Value.ToString();
            txtName.Text = row.Cells[2].Text;
            txtDOB.Text = row.Cells[3].Text;
            txtAddress.Text = row.Cells[4].Text;
            txtMobile.Text = row.Cells[5].Text;
        }

        protected void gvReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvReservations.SelectedRow;

            txtReservationID.Value = gvReservations.DataKeys[row.RowIndex].Value.ToString();
            txtArrival.Text = row.Cells[2].Text;
            txtDeparture.Text = row.Cells[3].Text;
            txtRoomType.Text = row.Cells[4].Text;

            
            string clientId = row.Cells[1].Text;

            if (ddlClient.Items.FindByValue(clientId) != null)
            {
                ddlClient.SelectedValue = clientId;
            }
            else
            {
                ddlClient.SelectedIndex = 0;
            }
        }


        private void ClearClientFields() //Clear client input fields 清除客户输入字段  把隐藏的客户 ID 清掉，避免误更新/误删除 Remove hidden customer IDs to prevent accidental updates/deletions.
        {
            txtClientID.Value = "";
            txtName.Text = "";
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
        }

        private void ClearReservationFields() //Clear reservation input fields 清除预订输入字段  清空预订 ID清空输入框
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
