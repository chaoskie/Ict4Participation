using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class inloggen : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int failedLoginAttempts = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();
            HttpCookie usc = Request.Cookies["usrckk"];
            if (usc != null)
            {
                if (usc.Value != null)
                {
                    inputGebruikersnaam.Value = usc.Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = inputGebruikersnaam.Value;
            string password = inputWachtwoord.Value;
            string message = string.Empty;

            if (GUIHandler.LogIn(username, password, out message))
            {
                if (checkbox.Checked)
                {
                    HttpCookie usc = new HttpCookie("usrckk", inputGebruikersnaam.Value);
                    Request.Cookies.Add(usc);
                }
                
                // Put GUIHandler in session
                Session["GUIHandler_obj"] = GUIHandler;

                // Get accountdetails of logged in person
                Accountdetails ad = GUIHandler.GetMainuserInfo();

                // Open new window with chat, and redirect to hoofdmenu.aspx
                string queryString = "http://192.168.20.27:8081?userID=" + ad.ID + "&userName=" + ad.Name
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin",
                 "<script>openNewWin('" + queryString + "','" + "hoofdmenu.aspx')</script>");
            }
            else
            {
                failedLoginAttempts++;

                // Show different message if failed login attempts > 3
                if (failedLoginAttempts > 3)
                {
                    message += Environment.NewLine + "Staat uw VPN aan?";
                }

                ShowErrorMessage(message);
            }
        }

        protected void btnRegistreren_Click(object sender, EventArgs e)
        {
            Response.Redirect("registreren.aspx", false);
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }
    }
}