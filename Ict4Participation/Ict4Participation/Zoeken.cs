//-----------------------------------------------------------------------
// <copyright file="Zoeken.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
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
    public partial class Zoeken : Form
    {
        Administration administration;
        private string V;

        //Find the helpers by default
        public Zoeken(bool findV, Administration a)
        {
            this.InitializeComponent();
            this.administration = a;
            lbUsers.DataSource = null;

            if (findV)
            {
                this.V = "Hulpverlener";
                lbUsers.DataSource = administration.GetAccounts("Hulpverlener");
            }
            else
            {
                this.V = "Hulpbehoevende";
                lbUsers.DataSource = administration.GetAccounts("Hulpbehoevende");
            }
        }

        private void btnShowProfile_Click(object sender, EventArgs e)
        {
            Form form = new Profiles(administration, lbUsers.SelectedIndex);
            form.Show();
            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbSearch.Text))
            {
                //Set datasource to new list
                lbUsers.DataSource = null;
                lbUsers.DataSource = administration.GetAccounts(V, true, tbSearch.Text);
            }
            else
            {
                lbUsers.DataSource = null;
            }
        }
    }
}
