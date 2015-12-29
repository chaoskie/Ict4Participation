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
    public partial class Reactie : Form
    {
        Commentdetails old;
        Accountdetails poster;

        public Reactie(Commentdetails cd)
        {
            InitializeComponent();
            old = cd;
            tbDescription.Text = cd.Description;
            tbPoster.Text = Program.AccountHander.GetInfo(true, cd.PosterID).Name;
            //shows time like this: 06/10/11 15:24:16 +00:00
            lblPostDate.Text = cd.PostDate.ToString("0:MM/dd/yy H:mm:ss zzz");
            tbTitleQuestion.Text = Program.AdminGUIHndlr.GetAll(true).Where(q => q.PostID == cd.PostedToID).First().Title;

            poster = Program.AdminGUIHndlr.GetAll().Where(ac => ac.ID == cd.PosterID).First();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Commentdetails cd = old;
            string message = "";
            cd.Description = tbDescription.Text;
            //bevestig en update de nieuwe input
            if (Program.AdminGUIHndlr.Edit(cd, cd.PosterID, cd.PostID, out message))
            {
                //Messagebox met succes
                MessageBox.Show("Reactie successvol aangepast!");
                //sluit form
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

            string message = ReasonPrompt.ShowDialog("Geef de reden voor verwijdering op:", "Weet u zeker dat u deze comment wilt verwijderen?");
            if (String.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("U heeft geen reden ingevuld, of u heeft de verwijdering geannuleerd.");
            }
            else
            {
                //Remove the comment
                string error = "";
                if (Program.AdminGUIHndlr.Remove(old.PostID, poster.Email, tbTitleQuestion.Text, message, out error))
                {
                    MessageBox.Show(error);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }
    }
}
