using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class wijziggegevens : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                // Get mainuser accountdetails
                Accountdetails m_ad = GUIHandler.GetMainuserInfo();

                // Fill in user details
                // General info
                string[] name_list = m_ad.Name.Split(' ');

                if (name_list.Length == 2)
                {
                    inputVoornaam.Value = name_list[0];
                    inputAchternaam.Value = name_list[1];
                }
                else if (name_list.Length == 3)
                {
                    inputVoornaam.Value = name_list[0];
                    inputTussenvoegsel.Value = name_list[1];
                    inputAchternaam.Value = name_list[2];
                }

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
                    // volunteer info
                    foreach (Skilldetails sd in m_ad.SkillsDetailList)
                    {
                        // TODO: Add skills to select_skills_output
                    }

                    inputVOG.Value = m_ad.VOGPath;
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

            // Get all info
            Accountdetails ad = new Accountdetails();
            //ad.Name = ..;
            //ad.Address = ...;
            //ad.City = ..;
            //ad.Phonenumber = ..;
            //ad.Gender = ..;
            //ad.Birthdate = ..;
            //ad.Email = ..;
            //ad.Username = ..;
            // TODO: check if both passwords are equal
            // TODO: set password
            //ad.AvatarPath = ..;
            //ad.OVPossible = ..;
            //ad.hasDriverLicense = ..;
            //ad.hasVehicle = ..;


            // Update user settings
            if (!GUIHandler.Edit(ad, out message))
            {
                ShowErrorMessage(message);
            }

            Response.Redirect("profiel.aspx", false);
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }
    }
}