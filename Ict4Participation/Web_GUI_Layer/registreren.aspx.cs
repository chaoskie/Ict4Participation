﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;
using System.IO;
using Web_GUI_Layer.Entities;

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

            int addedSkills = select_skills_output.Controls.Count;

            // acc.Birthdate = ...
            // acc.hasDriverLicense = ...
            // acc.hasVehicle = ...
            // acc.OVPossible = ...

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

        [System.Web.Services.WebMethod]
        public static int IsCity(string str)
        {
            // If str is a city, return 1

            // else return 0
            return 0;
        }

        [System.Web.Services.WebMethod]
        public static string GetCities(string str)
        {
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
    }
}