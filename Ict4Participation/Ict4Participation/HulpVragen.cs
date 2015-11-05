//-----------------------------------------------------------------------
// <copyright file="HulpVragen.cs" company="ICT4Participation">
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
    public partial class HulpVragen : Form
    {
        private Form previous;
        private Administration Administration;
        private int currentSelection;
        private bool allLoaded;
        private bool isRefresh;

        //load in either all the questions, or their own
        public HulpVragen(Form p, Administration a, bool all)
        {
            this.InitializeComponent();
            this.Administration = a;
            this.previous = p;
            this.allLoaded = all;

            //load in questions
            lbHulpvragen.DataSource = Administration.GetQuestionNames(allLoaded);
        }

        //opens up a form to post a new question
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            PlaatsHulpvraag form = new PlaatsHulpvraag(this, Administration);
            form.Show();
            this.Hide();
        }

        //changes the information about the question on the right
        private void lbHulpvragen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isRefresh)
            {
                tbComments.Text = string.Empty;
                int ind = lbHulpvragen.SelectedIndex;
                //refresh questions
                isRefresh = true;
                lbHulpvragen.DataSource = null;
                lbHulpvragen.DataSource = Administration.GetQuestionNames(allLoaded);
                //check if not too large &&
                //set selection to right one
                if (ind > lbHulpvragen.Items.Count - 1)
                {
                    ind = lbHulpvragen.SelectedIndex = lbHulpvragen.Items.Count - 1;
                }
                else
                {
                    lbHulpvragen.SelectedIndex = ind;
                }
                //load in details
                lblQuestionInfo.Text = Administration.GetQuestionDetails(ind, allLoaded);
                lblQuestionName.Text = lbHulpvragen.SelectedItem.ToString();
                lbSkills.Items.AddRange(Administration.GetQuestionSkills(ind, allLoaded).Cast<string>().ToArray());
                //Load in comments
                foreach (string s in Administration.GetQuestionComments(ind))
                {
                    tbComments.Text += s + Environment.NewLine;
                }
                currentSelection = ind;
                isRefresh = false;
            }
        }

        //Replies with a comment
        private void btnPlaats_Click(object sender, EventArgs e)
        {
            //place comment
            Administration.PlaceQuestionComment(tbChat.Text, currentSelection);
            //clear text
            tbChat.Clear();
            //reload comments
            tbComments.Clear();
            foreach (string s in Administration.GetQuestionComments(currentSelection))
            {
                tbComments.Text += s + Environment.NewLine;
            }
        }

        //Closes this screen, and brings the user back to the main menu
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.previous.Show();
            this.Close();
        }

        //Closes this screen, and brings the user back to the main menu
        private void HulpVragen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }
    }
}
