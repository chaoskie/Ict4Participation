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
    public static class Prompt
    {
        static bool hasError = false;

        public static bool ShowDialog()
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Authorisatie vereist!",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label()
            {
                Left = 50,
                Top = 20,
                Text = "Vul uw gegevens in (ww & pw)"
            };
            Label lblError = new Label()
            {
                Left = 50,
                Top = 40
            };
            TextBox tbUsername = new TextBox()
            {
                Left = 50,
                Top = 70,
                Width = 400
            };
            TextBox tbPassword = new TextBox()
            {
                Left = 50,
                Top = 120,
                Width = 400,
                UseSystemPasswordChar = true
            };
            Button confirmation = new Button()
            {
                Text = "Ok",
                Left = 350,
                Width = 100,
                Top = 150,
                DialogResult = DialogResult.OK
            };
            confirmation.Click += (sender, e) =>
            {
                if (!hasError)
                {
                    prompt.Close();
                }
            };
            prompt.Controls.Add(tbUsername);
            prompt.Controls.Add(tbPassword);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                //Verify account creds
                string error;
                if (Program.AccountHander.LogIn(tbUsername.Text, tbPassword.Text, out error))
                {
                    hasError = false;
                    return true;
                }
                else
                {
                    lblError.Text = error;
                    hasError = true;
                }

            }
            if (prompt.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
            return false;
        }
    }
}
