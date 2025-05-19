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
    public partial class S3_A_MallInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT IDENT_CURRENT('Malls')", connection))
                {
                    int lastId = Convert.ToInt32(command.ExecuteScalar());
                    tb_MallID.Text = (lastId + 1).ToString();
                }
            }
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            if (fl_MallImage.HasFile == true)
            {
                image = fl_MallImage.FileName;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query1 = "SELECT COUNT(*) FROM Malls WHERE Mall_Name = @Mall_Name";
                string query2 = "SELECT COUNT(*) FROM Malls WHERE Mall_ID = @Mall_ID";

                using (SqlCommand command1 = new SqlCommand(query1, connection))
                {
                    command1.Parameters.AddWithValue("@Mall_Name", ddl_MallName.SelectedValue);

                    int count1 = (int)command1.ExecuteScalar();

                    if (count1 > 0)
                    {
                        Response.Write("<script>alert('" + ddl_MallName.SelectedValue + " has already been registered. Please select another Mall Name');</script>");
                    }
                    else
                    {
                        using (SqlCommand command2 = new SqlCommand(query2, connection))
                        {
                            command2.Parameters.AddWithValue("@Mall_ID", tb_MallID.Text);

                            int count2 = (int)command2.ExecuteScalar();

                            if (count2 > 0)
                            {
                                Response.Write("<script>alert('Mall_ID" + tb_MallID.Text + " is already in use. Please refresh the page for a new Mall ID');</script>");
                            }
                            else
                            {
                                Mall mall = new Mall(ddl_MallName.SelectedValue, tb_MallLocation.Text, fl_MallImage.FileName);
                                result = mall.MallInsert();
                                if (result > 0)
                                {
                                    string saveimg = Server.MapPath("~/Imgs/") + "\\" + image;
                                    lbl_Result.Text = saveimg.ToString();
                                    fl_MallImage.SaveAs(saveimg);
                                    //loadProductInfo();
                                    //loadProduct();
                                    //clear1();
                                    Response.Write("<script>alert('Insert successful');</script>");
                                }
                                else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
                            }
                        }
                    }
                }
            }
        }

    }
}