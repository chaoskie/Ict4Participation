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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                Accountdetails mainuser = GUIHandler.GetMainuserInfo();

                // Set username
                username.InnerText = mainuser.Name;

                // TODO: add description to account and database

                // Insert all questions
                List<Questiondetails> questions = GUIHandler.GetAll(true);
                foreach (Questiondetails qd in questions)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    vragen_list.Controls.Add(li);

                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    a1.Attributes.Add("href", "#");
                    a1.InnerText = qd.Title;

                    li.Controls.Add(a1);
                }
                // Insert message if questions count == 0
                if (questions.Count == 0)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    vragen_list.Controls.Add(li);

                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", "#");
                    a.InnerText = "Geen vragen geplaatst! Klik hier om een vraag te plaatsen";

                    li.Controls.Add(a);
                }

                // Insert all reviews
                List<Reviewdetails> reviews = GUIHandler.GetAllReviews(mainuser.ID, true);
                foreach (Reviewdetails rd in reviews)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    reviews_list.Controls.Add(li);

                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    a1.Attributes.Add("href", "#");
                    a1.InnerText = rd.Rating.ToString();

                    li.Controls.Add(a1);
                }
                // Insert message if reviews count == 0
                if (reviews.Count == 0)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    reviews_list.Controls.Add(li);

                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", "#");
                    a.InnerText = "Geen reviews geplaatst! Klik hier om een review te plaatsen";

                    li.Controls.Add(a);
                }
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnPlaatsVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("plaatsvraag.aspx", false);
        }

        protected void btnGebruikers_Click(object sender, EventArgs e)
        {
            Response.Redirect("gebruikers.aspx", false);
        }

        [System.Web.Services.WebMethod]
        public static string ChangeUserName(string str)
        {
            // update username
            GUIHandler tempGUIHandler = new GUIHandler();
            return "Nieuwe username";
        }

        [System.Web.Services.WebMethod]
        public static string ChangeUserDescription(string str)
        {
            // update username
            return "Nieuwe description";
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