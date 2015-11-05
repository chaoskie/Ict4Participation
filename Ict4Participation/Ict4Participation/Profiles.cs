﻿//-----------------------------------------------------------------------
// <copyright file="Profiles.cs" company="ICT4Participation">
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
    public partial class Profiles : Form
    {
        private Administration administration;
        private int userIndex;

        private string username;
        private int userID;

        public Profiles(Administration a, int accIndex)
        {
            InitializeComponent();
            this.administration = a;
            this.userIndex = accIndex;

            userID = Convert.ToInt32(administration.AccountData(accIndex, 1));
            pbAvatar.ImageLocation = administration.AccountData(accIndex, 4);
            lblName.Text = username = administration.AccountData(accIndex, 2);
            lblRole.Text = administration.AccountData(accIndex, 6);
        }

        private void buttonTerug_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void afspraakMakenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void detailsWeergevenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        #region reviews
        private void plaatsenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new PlaatsReview(this, administration, userID, username);
            form.Show();
            this.Hide();
        }

        private void weergevenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string details = string.Empty;
            foreach (string s in administration.GetAccountReviews(Convert.ToInt32(userID)))
            {
                details += s + Environment.NewLine;
            }
            if (!String.IsNullOrWhiteSpace(details))
            {
                MessageBox.Show(details);
            }
        }
        #endregion
    }
}
