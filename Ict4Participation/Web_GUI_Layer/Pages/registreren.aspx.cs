using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;
using System.IO;
using Web_GUI_Layer.Entities;
using System.Web.UI.HtmlControls;

namespace Web_GUI_Layer
{
    public partial class registreren : System.Web.UI.Page
    {
        private static GUIHandler GUIHandler;
        private static List<Skilldetails> selected_skills;

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

        private Accountdetails GetAccount()
        {
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
            acc.Gender = input_geslacht.Value.ToLower() == "man" ? "M" : "V";
            acc.Birthdate = new DateTime(Convert.ToInt32(input_birthdate_3.Value), Convert.ToInt32(input_birthdate_2.Value), Convert.ToInt32(input_birthdate_1.Value));

            acc.Email = inputEmail.Value;
            acc.Username = inputGebruikersnaam.Value;

            acc.OVPossible = Request.Form["cbOVMogelijk"] == "true";
            acc.hasDriverLicense = Request.Form["cbRijbewijs"] == "true";
            acc.hasVehicle = Request.Form["cbAuto"] == "true";

            // upload photo
            acc.AvatarPath = inputProfielfoto.FileName;

            return acc;
        }

        protected void btnRegistreerHulpBehoevende_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // maak hulpbehoevende aan
            Accountdetails acc = GetAccount();     

            if (!GUIHandler.Register(acc, inputWachtwoord1.Value, inputWachtwoord2.Value, out message))
            {
                DisplayFailure(message);
            }
            else
            {
                error_message.Text = "Het registreren van uw account is gelukt! U wordt teruggestuurd in 3 seconden.";
                error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
                error_message.CssClass = error_message.CssClass.Replace("error-red", "error-green");

                if (!GUIHandler.Download(inputProfielfoto, out message))
                {
                    ShowErrorMessage("Het uploaden van de foto is niet gelukt!");
                }

                Response.AddHeader("REFRESH", "3;URL=pages/inloggen.aspx");
            }
        }

        protected void btnRegistreerVrijwilliger_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // Create a new volunteer
            Accountdetails acc = GetAccount();

            // Add skills to account skillsdetaillist
            foreach (Skilldetails sd in selected_skills)
            {
                acc.SkillsDetailList.Add(sd);
            }

            acc.VOGPath = inputVOG.PostedFile.FileName;

            if (!GUIHandler.Register(acc, inputWachtwoord1.Value, inputWachtwoord2.Value, out message))
            {
                DisplayFailure(message);
            }
            else
            {

                error_message.Text = "Het registreren van uw account is gelukt! U wordt teruggestuurd in 3 seconden.";
                error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
                error_message.CssClass = error_message.CssClass.Replace("error-red", "error-green");

                if (!GUIHandler.Download(inputProfielfoto, out message))
                {
                    ShowErrorMessage("Het uploaden van de foto is niet gelukt!");
                }

                if (!GUIHandler.Download(inputVOG, out message))
                {
                    ShowErrorMessage("Het uploaden van de VOG is niet gelukt!");
                }

                Response.AddHeader("REFRESH", "3;URL=pages/inloggen.aspx");
            }
        }

        private void DisplayFailure(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
            error_message.CssClass = error_message.CssClass.Replace("error-green", "error-red");

        }

        private void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        [System.Web.Services.WebMethod]
        public static string IsCity(string str)
        {
            // If str is a city, return 1
            if (GetCities(str) == str)
            {
                return "true";
            }

            // else return 0
            return "false";
        }

        [System.Web.Services.WebMethod]
        public static string GetCities(string str)
        {
            // Set input to lowercase
            str = str.ToLower();

            //Set the amount of found results to none
            int found = 0;

            string result = string.Empty;

            List<string> foundCities = new List<string>();

            string fileloc = HttpContext.Current.Server.MapPath(@"~\Content\Files\Woonplaatsen_Nederland.txt");

            //If the search isn't empty, then search
            if (!String.IsNullOrWhiteSpace(str))
            {
                //Read the file
                foreach (var line in File.ReadAllLines(fileloc))
                {
                    //Check if the compare function won't crash
                    if (line.Length >= str.Length)
                    {
                        //Check if the line contains the search
                        if (line.ToLower().Contains(str))
                        {
                            foundCities.Add(line.ToString());
                            found++;
                        }
                    }
                }

                List<CityStruct> tempCities = new List<CityStruct>();

                // Loop through foundCities
                foreach(string city in foundCities)
                {
                    decimal bullshit = (decimal)str.Length / (decimal)city.Length;
                    tempCities.Add(new CityStruct(city, bullshit));
                }

                tempCities = tempCities.OrderByDescending(c => c.Percentage).ToList();

                if (tempCities.Count > 0)
                {
                    if (tempCities.Count > 5)
                    {
                        tempCities.RemoveRange(5, tempCities.Count - 5);
                    }

                    return tempCities.Select(c => c.Name).Aggregate((x, y) => x + "|" + y);
                }
            }

            return "Niks gevonden";
        }

        [System.Web.Services.WebMethod]
        public static string UpdateSkills(string skills)
        {
            // split skills in List<string>
            List<string> skillList = skills.Split('|').ToList();

            selected_skills = new List<Skilldetails>();

            foreach (string skill in skillList)
            {
                Skilldetails sd = new Skilldetails();
                sd.Name = skill;
                selected_skills.Add(sd);
            }

            return string.Empty;
        }
    }
}