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
                    lbPostDetails.Items.Add(Administration.AccountData(index,1));
                    lbPostDetails.Items.Add(Administration.AccountData(index,2));
                    lbPostDetails.Items.Add(Administration.AccountData(index,3));
                    lbPostDetails.Items.Add(Administration.AccountData(index,4));
                    lbPostDetails.Items.Add(Administration.AccountData(index,5));
                    lbPostDetails.Items.Add(Administration.AccountData(index,6));
                    lbPostDetails.Items.Add(Administration.AccountData(index,7));
                    lbPostDetails.Items.Add(Administration.AccountData(index,8));
                    #endregion
                }
                if (lbTables.SelectedIndex == 2)
                {
                    #region Reviews
                    #endregion
                }
            }
        }

        private void btnEditPost_Click(object sender, EventArgs e)
        {
            //TODO
            // Call for right administration function to edit the desired class
            // As wel as update it into the database

            //Refresh list
        }

        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            //TODO
            // Check which table is selected
            // Call for right administration function to delete the right 'post'

            //Refresh list
        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            //TODO
            //Check is anything is selected
            // Edit comment
            // Call for prompt to fill in other details
            // Check selectionindex
            // Call right administration function to fullfill desires, based on index
            // LOADED IN COMMENTS ARE BASED ON THE SAME INDEX

            //Refresh list
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            //TODO
            //Check if anything is selected
            // Delete comment
            // Call right administration to delete right comment, based on index
            // LOADED IN COMMENTS ARE BASED ON THE SAME INDEX

            //Refresh list
        }
    }
}
