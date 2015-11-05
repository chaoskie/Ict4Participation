//-----------------------------------------------------------------------
// <copyright file="PlaatsReview.cs" company="ICT4Participation">
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
    public partial class PlaatsReview : Form
    {
        private Administration administration;
        private int userID;
        private string username;

        private Form previous;
        public PlaatsReview(Form p, Administration a, int userID, string username)
        {
            this.InitializeComponent();
            this.administration = a;
            this.previous = p;
            this.userID = userID;
            this.username = username;
            changeStars();
            cbHulpverlener.DataSource = administration.GetAccounts("Hulpverlener");

            cbHulpverlener.Text = username;
        }

        private void PlaatsReview_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }

        private void changeStars()
        {
            //Search through the controls to find the matching star to set visible (nud value 1 = star 1 visible)
            var pb = StarsPanel.Controls.Find("pbStar" + nudStar.Value, true).FirstOrDefault().Visible = true;
            //Search through the controls to find the matching star, yet 1 number higher (in case of decrease)
            var pbhi = StarsPanel.Controls.Find("pbStar" + Convert.ToInt32(nudStar.Value + 1), true).FirstOrDefault();
            if (pbhi != null) pbhi.Visible = false;
        }

        private void btnPlaceReview_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            //Check if username exists
            if (administration.GetAccounts().Exists(c => c == cbHulpverlener.Text))
            {
                //Post review
                administration.PostReview(userID, tbTitle.Text, tbDescription.Text, Convert.ToInt32(nudStar.Value), out message);
                MessageBox.Show(message);
                this.previous.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Gebruiker bestaat niet!");
            }
        }

        private void nudStar_ValueChanged(object sender, EventArgs e)
        {
            changeStars();
        }
    }
}
