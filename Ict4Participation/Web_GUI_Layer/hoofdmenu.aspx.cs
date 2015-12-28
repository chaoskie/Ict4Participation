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

            // Insert user name and role
            user_naam.InnerHtml = accDetails.Name;

            // Insert availability
            List<Availabilitydetails> ad = accDetails.AvailabilityDetailList;
            
            // Set tablecell class to beschikbaar if user is available on that day
            if (ad != null)
            {
                foreach (Availabilitydetails a in ad)
                {
                    HtmlTableCell tc = (HtmlTableCell)FindControl(string.Format("rooster_{0}_{1}", a.Day, a.Daytime));
                    tc.Attributes.Add("class", "beschikbaar");
                }
            }

            //rooster_ma_ochtend.DataBinding += delegate { rooster_change; };
        }

        protected void btnAfmelden_Click(object sender, EventArgs e)
        {
            // Remove GUIHandler
            Session["GUIHandler_obj"] = null;

            Response.Redirect("inloggen.aspx", false);
        }

        protected void btnVragen_Click(object sender, EventArgs e)
        {
            //Response.Redirect("...");
        }
        
        protected void btnZoeken_Click(object sender, EventArgs e)
        {
            Response.Redirect("zoeken.aspx", false);
        }

        protected void btnProfiel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }
        

        /// <summary>
        /// !!!!!!! Deze methode zou moeten werken als je deze aan kan roepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rooster_change(object sender, EventArgs e)
        {
            string message = string.Empty;

            Availabilitydetails ad = new Availabilitydetails();
            ad.Day = (sender as HtmlTableCell).Attributes["data-day"].ToString();
            ad.Daytime = (sender as HtmlTableCell).Attributes["data-daytime"].ToString();

            // Check if sender has class "beschikbaar"
            if ((sender as HtmlTableCell).Attributes["class"].ToString() == "beschikbaar")
            {
                // update availability in database
                GUIHandler.AddAvailability(ad, out message);
            }
            else
            {
                // update availability in database
                GUIHandler.RemoveAvailability(ad, out message);
            }

            // Show error if message is not empty
            if (!string.IsNullOrEmpty(message))
            {
                // TODO: Show error message
            }
        }

        /// <summary>
        /// !!!!!!!! Deze methode werkt wss niet, wordt aangeroepen vanuit hoofdmenu.js
        /// </summary>
        /// <param name="day"></param>
        /// <param name="daytime"></param>
        /// <param name="beschikbaar"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static string UpdateBeschikbaarheid(string day, string daytime, string beschikbaar)
        {
            string message = string.Empty;

            GUIHandler tempGUIHandler = new GUIHandler();

            Availabilitydetails ad = new Availabilitydetails();
            ad.Day = day;
            ad.Daytime = daytime;

            if (beschikbaar == "true")
            {
                if (!tempGUIHandler.AddAvailability(ad, out message))
                {
                    // TODO: Show message

                    return "true";
                }
            }
            else
            {
                if (!tempGUIHandler.RemoveAvailability(ad, out message))
                {
                    // TODO: Show message

                    return "true";
                }
            }

            // update to database

            return string.Empty;
        }
    }
}