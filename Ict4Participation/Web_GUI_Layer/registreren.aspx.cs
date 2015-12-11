using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class registreren : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();

            // Zet alle mogelijke skills in #select_skills
            List<Skilldetails> skills = GUIHandler.GetAllSkills();
            foreach (Skilldetails skill in skills)
            {
                select_skills.Items.Add(skill.Name);
            }
        }

        protected void btnAnnuleren_Click(object sender, EventArgs e)
        {
            Response.Redirect("inloggen.aspx");
        }

        protected void btnRegistreerHulpBehoevende_Click(object sender, EventArgs e)
        {
            // maak hulpbehoevende aan
            // regex controle moet in de guihandler_class / class_layer staan, niet in de GUI!
            // GUIHandler.Register();
        }

        protected void btnRegistreerVrijwilliger_Click(object sender, EventArgs e)
        {
            // check gegevens met regex
        }
    }
}