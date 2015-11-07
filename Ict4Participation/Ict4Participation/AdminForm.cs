//-----------------------------------------------------------------------
// <copyright file="AdminForm.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin_Layer;

namespace Ict4Participation
{
    public partial class AdminForm : Form
    {
        private Form previous;
        private Administration Administration;

        public AdminForm(Form p, Administration a)
        {
            this.InitializeComponent();
            this.Administration = a;
            this.previous = p;

            // Select first index of lbRubrics
            this.lbTables.SelectedIndex = 0;
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Close();
        }

        private void lbRubrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item from lbRubrics
            string itemText = lbTables.SelectedItem.ToString();

            // Get subitems from item through administration class
            List<string> list = null;
            switch (itemText.ToLower())
            {
                case "vragen":
                    list = this.Administration.GetQuestionNames();
                    break;
                case "gebruikers":
                    list = this.Administration.GetAccounts();
                    break;
                case "reviews":
                    list = this.Administration.GetAccountReviews();
                    break;
            }

            // Clear and Fill lbPosts with the subitems
            this.lbPost.DataSource = null;
            this.lbPost.DataSource = list;
        }

        private void lbPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item from lbPosts
            int index = lbPost.SelectedIndex;
            if (index != -1)
            {
                lbPostDetails.Items.Clear();
                lbPostComments.Items.Clear();

                // Clear and fill lbPostDetails with post details
                // And clear and fill lbPostComments with post comments
                if (lbTables.SelectedIndex == 0)
                {
                    #region Questions
                    string[] str = Administration.GetQuestionDetails(index, true).Split('\n');
                    foreach (string s in str)
                    {
                        lbPostDetails.Items.Add(s);
                        //Poster
                        //Time
                        //Description
                        //Location
                    }

                    List<string> comments = Administration.GetQuestionComments(index);
                    foreach (string s in comments)
                    {
                        lbPostComments.Items.Add(s);
                    }
                    #endregion
                }
                if (lbTables.SelectedIndex == 1)
                {
                    #region Users
                    lbPostDetails.Items.Add(Administration.AccountData(index, 2)); //Name
                    lbPostDetails.Items.Add(Administration.AccountData(index, 3)); //Location
                    lbPostDetails.Items.Add(Administration.AccountData(index, 5)); //Description / Information
                    lbPostDetails.Items.Add(Administration.AccountData(index, 6)); //Role
                    lbPostDetails.Items.Add(Administration.AccountData(index, 7)); //Sex
                    lbPostDetails.Items.Add(Administration.AccountData(index, 8)); //Email
                    #endregion
                }
                if (lbTables.SelectedIndex == 2)
                {
                    #region Reviews
                    string str = this.Administration.GetAccountReviews()[index];
                    ///x-Sterren: titel
                    ///Beschrijving
                    string[] lines = str.Split('\n');
                    lbPostDetails.Items.Add(lines[0].Substring(0, 9)); //Rating
                    lbPostDetails.Items.Add(lines[0].Substring(11)); //Title
                    lbPostDetails.Items.Add(lines[1]); //Description
                    #endregion
                }
            }
        }

        private void btnEditPost_Click(object sender, EventArgs e)
        {

            if (lbPost.SelectedIndex != -1)
            {
                #region Question editing
                if (lbTables.SelectedIndex == 0)
                {
                    ///If the poster is selected
                    if (lbPostDetails.SelectedIndex == 0)
                    {
                        string newUser = Prompt.ShowDialog("Pas de gebruiker aan naar het volgende: ", "Aanpassen");
                        string error;
                        //Validate username (to check if it exists)
                        if (Administration.ChangeQuestionPoster(lbPostDetails.SelectedIndex, newUser, out error))
                        {
                            MessageBox.Show("Hulpvraag aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(newUser);
                            btnEditPost_Click(sender, e);
                        }
                    }

                    ///If the time is selected
                    if (lbPostDetails.SelectedIndex == 1)
                    {
                        string newTime = Prompt.ShowDialog("Pas de tijd aan in het volgende format (24-Feb-2015 12:36:20): ", "Aanpassen");
                        //Validate time (to check if in right format)
                        string error;
                        //Validate username (to check if it exists)
                        if (Administration.ChangeQuestionTime(lbPostDetails.SelectedIndex, newTime, out error))
                        {
                            MessageBox.Show("Hulpvraag aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(newTime);
                            btnEditPost_Click(sender, e);
                        }
                    }

                    ///If the description is selected
                    if (lbPostDetails.SelectedIndex == 2)
                    {
                        string newDesc = Prompt.ShowDialog("Pas de beschrijving aan naar het volgende: ", "Aanpassen");
                        //Change description
                        string error;
                        if (Administration.ChangeQuestionDescription(lbPostDetails.SelectedIndex, newDesc, out error))
                        {
                            MessageBox.Show("Hulpvraag aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(newDesc);
                            btnEditPost_Click(sender, e);
                        }
                    }

                    ///If the location is selected
                    if (lbPostDetails.SelectedIndex == 3)
                    {
                        string newLoc = Prompt.ShowDialog("Pas de locatie aan naar het volgende: ", "Aanpassen");
                        //Change location
                        string error;
                        if (Administration.ChangeQuestionLocation(lbPostDetails.SelectedIndex, newLoc, out error))
                        {
                            MessageBox.Show("Hulpvraag aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(newLoc);
                            btnEditPost_Click(sender, e);
                        }
                    }
                }
                #endregion

                #region User editing
                if (lbTables.SelectedIndex == 1)
                {
                    //Edit Name
                    if (lbPostDetails.SelectedIndex == 0)
                    {
                        string edit = Prompt.ShowDialog("Pas de naam aan naar het volgende: ", "Aanpassen");
                        string error;
                        if (Administration.ChangeAccountName(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Gebruiker aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                    //Edit Location
                    if (lbPostDetails.SelectedIndex == 1)
                    {
                        string edit = Prompt.ShowDialog("Pas de locatie aan naar het volgende: ", "Aanpassen");
                        string error;
                        if (Administration.ChangeAccountLocation(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Gebruiker aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                    //Edit Description
                    if (lbPostDetails.SelectedIndex == 3)
                    {
                        string edit = Prompt.ShowDialog("Pas de beschrijving aan naar het volgende: ", "Aanpassen");
                        string error;
                        if (Administration.ChangeAccountDescription(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Gebruiker aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                    //Edit Role
                    if (lbPostDetails.SelectedIndex == 4)
                    {
                        string edit = Prompt.ShowDialog("Pas de rol aan naar het volgende (Hulpverlener / Hulpbehoevende): ", "Aanpassen");
                        string error;
                        if (Administration.ChangeAccountRole(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Gebruiker aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }

                    }
                    //Edit Sex
                    if (lbPostDetails.SelectedIndex == 5)
                    {
                        string edit = Prompt.ShowDialog("Pas het geslacht aan naar het volgende (M / F): ", "Aanpassen");
                        string error;
                        if (Administration.ChangeAccountSex(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Gebruiker aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                    //Edit Email
                    if (lbPostDetails.SelectedIndex == 6)
                    {
                        //TODO
                        string edit = Prompt.ShowDialog("Pas het geslacht aan naar het volgende (M / F): ", "Aanpassen");
                        string error;
                        if (Administration.ChangeAccountEmail(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Gebruiker aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                }
                #endregion

                #region Review editing
                if (lbTables.SelectedIndex == 2)
                {
                    //Edit rating
                    if (lbPostDetails.SelectedIndex == 0)
                    {
                        string edit = Prompt.ShowDialog("Pas de rating aan naar het volgende: ", "Aanpassen");
                        string error;
                        if (Administration.ChangeReviewRating(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Review aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                    //Edit title
                    if (lbPostDetails.SelectedIndex == 1)
                    {
                        string edit = Prompt.ShowDialog("Pas de titel aan naar het volgende: ", "Aanpassen");
                        string error;
                        if (Administration.ChangeReviewTitle(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Review aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                    //Edit description
                    if (lbPostDetails.SelectedIndex == 3)
                    {
                        string edit = Prompt.ShowDialog("Pas de beschrijving aan naar het volgende: ", "Aanpassen");
                        string error;
                        if (Administration.ChangeReviewDescription(lbPostDetails.SelectedIndex, edit, out error))
                        {
                            MessageBox.Show("Review aangepast!");
                            //Refresh
                        }
                        else
                        {
                            MessageBox.Show(error + " Text gekopieerd, probeer opnieuw!");
                            Clipboard.SetText(edit);
                            btnEditPost_Click(sender, e);
                        }
                    }
                }
                #endregion
            }
        }

        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            //TODO
            //If question is selected
            if (lbTables.SelectedIndex == 0)
            {

            }
            //If user is selected
            if (lbTables.SelectedIndex == 1)
            {

            }
            //If review is selected
            if (lbTables.SelectedIndex == 2)
            {

            }

            //Refresh list
            Refresh();
        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            //Check if anything is selected
            if (lbPostComments.SelectedIndex != -1)
            {
                // Edit comment
                // Call for prompt to fill in other details
                // Check selectionindex
                // Call right administration function to fullfill desires, based on index
                Administration.EditComment(lbPostComments.SelectedIndex, Prompt.ShowDialog("Pas de comment aan naar de volgende text:", "Edit comment"));
                // LOADED IN COMMENTS ARE BASED ON THE SAME INDEX

                //Refresh list
                Refresh();
            }
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            //Check if anything is selected
            if (lbPostComments.SelectedIndex != -1)
            {
                // Delete comment
                // Call right administration to delete right comment, based on index
                Administration.DeleteComment(lbPostComments.SelectedIndex);
                // LOADED IN COMMENTS ARE BASED ON THE SAME INDEX

                //Refresh list
                Refresh();
            }
        }

        private void Refresh()
        {
            lbTables.SelectedIndex = 0;
            lbTables.SelectedIndex = 1;
        }
    }
}
