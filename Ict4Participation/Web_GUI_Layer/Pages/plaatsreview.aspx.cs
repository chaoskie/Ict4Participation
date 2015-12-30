using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class plaatsreview : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int AccToReviewID;

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

            // Set id of user to be reviewed
            AccToReviewID = (int)Session["AccToReview_ID"];

            // Set name of user to be reviewed
            review_naam.InnerText = GUIHandler.GetInfo(true, AccToReviewID).Name;
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnPlaatsReview_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // Insert review in database
            Reviewdetails rd = new Reviewdetails();
            rd.Description = inputBeschrijving.InnerText.Trim();

            if (string.IsNullOrEmpty(rd.Description))
            {
                ShowErrorMessage(message);
                return;
            }

            // TODO: Get rating from control
            int ratingNr = Convert.ToInt32(review_rating.Attributes["data-rating-nr"].ToString());
            rd.Rating = ratingNr;

            if (rd.Rating < 1 ||
                rd.Rating > 5)
            {
                ShowErrorMessage(message);
                return;
            }

            rd.PosterID = GUIHandler.GetMainuserInfo().ID;
            rd.PostedToID = AccToReviewID;

            if (!GUIHandler.Place(rd, out message))
            {
                ShowErrorMessage(message);
                return;
            }

            // Redirect if true
            Response.Redirect("profiel.aspx", false);
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }
    }
}