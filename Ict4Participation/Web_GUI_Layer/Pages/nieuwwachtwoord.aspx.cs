using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class nieuwwachtwoord : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private string unhash;
        private string hash;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();

            if (Request.QueryString["q"] == null)
            {
                Response.Redirect("inloggen.aspx", false);
            }
            else
            {
                hash = Request.QueryString["q"];
                hash = hash.Replace(' ', '+');
                try
                {
                    GUIHandler.Unhash("", hash);
                }
                catch
                {
                    Response.Redirect("inloggen.aspx", false);
                    return;
                }
                if (GUIHandler.CheckValidRecoveryPassword(hash))
                {
                    Response.Redirect("inloggen.aspx", false);
                    return;
                }
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("inloggen.aspx", false);
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // Get first password
            string password1 = inputWachtwoord.Value;

            // Get second password
            string password2 = inputHerhaalWachtwoord.Value;
            List<Accountdetails> allaccs = GUIHandler.GetAll();

            Accountdetails acc = null;
            foreach (Accountdetails a in allaccs)
            {
                if (GUIHandler.Unhash(a.Username, hash))
                {
                    unhash = a.Username;
                    acc = a;
                    break;
                }
            }

            if (acc != null)
            {
                if (!GUIHandler.ChangePassword(acc.ID, password1, password2, hash, out message))
                {
                    ShowErrorMessage(message, true);
                }
                else
                {
                    ShowErrorMessage("Het wachtwoord is gewijzigd! U wordt teruggestuurd in 3 seconden", false);
                }
            }
            else
            {
                ShowErrorMessage("Kan gebruiker niet vinden!", true);
            }

            Response.AddHeader("REFRESH", "3;URL=inloggen.aspx");
        }

        protected void ShowErrorMessage(string message, bool isError)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");

            error_message.CssClass = isError ? error_message.CssClass.Replace("error-green", "error-red")
                                             : error_message.CssClass.Replace("error-red", "error-green");
        }
    }
}