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
    public partial class S2_S_ReportForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\CrowdFeedDTB.mdf;  Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT IDENT_CURRENT('Reports')", connection))
                {
                    int lastId = Convert.ToInt32(command.ExecuteScalar());
                    tb_ID.Text = (lastId + 1).ToString();
                }

                if (!IsPostBack)
                {
                    string name = Convert.ToString(Session["Name"]);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT Managers.Manager_ID, Managers.Name, Managers.Mall_Name FROM Managers WHERE Managers.Name = @Name", conn);
                        cmd.Parameters.AddWithValue("@Name", name);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            tb_Mall.Text = reader["Mall_Name"].ToString();
                            tb_Email.Text = reader["Manager_ID"].ToString();
                            tb_Name.Text = reader["Name"].ToString();
                        }

                        reader.Close();

                        // Add the following code to populate the dropdown with outlets
                        SqlCommand outletCommand = new SqlCommand("SELECT Outlet_Name FROM Outlets WHERE Mall_ID = (SELECT Mall_ID FROM Malls WHERE Mall_Name = @MallName)", conn);
                        outletCommand.Parameters.AddWithValue("@MallName", tb_Mall.Text);
                        SqlDataReader outletReader = outletCommand.ExecuteReader();

                        ddl_outlet.Items.Clear();
                        while (outletReader.Read())
                        {
                            ddl_outlet.Items.Add(outletReader["Outlet_Name"].ToString());
                        }

                        outletReader.Close();
                    }
                }
            }
        }



        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime selectedDate = Convert.ToDateTime(tb_date.Text);
            if (selectedDate < DateTime.Now)
            {
                args.IsValid = false;
                CustomValidator1.ErrorMessage = "Date must be today or a future date.";
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void button_Click(object sender, EventArgs e)
        {
            // Check if the email field is not empty
            if (!Page.IsValid)
            {
                return;
            }

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\CrowdFeedDTB.mdf;  Integrated Security=True";

            string selectedItems = string.Empty;
            foreach (ListItem item in cbl_item.Items)
            {
                if (item.Selected)
                {
                    selectedItems += item.Value + ",";
                }
            }
            if (!string.IsNullOrEmpty(selectedItems))
            {
                selectedItems = selectedItems.Remove(selectedItems.Length - 1);
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Check if mall name and outlet name exist in reports table
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Reports WHERE Mall_Name = @Mall_Name AND Outlet_Name = @Outlet_Name", conn);
                    cmdCheck.Parameters.AddWithValue("@Mall_Name", tb_Mall.Text);
                    cmdCheck.Parameters.AddWithValue("@Outlet_Name", ddl_outlet.SelectedValue);
                    int count = (int)cmdCheck.ExecuteScalar();

                    // If count is greater than 0, outlet has been reported
                    if (count > 0)
                    {
                        Response.Write("<script>alert('Outlet has been reported');</script>");
                        return;
                    }

                    // If count is 0, continue with INSERT statement
                    SqlCommand cmd = new SqlCommand("INSERT INTO Reports (Mall_Name, Outlet_Name, Business_Email, Partner_Name, Report_Fault, Report_Issue, CheckUp_Date) " +
                        "VALUES (@Mall_Name, @Outlet_Name, @Business_Email, @Partner_Name, @Report_Fault, @Report_Issue, @CheckUp_Date); SELECT SCOPE_IDENTITY()", conn);
                    cmd.Parameters.AddWithValue("@Mall_Name", tb_Mall.Text);
                    cmd.Parameters.AddWithValue("@Outlet_Name", ddl_outlet.SelectedValue);
                    cmd.Parameters.AddWithValue("@Business_Email", tb_Email.Text);
                    cmd.Parameters.AddWithValue("@Partner_Name", tb_Name.Text);
                    cmd.Parameters.AddWithValue("@Report_Fault", selectedItems);
                    cmd.Parameters.AddWithValue("@Report_Issue", tb_comment.Text);
                    cmd.Parameters.AddWithValue("@CheckUp_Date", tb_date.Text);
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    tb_ID.Text = newId.ToString();
                    tb_ID.ReadOnly = true;
                }
                Response.Redirect("S2_S_ReportRedirect.aspx");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('Insert NOT successful. Error: " + ex.Message + "');</script>");
            }
        }
    }
}

