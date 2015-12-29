﻿using System;
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

            if (cd_list != null)
            {
                foreach (Commentdetails cd in cd_list)
                {
                    string comment_template = string.Empty;
                    Accountdetails ad_poster = GUIHandler.GetInfo(false, cd.PosterID);

                    comment_template +=
                    @"<div class=""row comment-main"">" +
                        @"<div class=""col-xs-12"">" +
                            @"<div class=""row"" title=""Comment geplaatst op " + cd.PostDate.ToString("d MMMM yyyy HH:mm:ss") + @""">" +
                                @"<div class=""col-tn-6 col-tn-offset-3 col-xs-2"">";

                                comment_section.Controls.Add(new LiteralControl(comment_template));

                                HtmlImage htmlimage = new HtmlImage();
                                htmlimage.Attributes.Add("class", "img-responsive");
                                htmlimage.Src = ad_poster.AvatarPath;
                                htmlimage.Alt = "Foto";

                                comment_section.Controls.Add(htmlimage);

                                comment_template =
                                @"</div>" +
                                @"<div class=""col-xs-10"">" +
                                    @"<div class=""row"">";

                                comment_section.Controls.Add(new LiteralControl(comment_template));

                                // Check if the poster is the owner of the question
                                if (ad_poster.ID == qd.PosterID)
                                {
                                    comment_template =
                                        @"<div class=""col-xs-8"">";

                                    comment_section.Controls.Add(new LiteralControl(comment_template));

                                    HtmlGenericControl commentAuthor1 = new HtmlGenericControl("h3");
                                    commentAuthor1.Attributes.Add("class", "comment-author");
                                    commentAuthor1.InnerText = ad_poster.Name;

                                    comment_section.Controls.Add(commentAuthor1);

                                    comment_template =
                                        @"</div>" +
                                        @"<div class=""col-xs-4 comment-buttons"">";

                                        comment_section.Controls.Add(new LiteralControl(comment_template));

                                        HtmlButton btnVerwijder = new HtmlButton();
                                        btnVerwijder.Attributes.Add("class", "btn pull-right btn-custom2");
                                        btnVerwijder.InnerText = "Verwijder";
                                        btnVerwijder.ServerClick += new EventHandler(btnVerwijderVraag_Click);

                                        comment_section.Controls.Add(btnVerwijder);

                                        comment_template =
                                            @"</div>" +
                                        @"</div>";

                                        comment_section.Controls.Add(new LiteralControl(comment_template));
                                }
                                else
                                {
                                    comment_template =
                                        @"<div class=""col-xs-12"">";

                                    comment_section.Controls.Add(new LiteralControl(comment_template));

                                    HtmlGenericControl commentAuthor2 = new HtmlGenericControl("h3");
                                    commentAuthor2.Attributes.Add("class", "comment-author");
                                    commentAuthor2.InnerText = ad_poster.Name;

                                    comment_section.Controls.Add(commentAuthor2);

                                    comment_template =
                                        @"</div>" +
                                    @"</div>";

                                    comment_section.Controls.Add(new LiteralControl(comment_template));
                                }
                                        
                                comment_template =
                                    @"<div class=""row"">" +
                                        @"<div class=""col-xs-12"">";

                                comment_section.Controls.Add(new LiteralControl(comment_template));

                                HtmlGenericControl commentBody = new HtmlGenericControl("p");
                                commentBody.Attributes.Add("class", "comment-body");
                                commentBody.InnerText = cd.Description;

                                if (ad_poster.ID == qd.PosterID)
                                {
                                    commentBody.Attributes.Add("contenteditable", "true");
                                }

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
            else
            {
                // TODO: Nog geen reacties text
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

        protected void btnVerwijderVraag_Click(object sender, EventArgs e)
        {
            // TODO: Delete question
        }
    }
}