using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class wachtwoordvergeten : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("inloggen.aspx", false);
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // Get input
            string input = inputForgotPassword.Value;

            // Check if input is not null or empty
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowErrorMessage("Er is niks ingevuld!", true);
                return;
            }

            if (!GUIHandler.ValidateEmail(input, out message) && !GUIHandler.ValidateUsername(input, out message))
            {
                message = "Er is geen gebruiker gevonden met die gebruikersnaam of email.";
                ShowErrorMessage(message, true);
            }
            else
            {
                //Get user id
                int uid = GUIHandler.GetAll().Where(u => u.Email == input || u.Username == input).Select(u => u.ID).FirstOrDefault();

                //Send mail
                GUIHandler.RequestPasswordChange(uid, out message);
                ShowErrorMessage(message, false);
            }
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