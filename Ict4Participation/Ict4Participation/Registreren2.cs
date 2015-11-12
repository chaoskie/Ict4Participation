//-----------------------------------------------------------------------
// <copyright file="Registreren2.cs" company="ICT4Participation">
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
    public partial class Registreren2 : Form
    {
        private Form previous;
        private Administration Administration;
        OpenFileDialog ofd = new OpenFileDialog();

        public Registreren2(Form p, Administration a)
        {
            this.InitializeComponent();
            this.previous = p;
            this.Administration = a;
            cbSkills.DataSource = a.AllSkillTypes();
            this.cbSkills.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.previous.Show();
            this.Close();
        }

        private void Registreren_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.previous.Close();
        }

        private void btnRegistreer_Click(object sender, EventArgs e)
        {
            //Registreer
            string message = string.Empty;
            if (Administration.CreateAccountHPart(tbVOGPath.Text, "", lbSkills.Items.Cast<string>().ToList(), out message))
            {
                Administration.RegisterAccount();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            //check if skill doesn't already exist
            if (lbSkills.Items.Contains(cbSkills.Text))
            {
                MessageBox.Show("Skill al toegevoegd!");
            }
            else
            {
                //add skill
                lbSkills.Items.Add(cbSkills.Text);
            }
        }

        private void btnRemoveSkills_Click(object sender, EventArgs e)
        {
            //check if skill is selected
            if (lbSkills.SelectedIndex != -1)
            {
                //remove skill
                lbSkills.Items.RemoveAt(lbSkills.SelectedIndex);
            }
        }

        private void btnAddVOG_Click(object sender, EventArgs e)
        {
            ofd.Filter = "PDF Files (*.pdf)|*.pdf";
            string path = string.Empty;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                this.tbVOGPath.Text = path;
            }
        }
    }
}
