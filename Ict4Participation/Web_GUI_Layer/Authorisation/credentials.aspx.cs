using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_GUI_Layer.Authorisation
{
    public partial class credentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login.UserName;
            string password = Login.Password;
            if (FormsAuthentication.Authenticate(username, password))
            {
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
        }
    }
}