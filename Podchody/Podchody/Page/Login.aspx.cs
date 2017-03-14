﻿using System;
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
            Login1.LoggedIn += new EventHandler(Login_login);
        }

        private void Login_login(object sender, EventArgs e)
        {
            Server.Transfer("Managment.aspx");
        }
    }
}