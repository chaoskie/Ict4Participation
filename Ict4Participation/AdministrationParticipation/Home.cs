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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            // gebruiker start applicatie en moet inloggen
            // gebruiker wordt gevraagd om  USB_Hasp in te voegen (of andere volgorde idk)
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO
            // kijk welke zoek term is geselecteerd in cbSearchField 
            // zoek op de ingegeven tekst in tbSearchThis
            // Open resultaten form met de zoek resultaten
        }
              
        private void lbNewQuestions_DoubleClick(object sender, EventArgs e)
        {
            //TODO
            //open het geselecteerde object in het Hulpvraag form
        }
        private void lbNewReviews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TODO
            //open het geselecteerde object in het Review form
        }

        private void btnOpenQuestion_Click(object sender, EventArgs e)
        {
            //TODO
            //open het resulaten form voor de question objecten
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            //TODO
            //open het resulaten form voor de gebruiker objecten
        }

        private void btnOpenReaction_Click(object sender, EventArgs e)
        {
            //TODO
            //open het resulaten form voor de reactie objecten
        }

        private void btnOpenReviews_Click(object sender, EventArgs e)
        {
            //TODO
            //open het resulaten form voor de review objecten
        }
                      
    }
}
