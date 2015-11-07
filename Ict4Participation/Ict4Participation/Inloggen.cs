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

             Clipboard.SetText(Administration.giveTestHash());

            //if admin, continue to other screen with details
            if (true)
            {
                AdminForm form = new AdminForm(this, this.Administration);
                form.Show();
                this.Hide();
            }
        }

        private void btnRegistreren_Click(object sender, EventArgs e)
        {
            Registreren form = new Registreren(this, this.Administration);
            form.Show();
            this.Hide();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LogIn(sender, e);
        }

        private void LogIn(object sender, EventArgs e)
        {
            if (tbUsername.TextLength >= 3)
            {
                if (Administration.LogIn(tbUsername.Text, tbPassword.Text))
                {
                    Form form = new HoofdForm(Administration);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    tbPassword.Text = string.Empty;
                    MessageBox.Show("De combinatie van gebruikersnaam en wachtwoord bestaat niet!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                tbPassword.Text = string.Empty;
                MessageBox.Show("Gebruikersnaam is te kort.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
