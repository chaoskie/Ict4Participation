using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;
using System.Web.UI.HtmlControls;

namespace Web_GUI_Layer.Pages
{
    public partial class gebruikerprofiel : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int u_id;
        private static int mainuser_id;

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

            // Get userprofile id
            u_id = Convert.ToInt32(Session["UserProfile_ID"]);

            // Set mainuser_id
            mainuser_id = GUIHandler.GetMainuserInfo().ID;

            // Get user details
            Accountdetails ad = GUIHandler.GetAll().Find(i => i.ID == u_id);

            // Set username
            username.InnerText = ad.Name;

            // Set profilephoto
            profielfoto.ImageUrl = ad.AvatarPath;

            // Check if user is hulpverlener
            if (ad.VOGPath != null)
            {
                usertype.InnerText = "Vrijwilliger";
            }

            // TODO: add user description

            // Fill in all available days
            foreach (Availabilitydetails avail in ad.AvailabilityDetailList)
            {
                string dayToUpdate = string.Format("rooster_{0}_{1}", avail.Day, avail.Daytime);

                ((Button)FindControl(dayToUpdate)).Attributes["class"] = "beschikbaar";
            }

            // Insert all questions
            List<Questiondetails> questions = GUIHandler.GetAll(true).Where(i => i.PosterID == mainuser_id).ToList();
            foreach (Questiondetails qd in questions)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                vragen_list.Controls.Add(li);

                HtmlAnchor a = new HtmlAnchor();
                a.Attributes.Add("href", "#");
                a.Attributes.Add("data-question-id", Convert.ToString(qd.PostID));
                a.InnerText = qd.Title;
                a.ServerClick += btnNaarVraag_Click;

                li.Controls.Add(a);
            }
            // Insert message if questions count == 0
            if (questions.Count == 0)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                vragen_list.Controls.Add(li);

                HtmlAnchor a = new HtmlAnchor();
                a.Attributes.Add("href", "#");
                a.InnerText = "Geen vragen geplaatst!";

                li.Controls.Add(a);
            }

            // Insert all reviews placed by mainuser
            List<Reviewdetails> reviews_list_1 = GUIHandler.GetAllReviews(mainuser_id, false);
            foreach (Reviewdetails rd in reviews_list_1)
            {
                // Insert a new listitem to contain the anchors
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews_list1.Controls.Add(li);

                // Insert first anchor with reviewed user name
                HtmlAnchor a1 = new HtmlAnchor();
                a1.Attributes.Add("href", "#");
                a1.InnerText = string.Format("Review over: {0}", GUIHandler.GetAll().Find(i => i.ID == rd.PostedToID).Name);
                a1.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a1.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a1.ServerClick += btnNaarReview_Click;

                li.Controls.Add(a1);

                // Insert second anchor with the rating
                HtmlAnchor a2 = new HtmlAnchor();
                a2.Attributes.Add("href", "#");
                a2.Attributes.Add("class", "pull-right");
                a2.InnerText = string.Format("Aantal sterren: {0}", rd.Rating.ToString());
                a2.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a2.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a2.ServerClick += btnNaarReview_Click;

                li.Controls.Add(a2);

            }
            // Insert message if reviews count == 0
            if (reviews_list_1.Count == 0)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews_list1.Controls.Add(li);

                HtmlAnchor a = new HtmlAnchor();
                a.Attributes.Add("href", "#");
                a.InnerText = "Geen reviews geplaatst!";

                li.Controls.Add(a);
            }

            // Insert all reviews placed by other people about mainuser
            List<Reviewdetails> reviews_list_2 = GUIHandler.GetAllReviews(mainuser_id, true);
            foreach (Reviewdetails rd in reviews_list_2)
            {
                // Insert a new listitem to contain the anchors
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews_list2.Controls.Add(li);

                // Insert first anchor with reviewed user name
                HtmlAnchor a1 = new HtmlAnchor();
                a1.Attributes.Add("href", "#");
                a1.InnerText = string.Format("Review over: {0}", GUIHandler.GetAll().Find(i => i.ID == rd.PostedToID).Name);
                a1.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a1.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a1.ServerClick += btnNaarReview_Click;

                li.Controls.Add(a1);

                // Insert second anchor with the rating
                HtmlAnchor a2 = new HtmlAnchor();
                a2.Attributes.Add("href", "#");
                a2.Attributes.Add("class", "pull-right");
                a2.InnerText = string.Format("Aantal sterren: {0}", rd.Rating.ToString());
                a2.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a2.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a2.ServerClick += btnNaarReview_Click;

                li.Controls.Add(a2);
            }

            // Insert message if reviews count == 0
            if (reviews_list_2.Count == 0)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews_list2.Controls.Add(li);

                HtmlAnchor a = new HtmlAnchor();
                a.Attributes.Add("href", "#");
                a.InnerText = "Geen reviews geplaatst!";

                li.Controls.Add(a);
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnPlaatsReview_Click(object sender, EventArgs e)
        {
            // Check if account is mainuser's account
            if (u_id == mainuser_id)
            {
                ShowErrorMessage("U kunt geen review plaatsen over uzelf!");
                return;
            }

            // Check if user has already posted a review for the person
            if (GUIHandler.GetAllReviews(u_id, mainuser_id == u_id).Where(i => i.PostedToID == u_id).ToList().Count != 0)
            {
                ShowErrorMessage("U heeft al een review geplaatst over deze persoon!");
                return;
            }

            // Place ID of account to review in session
            Session["AccToReview_ID"] = u_id;

            Response.Redirect("plaatsreview.aspx", false);
        }

        protected void btnNaarVraag_Click(object sender, EventArgs e)
        {
            int q_id = Convert.ToInt32(((HtmlAnchor)sender).Attributes["data-question-id"].ToString());

            Session["QuestionDetails_id"] = q_id;

            Response.Redirect("vraag.aspx", false);
        }

        protected void btnNaarReview_Click(object sender, EventArgs e)
        {
            // Get reviewID from data attribute
            int r_id = Convert.ToInt32((sender as HtmlAnchor).Attributes["data-review-id"].ToString());
            int r_accID = Convert.ToInt32((sender as HtmlAnchor).Attributes["data-reviewacc-id"].ToString());

            Session["ReviewDetails_id"] = r_id;
            Session["ReviewUser_id"] = r_accID;

            Response.Redirect("review.aspx", false);
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }
    }
}