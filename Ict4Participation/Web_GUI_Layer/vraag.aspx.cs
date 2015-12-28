using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class vraag : System.Web.UI.Page
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

            // Retrieve questiondetails from session
            //Questiondetails qd = GUIHandler.GetAll(true).Select(vraag => vraag.ID == Convert.ToInt32(Session["QuestionDetails_id"])).ToList()[0];

            // Fill in forms
            //vraag_naam = ...
            //vraag_titel = ...
            //vraag_startdatum = ...
            //vraag_einddatum = ...

            // Alleen iets invullen als urgentie true is
            //vraag_urgentie = ...
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }
    }
}