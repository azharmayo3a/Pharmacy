using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pharmacy.DAL;
using System.Data;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userID = txtUserID.Text;
        string password = txtPassword.Text;

        DALUser obj = new DALUser();
        DataSet ds= obj.User_Login(userID, password);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session.Add("IsValid", "kuchbhi");
            Response.Redirect("Home.aspx");
        }
        else
        {
            lblMessage.Text = "Your User Id or Password don't match";
        }
    }
}