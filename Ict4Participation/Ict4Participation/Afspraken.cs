//-----------------------------------------------------------------------
// <copyright file="Afspraken.cs" company="ICT4Participation">
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
    public partial class Afspraken : Form
    {
        private Administration administration;
        private bool containsMeetings;

        public Afspraken(Administration a, bool loadMeeting)
        {
            this.InitializeComponent();
            administration = a;
            rtbInfo.Enabled = false;

            lblType.Text = loadMeeting ? "Afspraken:" : "Reviews";
            containsMeetings = loadMeeting;

            if (loadMeeting)
            {
                //Load meetings
                foreach (string s in administration.GetMainAccountMeetings())
                {
                    rtbInfo.Text += s + Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                //If the logged in user is a 'hulpverlener', he wants to see the reviews posted to his account
                //If the logged in user is a 'hulpbehoevende', he wants to see the reviews he posted to people
                bool isPoster = administration.MainAccountData(6) == "Hulpverlener" ? false : true;
                foreach (string s in administration.GetAccountReviews(isPoster))
                {
                    rtbInfo.Text += s + Environment.NewLine + Environment.NewLine;
                }
            }
        }
    }
}
