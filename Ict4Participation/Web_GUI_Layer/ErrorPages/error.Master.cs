using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_GUI_Layer.ErrorPages
{
    public partial class Error1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/hoofdmenu.aspx", false);
        }
    }
}