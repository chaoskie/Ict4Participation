using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class wijzigvraag : System.Web.UI.Page
    {
        private static GUIHandler GUIHandler;
        private static Questiondetails qd;
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

            // Get question id from session
            int q_id = Convert.ToInt32(Session["QuestionDetails_id"]);

            if (!IsPostBack)
            {
                // Get questiondetails
                List<Questiondetails> qd_list = GUIHandler.GetAll(true);

                qd = GUIHandler.GetAll(true).Where(vraag => vraag.PostID == q_id).FirstOrDefault();

                // update inputs
                inputTitel.Value = qd.Title;
                inputBeschrijving.Value = qd.Description;
                inputLocatie.Value = qd.Location;
                input_max_accs.SelectedIndex = qd.AmountAccs - 1;

                int s_date_day = 0;
                int s_date_month = 0;
                int s_date_year = 2016;
                int s_date_hour = 0;
                int s_date_min = 0;

                int e_date_day = 0;
                int e_date_month = 0;
                int e_date_year = 2016;
                int e_date_hour = 0;
                int e_date_min = 0;

                if (qd.StartDate.HasValue)
                {
                    s_date_day = Convert.ToInt32(((DateTime) qd.StartDate).ToString("dd"));
                    s_date_month = Convert.ToInt32(((DateTime) qd.StartDate).ToString("MM"));
                    s_date_year = Convert.ToInt32(((DateTime) qd.StartDate).ToString("yyyy"));
                    s_date_hour = Convert.ToInt32(((DateTime) qd.StartDate).ToString("HH"));
                    s_date_min = Convert.ToInt32(((DateTime) qd.StartDate).ToString("mm"));
                }

                if (qd.EndDate.HasValue)
                {
                    e_date_day = Convert.ToInt32(((DateTime)qd.EndDate).ToString("dd"));
                    e_date_month = Convert.ToInt32(((DateTime)qd.EndDate).ToString("MM"));
                    e_date_year = Convert.ToInt32(((DateTime)qd.EndDate).ToString("yyyy"));
                    e_date_hour = Convert.ToInt32(((DateTime)qd.EndDate).ToString("HH"));
                    e_date_min = Convert.ToInt32(((DateTime)qd.EndDate).ToString("mm"));
                }

                input_startdate_1.Value = input_startdate_1.Items.FindByValue(Convert.ToString(s_date_day)).ToString();
                input_startdate_2.Value = input_startdate_2.Items.FindByValue(Convert.ToString(s_date_month)).ToString();
                input_startdate_3.Value = input_startdate_3.Items.FindByValue(Convert.ToString(s_date_year)).ToString();
                input_startdate_4.Value = input_startdate_4.Items.FindByValue(Convert.ToString(s_date_hour)).ToString();
                input_startdate_5.Value = input_startdate_5.Items.FindByValue(Convert.ToString(s_date_min)).ToString();

                input_einddate_1.Value = input_einddate_1.Items.FindByValue(Convert.ToString(e_date_day)).ToString();
                input_einddate_2.Value = input_einddate_2.Items.FindByValue(Convert.ToString(e_date_month)).ToString();
                input_einddate_3.Value = input_einddate_3.Items.FindByValue(Convert.ToString(e_date_year)).ToString();
                input_einddate_4.Value = input_einddate_4.Items.FindByValue(Convert.ToString(e_date_hour)).ToString();
                input_einddate_5.Value = input_einddate_5.Items.FindByValue(Convert.ToString(e_date_min)).ToString();

                inputUrgentie.Checked = qd.Urgent;

                // Empty select_skills
                select_skills.Items.Clear();
                selected_skills = new List<Skilldetails>();

                // Add all skills in select_skills
                List<Skilldetails> skills = GUIHandler.GetAllSkills();
                foreach (Skilldetails skill in skills)
                {
                    if (!qd.Skills.Contains(skill.Name))
                    {
                        select_skills.Items.Add(skill.Name);
                    }
                    else
                    {
                        select_skills_output.Items.Add(skill.Name);
                        selected_skills.Add(skill);
                    }
                }

            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("vraag.aspx", false);
        }

        protected void btnWijzigVraag_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // Edit the question
            qd.PosterID = GUIHandler.GetMainuserInfo().ID;
            qd.Title = inputTitel.Value;
            qd.Description = inputBeschrijving.Value;

            qd.Skills = selected_skills.Select(sk => sk.Name).ToList();

            qd.Location = inputLocatie.Value;
            qd.StartDate = new DateTime(Convert.ToInt32(input_startdate_3.Value),
                Convert.ToInt32(input_startdate_2.Value), Convert.ToInt32(input_startdate_1.Value),
                Convert.ToInt32(input_startdate_4.Value), Convert.ToInt32(input_startdate_5.Value), 0);
            qd.EndDate = new DateTime(Convert.ToInt32(input_einddate_3.Value),
                Convert.ToInt32(input_einddate_2.Value), Convert.ToInt32(input_einddate_1.Value),
                Convert.ToInt32(input_einddate_4.Value), Convert.ToInt32(input_einddate_5.Value), 0);
            qd.AmountAccs = Convert.ToInt32(input_max_accs.Value);
            qd.Urgent = inputUrgentie.Checked;

            if (!GUIHandler.Edit(qd, qd.PostID, out message))
            {
                ShowErrorMessage(message);
                return;
            }

            Response.Redirect("vraag.aspx", false);
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }


        [System.Web.Services.WebMethod]
        public static string UpdateSkills(string skills)
        {
            // Split skills in List<string>
            List<string> skillList = skills.Split('|').ToList();

            selected_skills = new List<Skilldetails>();

            foreach (string skill in skillList)
            {
                Skilldetails sd = new Skilldetails();
                sd.Name = skill;
                sd.UserID = GUIHandler.GetMainuserInfo().ID;
                selected_skills.Add(sd);
            }

            return string.Empty;
        }
    }
}