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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;
            if (administration.EditAccount(tbName.Text, tbAdress.Text, tbCity.Text, cbSex.Text, tbPassword1.Text, tbPhotoPath.Text, tbEmail.Text, out errorMessage))
            {
                MessageBox.Show("Account successvol aangepast! \nDe veranderingen zullen de volgende keer worden weergegeven");
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
