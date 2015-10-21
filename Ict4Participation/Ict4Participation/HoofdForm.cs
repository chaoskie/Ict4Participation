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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin_Layer;

namespace Ict4Participation
{

    public partial class HoofdForm : Form
    {
        private Form previous;

        public HoofdForm(Form p)
        {
            this.InitializeComponent();

            this.previous = p;
        }

        private void HoofdForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HulpVragen form = new HulpVragen(this);
            form.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAfspraken_Click(object sender, EventArgs e)
        {
            Afspraken form = new Afspraken(this);
            form.Show();
            this.Hide();
        }

        private void btnZoeken_Click(object sender, EventArgs e)
        {
            Zoeken form = new Zoeken(this);
            form.Show();
            this.Hide();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            PlaatsReview form = new PlaatsReview(this);
            form.Show();
            this.Hide();
        }

        private void btnProfiles_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
