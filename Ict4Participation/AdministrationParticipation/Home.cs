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
            //Set username
            lblUsername.Text = Program.AccountHander.MainUser.Name;

            //Start initialising the set up for the reviews
            List<int> ids = Program.AdminGUIHndlr.GetAll().Select(u => u.ID).Cast<int>().ToList();
            List<Reviewdetails> reviews = new List<Reviewdetails>();

            //Load reviews, order by newest
            foreach (int id in ids)
            {
                reviews.AddRange(Program.AdminGUIHndlr.GetAllReviews(id));
            }
            reviews = reviews.OrderByDescending(r => r.PostID).OrderByDescending(r => r.PostID).ToList();
            lbNewReviews.DataSource = reviews;

            //Load questions, order by postdate
            List<Questiondetails> questions = Program.AdminGUIHndlr.GetAll(true).OrderByDescending(q => q.PostDate).ToList();
            lbNewQuestions.DataSource = questions;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form f = new Form();

            // kijk welke zoek term is geselecteerd in cbSearchField 
            // zoek op de ingegeven tekst in tbSearchThis
            // Open resultaten form met de zoek resultaten
            if (cbSearchField.SelectedIndex == 0)
            {
                //TODO
                // Alles... hebben niets voor lmao
            }
            if (cbSearchField.SelectedIndex == 1)
            {
                List<Accountdetails> accd = new List<Accountdetails>();

                //Users
                Accountdetails acc = new Accountdetails();
                acc.Name = tbSearchThis.Text;
                accd.AddRange(Program.AdminGUIHndlr.Search(acc, true));

                //Show results in new form
                f = new Resultaten(accd.Cast<Object>().ToList());
            }
            if (cbSearchField.SelectedIndex == 2)
            {
                List<Questiondetails> qued = new List<Questiondetails>();

                //Questions
                Questiondetails que = new Questiondetails();
                que.Title = tbSearchThis.Text;
                qued.AddRange(Program.AdminGUIHndlr.Search(que, true));

                que = new Questiondetails();
                que.Description = tbSearchThis.Text;
                qued.AddRange(Program.AdminGUIHndlr.Search(que, true));

                //Show results in new form
                f = new Resultaten(qued.Cast<Object>().ToList());
            }
            if (cbSearchField.SelectedIndex == 3)
            {
                //Comments
                List<Commentdetails> commd = new List<Commentdetails>();

                //Fetch all the comments
                foreach (Question q in Program.AdminGUIHndlr.LoadedQuestions)
                {
                    commd.AddRange(Program.AdminGUIHndlr.GetAll(q.PostID));
                }
                commd = commd.Where(c => c.Description.Contains(tbSearchThis.Text)).ToList();

                //Show results in new form
                f = new Resultaten(commd.Cast<Object>().ToList());
            }
            if (cbSearchField.SelectedIndex == 4)
            {
                //Reviews
                List<int> ids = Program.AdminGUIHndlr.GetAll().Select(u => u.ID).Cast<int>().ToList();
                List<Reviewdetails> reviews = new List<Reviewdetails>();

                //Load reviews, order by newest
                foreach (int id in ids)
                {
                    reviews.AddRange(Program.AdminGUIHndlr.GetAllReviews(id));
                }
                reviews = reviews.OrderByDescending(r => r.PostID).Where(r => r.Description.Contains(tbSearchThis.Text)).ToList();

                //Show results in new form
                f = new Resultaten(reviews.Cast<Object>().ToList());
            }

            //Open form
            f.Show();
        }

        private void lbNewQuestions_DoubleClick(object sender, EventArgs e)
        {
            //open het geselecteerde object in het Hulpvraag form
            Form f = new Hulpvraag((Questiondetails)lbNewQuestions.SelectedItem);
            f.Show();
        }
        private void lbNewReviews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //open het geselecteerde object in het Review form
            Form f = new Reviews((Reviewdetails)lbNewReviews.SelectedItem);
            f.Show();
        }

        private void btnOpenQuestion_Click(object sender, EventArgs e)
        {
            //open het resulaten form voor de question objecten
            List<Questiondetails> questions = Program.AdminGUIHndlr.GetAll(true).OrderByDescending(q => q.PostDate).ToList();
            Form f = new Resultaten(questions.Cast<Object>().ToList());
            f.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            //open het resulaten form voor de gebruiker objecten
            List<Accountdetails> users = Program.AdminGUIHndlr.GetAll();
            Form f = new Resultaten(users.Cast<Object>().ToList());
            f.Show();
        }

        private void btnOpenReaction_Click(object sender, EventArgs e)
        {
            //open het resulaten form voor de comment objecten
            List<Commentdetails> commd = new List<Commentdetails>();
            //Fetch all the comments
            foreach (Question q in Program.AdminGUIHndlr.LoadedQuestions)
            {
                commd.AddRange(Program.AdminGUIHndlr.GetAll(q.PostID));
            }
            commd = commd.OrderByDescending(c => c.PostDate).ToList();
            Form f = new Resultaten(commd.Cast<Object>().ToList());
            f.Show();
        }

        private void btnOpenReviews_Click(object sender, EventArgs e)
        {
            //open het resulaten form voor de review objecten

            //Start initialising the set up for the reviews
            List<int> ids = Program.AdminGUIHndlr.GetAll().Select(u => u.ID).Cast<int>().ToList();
            List<Reviewdetails> reviews = new List<Reviewdetails>();

            //Load reviews, order by newest
            foreach (int id in ids)
            {
                reviews.AddRange(Program.AdminGUIHndlr.GetAllReviews(id));
            }
            reviews = reviews.OrderByDescending(r => r.PostID).OrderByDescending(r => r.PostID).ToList();
            Form f = new Resultaten(reviews.Cast<Object>().ToList());
            f.Show();
        }

    }
}
