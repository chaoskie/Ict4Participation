using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;
using System.Web.UI.HtmlControls;

namespace Web_GUI_Layer
{
    public partial class profiel : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int mainuserID;

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

            // Get all details of mainuser
            Accountdetails mainuser = GUIHandler.GetMainuserInfo();

            // Set mainuserID
            mainuserID = mainuser.ID;

            // Set username
            username.InnerText = mainuser.Name;

            // Set image
            profielfoto.ImageUrl = mainuser.AvatarPath;

            // Set description
            userdescription.InnerText = mainuser.Description;

            // Set account role
            usertype.InnerText = string.IsNullOrEmpty(mainuser.VOGPath) ? "Hulpbehoevende" : "Vrijwilliger";

            // Insert all questions
            List<Questiondetails> questions = GUIHandler.GetAll(true).Where(i => i.PosterID == mainuser.ID).ToList();
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
                a.InnerText = "Geen vragen geplaatst! Klik hier om een vraag te plaatsen";
                a.ServerClick += btnPlaatsVraag_Click;

                li.Controls.Add(a);
            }

            // Insert all reviews placed by mainuser
            List<Reviewdetails> reviews_list1 = GUIHandler.GetAllReviews(mainuser.ID, true);
            foreach (Reviewdetails rd in reviews_list1)
            {
                // Insert a new listitem to contain the anchors
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews1_list.Controls.Add(li);

                // Insert first anchor with reviewed user name
                HtmlAnchor a1 = new HtmlAnchor();
                a1.Attributes.Add("href", "#");
                a1.InnerText = string.Format("Review over: {0}", GUIHandler.GetAll().Find(i => i.ID == rd.PostedToID).Name);
                a1.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a1.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a1.ServerClick += btnGaNaarReview_Click;

                li.Controls.Add(a1);

                // Insert second anchor with the rating
                HtmlAnchor a2 = new HtmlAnchor();
                a2.Attributes.Add("href", "#");
                a2.Attributes.Add("class", "pull-right");
                a2.InnerText = string.Format("Aantal sterren: {0}", rd.Rating.ToString());
                a2.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a2.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a2.ServerClick += btnGaNaarReview_Click;

                li.Controls.Add(a2);

            }
            // Insert message if reviews count == 0
            if (reviews_list1.Count == 0)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews1_list.Controls.Add(li);
                
                HtmlAnchor a = new HtmlAnchor();
                a.Attributes.Add("href", "#");
                a.InnerText = "Geen reviews geplaatst!";

                li.Controls.Add(a);
            }

            // Insert all reviews placed by other people about mainuser
            List<Reviewdetails> reviews_list2 = GUIHandler.GetAllReviews(mainuser.ID, false);
            foreach (Reviewdetails rd in reviews_list2)
            {
                // Insert a new listitem to contain the anchors
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews2_list.Controls.Add(li);

                // Insert first anchor with reviewed user name
                HtmlAnchor a1 = new HtmlAnchor();
                a1.Attributes.Add("href", "#");
                a1.InnerText = string.Format("Review over: {0}", GUIHandler.GetAll().Find(i => i.ID == rd.PostedToID).Name);
                a1.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a1.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a1.ServerClick += btnGaNaarReview_Click;

                li.Controls.Add(a1);

                // Insert second anchor with the rating
                HtmlAnchor a2 = new HtmlAnchor();
                a2.Attributes.Add("href", "#");
                a2.Attributes.Add("class", "pull-right");
                a2.InnerText = string.Format("Aantal sterren: {0}", rd.Rating.ToString());
                a2.Attributes.Add("data-review-id", Convert.ToString(rd.PostID));
                a2.Attributes.Add("data-reviewacc-id", Convert.ToString(rd.PostedToID));
                a2.ServerClick += btnGaNaarReview_Click;

                li.Controls.Add(a2);
            }

            // Insert message if reviews count == 0
            if (reviews_list2.Count == 0)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                reviews2_list.Controls.Add(li);

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

        protected void btnWijzigGegevens_Click(object sender, EventArgs e)
        {
            Response.Redirect("wijziggegevens.aspx", false);
        }

        protected void btnPlaatsVraag_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GUIHandler.GetMainuserInfo().VOGPath))
            {
                Response.Redirect("plaatsvraag.aspx", false);
                return;
            }

            ShowErrorMessage("Een vrijwilliger kan geen vraag plaatsen!");
        }

        protected void btnGebruikers_Click(object sender, EventArgs e)
        {
            Response.Redirect("gebruikers.aspx", false);
        }

        private void btnNaarVraag_Click(object sender, EventArgs e)
        {
            int q_id = Convert.ToInt32(((HtmlAnchor)sender).Attributes["data-question-id"]);

            Session["QuestionDetails_id"] = q_id;

            Response.Redirect("vraag.aspx", false);
        }

        private void btnGaNaarReview_Click(object sender, EventArgs e)
        {
            // Get reviewID from data attribute
            int r_id = Convert.ToInt32((sender as HtmlAnchor).Attributes["data-review-id"]);
            int r_accID = Convert.ToInt32((sender as HtmlAnchor).Attributes["data-reviewacc-id"]);

            Session["ReviewDetails_id"] = r_id;
            Session["ReviewUser_id"] = r_accID;

            Response.Redirect("review.aspx", false);
        }

        private void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        [System.Web.Services.WebMethod]
        public static string ChangeUserDescription(string str)
        {
            string message = string.Empty;

            // update username
            GUIHandler tempGuiHandler = new GUIHandler();

            // Load all accounts
            tempGuiHandler.GetAll();

            // Get mainuser account details
            Accountdetails ad = tempGuiHandler.GetInfo(true, mainuserID);

            // Change account description
            ad.Description = str;
            
            tempGuiHandler.Edit(ad, out message);

            // Edit doesnt work currently as this is a static method and mainuser is undefined
            //tempGuiHandler.Edit(ad, out message);

            // Return user description
            return ad.Description;
        }

        [System.Web.Services.WebMethod]
        public static string GetUser(int id)
        {
            GUIHandler tempGUIHandler = new GUIHandler();
            Accountdetails account = tempGUIHandler.GetInfo(true, id);

            // Check if a user got returned
            if (account.Name == string.Empty)
            {
                return "null";
            }

            return account.Name + ":" + account.AvatarPath + ":" + (account.VOGPath == null ? 0 : 1);
        }
    }
}