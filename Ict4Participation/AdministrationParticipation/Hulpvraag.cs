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
    public partial class Hulpvraag : Form
    {
        Questiondetails old;
        Accountdetails poster;

        public Hulpvraag(Questiondetails qd)
        {
            InitializeComponent();
            old = qd;
            lblPostDate.Text = qd.PostDate.ToString("0:MM/dd/yy H:mm:ss zzz");
            tbAddress.Text = qd.Location;
            tbDescription.Text = qd.Description;
            tbEndDate.Text = ((DateTime)qd.EndDate).ToString("0:MM/dd/yy H:mm:ss zzz");
            tbPoster.Text = Program.AccountHander.GetInfo(true, qd.PosterID).Name;
            tbQuestionTitle.Text = qd.Title;
            tbStartDate.Text = ((DateTime)qd.StartDate).ToString("0:MM/dd/yy H:mm:ss zzz");

            poster = Program.AdminGUIHndlr.GetAll().Where(ac => ac.ID == qd.PosterID).First();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Questiondetails qd = old;
            qd.Title = tbQuestionTitle.Text;
            qd.Description = tbDescription.Text;
            //bevestig en update de nieuwe input
            //Messagebox met succes
            string message = "";
            if (Program.AdminGUIHndlr.Edit(qd, qd.PostID, poster.ID, out message))
            {
                MessageBox.Show("Vraag succesvol aangepast!");
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
            //verwijder de entry in de database
            //Mail user van de aanpassing + reden opgeven
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
                if (Program.AdminGUIHndlr.RemoveQuestion(old.PostID, poster.Email, old.Title, message, out error))
                {
                    MessageBox.Show("Vraag succesvol verwijderd!");
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
