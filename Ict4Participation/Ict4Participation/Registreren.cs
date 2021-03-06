﻿//-----------------------------------------------------------------------
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
        private Administration Administration;
        OpenFileDialog ofd = new OpenFileDialog();

        public Registreren(Form p, Administration a)
        {
            this.InitializeComponent();
            this.previous = p;
            this.Administration = a;

            this.cbRoles.SelectedIndex = 0;
            this.cbSex.SelectedIndex = 0;
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
            string ErrorMessage = string.Empty;
            string name = this.tbName.Text;
            string address = this.tbAdress.Text;
            string city = this.tbCity.Text;
            string sex = this.cbSex.SelectedItem.ToString();
            string role = this.cbRoles.SelectedItem.ToString();
            string avatarPath = ofd.FileName;
            string password = this.tbPassword1.Text;
            string email = this.tbEmail.Text;

            //Check if the account is filled in correctly
            if (Administration.CreateAccount(name, address, city, password, avatarPath, role, sex, email, out ErrorMessage))
            {
                //If role is 'hulpbehoevende', it's done
                if (cbRoles.SelectedIndex == 0)
                {
                     if (Administration.RegisterAccount())
                     {
                         Form form = new HoofdForm(Administration);
                         form.Show();
                         this.Hide();
                     }
                }
                else
                {
                    //else, send the 'hulpverlener' to the next screen
                    Form form = new Registreren2(this, Administration);
                    form.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show(ErrorMessage);
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "All Files (*.*)|*.*|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|BMP Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|JPEG Files (*.jpeg)|*.jpeg";
            string filename = string.Empty;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                if (filename.ToLower().Contains(".jpg") || filename.ToLower().Contains(".png") || 
                        filename.ToLower().Contains(".bmp") || filename.ToLower().Contains(".gif") || 
                        filename.ToLower().Contains(".jpeg"))
                {
                    this.tbPhotoPath.Text = filename;
                }
                else
                {
                    MessageBox.Show("Profielfoto is geen afbeelding!");
                }
            }
        }
    }
}
