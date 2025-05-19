using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace badpj_integration_trial4
{
    public partial class S3_A_MallView : System.Web.UI.Page
    {
        Mall aMall = new Mall();
        Outlet aOutlet = new Outlet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<Mall> mallList = new List<Mall>();
            mallList = aMall.getMallAll();
            gvMall.DataSource = mallList;
            gvMall.DataBind();
        }

        protected void gvMall_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvMall.SelectedRow;

            string mall_ID = row.Cells[0].Text;

            Response.Redirect("S3_A_MallDetails.aspx?Mall_ID=" + mall_ID);

        }

        protected void gvMall_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMall.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvMall_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMall.EditIndex = -1;
            bind();
        }

        protected void gvMall_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Mall mall = new Mall();
            GridViewRow row = (GridViewRow)gvMall.Rows[e.RowIndex];
            string id = gvMall.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tname = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tprice = ((TextBox)row.Cells[2].Controls[0]).Text;

            result = mall.MallUpdate(tid, tname, tprice);
            if (result > 0)
            {
                Response.Write("<script>alert('Mall updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Mall NOT updated');</script>");
            }
            gvMall.EditIndex = -1;
            bind();
        }

        protected void gvMall_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Mall mall = new Mall();
            string mallID = gvMall.DataKeys[e.RowIndex].Values[0].ToString();
            try
            {
                result = mall.MallDelete(mallID);

                if (result > 0)
                {
                    Response.Write("<script>alert('Mall deleted successfully');</script>");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
                {
                    Response.Write("<script>alert('Please delete outlets under Mall ID: " + mallID + " before deleting the mall');</script>");
                }
            }
            // check if there are any records available in the database
            string queryStr = "SELECT * FROM Malls";
            string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // bind the gridview only if there are records available in the database
            if (dt.Rows.Count > 0)
            {
                gvMall.DataSource = dt;
                gvMall.DataBind();
            }
        }

        protected void gvMall_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[4].ToolTip = "Edit Resource Details";

                    // In Edit mode
                    if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState.ToString() == "Alternate, Edit")
                    {
                        // Update button
                        ((System.Web.UI.WebControls.ImageButton)(e.Row.Cells[4].Controls[0])).ToolTip = "Update Edit";

                        // Cancel button
                        ((System.Web.UI.WebControls.ImageButton)(e.Row.Cells[4].Controls[2])).ToolTip = "Cancel Edit";
                    }
                    else
                    {
                        // Select button
                        ((System.Web.UI.WebControls.ImageButton)(e.Row.Cells[4].Controls[0])).ToolTip = "Edit Mall";

                        ((System.Web.UI.WebControls.ImageButton)(e.Row.Cells[4].Controls[2])).ToolTip = "Delete Mall";

                        // Edit button
                        ((System.Web.UI.WebControls.ImageButton)(e.Row.Cells[4].Controls[4])).ToolTip = "Show Mall Details";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchField = ddlSearchField.SelectedValue;
            List<Mall> filteredMalls = new List<Mall>();

            // Get all reports
            List<Mall> allMalls = aMall.getMallAll();
            foreach (Mall mall in allMalls)
            {
                // Check if the selected search field contains the search text
                if (mall.GetType().GetProperty(searchField).GetValue(mall, null).ToString().Contains(searchText))
                {
                    filteredMalls.Add(mall);
                }

                if (filteredMalls.Count == 0)
                {
                    // Display message that no reports were found
                    lblMessage.Text = "No reports were found that match the search criteria.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
                else
                {
                    gvMall.DataSource = filteredMalls;
                    gvMall.DataBind();
                }

            }
            gvMall.DataSource = filteredMalls;
            gvMall.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("S3_S_ReportView.aspx");

        }
    }
}
