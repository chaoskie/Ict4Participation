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

            //OLD this.cb1.CheckState = CheckState.Indeterminate;
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

        private void nudStar_ValueChanged(object sender, EventArgs e)
        {
            StarsChange();
            switch ((int)nudStar.Value)
            {
                case 0:
                    StarsChange();
                    break;
                case 1:
                    pbStar1.Visible = true;
                    break;
                case 2:
                    pbStar1.Visible = true;
                    pbStar2.Visible = true;
                    break;
                case 3:
                    pbStar1.Visible = true;
                    pbStar2.Visible = true;
                    pbStar3.Visible = true;
          
                    break;
                case 4:
                    pbStar1.Visible = true;
                    pbStar2.Visible = true;
                    pbStar3.Visible = true;
                    pbStar4.Visible = true;
                    break;
                case 5:
                    pbStar1.Visible = true;
                    pbStar2.Visible = true;
                    pbStar3.Visible = true;
                    pbStar4.Visible = true;
                    pbStar5.Visible = true;
                    break;
            }
        }
        public void StarsChange()
        {
            pbStar1.Visible = false;
            pbStar2.Visible = false;
            pbStar3.Visible = false;
            pbStar4.Visible = false;
            pbStar5.Visible = false;
        }
    }
}
