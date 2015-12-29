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
    public partial class vraag : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int q_id;

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

            if (!IsPostBack)
            {
                // Retrieve questiondetails from session
                q_id = Convert.ToInt32(Session["QuestionDetails_id"]);

                Questiondetails qd = GUIHandler.GetAll(true).Where(vraag => vraag.PostID == Convert.ToInt32(Session["QuestionDetails_id"])).ToList()[0];

                // Fill in forms
                Accountdetails ad = GUIHandler.GetAll().Where(account => account.ID == qd.PosterID).ToList()[0];
                vraag_naam.InnerText = ad.Name;
                vraag_titel.InnerText = qd.Title;
                vraag_body.InnerText = qd.Description;
                vraag_startdatum.InnerText = ((DateTime)qd.StartDate).ToString("dd-MM-yyyy HH:mm:ss");
                vraag_einddatum.InnerText = ((DateTime)qd.EndDate).ToString("dd-MM-yyyy HH:mm:ss");
                vraag_locatie.InnerText = qd.Location;
                qProfilePhoto.ImageUrl = ad.AvatarPath;

                if (qd.Urgent)
                {
                    vraag_urgentie.InnerText = "Urgent";
                }

                // Insert all comments
                List<Commentdetails> cd_list = GUIHandler.GetAll(qd.PostID);

                // TEMP
                cd_list = null;
                foreach (Commentdetails cd in cd_list)
                {
                    string comment_template = string.Empty;
                    // TEMP
                    Accountdetails ad_poster = null; //= GUIHandler.GetInfo(true, cd.PosterID);

                    comment_template +=
                    @"<div class=""row comment-main"">" +
                        @"<div class=""col-xs-12"">" +
                            @"<div class=""row"">" +
                                @"<div class=""col-tn-6 col-tn-offset-3 col-xs-2"">";

                                comment_section.Controls.Add(new LiteralControl(comment_template));

                                HtmlImage htmlimage = new HtmlImage();
                                htmlimage.Attributes.Add("class", "img-responsive");
                                htmlimage.Src = ad_poster.AvatarPath;
                                htmlimage.Alt = "Profielfoto";

                                comment_section.Controls.Add(htmlimage);

                                comment_template =
                                @"</div>" +
                                @"<div class=""col-xs-10"">" +
                                    @"<div class=""row"">" +
                                        @"<div class=""col-xs-12"">";

                                comment_section.Controls.Add(new LiteralControl(comment_template));

                                HtmlGenericControl commentAuthor = new HtmlGenericControl("h3");
                                commentAuthor.Attributes.Add("class", "comment-author");
                                commentAuthor.InnerText = ad_poster.Name;

                                comment_section.Controls.Add(commentAuthor);

                                comment_template =
                                        @"</div>" +
                                    @"</div>" +
                                    @"<div class=""row"">" +
                                        @"<div class=""col-xs-12"">";

                                comment_section.Controls.Add(new LiteralControl(comment_template));

                                HtmlGenericControl commentBody = new HtmlGenericControl("p");
                                commentBody.Attributes.Add("class", "comment-author");
                                commentBody.InnerText = cd.Description;

                                comment_section.Controls.Add(commentBody);
                                
                                comment_template =
                                        @"</div>" +
                                    @"</div>" +
                                @"</div>" +
                            @"</div>" +
                        @"</div>" +
                    @"</div>";

                    comment_section.Controls.Add(new LiteralControl(comment_template));
                }
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnPlaatsVraag_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            Commentdetails cd = new Commentdetails();
            cd.PostedToID = q_id;
            cd.Description = tb_vraag.Text;
            cd.PostDate = DateTime.Now;

            if (!GUIHandler.Place(cd, out message))
            {
                // TODO: Show error message
            }

            tb_vraag.Text = string.Empty;
        }
    }
}