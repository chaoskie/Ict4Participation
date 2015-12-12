using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class hoofdmenu : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();
        }

        protected void btnAfmelden_Click(object sender, EventArgs e)
        {
            // TODO: meld gebruiker af
            Response.Redirect("inloggen.aspx");
        }

        protected void btnVragen_Click(object sender, EventArgs e)
        {
            //Response.Redirect("...");
        }
        
        protected void btnZoeken_Click(object sender, EventArgs e)
        {
            Response.Redirect("zoeken.aspx");
        }

        protected void btnProfiel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx");
        }
    }
}