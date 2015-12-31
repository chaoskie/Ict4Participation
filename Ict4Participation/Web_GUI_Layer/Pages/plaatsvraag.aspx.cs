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
        private static GUIHandler GUIHandler;

        private static List<Skilldetails> selected_skills;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                // Empty select_skills
                select_skills.Items.Clear();

                // Add all skills in select_skills
                List<Skilldetails> skills = GUIHandler.GetAllSkills();
                foreach (Skilldetails skill in skills)
                {
                    select_skills.Items.Add(skill.Name);
                }

                selected_skills = new List<Skilldetails>();
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }

        protected void btnPlaatsHulpvraag_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // Get values of page
            string title = inputTitel.Value;
            string desc = inputBeschrijving.Value;
            string location = inputLocatie.Value;
            DateTime startDate = new DateTime(Convert.ToInt32(input_startdate_3.Value), 
                Convert.ToInt32(input_startdate_2.Value), Convert.ToInt32(input_startdate_1.Value), 
                Convert.ToInt32(input_startdate_4.Value), Convert.ToInt32(input_startdate_5.Value), 0);
            DateTime endDate = new DateTime(Convert.ToInt32(input_einddate_3.Value), 
                Convert.ToInt32(input_einddate_2.Value), Convert.ToInt32(input_einddate_1.Value), 
                Convert.ToInt32(input_einddate_4.Value), Convert.ToInt32(input_einddate_5.Value), 0);

            //TODO  bool checkSucces = Admin_Layer.Check.QuestionDetails(qd, string errorMessage );


            // Create new question details and fill properties
            Questiondetails qd = new Questiondetails();
            qd.Title = title;
            qd.Description = desc;
            qd.PostDate = DateTime.Now;
            qd.Skills = selected_skills.Select(i => i.Name).ToList();
            qd.Location = location;
            qd.StartDate = startDate;
            qd.EndDate = endDate;
            qd.Urgent = inputUrgentie.Checked;
            qd.Status = "Open";
            qd.AmountAccs = Convert.ToInt32(input_max_accs.Value);
                    
        
            // Place question
            if (!GUIHandler.Place(qd, out message))
            {
                ShowErrorMessage(message);
                return;
            }
            else
            {
                // Redirect to profiel.aspx if question was placed successfully
                Response.Redirect("profiel.aspx", false);
            }
        }

        private void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
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
                sd.Name = skill.ToLower();
                sd.UserID = GUIHandler.GetMainuserInfo().ID;
                selected_skills.Add(sd);
            }

            return string.Empty;
        }
    }
}