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

namespace Web_GUI_Layer.Pages
{
    public partial class wijziggegevens : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static List<Skilldetails> selected_skills;

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

            if (!IsPostBack)
            {
                // Get mainuser accountdetails
                Accountdetails m_ad = GUIHandler.GetMainuserInfo();

                // Fill in user details
                // General info
                string[] name_list = m_ad.Name.Split(' ');

                inputFullName.Value = m_ad.Name;

                string[] street_list = m_ad.Address.Split(' ');
                string adresnr = street_list[street_list.Length-1];

                inputHuisnummer.Value = adresnr;
                inputStraatnaam.Value = m_ad.Address.Substring(0, m_ad.Address.Length - adresnr.Length);

                inputWoonplaats.Value = m_ad.City;
                inputTelefoonnummer.Value = m_ad.Phonenumber;

                if (m_ad.Gender.ToUpper() == "M")
                {
                    input_geslacht.SelectedIndex = 0;
                }
                else if (m_ad.Gender.ToUpper() == "V")
                {
                    input_geslacht.SelectedIndex = 1;
                }

                input_birthdate_1.SelectedIndex =
                    input_birthdate_1.Items.IndexOf(new ListItem(m_ad.Birthdate.ToString("dd"),
                        m_ad.Birthdate.ToString("dd")));
                input_birthdate_2.SelectedIndex =
                    input_birthdate_2.Items.IndexOf(new ListItem(m_ad.Birthdate.ToString("MM"),
                        m_ad.Birthdate.ToString("MM")));
                input_birthdate_3.SelectedIndex =
                    input_birthdate_3.Items.IndexOf(new ListItem(m_ad.Birthdate.ToString("yyyy"),
                        m_ad.Birthdate.ToString("yyyy")));

                // Account info
                inputEmail.Value = m_ad.Email;
                inputGebruikersnaam.Value = m_ad.Username;
                // Leave password fields empty

                // Profile picture
                // TODO: Set inputProfielfoto

                // Travel possibilities
                if (m_ad.OVPossible.HasValue)
                {
                    cb_ovmogelijkheid.Checked = (bool) m_ad.OVPossible;
                }
                if (m_ad.hasDriverLicense.HasValue)
                {
                    cb_rijbewijs.Checked = (bool) m_ad.hasDriverLicense;
                }
                if (m_ad.hasVehicle.HasValue)
                {
                    cb_auto.Checked = (bool) m_ad.hasVehicle;
                }

                // Role specific info
                if (m_ad.VOGPath != string.Empty)
                {
                    List<Skilldetails> skills_list = GUIHandler.GetAllSkills();

                    // Insert all skills except
                    foreach (Skilldetails sd in skills_list)
                    {
                        if (!(m_ad.SkillsDetailList.FindIndex(i => i.Name == sd.Name) >= 0))
                        {
                            select_skills.Items.Add(sd.Name);
                        }
                    }

                    // Define selected_skills
                    selected_skills = new List<Skilldetails>();

                    // Insert user skills
                    foreach (Skilldetails sd in m_ad.SkillsDetailList)
                    {
                        // Add the skilldetails object to the server list
                        selected_skills.Add(sd);

                        // Add the skilldetails to the local displayed list
                        select_skills_output.Items.Add(sd.Name);
                    }
                }
                else
                {
                    formVrijwilliger.Visible = false;
                }
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void UpdateInfo_Click(object sender, EventArgs e)
        {

            string message = string.Empty;
            
            if (!GUIHandler.ValidatePassword(inputWachtwoordValidate.Value, out message))
            {
                //Show error
                ShowErrorMessage(message);
                return;
            }

            // Get all info
            Accountdetails ad = GUIHandler.GetMainuserInfo();

            ad.Name = inputFullName.Value;
            
            ad.Address = string.Format("{0} {1}", inputStraatnaam.Value, inputHuisnummer.Value);
            ad.City = inputWoonplaats.Value;
            ad.Phonenumber = inputTelefoonnummer.Value;
            ad.Gender = input_geslacht.Value.ToLower() == "man" ? "M" : "V";
            ad.Birthdate = new DateTime(Convert.ToInt32(input_birthdate_3.Value), Convert.ToInt32(input_birthdate_2.Value), Convert.ToInt32(input_birthdate_1.Value));

            ad.Email = inputEmail.Value;
            ad.Username = inputGebruikersnaam.Value;

            ad.OVPossible = Request.Form["cbOVMogelijk"] == "true";
            ad.hasDriverLicense = Request.Form["cbRijbewijs"] == "true";
            ad.hasVehicle = Request.Form["cbAuto"] == "true";

            ad.SkillsDetailList = selected_skills;

            // Check if user has updated avatar
            if (inputProfielfoto.HasFile)
            {
                ad.AvatarPath = inputProfielfoto.FileName;
            }
            
            // Update user settings
            if (!GUIHandler.Edit(ad, out message, inputWachtwoord1.Value, inputWachtwoord2.Value, true))
            {
                ShowErrorMessage(message);
                return;
            }
            else
            {
                string pw = String.IsNullOrWhiteSpace(inputWachtwoord1.Value)
                    ? inputWachtwoordValidate.Value
                    : inputWachtwoord1.Value;

                GUIHandler.LogIn(ad.Username, pw, out message);
            }
            
            // Download avatar if input has a file
            if (inputProfielfoto.HasFile)
            {
                // Download new avatar if account has been updated
                if (!GUIHandler.Download(inputProfielfoto, out message))
                {
                    ShowErrorMessage(message);
                    return;
                }
            }

            // Return to profilepage
            Response.Redirect("profiel.aspx", false);
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        [System.Web.Services.WebMethod]
        public static string IsCity(string str)
        {
            // If str is a city, return 1
            string[] cities = GetCities(str).Split('|');
            foreach (string city in cities)
            {
                if (city == str &&
                    city != "Niks gevonden")
                {
                    return "true";
                }
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
            if (!string.IsNullOrWhiteSpace(str))
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
                foreach (string city in foundCities)
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