using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class vragen : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;
        private static bool orderDescTitle;
        private static bool orderDescUrgency;

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

            // Insert questions
            List<Questiondetails> qd_list = GUIHandler.GetAll(true);

            if (orderDescTitle)
            {
                qd_list = qd_list.OrderByDescending(i => i.Title).ToList();
            }
            if (orderDescUrgency)
            {
                qd_list = qd_list.OrderByDescending(i => i.Urgent).ToList();
            }

            // Clear all controls inside vragen_list
            vragen_list.Controls.Clear();

            // Get all accounts
            GUIHandler.GetAll();

            // Insert questions to vragen_list
            foreach (Questiondetails qd in qd_list)
            {
                // Get userdetails
                Accountdetails ad = GUIHandler.GetInfo(false, qd.PosterID);

                // Insert new row in table
                TableRow tr = new TableRow();
                vragen_list.Controls.Add(tr);

                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();

                tr.Controls.Add(tc1);
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc3);

                HtmlGenericControl p1 = new HtmlGenericControl("p");
                HtmlGenericControl p2 = new HtmlGenericControl("p");
                HtmlGenericControl p3 = new HtmlGenericControl("p");

                tc1.Controls.Add(p1);
                tc2.Controls.Add(p2);
                tc3.Controls.Add(p3);

                HtmlAnchor a1 = new HtmlAnchor();
                a1.Attributes.Add("data-q-id", Convert.ToString(qd.PostID));
                a1.ServerClick += Question_Click;
                a1.InnerText = qd.Title;
                p1.Controls.Add(a1);

                HtmlAnchor a2 = new HtmlAnchor();
                a2.Attributes.Add("data-u-id", Convert.ToString(ad.ID));
                a2.ServerClick += Account_Click;
                a2.InnerText = ad.Name;
                p2.Controls.Add(a2);

                HtmlAnchor a3 = new HtmlAnchor();
                a3.Attributes.Add("data-q-id", Convert.ToString(qd.PostID));
                a3.ServerClick += Question_Click;
                a3.InnerText = qd.Urgent ? "Urgent" : "Niet urgent";
                p3.Controls.Add(a3);
            }

            // Change icons based on bools
            if (orderDescTitle)
            {
                vragen_order_titel.InnerHtml = "Vraag&nbsp;<i class=\"fa fa-fw fa-chevron-up\"></i>";
            }
            else
            {
                vragen_order_titel.InnerHtml = "Vraag&nbsp;<i class=\"fa fa-fw fa-chevron-down\"></i>";
            }

            if (orderDescUrgency)
            {
                vragen_order_urgentie.InnerHtml = "Urgentie&nbsp;<i class=\"fa fa-fw fa-chevron-up\"></i>";
            }
            else
            {
                vragen_order_urgentie.InnerHtml = "Urgentie&nbsp;<i class=\"fa fa-fw fa-chevron-down\"></i>";
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        private void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        protected void ChangeOrderTitle_Click(object sender, EventArgs e)
        {
            orderDescTitle = !orderDescTitle;

            Response.Redirect(Request.RawUrl, false);
        }

        protected void ChangeOrderUrgency_Click(object sender, EventArgs e)
        {
            orderDescUrgency = !orderDescUrgency;

            Response.Redirect(Request.RawUrl, false);
        }

        private void Account_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as HtmlAnchor).Attributes["data-u-id"].ToString());

            Session["UserProfile_ID"] = Convert.ToInt32(id);

            Response.Redirect("gebruikerprofiel.aspx", false);
        }

        private void Question_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as HtmlAnchor).Attributes["data-q-id"].ToString());

            Session["QuestionDetails_id"] = Convert.ToString(id);

            Response.Redirect("vraag.aspx", false);
        }
    }
}
