//-----------------------------------------------------------------------
// <copyright file="Registreren.cs" company="ICT4Participation">
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin_Layer;

namespace Ict4Participation
{
    public partial class Registreren : Form
    {
        public Form previous;
        OpenFileDialog ofd = new OpenFileDialog();

        public Registreren(Form p)
        {
            this.InitializeComponent();
            this.previous = p;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.previous.Show();
            this.Close();
        }

        private void Registreren_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Show();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            string name = this.tbName.Text;
            string adress = this.tbAdress.Text;
            string city = this.tbCity.Text;
            string sex = this.cbSex.SelectedItem.ToString();

            /* Accounttype role;
             Enum.TryParse<Accounttype>(this.cbRoles.SelectedValue.ToString(), out role);
             */
            string photopath = ofd.FileName;

            string id = this.tbID.Text;
            string password = this.tbPassword1.Text;

            bool allOK = true;
            string error = string.Empty;

            if (Regex.IsMatch(name.Trim(), @"^[A-Z][A-Za-z]+$") == false)
            {
                allOK = false;
                error += "Naam is niet correct!\n";
            }
            if (!Regex.IsMatch(adress, @"^[A-Z]\D{1,}\s?\d{1,}$"))
            {
                allOK = false;
                error += "Adres is niet correct!\n";
            }
            if (!Regex.IsMatch(city, @"^[A-Z']\D{1,}$"))
            {
                allOK = false;
                error += "Woonplaats is niet correct!\n";
            }
            if (!Regex.IsMatch(sex, @"^[MF]$"))
            {
                allOK = false;
                error += "Geslacht is niet correct!\n";
            }
            /* NOG NIET GOED! */
            if (ofd.FileName == null)
            {
                allOK = false;
                error += "Geen foto geselecteerd!\n";
            }
            if (!Regex.IsMatch(password, @"^(?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])\S{8,}$"))
            {
                allOK = false;
                error += "Het wachtwoord is niet sterk genoeg! Minimaal 1 hoofdletter, 1 kleine letter en 1 nummer/speciaal karakter.";
            }

            /* if (allOK) {
                 Form form = new Registreren2(this, name, adress, city, sex, role, photopath, id, password);
                 form.Show();
                 this.Hide();
             } else {
                 MessageBox.Show(error);
             }*/

        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            string path = string.Empty;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                this.tbPhotoPath.Text = path;
            }
        }
    }
}
