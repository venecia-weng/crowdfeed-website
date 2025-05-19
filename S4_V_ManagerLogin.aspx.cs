using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace badpj_integration_trial4
{
    public partial class S4_V_ManagerLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Managers where Manager_ID='" + tb_ManagerID.Text.Trim() + "' AND Password='" + tb_Password.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["name"] = dr.GetValue(1).ToString();
                        Session["role"] = "user";
                        Response.Write("<script>alert('Login Successful');</script>");
                        Response.Redirect("S2_HomePage.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Incorrect password');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }

        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("S4_V_ManagerRegistration.aspx");
        }

        protected void Lbtn_ResetPw_Click(object sender, EventArgs e)
        {
            Response.Redirect("S4_V_ManagerForgotPw.aspx");
        }
    }
}