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

namespace AdministrationParticipation
{
    public partial class Gebruikers : Form
    {
        Accountdetails old;
        string newpass = "";

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
            //TODO IMP: on website deployment, change this path
            pbProfielImage.ImageLocation = "http://localhost:9472/" + ad.AvatarPath.Substring(3);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Accountdetails accd = new Accountdetails();
            //TODO Fill in the details
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
                MessageBox.Show("Account succesvol aangepast!");
                //sluit form
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
            //TODO
            //sluit form + verwerp aanpassingen
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            //TODO
            //verwijder de entry in de database
            //Mail user van de aanpassing + reden opgeven
            //sluit form
        }

        private void btnGenerateNewPass_Click(object sender, EventArgs e)
        {
            //TODO
            //Genereer nieuw wachtwoord en mail dit naar de gebruiker 
        }

        private void btnDelPicture_Click(object sender, EventArgs e)
        {
            //TODO
            //verwijder de profielfoto van en gebruiker 
            // mail gebruiker van wijziging met reden
        }

        private void btnDownloadVOG_Click(object sender, EventArgs e)
        {
            //TODO
            //open de default browser met url naar de file
            //application.run(url) oid.
        }
    }
}
