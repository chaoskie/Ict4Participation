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

            if (!IsPostBack)
            {
                // Get all user info
                Accountdetails accDetails = GUIHandler.GetMainuserInfo();

                // Insert user name and role
                user_naam.InnerHtml = accDetails.Name;

                // Set profilephoto
                profielfoto.ImageUrl = accDetails.AvatarPath;

                // Insert availability
                List<Availabilitydetails> ad = accDetails.AvailabilityDetailList;

                // Set tablecell class to beschikbaar if user is available on that day
                if (ad != null)
                {
                    foreach (Availabilitydetails a in ad)
                    {
                        Button btn = (Button)FindControl(string.Format("rooster_{0}_{1}", a.Day, a.Daytime));
                        btn.CssClass += "beschikbaar";
                    }
                }
            }

            // TODO: Fill activities
            // Temporary message
            activiteiten_list.Controls.Add(new LiteralControl("<li><a href=\"#\">Geen activiteiten</a>"));
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
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }
    }
}