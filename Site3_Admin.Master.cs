using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace badpj_integration_trial4
{
    public partial class Site3_Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    return;
                }

                else if (Session["role"].Equals(""))
                {

                    Lbtn_Logout.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button


                    Lbtn_AdminLogin.Visible = true; // admin login link button


                }
                else if (Session["role"].Equals("user"))
                {
                    Lbtn_Logout.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["name"].ToString();


                    Lbtn_AdminLogin.Visible = true; // admin login link button

                }
                else if (Session["role"].Equals("admin"))
                {

                    Lbtn_Logout.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";


                    Lbtn_AdminLogin.Visible = false; // admin login link button

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void Lbtn_Logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";

            Lbtn_Logout.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button


            Lbtn_AdminLogin.Visible = true; // admin login link button

            Response.Redirect("S2_HomePage.aspx");

        }


        protected void Lbtn_AdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("S3_V_AdminLogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {

        }
    }
}
