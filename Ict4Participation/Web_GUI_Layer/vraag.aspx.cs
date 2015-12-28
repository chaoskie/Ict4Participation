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
            int q_id = Convert.ToInt32(Session["QuestionDetails_id"]);

            Questiondetails qd = GUIHandler.GetAll(true).Where(vraag => vraag.PostID == Convert.ToInt32(Session["QuestionDetails_id"])).ToList()[0];

            // Fill in forms
            Accountdetails ad = GUIHandler.GetAll().Where(account => account.ID == qd.PosterID).ToList()[0];
            vraag_naam.InnerText = ad.Name;
            vraag_titel.InnerText = qd.Title;
            vraag_startdatum.InnerText = ((DateTime)qd.StartDate).ToString("dd-MM-yyyy HH:mm:ss");
            vraag_einddatum.InnerText = ((DateTime)qd.EndDate).ToString("dd-MM-yyyy HH:mm:ss");
            vraag_locatie.InnerText = qd.Location;
            
            if (qd.Urgent)
            {
                vraag_urgentie.InnerText = "Urgent";
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }
    }
}