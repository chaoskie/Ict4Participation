using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class review : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int r_id;

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

            // Retrieve reviewdetails from session
            r_id = Convert.ToInt32(Session["ReviewDetails_id"]);

            // Get mainuser ID
            int mainuserID = GUIHandler.GetMainuserInfo().ID;
        }

        protected void btnDeleteReview_Click(object sender, EventArgs e)
        {
            // TODO: Delete review
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx", false);
        }
    }
}