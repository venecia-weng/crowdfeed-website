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
    public partial class S2_S_ReportRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
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
                ReportInfoRepeater.DataSource = table;
                ReportInfoRepeater.DataBind();
            }
        }
    }
}
