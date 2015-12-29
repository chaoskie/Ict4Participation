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
    public partial class Resultaten : Form
    {
        public Resultaten(List<Object> objects)
        {
            InitializeComponent();
            lbResultaten.DataSource = objects;
        }

        private void lbResultaten_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Open form dat bij het resultaat hoort
            // vb: hulpvraag objecten --> open Hulpvraag form
            Form f = new Form();
            if (lbResultaten.SelectedItem is Reviewdetails)
            {
                f = new Reviews((Reviewdetails)lbResultaten.SelectedItem);
            }
            if (lbResultaten.SelectedItem is Accountdetails)
            {
                f = new Gebruikers((Accountdetails)lbResultaten.SelectedItem);
            }
            if (lbResultaten.SelectedItem is Questiondetails)
            {
                f = new Hulpvraag((Questiondetails)lbResultaten.SelectedItem);
            }
            if (lbResultaten.SelectedItem is Commentdetails)
            {
                f = new Reactie((Commentdetails)lbResultaten.SelectedItem);
            }
            f.Show();
        }
    }
}
