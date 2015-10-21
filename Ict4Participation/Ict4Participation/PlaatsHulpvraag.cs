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

        public PlaatsHulpvraag(Form p)
        {
            this.InitializeComponent();

            this.previous = p;
            this.cbSkills.SelectedIndex = 2;

            this.dtpDate.CustomFormat = "d MMMM yyyy - hh:mm:ss";
        }

        private void btnGereed_Click(object sender, EventArgs e)
        {
            this.previous.Show();
            this.Close();
        }

        private void PlaatsHulpvraag_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }
    }
}
