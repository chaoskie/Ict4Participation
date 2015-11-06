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
        List<Button> Delbuttons;
        List<Button> Editbuttons;

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
                currentSelection = ind;
                isRefresh = false;
            }
        }

        private void UpdateComments()
        {
            int ind = lbHulpvragen.SelectedIndex;
            //Voor panel
            int loops = 0;
            int previousy = 0;
            Delbuttons = new List<Button>();
            Editbuttons = new List<Button>();
            List<string> comments = Administration.GetQuestionComments(ind);
            foreach (string s in comments)
            {
                #region Add Label
                //LABELS
                //Check how many lines it'd take to give the label extra space
                int numLines = 1;
                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
                {
                    SizeF size = graphics.MeasureString(s, new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point));
                    numLines = (int)Math.Ceiling(size.Width / 380) + 1;
                }
                var label = new Label
                {
                    Text = s,
                    Location = new Point(50, previousy),
                    AutoSize = false,
                    Size = new Size(380, 10 * numLines),
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point)
                };
                panelChat.Controls.Add(label);
                #endregion

                if (Administration.MainAccountData(1) == Administration.GetCommentPosterID(loops))
                {
                    #region Add Delete Button
                    //REMOVE BUTTON
                    Button newDelButton = new Button
                    {
                        Name = "btnDel" + loops.ToString(),
                        Text = "d",
                        Location = new Point(0, previousy),
                        AutoSize = false,
                        Size = new Size(18, 18),
                        Font = new Font("Microsoft Sans Serif", 6, FontStyle.Regular, GraphicsUnit.Point)
                    };
                    Delbuttons.Add(newDelButton);
                    panelChat.Controls.Add(newDelButton);
                    #endregion

                    #region Add Edit Button
                    //EDIT BUTTON
                    Button newEditButton = new Button
                    {
                        Name = "btnEdit" + loops.ToString(),
                        Text = "e",
                        Location = new Point(20, previousy),
                        AutoSize = false,
                        Size = new Size(18, 18),
                        Font = new Font("Microsoft Sans Serif", 6, FontStyle.Regular, GraphicsUnit.Point)
                    };
                    Editbuttons.Add(newEditButton);
                    panelChat.Controls.Add(newEditButton);
                    #endregion

                #region Add Button Handlers
                newDelButton.Click += btnDeleteComment;
                newEditButton.Click += newEditButton_Click;
                #endregion

                }

                //Define the previous Y
                previousy += 10 * numLines;
                loops++;
            }
            //Scroll down
            panelChat.VerticalScroll.Value = panelChat.VerticalScroll.Maximum;
            panelChat.PerformLayout();
        }

        //Edit a comment
        void newEditButton_Click(object sender, EventArgs e)
        {
            //Edits the comment. Possibly through a new screen
            int index = Convert.ToInt32(((Button)sender).Name.Substring(7));
            Administration.EditComment(index,Prompt.ShowDialog("Pas de comment aan naar de volgende text:", "Edit comment"));
            UpdateComments();
        }

        //Delete a comment
        private void btnDeleteComment(object sender, EventArgs e)
        {
            //Deletes the comment
            int index = Convert.ToInt32(((Button)sender).Name.Substring(6));
            Administration.DeleteComment(index);
            UpdateComments();
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

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Pas aan!", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
