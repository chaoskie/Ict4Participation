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
    public partial class Resultaten : Form
    {
        public Resultaten(List<Object> objects)
        {
            InitializeComponent();
            lbResultaten.DataSource = objects;
        }

        private void lbResultaten_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TODO
            //Open form dat bij het resultaat hoort
            // vb: hulpvraag objecten --> open Hulpvraag form
        }
    }
}
