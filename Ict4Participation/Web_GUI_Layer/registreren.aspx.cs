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

            // Maak #select_skills leeg
            select_skills.Items.Clear();

            // Zet alle mogelijke skills in #select_skills
            List<Skilldetails> skills = GUIHandler.GetAllSkills();
            foreach (Skilldetails skill in skills)
            {
                select_skills.Items.Add(skill.Name);
            }
        }

        protected void btnAnnuleren_Click(object sender, EventArgs e)
        {
            Response.Redirect("inloggen.aspx", false);
        }

        protected void btnRegistreerHulpBehoevende_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // maak hulpbehoevende aan
            Accountdetails acc = new Accountdetails();
            if (string.IsNullOrEmpty(inputTussenvoegsel.Value))
            {
                acc.Name = string.Format("{0} {1}", inputVoornaam.Value, inputAchternaam.Value);
            }
            else
            {
                acc.Name = string.Format("{0} {1} {2}", inputVoornaam.Value, inputTussenvoegsel.Value, inputAchternaam.Value);
            }
            acc.Address = string.Format("{0} {1}", inputStraatnaam.Value, inputHuisnummer.Value);
            acc.City = inputWoonplaats.Value;
            acc.Phonenumber = inputTelefoonnummer.Value;
            acc.Gender = input_geslacht.Value.ToLower() == "Man" ? "M" : "V";
            acc.Email = inputEmail.Value;
            acc.Username = inputGebruikersnaam.Value;

            // TODO: acc.AvatarPath = ...
            // =======================
            acc.AvatarPath = "TEST/AVATAR/PATH.png";

            if (!GUIHandler.Register(acc, inputWachtwoord1.Value, inputWachtwoord2.Value, out message))
            {
                error_message.Text = message;
                error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
                error_message.CssClass = error_message.CssClass.Replace("error-green", "error-red");
            }
            else
            {
                error_message.Text = "Het registreren van uw account is gelukt!";
                error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
                error_message.CssClass = error_message.CssClass.Replace("error-red", "error-green");
            }
        }

        protected void btnRegistreerVrijwilliger_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // maak hulpbehoevende aan
            Accountdetails acc = new Accountdetails();
            if (string.IsNullOrEmpty(inputTussenvoegsel.Value))
            {
                acc.Name = string.Format("{0} {1}", inputVoornaam.Value, inputAchternaam.Value);
            }
            else
            {
                acc.Name = string.Format("{0} {1} {2}", inputVoornaam.Value, inputTussenvoegsel.Value, inputAchternaam.Value);
            }
            acc.Address = string.Format("{0} {1}", inputStraatnaam.Value, inputHuisnummer.Value);
            acc.City = inputWoonplaats.Value;
            acc.Phonenumber = inputTelefoonnummer.Value;
            // TODO: account geslacht mist nog
            acc.Email = inputEmail.Value;
            acc.Username = inputGebruikersnaam.Value;
            // TODO: acc.AvatarPath = ...
            // TODO: voeg elke toegevoegde skill toe aan acc.SkillsDetailList
            // TODO: acc.VOGPath = ...

            if (!GUIHandler.Register(acc, inputWachtwoord1.Value, inputWachtwoord2.Value, out message))
            {
                error_message.Text = message;
                error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
                error_message.CssClass = error_message.CssClass.Replace("error-green", "error-red");
            }
            else
            {
                error_message.Text = "Het registreren van uw account is gelukt!";
                error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
                error_message.CssClass = error_message.CssClass.Replace("error-red", "error-green");
            }
        }
    }
}