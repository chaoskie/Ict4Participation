using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class meeting : System.Web.UI.Page
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

            // Return if session is null
            if (Session["meetingID"] == null)
            {
                Response.Redirect("hoofdmenu.aspx", false);
                return;
            }
            
            // Get all accounts
            List<Accountdetails> accounts_list = GUIHandler.GetAll();

            // Get meeting ID from session
            int meetingID = (int)Session["meetingID"];

            // Get Meeting object
            Meetingdetails md = GUIHandler.GetAllMeetings().Find(i => i.PostID == meetingID);

            // Insert all data
            persoon1.InnerText = accounts_list.Find(i => i.ID == md.PosterID).Name;
            persoon2.InnerText = accounts_list.Find(i => i.ID == md.RequesterID).Name;
            lblLocatie.InnerText = md.Location;

            if (md.StartDate == null)
            {
                lblGeenDatum.Visible = true;
            }
            else
            {
                lblGeenDatum.Visible = false;

                lblStartDatum.InnerText = ((DateTime)md.StartDate).ToString("d-MMM-yyyy HH:mm:ss");
                lblEindDatum.InnerText = ((DateTime)md.EndDate).ToString("d-MMM-yyyy HH:mm:ss");
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }
    }
}