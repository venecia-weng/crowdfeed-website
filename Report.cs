using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace badpj_integration_trial4
{
    public class Report
    {
        string _connStr = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        private int _reportIDAutoIncrement = 0;
        private string _mallName = "";
        private string _outletName = "";
        private string _businessEmail = "";
        private string _partnerName = "";
        private string _reportFault = "";
        private string _reportIssue = "";
        private string _checkUpDate = "";


        // Default constructor
        public Report()
        {
        }

        // Constructor that take in all data required to build a Product object
        public Report(int reportIDAutoIncrement, string mallName, string outletName, string businessEmail, string partnerName, string reportFault, string reportIssue, string checkUpDate)
        {
            _reportIDAutoIncrement = reportIDAutoIncrement;
            _mallName = mallName;
            _outletName = outletName;
            _businessEmail = businessEmail;
            _partnerName = partnerName;
            _reportFault = reportFault;
            _reportIssue = reportIssue;
            _checkUpDate = checkUpDate;
        }

        // Constructor that take in all except product ID
        public Report(string mallName, string outletName, string businessEmail, string partnerName, string reportFault, string reportIssue, string checkUpDate)

            : this(0, mallName, outletName, businessEmail, partnerName, reportFault, reportIssue, checkUpDate)
        {
        }

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public Report(int reportIDAutoIncrement)
            : this(reportIDAutoIncrement, "", "", "", "", "", "", "")
        {
        }

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public int Report_Id_AutoIncrement
        {
            get { return _reportIDAutoIncrement; }
            set { _reportIDAutoIncrement = value; }
        }
        public string Mall_Name
        {
            get { return _mallName; }
            set { _mallName = value; }
        }
        public string Outlet_Name
        {
            get { return _outletName; }
            set { _outletName = value; }
        }
        public string Business_Email
        {
            get { return _businessEmail; }
            set { _businessEmail = value; }
        }
        public string Partner_Name
        {
            get { return _partnerName; }
            set { _partnerName = value; }
        }
        public string Report_Fault
        {
            get { return _reportFault; }
            set { _reportFault = value; }
        }
        public string Report_Issue
        {
            get { return _reportIssue; }
            set { _reportIssue = value; }
        }
        public string CheckUp_Date
        {
            get { return _checkUpDate; }
            set { _checkUpDate = value; }
        }

        //Below as the Class methods for some DB operations. 
        public Report getReport(string reportIDAutoIncrement)
        {
            Report reportDetail = null;

            string mall_Name, outlet_Name, business_Email, partner_Name, report_Fault, report_Issue, checkUp_Date;

            int reportID;
            if (int.TryParse(reportIDAutoIncrement, out reportID))
            {
                string queryStr = "SELECT * FROM Reports WHERE Report_Id_AutoIncrement = @Report_Id_AutoIncrement";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@Report_Id_AutoIncrement", reportID);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    mall_Name = dr["Mall_Name"].ToString();
                    outlet_Name = dr["Outlet_Name"].ToString();
                    business_Email = dr["Business_Email"].ToString();
                    partner_Name = dr["Partner_Name"].ToString();
                    report_Fault = dr["Report_Fault"].ToString();
                    report_Issue = dr["Report_Issue"].ToString();
                    checkUp_Date = dr["CheckUp_Date"].ToString();


                    reportDetail = new Report(reportID, mall_Name, outlet_Name, business_Email, partner_Name, report_Fault, report_Issue, checkUp_Date);
                }
                else
                {
                    reportDetail = null;
                }

                conn.Close();
                dr.Close();
                dr.Dispose();
            }

            return reportDetail;
        }



        public List<Report> getReportAll()
        {
            List<Report> reportList = new List<Report>();

            string mall_Name, outlet_Name, business_Email, partner_Name, report_Fault, report_Issue, checkUp_Date;
            int reportIDAutoIncrement;

            string queryStr = "SELECT * FROM Reports Order By Report_Id_AutoIncrement";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                reportIDAutoIncrement = int.Parse(dr["Report_Id_AutoIncrement"].ToString());
                mall_Name = dr["Mall_Name"].ToString();
                outlet_Name = dr["Outlet_Name"].ToString();
                business_Email = dr["Business_Email"].ToString();
                partner_Name = dr["Partner_Name"].ToString();
                report_Fault = dr["Report_Fault"].ToString();
                report_Issue = dr["Report_Issue"].ToString();
                checkUp_Date = dr["CheckUp_Date"].ToString();
                Report a = new Report(reportIDAutoIncrement, mall_Name, outlet_Name, business_Email, partner_Name, report_Fault, report_Issue, checkUp_Date);
                reportList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return reportList;
        }

        public int ReportInsert()
        {
            int result = 0;

            string queryStr = "INSERT INTO Reports(Report_Id_AutoIncrement,Mall_Name,Outlet_Name, Business_Email, Partner_Name,Report_Fault,Report_Issue,CheckUp_Date)"
            + " values (@Report_ID,@Mall_Name, @Outlet_Name, @Business_Email, @Partner_Name,@Report_Fault,@Report_Issue,@CheckUp_Date)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Report_Id_AutoIncrement", this.Report_Id_AutoIncrement);
            cmd.Parameters.AddWithValue("@Mall_Name", this.Mall_Name);
            cmd.Parameters.AddWithValue("@Outlet_Name", this.Outlet_Name);
            cmd.Parameters.AddWithValue("@Business_Email", this.Business_Email);
            cmd.Parameters.AddWithValue("@Partner_Name", this.Partner_Name);
            cmd.Parameters.AddWithValue("@Report_Fault", this.Report_Fault);
            cmd.Parameters.AddWithValue("@Report_Issue", this.Report_Issue);
            cmd.Parameters.AddWithValue("@CheckUp_Date", this.CheckUp_Date);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }
        //end Insert

        public int ReportDelete(string ID)
        {
            string queryStr = "DELETE FROM Reports WHERE Report_Id_AutoIncrement=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            // Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete


        public int ReportUpdate(int rId, string rBizEmail,string rPartName, string rMallName, string rOutletName, string rFault, string rIssue, string rCheckUp)
        {
            string queryStr = "UPDATE Reports SET" +
                " Mall_Name = @mallName, " +
                " Outlet_Name = @outletName, " +
                " Business_Email = @businessEmail, " +
                " Partner_Name = @partnerName, " +
                " Report_Fault = @reportFault, " +
                " Report_Issue = @reportIssue, " +
                " CheckUp_Date = @checkUpDate " +
                " WHERE Report_Id_AutoIncrement = @reportIDAutoIncrement";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@reportIDAutoIncrement", rId);
            cmd.Parameters.AddWithValue("@mallName", rMallName);
            cmd.Parameters.AddWithValue("@outletName", rOutletName);
            cmd.Parameters.AddWithValue("@businessEmail", rBizEmail);
            cmd.Parameters.AddWithValue("@partnerName", rPartName);
            cmd.Parameters.AddWithValue("@reportFault", rFault);
            cmd.Parameters.AddWithValue("@reportIssue", rIssue);
            cmd.Parameters.AddWithValue("@checkUpDate", rCheckUp);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;

        }//end Update



    }

}