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

            // Get info of all users
            List<Accountdetails> all_accounts = GUIHandler.GetAll();
            Accountdetails user = null;

            // Check if accounts are retrieved
            if (all_accounts.Count > 0)
            {
                // Check if the input has an email format
                if (Check.isEmail(input))
                {
                    // Find the correct user in the accounts (emails are converted to lower to avoid capitalize mistakes, as emails capitalization shouldnt matter)
                    user = all_accounts.Find(i => i.Email.ToLower() == input.ToLower());
                }
                else
                {
                    user = all_accounts.Find(i => i.Username == input);
                }
            }

            if (user != null)
            {
                GUIHandler.ChangePass(user.ID, out message);

                ShowErrorMessage(message, false);
            }
            else
            {
                message = "Er is geen gebruiker gevonden met die gebruikersnaam of email.";
                ShowErrorMessage(message, true);
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