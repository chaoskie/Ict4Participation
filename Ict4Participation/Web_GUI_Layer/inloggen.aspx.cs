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

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = inputGebruikersnaam.Value;
            string password = inputWachtwoord.Value;
            string message = string.Empty;

            if (GUIHandler.LogIn(username, password, out message))
            {
                Response.Redirect("hoofdmenu.aspx");
            }
            else
            {
                error_message.Text = message;
                error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
            }
        }

        protected void btnRegistreren_Click(object sender, EventArgs e)
        {
            Response.Redirect("registreren.aspx");
        }
    }
}