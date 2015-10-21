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

namespace Ict4Participation
{
    public partial class HulpVragen : Form
    {
        private Form previous;

        public HulpVragen(Form p)
        {
            this.InitializeComponent();

            this.previous = p;
        }

        private void btnNieuw_Click(object sender, EventArgs e)
        {
            PlaatsHulpvraag form = new PlaatsHulpvraag(this);
            form.Show();
            this.Hide();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();
            this.previous.Show();
        }

        private void HulpVragen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }
    }
}
