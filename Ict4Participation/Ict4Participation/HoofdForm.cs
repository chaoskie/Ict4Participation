//-----------------------------------------------------------------------
// <copyright file="HoofdForm.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin_Layer;

namespace Ict4Participation
{

    public partial class HoofdForm : Form
    {
        private Administration Administration;

        public HoofdForm(Administration a)
        {
            this.InitializeComponent();
            this.Administration = a;

            //Check if the user is a 'hulpverlener', which in that case, they should not be allowed to do as much as usual.
            if (this.Administration.MainAccountData(6) == "Hulpverlener")
            {
                tsbtnPlaceQuestion.Visible = false;
                tsbtnShowOwnRequests.Visible = false;
            }

            lblName.Text = a.MainAccountData(2);
            pbAvatar.ImageLocation = a.MainAccountData(4);
        }

        //Closes the entire app
        private void HoofdForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Logs the user out
        private void tsbtnLogOut_Click(object sender, EventArgs e)
        {
            Administration.LogOut();
            //Show the log in form, do not grant admin rights
            Form form = new Inloggen(false);
            form.Show();
            this.Hide();
        }

        //Opens up the right form to place a question
        private void tsbtnPlaceQuestion_Click(object sender, EventArgs e)
        {
            Form form = new PlaatsHulpvraag(this, Administration);
            form.Show();
            this.Hide();
        }

        #region Requests / Help questions


        private void tsbtnShowAllRequests_Click(object sender, EventArgs e)
        {
            Form form = new HulpVragen(this, Administration, true);
            form.Show();
            this.Hide();
        }

        private void tsbtnShowOwnRequests_Click(object sender, EventArgs e)
        {
            Form form = new HulpVragen(this, Administration, false);
            form.Show();
            this.Hide();
        }

        #endregion

        private void tsmVrijwilligers_Click(object sender, EventArgs e)
        {
            Form form = new Zoeken(true, Administration);
            form.Show();
        }

        private void tsmHulpbehoevenden_Click(object sender, EventArgs e)
        {
            Form form = new Zoeken(false, Administration);
            form.Show();
        }

        #region view own Reviews and Meetings

        private void reviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Afspraken(Administration, false);
            form.Show();
        }

        private void afsprakenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Afspraken(Administration, true);
            form.Show();
        }
        #endregion

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Form form = new UpdateProfile(Administration);
            form.Show();
        }
    }
}
