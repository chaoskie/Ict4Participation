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
    public partial class Reviews : Form
    {
        public Reviews()
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
            //Mail user van de aanpassing + reden opgeven
            //verwijder de entry in de database
            //sluit form
        }
    }
}
