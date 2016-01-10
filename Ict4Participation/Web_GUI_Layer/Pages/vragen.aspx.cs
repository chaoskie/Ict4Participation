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
        private static bool orderDescUser;
        private static bool orderDescUrgency;
        private static bool orderDescStatus;

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

            // If the main user is a volunteer, hide the place question button
            Accountdetails mainuser = GUIHandler.GetMainuserInfo();
            if (string.IsNullOrWhiteSpace(mainuser.VOGPath))
            {
                //Set button widths to 25%
                btnPlaceQuestion.Style["width"] = "25%";
                btnTerug.Style["width"] = "25%";
                btnSearch.Style["width"] = "25%";
                btnProfile.Style["width"] = "25%";
            }
            else
            {
                //Remove question button
                btnPlaceQuestion.Visible = false;
            }

            // Insert questions
            List<Questiondetails> qd_list = GUIHandler.GetAll(true);

            qd_list = PrioritySorter.OrderBy(qd_list, orderDescTitle, false, orderDescUrgency, orderDescStatus);

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
                TableCell tc4 = new TableCell();

                tr.Controls.Add(tc1);
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc3);
                tr.Controls.Add(tc4);

                HtmlGenericControl p1 = new HtmlGenericControl("p");
                HtmlGenericControl p2 = new HtmlGenericControl("p");
                HtmlGenericControl p3 = new HtmlGenericControl("p");
                HtmlGenericControl p4 = new HtmlGenericControl("p");

                tc1.Controls.Add(p1);
                tc2.Controls.Add(p2);
                tc3.Controls.Add(p3);
                tc4.Controls.Add(p4);

                HtmlAnchor a1 = new HtmlAnchor();
                a1.Attributes.Add("data-q-id", Convert.ToString(qd.PostID));
                a1.ServerClick += Question_Click;
                a1.InnerText = qd.Title;
                p1.Controls.Add(a1);

                HtmlAnchor a2 = new HtmlAnchor();
                a2.Attributes.Add("data-u-id", Convert.ToString(ad.ID));
                a2.Attributes.Add("title", string.Format("<div style='width: 350px; height: 150px;'><div style='width:90px; height: 150px; margin-right: 10px; text-align: center; line-height: 150px;' class='pull-left'><img src='{0}' style='width: 100%; margin: 0 auto; vertical-align: middle;' /></div><div style='width: 250px' class='pull-right'><p>{1}</p><p>{2}</p><p>{3}</p></div></div><div style='clear:both'></div>", ad.AvatarPath, ad.Name, ad.VOGPath == null ? "Hulpbehoevende" : "Vrijwilliger", ad.Description));
                a2.Attributes.Add("data-html", "true");
                a2.Attributes.Add("rel", "tooltip");
                a2.ServerClick += Account_Click;
                a2.InnerText = ad.Name;
                p2.Controls.Add(a2);

                HtmlAnchor a3 = new HtmlAnchor();
                a3.Attributes.Add("data-q-id", Convert.ToString(qd.PostID));
                a3.ServerClick += Question_Click;
                a3.InnerText = qd.Urgent ? "Urgent" : "Niet urgent";
                p3.Controls.Add(a3);

                HtmlAnchor a4 = new HtmlAnchor();
                a4.Attributes.Add("data-q-id", Convert.ToString(qd.PostID));
                a4.ServerClick += Question_Click;
                a4.InnerText = qd.Status;
                p4.Controls.Add(a4);
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

            if (orderDescUser)
            {
                vragen_order_urgentie.InnerHtml = "Geplaatst door&nbsp;<i class=\"fa fa-fw fa-chevron-up\"></i>";
            }
            else
            {
                vragen_order_urgentie.InnerHtml = "Geplaatst door&nbsp;<i class=\"fa fa-fw fa-chevron-down\"></i>";
            }

            if (orderDescUrgency)
            {
                vragen_order_urgentie.InnerHtml = "Urgentie&nbsp;<i class=\"fa fa-fw fa-chevron-up\"></i>";
            }
            else
            {
                vragen_order_urgentie.InnerHtml = "Urgentie&nbsp;<i class=\"fa fa-fw fa-chevron-down\"></i>";
            }

            if (orderDescStatus)
            {
                vragen_order_status.InnerHtml = "Status&nbsp;<i class=\"fa fa-fw fa-chevron-up\"></i>";
            }
            else
            {
                vragen_order_status.InnerHtml = "Status&nbsp;<i class=\"fa fa-fw fa-chevron-down\"></i>";
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        protected void btnPlaceQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("plaatsvraag.aspx", false);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("zoeken.aspx", false);
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }

        private void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        protected void ChangeOrderTitle_Click(object sender, EventArgs e)
        {
            orderDescTitle = !orderDescTitle;
            orderDescStatus = false;
            orderDescUrgency = false;
            orderDescUser = false;

            Response.Redirect(Request.RawUrl, false);
        }

        protected void ChangeOrderUser_Click(object sender, EventArgs e)
        {
            
        }

        protected void ChangeOrderUrgency_Click(object sender, EventArgs e)
        {
            orderDescUrgency = !orderDescUrgency;
            orderDescStatus = false;
            orderDescTitle = false;
            orderDescUser = false;

            Response.Redirect(Request.RawUrl, false);
        }

        protected void ChangeOrderStatus_Click(object sender, EventArgs e)
        {
            orderDescStatus = !orderDescStatus;
            orderDescUrgency = false;
            orderDescTitle = false;
            orderDescUser = false;

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
