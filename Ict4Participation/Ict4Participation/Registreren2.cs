//-----------------------------------------------------------------------
// <copyright file="Registreren2.cs" company="ICT4Participation">
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
    public partial class Registreren2 : Form
    {
        private Form previous;
        private Administration Administration;

        public Registreren2(Form p, Administration a)
        {
            this.InitializeComponent();
            this.previous = p;
            this.comboBox1.SelectedIndex = 0;
            this.Administration = a;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.previous.Show();
            this.Close();
        }

        private void Registreren_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Close();
        }

        private void btnRegistreer_Click(object sender, EventArgs e)
        {
            //WTF?
            (((Registreren)this.previous).previous).Show();
            this.Close();
        }
    }
}
