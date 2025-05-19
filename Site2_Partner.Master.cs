using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace badpj_integration_trial4
{
    public partial class Site2_Partner : System.Web.UI.MasterPage
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
                }
                else if (Session["role"].Equals("user"))
                {
                    Lbtn_Logout.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["name"].ToString();


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Lbtn_ManagerLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("S4_V_ManagerLogin.aspx");
        }

        protected void Lbtn_ManagerRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("S4_V_ManagerRegistration.aspx");
        }

        protected void Lbtn_Logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";

            Lbtn_Logout.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button

            Response.Redirect("S1_HomePage.aspx");

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("S2_V_UserProfile.aspx");

        }
    }

}