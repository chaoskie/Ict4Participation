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
    public partial class MaakAfspraak : Form
    {
        private Administration administration;

        private string username;
        private int userID;

        public MaakAfspraak(Administration a, int accIndex)
        {
            InitializeComponent();
            this.administration = a;

            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.CustomFormat = "dd-MMM-yyyy HH:mm:s";

            userID = Convert.ToInt32(administration.AccountData(accIndex, 1));
            lblName.Text = username = administration.AccountData(accIndex, 2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(administration.CreateMeeting(userID, dtpTime.Value, tbLoc.Text));
            this.Close();
        }
    }
}
