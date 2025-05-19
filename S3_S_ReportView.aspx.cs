using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace badpj_integration_trial4
{
    public partial class S3_S_ReportView : System.Web.UI.Page
    {
        Report aReport = new Report();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            List<Report> reportList = new List<Report>();
            reportList = aReport.getReportAll();
            gvReport.DataSource = reportList;
            gvReport.DataBind();
        }

        protected void gvReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Report report = new Report();
            string Report_Id_AutoIncrement = gvReport.DataKeys[e.RowIndex].Value.ToString();
            result = report.ReportDelete(Report_Id_AutoIncrement);

            if (result > 0)
            {
                Response.Write("<script>alert Report Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert Report Removal NOT successfully');</script>");
            }

            Response.Redirect("S3_S_ReportView.aspx");
        }

        protected void gvReport_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvReport.EditIndex = e.NewEditIndex;
            bind();

        }

        protected void gvReport_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReport.EditIndex = -1;
            bind();

        }

        protected void gvReport_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Report report = new Report();
            GridViewRow row = (GridViewRow)gvReport.Rows[e.RowIndex];
            string tID = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tMallName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tOutletName = ((TextBox)row.Cells[2].Controls[0]).Text;
            string tBizEmail = ((TextBox)row.Cells[3].Controls[0]).Text;
            string tPartName = ((TextBox)row.Cells[4].Controls[0]).Text;
            string tFault = ((TextBox)row.Cells[5].Controls[0]).Text;
            string tIssue = ((TextBox)row.Cells[6].Controls[0]).Text;
            string tCheckUp = ((TextBox)row.Cells[7].Controls[0]).Text;

            result = report.ReportUpdate(int.Parse(tID), tPartName, tBizEmail, tMallName, tOutletName, tFault, tIssue, tCheckUp);

            if (result > 0)
            {
                Response.Write("<script>alert('Report updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Report NOT updated');</script>");
            }
            gvReport.EditIndex = -1;
            bind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string searchField = ddlSearchField.SelectedValue;
            List<Report> filteredReports = new List<Report>();

            // Get all reports
            List<Report> allReports = aReport.getReportAll();
            foreach (Report report in allReports)
            {
                // Check if the selected search field contains the search text
                if (report.GetType().GetProperty(searchField).GetValue(report, null).ToString().Contains(searchText))
                {
                    filteredReports.Add(report);
                }

                if (filteredReports.Count == 0)
                {
                    // Display message that no reports were found
                    lblMessage.Text = "No reports were found that match the search criteria.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
                else
                {
                    gvReport.DataSource = filteredReports;
                    gvReport.DataBind();
                }

            }
            gvReport.DataSource = filteredReports;
            gvReport.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("S3_S_ReportView.aspx");

        }
    }
}