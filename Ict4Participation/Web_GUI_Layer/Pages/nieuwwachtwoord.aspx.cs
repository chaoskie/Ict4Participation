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

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();

            if (Request.QueryString["q"] == null)
            {
                Response.Redirect("inloggen.aspx", false);
            }
            else
            {
                string hash = Request.QueryString["q"];

                try
                {
                    //unhash = 
                }
                catch
                {
                    Response.Redirect("inloggen.aspx", false);
                }
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("inloggen.aspx", false);
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            // Get first password
            string password1 = inputWachtwoord.Value;

            // Get second password
            string password2 = inputHerhaalWachtwoord.Value;

            // Get hash from url

            //Accountdetails acc = GUIHandler.GetAll().Where(i => i.Username == );

        }
    }
}