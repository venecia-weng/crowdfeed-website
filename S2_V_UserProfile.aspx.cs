using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace badpj_integration_trial4
{
    public partial class S2_V_UserProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null)
                {
                    return;
                }

                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("S2_V_ManagerLogin.aspx");
                }
                else
                {

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("S2_V_ManagerLogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("S2_V_ManagerLogin.aspx.aspx");
            }
            else
            {
                updateUserPersonalDetails();

            }
        }

        // user defined function


        void updateUserPersonalDetails()
        {
            string password = "";
            if (tb_NewPw.Text.Trim() == "")
            {
                password = tb_OldPw.Text.Trim();
            }
            else
            {
                password = tb_NewPw.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update Managers set Password=@password WHERE Manager_ID='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@password", password);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();

                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Managers where Manager_ID='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                tb_ManagerID.Text = dt.Rows[0]["Manager_ID"].ToString();
                tb_Name.Text = dt.Rows[0]["Name"].ToString();
                tb_MallName.Text = dt.Rows[0]["Mall_Name"].ToString();
                tb_OldPw.Text = dt.Rows[0]["Password"].ToString();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}