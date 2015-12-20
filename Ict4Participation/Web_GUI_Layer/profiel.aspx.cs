using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class profiel : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if GUIHandler exists
            if (Session["GUIHandler_obj"] == null)
            {
                // Go back if no GUIhandler can be found
                Response.Redirect("inloggen.aspx", false);
                return;
            }

            // Retrieve GUIHandler object from session
            GUIHandler = (GUIHandler)Session["GUIHandler_obj"];

            // TODO: 
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnPlaatsVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("plaatsvraag.aspx", false);
        }

        protected void btnGebruikers_Click(object sender, EventArgs e)
        {
            Response.Redirect("gebruikers.aspx", false);
        }

        [System.Web.Services.WebMethod]
        public static string ChangeUserName(string str)
        {
            // update username
            return "Nieuwe username";
        }

        [System.Web.Services.WebMethod]
        public static string ChangeUserDescription(string str)
        {
            // update username
            return "Nieuwe description";
        }
    }
}