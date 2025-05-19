using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;


namespace badpj_integration_trial4
{
    public partial class S2_E_TransactionForm : System.Web.UI.Page
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
                    Response.Redirect("S4_V_ManagerLogin.aspx");
                }
                else
                {

                    if (!Page.IsPostBack)
                    {
                        getTransaction();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("S4_V_ManagerLogin.aspx");
            }
        }

        protected void btn_Next_Click(object sender, EventArgs e)
        {

            int result = 0;

            TransactionPart1 transac = new TransactionPart1(tb_TransactionID.Text, tb_TransactionManager.Text, tb_BizEmail.Text, tb_Mall.Text, int.Parse(tb_OutletsNo.Text), int.Parse(tb_SensorsNo.Text));
            result = transac.S1_E_TransactionInsert();
            Session["transac_id"] = tb_TransactionID.Text;
            Session["transac_outletsNo"] = tb_OutletsNo.Text;
            Session["transac_sensorsNo"] = tb_SensorsNo.Text;

            Response.Redirect("S2_E_TransactionForm2.aspx");


        }

        bool CheckEmailExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Managers where Manager_ID='" + tb_BizEmail.Text.Trim() + "';", con);
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

        private string GenerateSendOtp(string email)
        {
            // generate a reset password token
            string resetToken = Guid.NewGuid().ToString();

            // store the reset password token in the database
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Transactions_Part1 SET otp_code = @resetToken WHERE Transaction_BizEmail = @email", connection);
                command.Parameters.AddWithValue("@resetToken", resetToken);
                command.Parameters.AddWithValue("@email", email);

                command.ExecuteNonQuery();
            }

            return resetToken;
        }

        private void SendOtpEmail(string email, string OTP)
        {
            // Sender's email
            string fromEmail = "effahumairah2610@gmail.com";

            // Sender's email password
            string password = "uofz hpfe zplo tfxe";

            ICredentialsByHost credentials = new NetworkCredential(fromEmail, password);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = credentials
            };

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(tb_BizEmail.Text);

            // Email subject
            mail.Subject = "One-Time Password";

            // Email body
            mail.Body = "Hello, " +
                "Your One-Time Password is: " + OTP + " Please use this password to complete your verification. " +
                "This password will expire in 10 minutes." +
                "Thank you, Support Team";

            try
            {
                // Send the email
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        void getTransaction()
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

                tb_TransactionManager.Text = dt.Rows[0]["Name"].ToString();
                tb_BizEmail.Text = dt.Rows[0]["Manager_ID"].ToString();
                tb_Mall.Text = dt.Rows[0]["MallName"].ToString();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void btn_TransactionOTP_Click1(object sender, EventArgs e)
        {
            string emailAddress = tb_BizEmail.Text;

            // check if the email address exists in the database
            if (CheckEmailExists())
            {
                // generate a reset password token and send it to the user
                string resetToken = GenerateSendOtp(emailAddress);
                SendOtpEmail(emailAddress, resetToken);

                // show a success message
                Response.Write("<script>alert('An email has been sent to your email address. Please follow the instructions to reset your password.');</script>");

            }

            else
            {
                Response.Write("<script>alert('This email is not registered in our database.');</script>");
            }
        }
    }
}