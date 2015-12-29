using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministrationParticipation
{
    public partial class Gebruikers : Form
    {
        public Gebruikers()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //TODO
            //bevestig en update de nieuwe input
            //Messagebox met succes
            //sluit form
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
