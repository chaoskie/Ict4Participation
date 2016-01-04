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
    public partial class Reviews : Form
    {
        Reviewdetails old;
        Accountdetails poster;
        Accountdetails posted;

        public Reviews(Reviewdetails rd)
        {
            InitializeComponent();
            old = rd;
            tbDescription.Text = rd.Description;
            tbPoster.Text = Program.AccountHander.GetInfo(true, rd.PosterID).Name;
            tbPosted.Text = Program.AccountHander.GetInfo(true, rd.PostedToID).Name;

            poster = Program.AdminGUIHndlr.GetAll().Where(ac => ac.ID == rd.PosterID).First();
            posted = Program.AdminGUIHndlr.GetAll().Where(ac => ac.ID == rd.PostedToID).First();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Reviewdetails rd = old;
            rd.Description = tbDescription.Text;
            //bevestig en update de nieuwe input
            string message = "";
            if (Program.AdminGUIHndlr.Edit(rd, rd.PostID, poster.ID, out message))
            {
                MessageBox.Show("Review succesvol aangepast!");
                this.Close();
            }
            else
            {
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
            //Mail user van de aanpassing + reden opgeven
            //verwijder de entry in de database
            //sluit form

            string message = ReasonPrompt.ShowDialog("Geef de reden voor verwijdering op:", "Weet u zeker dat u deze review wilt verwijderen?");
            if (String.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("U heeft geen reden ingevuld, of u heeft de verwijdering geannuleerd.");
            }
            else
            {
                //Remove the Question
                string error = "";
                if (Program.AdminGUIHndlr.RemoveReview(old.PostID, poster.Email, posted.Username, message, out error))
                {
                    MessageBox.Show("Review succesvol verwijderd!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }

        private void Reviews_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.home.Fill();
        }
    }
}
