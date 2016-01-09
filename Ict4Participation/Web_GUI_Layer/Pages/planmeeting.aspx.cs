using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class planmeeting : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static int RequesterID;

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

            // Get requester id from session
            RequesterID = Convert.ToInt32(Session["RequesterID"]);

            // Return if requesterID is 0
            if (RequesterID == 0)
            {
                Response.Redirect("gebruikerprofiel.aspx", false);
                return;
            }

            // Set requester name
            ander_persoon.InnerText = GUIHandler.GetAll().Find(i => i.ID == RequesterID).Name;


        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("gebruikerprofiel.aspx", false);
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        protected void btnPlaatsMeeting_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // insert new meeting
            Meetingdetails md = new Meetingdetails();
            //TODO
            //If checkbox = unchecked, then the following
            md.StartDate = new DateTime(Convert.ToInt32(input_startdate_3.Value), Convert.ToInt32(input_startdate_2.Value), Convert.ToInt32(input_startdate_1.Value), Convert.ToInt32(input_startdate_4.Value), Convert.ToInt32(input_startdate_5.Value), 0);
            md.EndDate = new DateTime(Convert.ToInt32(input_einddate_3.Value), Convert.ToInt32(input_einddate_2.Value), Convert.ToInt32(input_einddate_1.Value), Convert.ToInt32(input_einddate_4.Value), Convert.ToInt32(input_einddate_5.Value), 0);
            
            md.CreationDate = DateTime.Now;
            md.Location = inputLocatie.Value;
            md.RequesterID = GUIHandler.GetMainuserInfo().ID;
            md.PosterID = RequesterID;

            if (!GUIHandler.Create(md, out message))
            {
                ShowErrorMessage(message);
                return;
            }

            Response.Redirect("gebruikerprofiel.aspx", false);
        }

        protected void cbGeenDatum_CheckChange(object sender, EventArgs e)
        {
            // TODO: Made dis
        }
    }
}