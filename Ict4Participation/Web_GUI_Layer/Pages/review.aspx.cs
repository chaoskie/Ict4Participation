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
        private static int r_accID;

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
            r_accID = Convert.ToInt32(Session["ReviewUser_id"]);

            // Get mainuser ID
            int mainuserID = GUIHandler.GetMainuserInfo().ID;

            // Get reviewdetails
            Reviewdetails rd = GUIHandler.GetAllReviews(r_accID, false).Find(i => i.PostID == r_id);

            // Get accountdetails of postedUser
            Accountdetails ad_reviewer = GUIHandler.GetAll().Find(i => i.ID == rd.PosterID);

            // Get accountdetails of reviewed user
            Accountdetails ad = GUIHandler.GetAll().Find(i => i.ID == rd.PostedToID);

            // Remove delete button if mainuser is not the owner of the review
            if (mainuserID != rd.PosterID)
            {
                btnDeleteReview.Visible = false;
            }

            // Fill in reviewed user details
            reviewende_naam1.InnerText = ad.Name;
            reviewende_naam2.InnerText = ad.Name;
            reviewende_image.ImageUrl = ad.AvatarPath;

            if (!string.IsNullOrWhiteSpace(ad.VOGPath))
            {
                reviewende_type.InnerText = "Vrijwilliger";
            }
            
            // Fill in review details
            review_body.InnerText = rd.Description;
            review_rating.Attributes["data-rating-nr"] = Convert.ToString(rd.Rating);

            // Fill in reviewer details
            reviewer_naam.InnerText = ad_reviewer.Name;
            reviewer_image.ImageUrl = ad_reviewer.AvatarPath;

            if (ad.VOGPath != null)
            {
                reviewer_type.InnerText = "Vrijwilliger";
            }
        }

        protected void btnDeleteReview_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (!GUIHandler.RemoveReview(r_id, out message))
            {
                ShowErrorMessage(message);
            }

            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        private void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }
    }
}