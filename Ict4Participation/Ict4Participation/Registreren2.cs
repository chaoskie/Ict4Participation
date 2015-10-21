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
        private string Name;
        private string Adress;
        private string City;
        private string Sex;
        private string Role;
        private string Photopath;
        private int Id;
        private string Password;

        public Registreren2(Form p, string name, string adress, string city, string sex, string role, string photopath, int id, string password)
        {
            this.InitializeComponent();
            this.previous = p;
            this.comboBox1.SelectedIndex = 0;

            this.Name = name;
            this.Adress = adress;
            this.City = city;
            this.Sex = sex;
            this.Role = role;
            this.Photopath = photopath;
            this.Id = id;
            this.Password = password;
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
            (((Registreren)this.previous).previous).Show();
            this.Close();
        }
    }
}
