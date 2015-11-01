//-----------------------------------------------------------------------
// <copyright file="Inloggen.cs" company="ICT4Participation">
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
    public partial class Inloggen : Form
    {
        private Administration Administration;

        public Inloggen(bool usbAdmin)
        {
            this.InitializeComponent();
            this.Administration = new Administration();

             if (!Administration.testDatabase())
                 MessageBox.Show("Oeps! Er is iets misgegaan tijdens het verbinden. \n Probeer opnieuw of raadpleeg een administrator!");

            //if admin, continue to other screen with details
        }

        private void btnRegistreren_Click(object sender, EventArgs e)
        {
            Registreren form = new Registreren(this);
            form.Show();
            this.Hide();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (Administration.LogIn(tbUsername.Text, tbPassword.Text))
            {
                Form form = new HoofdForm(this, Administration);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("De combinatie van gebruikersnaam en wachtwoord bestaat niet!");
            }
        }
    }
}
