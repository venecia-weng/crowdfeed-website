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
    public partial class S4_V_ManagerRegistration : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkManagerExists())
                {
                    Response.Write("<script>alert('A Manager Already Exist with this Manager ID, try a different ID');</script>");
                }
                if (checkMallExists())
                {
                    Response.Write("<script>alert('Mall Already Exist.');</script>");
                }
                else
                {
                    signUpNewManager();
                }
            }
            catch (Exception ex)
            {
                // Log the exception and show an error message to the user
                Response.Write("<script>alert('An error occurred, please try again later.');</script>");
            }
        }

        // user defined method
        bool checkManagerExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Managers where Manager_ID='" + tb_ManagerID.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        bool checkMallExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Managers where Mall_Name='" + tb_MallName.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void signUpNewManager()
        {
            int result = 0;

            Manager manager = new Manager(tb_ManagerID.Text, tb_Name.Text, tb_MallName.Text, tb_Password.Text);

            result = manager.ManagerInsert();

            if (result > 0)

            {
                Response.Write("<script>alert('Registration is successful');</script>");
                Response.Redirect("S4_V_ManagerLogin.aspx");

            }

            else { Response.Write("<script>alert('Registration NOT successful');</script>"); }
            Response.Redirect("S3_V_ManagerView.aspx");
        }
    }
}