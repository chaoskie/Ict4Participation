using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class hoofdmenu : System.Web.UI.Page
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

            // Get all user info
            Accountdetails accDetails = GUIHandler.GetMainuserInfo();

            // Insert user name and role
            user_naam.InnerHtml = accDetails.Name;
        }

        protected void btnAfmelden_Click(object sender, EventArgs e)
        {
            // Remove GUIHandler
            Session["GUIHandler_obj"] = null;

            Response.Redirect("inloggen.aspx", false);
        }

        protected void btnVragen_Click(object sender, EventArgs e)
        {
            //Response.Redirect("...");
        }
        
        protected void btnZoeken_Click(object sender, EventArgs e)
        {
            Response.Redirect("zoeken.aspx", false);
        }

        protected void btnProfiel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }
    }
}