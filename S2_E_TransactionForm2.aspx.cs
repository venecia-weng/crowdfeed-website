using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace badpj_integration_trial4
{
    public partial class S2_E_TransactionForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            TransactionPart1 transac = new TransactionPart1();
            string transac_id = Session["transac_id"].ToString();
            TransactionPart1 transac_info = transac.getTransaction(transac_id);
            lbl_TransactionID.Text = transac_info.Transaction_ID.ToString();

            string transac_outletsNo = Session["transac_outletsNo"].ToString();
            TransactionPart1 transac_info2 = transac.getTransaction(transac_outletsNo);
            lbl_OutletsNo.Text = transac_info.Transaction_OutletsNo.ToString();

            string transac_sensorsNo = Session["transac_sensorsNo"].ToString();
            TransactionPart1 transac_info3 = transac.getTransaction(transac_sensorsNo);
            lbl_SensorsNo.Text = transac_info.Transaction_SensorsNo.ToString();

            int sensorsNo = int.Parse(lbl_SensorsNo.Text);
            int outletsNo = int.Parse(lbl_OutletsNo.Text);

            int a = sensorsNo * 5;
            int b = outletsNo * 150;

            int total = a + b + 100;

            double totalWithTax = total * 1.08;

            lbl_Total.Text = totalWithTax.ToString();
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Transactions_Part1 WHERE otp_code ='" + tb_TransactionOTP.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Response.Write("<script>alert('Successful verification');</script>");
                            int result = 0;
                            TransactionPart2 transac = new TransactionPart2(tb_TransactionID.Text,
    int.Parse(tb_TransactionCardNo.Text), tb_TransactionExpiryDate.Text, int.Parse(tb_TransactionCVC.Text));
                            result = transac.S2_E_TransactionInsertPart2();



                            Response.Redirect("S2_E_ConfirmationPage.aspx");
                        }
                    }


                    else
                    {
                        Response.Write("<script>alert('Invalid OTP');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }

        }

        protected void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            tb_TransactionCVC.Text = tb_TransactionCVC.Text;
            tb_TransactionCardNo.Text = tb_TransactionCardNo.Text;
        }

    }
}