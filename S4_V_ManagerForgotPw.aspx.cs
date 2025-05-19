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
    public partial class S4_V_ManagerForgotPw : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["CrowdFeedDTB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_OTP_Click(object sender, EventArgs e)
        {
            string emailAddress = tb_ManagerID.Text;

            // check if the email address exists in the database
            if (CheckEmailExists())
            {
                // generate a reset password token and send it to the user
                string resetToken = GenerateResetToken(emailAddress);
                SendResetPasswordEmail(emailAddress, resetToken);

                // show a success message
                Response.Write("<script>alert('An email has been sent to your email address. Please follow the instructions to reset your password.');</script>");
                Response.Redirect("S4_V_EnterOTP.aspx");
            }

            else
            {
                Response.Write("<script>alert('This email is not registered in our database.');</script>");
            }

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

        private string GenerateResetToken(string email)
        {
            // generate a reset password token
            string resetToken = Guid.NewGuid().ToString();

            // store the reset password token in the database
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Managers SET reset_token = @resetToken WHERE Manager_ID = @email", connection);
                command.Parameters.AddWithValue("@resetToken", resetToken);
                command.Parameters.AddWithValue("@email", email);

                command.ExecuteNonQuery();
            }

            return resetToken;
        }
        private void SendResetPasswordEmail(string email, string OTP)
        {
            // Sender's email
            string fromEmail = "venecia.weng@gmail.com";

            // Sender's email password
            string password = "fppbsaloqsftmqgy";

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
            mail.To.Add(tb_ManagerID.Text);

            // Email subject
            mail.Subject = "One-Time Password";

            // Email body
            mail.Body = "Hello, " +
            "Your One-Time Password is: " + OTP + " Please use this password to complete your verification. " +
            "Thank you, CrowdFeed Support Team";

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
    }
}