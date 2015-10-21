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
        private Form previous;
        public PlaatsReview(Form p)
        {
            this.InitializeComponent();

            this.previous = p;

            this.cb1.CheckState = CheckState.Indeterminate;
        }

        private void PlaatsReview_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }

        private void changeStars(object sender, EventArgs e)
        {
        }

        private void btnPlaceReview_Click(object sender, EventArgs e)
        {
            this.previous.Show();
            this.Close();
        }
    }
}
