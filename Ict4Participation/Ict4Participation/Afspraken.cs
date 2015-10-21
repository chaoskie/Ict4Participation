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

namespace Ict4Participation
{
    public partial class Afspraken : Form
    {
        private Form previous;

        public Afspraken(Form p)
        {
            this.InitializeComponent();

            this.previous = p;
        }

        private void Afspraken_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }
    }
}
