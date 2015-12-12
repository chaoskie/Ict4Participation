using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class profiel : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx");
        }

        protected void btnPlaatsVraag_Click(object sender, EventArgs e)
        {
            Response.Redirect("plaatsvraag.aspx");
        }

        protected void btnGebruikers(object sender, EventArgs e)
        {
            Response.Redirect("gebruikers.aspx");
        }
    }
}