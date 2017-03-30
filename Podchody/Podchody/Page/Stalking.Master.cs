using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Podchody.Page
{
    public partial class Stalking : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!App_Code.Properties.LogIn)
            {
                logOutDiv.Controls.Clear();
            }
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            App_Code.Properties.LogIn = false;
            Server.Transfer("Index.aspx");
        }
    }
}