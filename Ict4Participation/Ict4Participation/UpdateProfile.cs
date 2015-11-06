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

namespace Ict4Participation
{
    public partial class UpdateProfile : Form
    {
        private Administration administration;

        public UpdateProfile(Administration a)
        {
            InitializeComponent();
            this.administration = a;
        }

        
    }
}
