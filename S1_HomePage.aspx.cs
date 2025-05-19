using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;


namespace badpj_integration_trial4
{
    public partial class S1_HomePage : System.Web.UI.Page
    {
        Mall_Info aMall = new Mall_Info();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Execute the query in Page_Load instead of Timer1_Tick
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\CrowdFeedDTB.mdf;  Integrated Security=True";
            string query = @"
insert into Mall_Info (Mall_ID, Mall_Name, Mall_Location, Mall_Image, Outlet_Name, Outlet_Code, Outlet_SeatNo, Outlet_Image)
select Malls.Mall_ID, Malls.Mall_Name, Malls.Mall_Location, Malls.Mall_Image, Outlets.Outlet_Name, Outlets.Outlet_Code, Outlets.Outlet_SeatNo, Outlets.Outlet_Image
from Malls
inner join Outlets on Malls.Mall_ID = Outlets.Mall_ID
where not exists (select 1 from Mall_Info where Mall_Info.Outlet_Code = Outlets.Outlet_Code)
";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            bind();
        }

        protected void bind()
        {
            List<Mall_Info> mallList = new List<Mall_Info>();
            mallList = aMall.getMallAll();
            MallInfoRepeater.DataSource = mallList;
            MallInfoRepeater.DataBind();
        }
    }
}
