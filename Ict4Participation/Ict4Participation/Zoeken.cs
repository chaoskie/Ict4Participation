//-----------------------------------------------------------------------
// <copyright file="Zoeken.cs" company="ICT4Participation">
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
    public partial class Zoeken : Form
    {
        private Form previous;

        public Zoeken(Form p)
        {
            this.InitializeComponent();

            this.previous = p;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.previous.Show();
            this.Close();
        }

        private void Zoeken_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }
    }
}
