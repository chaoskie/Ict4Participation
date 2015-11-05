﻿//-----------------------------------------------------------------------
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
            this.lbRubrics.SelectedIndex = 0;
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Close();
        }

        private void lbRubrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item from lbRubrics
            string itemText = lbRubrics.SelectedItem.ToString();

            // Get subitems from item through administration class
            List<string> list = null;
            switch (itemText.ToLower())
            {
                case "vragen":
                    list = this.Administration.GetQuestionNames();
                    break;
                case "gebruikers":
                    list = this.Administration.GetAccounts("All");
                    break;
                case "reviews":
                    list = this.Administration.GetAccountReviews();
                    break;
            }

            // Clear and Fill lbPosts with the subitems
            this.lbPosts.DataSource = null;
            this.lbPosts.DataSource = list;
        }

        private void lbPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected item from lbPosts
            Object itemText = lbPosts.SelectedItem;

            // Get post through administration class
            List<Object> list = null;

            //if (typeof(Object).Name == )

            // Clear and Fill lbPostDetails with post details

            // Clear and Fill lbPostComments with post comments

            // Set lblPostOwner text to post owner

            // Set lblPostDate text to post date
        }

        private void btnEditPost_Click(object sender, EventArgs e)
        {
            // Edit post
        }

        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            // Delete post
        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            // Edit comment
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            // Delete comment
        }
    }
}
