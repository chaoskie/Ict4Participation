using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_Layer;
using Admin_Layer;

namespace AdministrationParticipation
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            List<int> ids = Program.AdminGUIHndlr.GetAll().Select(u => u.ID).Cast<int>().ToList();
            List<Reviewdetails> reviews = new List<Reviewdetails>();

            //Load reviews, order by ...?
            foreach (int id in ids)
            {
                reviews.AddRange(Program.AdminGUIHndlr.GetAllReviews(id));
            }
            //reviews.OrderByDescending(r => r.)
            //Load questions, order by postdate
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO
            // kijk welke zoek term is geselecteerd in cbSearchField 
            // zoek op de ingegeven tekst in tbSearchThis
            // Open resultaten form met de zoek resultaten
            if (cbSearchField.SelectedIndex == 0)
            {
                // Alles... hebben niets voor lmao
            }
            if (cbSearchField.SelectedIndex == 1)
            {
                //Users
            }
            if (cbSearchField.SelectedIndex == 2)
            {
                //Questions
            }
            if (cbSearchField.SelectedIndex == 3)
            {
                //Comments
            }
            if (cbSearchField.SelectedIndex == 4)
            {
                //Reviews
            }
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
