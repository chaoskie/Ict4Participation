﻿using System;
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
    public partial class UpdateProfile : Form
    {
        private Administration administration;
        OpenFileDialog ofd = new OpenFileDialog();

        public UpdateProfile(Administration a)
        {
            InitializeComponent();
            this.administration = a;
            tbAdress.Text = administration.MainAccountData(3);
            tbEmail.Text = administration.MainAccountData(8);
            tbName.Text = administration.MainAccountData(2);
            tbPhotoPath.Text = administration.MainAccountData(4);
            cbSex.SelectedItem = administration.MainAccountData(7);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;
            if (tbPassword1.Text == tbPassword2.Text)
            {
                //Ask for right password through a prompt
                if (administration.CheckPass(PassPrompt.ShowDialog("Vul uw huidige wachtwoord in:", "Bevestig veranderingen")))
                {
                    if (administration.EditAccount(tbName.Text, tbAdress.Text, cbSex.Text, tbPassword1.Text, tbPhotoPath.Text, tbEmail.Text, out errorMessage))
                    {
                        MessageBox.Show("Account successvol aangepast! \nDe veranderingen zullen de volgende keer worden weergegeven");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }
                else
                {
                    MessageBox.Show("Uw wachtwoord is onjuist! Probeer opnieuw.");
                }
            }
            else
            {
                MessageBox.Show("Wachtwoorden komen niet overeen!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            ofd.DefaultExt = ".png";
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
