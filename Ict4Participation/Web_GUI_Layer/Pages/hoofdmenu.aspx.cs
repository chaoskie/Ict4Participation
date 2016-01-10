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
    public partial class hoofdmenu : System.Web.UI.Page
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
            
            // Get all user info
            Accountdetails accDetails = GUIHandler.GetMainuserInfo();

            Page.Title = "Welkom, " + accDetails.Name.Split()[0];

            // Insert user name, role and description
            user_naam.InnerText = accDetails.Name;
            user_rol.InnerText = string.IsNullOrEmpty(accDetails.VOGPath) ? "Hulpbehoevende" : "Vrijwilliger";
            user_description.InnerText = accDetails.Description;

            // Set profilephoto
            profielfoto.ImageUrl = accDetails.AvatarPath;

            // Insert availability
            List<Availabilitydetails> ad = accDetails.AvailabilityDetailList;

            // Set tablecell class to beschikbaar if user is available on that day
            if (ad != null)
            {
                foreach (Availabilitydetails a in ad)
                {
                    HtmlInputButton btn = (HtmlInputButton)FindControl(string.Format("rooster_{0}_{1}", a.Day, a.Daytime));
                    btn.Attributes["class"] = "beschikbaar";
                }
            }

            // Get mainuserID
            int mainuserID = GUIHandler.GetMainuserInfo().ID;

            // Get all accounts from GUIHandler
            List<Accountdetails> accounts_list = GUIHandler.GetAll();

            // Fill activities
            List<Meetingdetails> Meetings = GUIHandler.GetAllMeetings();
            List<QuestionAccountdetails> Activities = GUIHandler.GetActivity();

            foreach (Meetingdetails md in Meetings)
            {
                if (md.RequesterID == mainuserID || md.PosterID == mainuserID)
                {
                    // Find the other user, not this user
                    int findID = mainuserID == md.RequesterID ? md.PosterID : md.RequesterID;

                    if (md.EndDate >= DateTime.Now)
                    {
                        HtmlAnchor a = new HtmlAnchor();
                        a.InnerText = string.Format("Ontmoeting met {0}", accounts_list.Find(i => i.ID == findID).Name);
                        a.Attributes["data-meeting-id"] = Convert.ToString(md.PostID);
                        a.ServerClick += btnGaNaarMeeting_Click;

                        // Insert meeting in list
                        activiteiten_list.Controls.Add(new LiteralControl("<li>"));
                        activiteiten_list.Controls.Add(a);
                        activiteiten_list.Controls.Add(new LiteralControl("</li>"));
                    }

                    if (md.EndDate == null)
                    {
                        HtmlAnchor a = new HtmlAnchor();
                        a.InnerText = string.Format("Tijdloze ontmoeting met {0}", accounts_list.Find(i => i.ID == findID).Name);
                        a.Attributes["data-meeting-id"] = Convert.ToString(md.PostID);
                        a.ServerClick += btnGaNaarMeeting_Click;

                        // Insert meeting in list
                        activiteiten_list.Controls.Add(new LiteralControl("<li>"));
                        activiteiten_list.Controls.Add(a);
                        activiteiten_list.Controls.Add(new LiteralControl("</li>"));
                    }
                }
            }

            foreach (QuestionAccountdetails act in Activities)
            {
                HtmlAnchor a = new HtmlAnchor();
                a.InnerText = act.ToString();

                activiteiten_list.Controls.Add(new LiteralControl("<li>"));
                activiteiten_list.Controls.Add(a);
                activiteiten_list.Controls.Add(new LiteralControl("</li>"));
            }

            if (Meetings.Count == 0 && Activities.Count == 0)
            {
                activiteiten_list.Controls.Add(new LiteralControl("<li><p>Er zijn geen recente activeiten om weer te geven</p></li>"));
            }

            // Open new window with chat
            // TODO: Fix URL
            string queryString = "http://192.168.20.27:8081"; //"?userID=" + accDetails.ID + "&userName" + accDetails.Name;
            string newwin = "window.open('" + queryString + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "pop", newwin, true);
        }

        protected void btnAfmelden_Click(object sender, EventArgs e)
        {
            // Remove GUIHandler
            Session["GUIHandler_obj"] = null;

            Response.Redirect("inloggen.aspx", false);
        }

        protected void btnVragen_Click(object sender, EventArgs e)
        {
            Response.Redirect("vragen.aspx", false);
        }
        
        protected void btnZoeken_Click(object sender, EventArgs e)
        {
            Response.Redirect("zoeken.aspx", false);
        }

        protected void btnProfiel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }

        private void btnGaNaarMeeting_Click(object sender, EventArgs e)
        {
            // Set meeting ID in session
            Session["meetingID"] = Convert.ToInt32((sender as HtmlAnchor).Attributes["data-meeting-id"]); ;

            Response.Redirect("meeting.aspx", false);
        }
        
        protected void rooster_change(object sender, EventArgs e)
        {
            string message = string.Empty;

            Availabilitydetails ad = new Availabilitydetails();
            ad.Day = (sender as Button).ID.Split('_')[1];
            ad.Daytime = (sender as Button).ID.Split('_')[2];

            // Check if sender has class "beschikbaar"
            if ((sender as Button).CssClass.Contains("beschikbaar"))
            {
                // update availability in database
                if (GUIHandler.RemoveAvailability(ad, out message))
                {
                    // Update visual style on button
                    (sender as Button).CssClass = (sender as Button).CssClass.Replace("beschikbaar", string.Empty).Trim();
                }
            }
            else
            {
                // update availability in database
                if (GUIHandler.AddAvailability(ad, out message))
                {
                    (sender as Button).CssClass += "beschikbaar";
                }
            }

            // Show error if message is not empty
            if (!string.IsNullOrEmpty(message))
            {
                ShowErrorMessage(message);
            }
            else
            {
                Response.Redirect(Request.RawUrl, false);
            }
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        [System.Web.Services.WebMethod]
        public static string UpdateAvailability(string id, string beschikbaar)
        {
            // Create a new guihandler object
            GUIHandler tempGUIHandler = new GUIHandler();

            string message = string.Empty;

            // Create new Availabilitydetails
            Availabilitydetails ad = new Availabilitydetails();
            ad.Day = id.Split('_')[1];
            ad.Daytime = id.Split('_')[2];
            
            // Check if sender has class "beschikbaar"
            if (beschikbaar == "true")
            {
                // update availability in database
                if (tempGUIHandler.RemoveAvailability(ad, out message))
                {
                    // Update visual style on button
                    return "false";
                }
            }
            else
            {
                // update availability in database
                if (tempGUIHandler.AddAvailability(ad, out message))
                {
                    return "true";
                }
            }
            
            return "nothing";
        }
    }
}