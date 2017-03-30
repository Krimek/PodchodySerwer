using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Podchody.Page
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Log_Click(object sender, EventArgs e)
        {
            if (App_Code.Properties.Login == LoginTextBox.Text && App_Code.Properties.Password == PasswordTextBox.Text)
            {
                App_Code.Properties.LogIn = true;
                Server.Transfer("Managment.aspx");
            }
        }
    }
}