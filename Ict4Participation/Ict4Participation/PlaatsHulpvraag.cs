//-----------------------------------------------------------------------
// <copyright file="PlaatsHulpvraag.cs" company="ICT4Participation">
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
    public partial class PlaatsHulpvraag : Form
    {
        private Form previous;
        private Administration Administration;

        public PlaatsHulpvraag(Form p, Administration a)
        {
            this.InitializeComponent();

            this.previous = p;
            this.Administration = a;

            cbSkills.DataSource = Administration.AllSkillTypes();
            this.cbSkills.SelectedIndex = 0;

            this.dtpDate.CustomFormat = "d MMMM yyyy - hh:mm:ss";
        }

        private void btnVoegToe_Click(object sender, EventArgs e)
        {
            //check if skill doesn't already exist
            if (lbSkills.Items.Contains(cbSkills.Text))
            {
                MessageBox.Show("Skill al toegevoegd!");
            }
            else
            {
                //add skill
                lbSkills.Items.Add(cbSkills.Text);
            }
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            //check if skill is selected
            if (lbSkills.SelectedIndex != -1)
            {
                //remove skill
                lbSkills.Items.RemoveAt(lbSkills.SelectedIndex);
            }
        }

        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            //close screen
            this.previous.Show();
            this.Close();
        }

        private void btnGereed_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbTitel.Text))
            {
                //Call the admin class to handle the question creation, which yields a success / failure string
                MessageBox.Show(Administration.PostQuestion(tbTitel.Text, dtpDate.Value, tbHulpvraag.Text));
                this.previous.Show();
                this.Close();
            }
        }

        private void PlaatsHulpvraag_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }
    }
}
