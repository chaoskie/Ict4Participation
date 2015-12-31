using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class gebruikerprofiel : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int u_id;

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

            // Get user details
            Accountdetails ad = GUIHandler.GetAll().Find(i => i.ID == u_id);

            // Set username
            username.InnerText = ad.Name;

            // Check if user is hulpverlener
            if (ad.VOGPath != null)
            {
                usertype.InnerText = "Vrijwilliger";
            }

            // TODO: add description

            // Fill in all available days
            foreach (Availabilitydetails avail in ad.AvailabilityDetailList)
            {
                string dayToUpdate = string.Format("rooster_{0}_{1}", avail.Day, avail.Daytime);

                ((Button)FindControl(dayToUpdate)).Attributes["class"] = "beschikbaar";
            }

            // Insert all questions
            //List<Questiondetails> questions = GUIHandler.GetAll(true);
            //foreach (Questiondetails qd in questions)
            //{
            //    HtmlGenericControl li = new HtmlGenericControl("li");
            //    vragen_list.Controls.Add(li);

            //    HtmlAnchor a = new HtmlAnchor();
            //    a.Attributes.Add("href", "#");
            //    a.Attributes.Add("data-question-id", Convert.ToString(qd.PostID));
            //    a.InnerText = qd.Title;
            //    a.ServerClick += btnNaarVraag_Click;

            //    li.Controls.Add(a);
            //}

            // Insert message if questions count == 0
            //if (questions.Count == 0)
            //{
            //    HtmlGenericControl li = new HtmlGenericControl("li");
            //    vragen_list.Controls.Add(li);

            //    HtmlAnchor a = new HtmlAnchor();
            //    a.Attributes.Add("href", "#");
            //    a.InnerText = "Geen vragen geplaatst! Klik hier om een vraag te plaatsen";
            //    a.ServerClick += btnPlaatsVraag_Click;

            //    li.Controls.Add(a);
            //}

            // Insert all reviews
            //List<Reviewdetails> reviews = GUIHandler.GetAllReviews(mainuser.ID, true);
            //foreach (Reviewdetails rd in reviews)
            //{
            //    HtmlGenericControl li = new HtmlGenericControl("li");
            //    reviews_list.Controls.Add(li);

            //    HtmlGenericControl a = new HtmlGenericControl("a");
            //    a.Attributes.Add("href", "#");
            //    a.InnerText = rd.Rating.ToString();

            //    li.Controls.Add(a);
            //}

            // Insert message if reviews count == 0
            //if (reviews.Count == 0)
            //{
            //    HtmlGenericControl li = new HtmlGenericControl("li");
            //    reviews_list.Controls.Add(li);

            //    HtmlAnchor a = new HtmlAnchor();
            //    a.Attributes.Add("href", "#");
            //    a.InnerText = "Geen reviews geplaatst!";

            //    li.Controls.Add(a);
            //}
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnPlaatsReview_Click(object sender, EventArgs e)
        {
            if (u_id == GUIHandler.GetMainuserInfo().ID)
            {
                ShowErrorMessage("U kunt geen review plaatsen over uzelf!");
            }

            // Place ID of account to review in session
            Session["AccToReview_ID"] = u_id;

            Response.Redirect("plaatsreview.aspx", false);
            return;
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }
    }
}