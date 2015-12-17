using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class plaatsvraag : System.Web.UI.Page
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
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }

        protected void btnPlaatsHulpvraag_Click(object sender, EventArgs e)
        {
            string title = inputTitel.Value;
            string desc = inputBeschrijving.Value;
            List<Skilldetails> skills = new List<Skilldetails>();
            foreach (ListItem item in select_skills_output.Items)
            {
                Skilldetails sk = new Skilldetails();
                sk.Name = item.Value;
                skills.Add(sk);
            }

            Questiondetails qd = new Questiondetails();
            string message = String.Empty;
            

            //GUIHandler.Place(qd, out message);
        }
    }
}