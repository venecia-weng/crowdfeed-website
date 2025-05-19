using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace badpj_integration_trial4
{
    public partial class S3_A_OutletInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            if (fl_OutletImage.HasFile == true)
            {
                image = "Imgs\\" + fl_OutletImage.FileName;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Outlets WHERE Mall_ID = @Mall_ID AND Outlet_Name = @Outlet_Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Mall_ID", ddl_MallID.SelectedValue);
                    command.Parameters.AddWithValue("@Outlet_Name", tb_OutletName.Text);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        Response.Write(tb_OutletName.Text + " has already been registered for " + ddl_MallID.SelectedItem + ". Please select another Mall Name or Outlet Name");
                    }
                    else
                    {

                        Outlet outlet = new Outlet(int.Parse(ddl_MallID.SelectedValue), tb_OutletName.Text, tb_OutletCode.Text, int.Parse(tb_OutletSeatNo.Text), fl_OutletImage.FileName);
                        result = outlet.OutletInsert();

                        if (result > 0)
                        {
                            string saveimg = Server.MapPath(" ") + "\\" + image;
                            lbl_Result.Text = saveimg.ToString();
                            fl_OutletImage.SaveAs(saveimg);
                            //loadProductInfo();
                            //loadProduct();
                            //clear1();
                            Response.Write("<script>alert('Insert successful');</script>");
                        }
                        else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
                    }
                }
            }

            string query2 = @"
insert into Mall_Info (Mall_ID, Mall_Name, Mall_Location, Mall_Image, Outlet_Name, Outlet_Code, Outlet_SeatNo, Outlet_Image)
select Malls.Mall_ID, Malls.Mall_Name, Malls.Mall_Location, Malls.Mall_Image, Outlets.Outlet_Name, Outlets.Outlet_Code, Outlets.Outlet_SeatNo, Outlets.Outlet_Image
from Malls
inner join Outlets on Malls.Mall_ID = Outlets.Mall_ID
where not exists (select 1 from Mall_Info where Mall_Info.Outlet_Code = Outlets.Outlet_Code)
";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query2, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}