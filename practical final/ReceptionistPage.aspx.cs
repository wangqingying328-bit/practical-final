using practical_final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
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
                lblWelcome.Text = "Welcome, Front Desk Administrator:" + Session["Username"];
                LoadClients();
                LoadReservations();
                LoadClientDropdown();
            }
        }

        void LoadClients()
        {
            string sql = "SELECT * FROM Clients ORDER BY ClientID";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            gvClients.DataSource = dt;
            gvClients.DataBind();
        }

        
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

    
        void LoadClientDropdown()
        {
            string sql = "SELECT ClientID, Name FROM Clients ORDER BY Name";
            DataTable dt = DatabaseHelper.ExecuteQuery(sql);
            ddlClient.DataSource = dt;
            ddlClient.DataTextField = "Name";
            ddlClient.DataValueField = "ClientID";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("--Select Customers--", "0"));
        }

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
                    lblMessage.Text = "Customer added successfully!";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Addition failed:" + ex.Message;
            }
        }
        protected void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClientID.Value))
            {
                lblMessage.Text = "Please select the customer you wish to modify!";
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
                    lblMessage.Text = "Customer information updated successfully!";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Update failed:" + ex.Message;
            }
        }

      
        protected void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClientID.Value))
            {
                lblMessage.Text = "Please select the customers you want to delete!";
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
                    lblMessage.Text = "Deletion successful!";
                    ClearClientFields();
                    LoadClients();
                    LoadClientDropdown();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Deletion failed:" + ex.Message;
            }
        }

      
        protected void btnAddRes_Click(object sender, EventArgs e)
        {
            if (ddlClient.SelectedValue == "0")
            {
                lblResMessage.Text = "Please select a customer!";
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
                    lblResMessage.Text = "Reservation added successfully!";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "Addition failed:" + ex.Message;
            }
        }

        protected void btnUpdateRes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReservationID.Value))
            {
                lblResMessage.Text = "Please select the reservation you wish to modify first!";
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
                    lblResMessage.Text = "Reservation updated successfully!";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "Update failed:" + ex.Message;
            }
        }

        protected void btnDeleteRes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReservationID.Value))
            {
                lblResMessage.Text = "Please select the reservations you wish to delete!";
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
                    lblResMessage.Text = "Reservation cancelled successfully!";
                    ClearReservationFields();
                    LoadReservations();
                }
            }
            catch (Exception ex)
            {
                lblResMessage.Text = "Deletion failed:" + ex.Message;
            }
        }

       
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

        
        protected void gvClients_SelectedIndexChanged(object sender, EventArgs e)
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
            ddlClient.SelectedValue = clientId;
        }

      
        void ClearClientFields()
        {
            txtClientID.Value = "";
            txtName.Text = "";
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
        }

       
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