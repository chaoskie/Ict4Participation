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
        public Form previous;
        private Administration Administration;
        private int currentSelection;
        private bool allLoaded;
        private bool isRefresh;
        private bool questionOpened;

        //load in either all the questions, or their own
        public HulpVragen(Form p, Administration a, bool all)
        {
            this.InitializeComponent();
            this.Administration = a;
            this.previous = p;
            this.allLoaded = all;
            this.questionOpened = false;

            //Check if the user is a 'hulpverlener', which in that case, they should not be allowed to do as much as usual.
            if (this.Administration.MainAccountData(6) == "Hulpverlener")
            {
                btnNieuw.Enabled = false;
            }

            //load in questions
            lbHulpvragen.DataSource = Administration.GetQuestionNames(allLoaded);
        }

        //opens up a form to post a new question
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            PlaatsHulpvraag form = new PlaatsHulpvraag(this, Administration);
            form.Show();
            questionOpened = true;
            this.Close();
        }

        //changes the information about the question on the right
        private void lbHulpvragen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isRefresh)
            {
                panelChat.Controls.Clear();
                int ind = lbHulpvragen.SelectedIndex;
                if (ind != -1)
                {
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
                    lbSkills.Items.Clear();
                    lbSkills.Items.AddRange(Administration.GetQuestionSkills(ind, allLoaded).Cast<string>().ToArray());
                    //Load in comments
                    UpdateComments();

                }
                isRefresh = false;
            }
        }

        private void UpdateComments()
        {
            int ind = lbHulpvragen.SelectedIndex;
            //Voor panel
            int previousy = 0;
            foreach (string s in Administration.GetQuestionComments(ind))
            {
                //LABELS
                //Check how many lines it'd take to give the label extra space
                int numLines = 1;
                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
                {
                    SizeF size = graphics.MeasureString(s, new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point));
                    numLines = (int)Math.Ceiling(size.Width / 399) + 1;
                }
                var label = new Label
                {
                    Text = s,
                    Location = new Point(50, previousy),
                    AutoSize = false,
                    Size = new Size(400, 10 * numLines),
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point)
                };
                panelChat.Controls.Add(label);
                //Define the previous Y
                previousy += 10 * numLines;

                //BUTTONS

                //Scroll down
                panelChat.VerticalScroll.Value = panelChat.VerticalScroll.Maximum;
                panelChat.PerformLayout();
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
            panelChat.Controls.Clear();
            UpdateComments();
        }

        //Closes this screen, and brings the user back to the main menu
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Closes this screen, and brings the user back to the main menu
        private void HulpVragen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!questionOpened)
            {
                Form form = new HoofdForm(Administration);
                form.Show();
            }
        }
    }
}
