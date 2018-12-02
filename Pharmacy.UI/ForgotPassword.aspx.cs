using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pharmacy.DAL;
using System.Data;
using System.Net.Mail;
public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        DALUser obj = new DALUser();
        DataSet ds = obj.User_GetLoginDetails(txtEmail.Text.Trim());

        if (ds.Tables[0].Rows.Count > 0)
        {
            string from = "m.zahidkamran@gmail.com";
            string to = txtEmail.Text.Trim();

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from, "My Pharmacy", System.Text.Encoding.UTF8);
            mail.Subject = "Password Recovery Email";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Dear Valued Customer," + ds.Tables[0].Rows[0]["FullName"].ToString() + "<br/>" +
                        "Your login details are as follows:<br/><br/>" +
                        "<b>Member ID:" + txtEmail.Text.Trim() + "</b> <br/>" +
                        "<b>Password:" + ds.Tables[0].Rows[0]["Password"].ToString() + "</b> <br/><br/>" +
                        "MyPharmacy Support Team<br/>" +
                        "www.mypharmacy.com";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(from, "bsit6861668");

            //client.UseDefaultCredentials = true;
            client.Port = 25; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
                lblMessage.Text = "Email sent successfully!";
            }
            catch (Exception ex)
            {
                obj.ErrorLog_Add(ex.Message);
                lblMessage.Text = "Our email server is in process of upgradation.\nTry after sometime.";
            }
        }
        else
        {
            lblMessage.Text = "Invalid Email";
        }
    }
}