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

        //Find the helpers by default
        public Zoeken(bool findV, Administration a)
        {
            this.InitializeComponent();
            this.administration = a;
            lbUsers.DataSource = null;
            
            if (findV)
            {
                lbUsers.DataSource = administration.GetAccounts("V");
            }
            else
            {
                lbUsers.DataSource = administration.GetAccounts("H");
            }
        }

        private void btnShowProfile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //TODO
            //Set datasource to new list
            lbUsers.DataSource = null;
            //lbUsers.DataSource = administration.GetAccounts("");
        }
    }
}
