using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

namespace badpj_integration_trial4
{
    public partial class S3_S_ReportDetails : System.Web.UI.Page
    {
        Report aReport = new Report();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                if (Session["Name"] != null)
                {
                    string partnerName = Session["Name"].ToString();
                    LoadReportInfo(partnerName);
                }
            }
        }
        private void LoadReportInfo(string partnerName)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\CrowdFeedDTB.mdf;  Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Reports WHERE Partner_Name = @PartnerName", connection);
                command.Parameters.AddWithValue("@PartnerName", partnerName);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                gvReport.DataSource = table;
                gvReport.DataBind();
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

            Response.Redirect("S3_S_ReportDetails.aspx");
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

            result = report.ReportUpdate(int.Parse(tID),tPartName, tBizEmail, tMallName, tOutletName, tFault, tIssue, tCheckUp);

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


    }
}