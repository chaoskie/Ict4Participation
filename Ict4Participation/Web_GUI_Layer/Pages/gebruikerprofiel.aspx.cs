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

            Page.Title = "Profiel van " + ad.Name.Split()[0];

            // Set user details
            profielfoto.ImageUrl = ad.AvatarPath;
            username.InnerText = ad.Name;
            userdescription.InnerText = ad.Description;

            // Check if user is hulpverlener
            if (!string.IsNullOrEmpty(ad.VOGPath))
            {
                usertype.InnerText = "Vrijwilliger";
                RowRevsFrom.Visible = false;
                RowQuestionsFrom.Visible = false;
            }
            else
            {
                RowRevsOf.Visible = false;
            }

            userdescription.InnerText = ad.Description;
            useremail.InnerText = ad.Email;
            userphonenr.InnerText = ad.Phonenumber;

            //If the main user is not a 'hulpbehoevende' or if the user selected is a 'hulpbehoevende'
            if (!string.IsNullOrEmpty(GUIHandler.GetMainuserInfo().VOGPath) || string.IsNullOrEmpty(ad.VOGPath))
            {
                btnPlaatsReview.Visible = false;
                btnTerug.Style["width"] = "50%";
                btnPlanMeeting.Style["width"] = "50%";
            }

            usergender.InnerText = ad.Gender.ToLower() == "m" ? "Man" : "Vrouw";
            userlogindate.InnerText = string.Format("{0} heeft voor het laatst ingelogd op: {1}", ad.Name, ad.Lastlogin.ToString("dd-M-yyyy HH:mm"));
            
            if ((bool) ad.hasVehicle)
            {
                vervoer_auto.Visible = true;
                username2.InnerText = ad.Name;
            }

            if ((bool) ad.hasDriverLicense)
            {
                vervoer_auto.Visible = true;
                username3.InnerText = ad.Name;
            }

            if ((bool) ad.OVPossible)
            {
                vervoer_ov.Visible = true;
                username4.InnerText = ad.Name;
            }

            // Enable text if user has no traveling options
            if (!(bool) ad.hasVehicle &&
                !(bool) ad.hasDriverLicense &&
                !(bool) ad.OVPossible)
            {
                vervoer_geen.Visible = true;
                username5.InnerText = ad.Name;
            }

            // Get mainuser accountdetails
            Accountdetails m_ad = GUIHandler.GetMainuserInfo();

            // Add address, city and birthdate only if mainuser is a volunteer
            if (!string.IsNullOrEmpty(m_ad.VOGPath))
            {
                vrijwilliger_only.Visible = true;

                userstreet.InnerText = ad.Address;
                usercity.InnerText = ad.City;
                userbirthdate.InnerText = ad.Birthdate.ToString("dd MMM yyyy");
            }


            // Fill in all available days
            foreach (Availabilitydetails avail in ad.AvailabilityDetailList)
            {
                string dayToUpdate = string.Format("rooster_{0}_{1}", avail.Day, avail.Daytime);

                ((HtmlInputButton) FindControl(dayToUpdate)).Attributes["class"] = "beschikbaar";
            }

            // Insert all questions
            List<Questiondetails> questions = GUIHandler.GetAll(true).Where(i => i.PosterID == u_id).ToList();
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
            List<Reviewdetails> reviews_list_1 = GUIHandler.GetAllReviews(u_id, true);
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
                
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = "Geen reviews geplaatst!";

                li.Controls.Add(p);
            }

            // Insert all reviews placed by other people about mainuser
            List<Reviewdetails> reviews_list_2 = GUIHandler.GetAllReviews(u_id, false);
            foreach (Reviewdetails rd in reviews_list_2)
            {
                // Insert a new listitem to contain the anchors
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews_list2.Controls.Add(li);

                // Insert first anchor with reviewed user name
                HtmlAnchor a1 = new HtmlAnchor();
                a1.Attributes.Add("href", "#");
                a1.InnerText = string.Format("Review van: {0}", GUIHandler.GetAll().Find(i => i.ID == rd.PosterID).Name);
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
                
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = "Geen reviews geplaatst!";

                li.Controls.Add(p);
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

        protected void btnPlanMeeting_Click(object sender, EventArgs e)
        {
            // Check if user can plan meeting with this person
            if (mainuser_id == u_id)
            {
                ShowErrorMessage("U kunt geen ontmoeting plannen met uzelf!");
                return;
            }

            Session["RequesterID"] = u_id;

            Response.Redirect("planmeeting.aspx", false);
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