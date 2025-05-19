using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace badpj_integration_trial4
{
    public partial class S3_V_ManagerView : System.Web.UI.Page
    {
        Manager aManager = new Manager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

        }

        protected void bind()
        {
            List<Manager> managerList = new List<Manager>();
            managerList = aManager.getManagerAll();
            gvManager.DataSource = managerList;
            gvManager.DataBind();
        }

        protected void gvManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvManager.SelectedRow;
            string managerID = row.Cells[0].Text;
            Response.Redirect("S4_V_ManagerRegistration.aspx?ManagerID=" + managerID);
        }

        protected void gvManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Manager manager = new Manager();
            string categoryID = gvManager.DataKeys[e.RowIndex].Value.ToString();
            result = manager.ManagerDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Manager Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Manager Removal NOT successfully');</script>");
            }

            Response.Redirect("S3_V_ManagerView.aspx");

        }

        protected void gvManager_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvManager.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvManager_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvManager.EditIndex = -1;
            bind();
        }

        protected void gvManager_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Manager manager = new Manager();
            GridViewRow row = (GridViewRow)gvManager.Rows[e.RowIndex];
            string id = gvManager.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tname = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tmallname = ((TextBox)row.Cells[2].Controls[0]).Text;
            string tpassword = ((TextBox)row.Cells[3].Controls[0]).Text;

            result = manager.ManagerUpdate(tid, tname, tmallname, tpassword);
            if (result > 0)
            {
                Response.Write("<script>alert('Manager account details updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Manager account details NOT updated');</script>");
            }
            gvManager.EditIndex = -1;
            bind();

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchField = ddlSearchField.SelectedValue;
            List<Manager> filteredManagers = new List<Manager>();

            // Get all reports
            List<Manager> allManagers = aManager.getManagerAll();
            foreach (Manager manager in allManagers)
            {
                // Check if the selected search field contains the search text
                if (manager.GetType().GetProperty(searchField).GetValue(manager, null).ToString().Contains(searchText))
                {
                    filteredManagers.Add(manager);
                }

                if (filteredManagers.Count == 0)
                {
                    // Display message that no reports were found
                    lblMessage.Text = "No managers were found that match the search criteria.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
                else
                {
                    gvManager.DataSource = filteredManagers;
                    gvManager.DataBind();
                }

            }
            gvManager.DataSource = filteredManagers;
            gvManager.DataBind();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("S3_V_ManagerView.aspx");

        }
    }
}