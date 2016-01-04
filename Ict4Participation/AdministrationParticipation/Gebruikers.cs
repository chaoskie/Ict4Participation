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
using Class_Layer.Utility_Classes;

namespace AdministrationParticipation
{
    public partial class Gebruikers : Form
    {
        Accountdetails old;
        //TODO IMP: on website deployment, change this path
        const string site = "http://localhost:9472/";

        string newpass = "";
        bool passChanged = false;

        public Gebruikers(Accountdetails ad)
        {
            InitializeComponent();

            old = ad;
            tbAddress.Text = ad.Address;
            tbMail.Text = ad.Email;
            tbName.Text = ad.Name;
            tbUsername.Text = ad.Username;
            tbPhone.Text = ad.Phonenumber;
            cbGeslacht.SelectedIndex = ad.Gender.ToLower() == "m" ? 0 : 1;
            cbTypeAcc.SelectedIndex = String.IsNullOrWhiteSpace(ad.VOGPath) ? 0 : 1;
            pbProfielImage.ImageLocation = site + @"ProfileAvatars\" + ad.AvatarPath;
            pbProfielImage.SizeMode = PictureBoxSizeMode.Zoom;

            DateTime zeroTime = new DateTime(1, 1, 1);

            TimeSpan span = DateTime.Now - ad.Birthdate;
            int years = (zeroTime + span).Year - 1;

            lblAge.Text = years.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Accountdetails accd = new Accountdetails();
            //Fill in the details
            accd = old;
            accd.Address = tbAddress.Text;
            accd.Email = tbMail.Text;
            accd.Name = tbName.Text;
            accd.Username = tbUsername.Text;
            accd.Phonenumber = tbPhone.Text;
            accd.Gender = cbGeslacht.SelectedItem.ToString() == "Man" ? "M" : "V";

            string message = "";
            //bevestig en update de nieuwe input
            if (Program.AdminGUIHndlr.Edit(accd, out message, accd.ID, newpass, newpass))
            {
                if (passChanged)
                {
                    EmailHandler.SendPassChange(old.Email, old.Username, newpass, true);
                }
                MessageBox.Show("Account succesvol aangepast!");
                this.Close();
            }
            else
            {
                //it failed
                MessageBox.Show(message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //sluit form + verwerp aanpassingen
            this.Close();
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            //verwijder de entry in de database
            //Mail user van de aanpassing + reden opgeven
            string message = ReasonPrompt.ShowDialog("Geef de reden voor deactivatie op:", "Weet u zeker dat u dit account wilt deactiveren?");
            if (String.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("U heeft geen reden ingevuld, of u heeft de deactivatie geannuleerd.");
            }
            else
            {
                //Deactivate the account
                Program.AdminGUIHndlr.DeactivateAccount(old.ID, old.Email, old.Username, message);
                this.Close();
            }
        }

        private void btnGenerateNewPass_Click(object sender, EventArgs e)
        {
            //Genereer nieuw wachtwoord en mail dit naar de gebruiker 
            newpass = KeyGenerator.GetUniqueKey(30);
            passChanged = true;
            MessageBox.Show("Nieuw wachtwoord gegenereerd, bevestig om de veranderingen definitief te maken.");
        }

        private void btnDelPicture_Click(object sender, EventArgs e)
        {
            // mail gebruiker over het foutief gebruik van avatars
            // mail webbeheerder
            EmailHandler.SendWrongAvatar(old.Email, old.Username);
        }

        private void btnDownloadVOG_Click(object sender, EventArgs e)
        {
            //open de default browser met url naar de file
            System.Diagnostics.Process.Start(site + "ProfileVOGs_Unvalidated/" + old.ID + ".pdf");
        }
    }
}
