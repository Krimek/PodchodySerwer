using Podchody.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Podchody.Page
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NextButton.Click += new EventHandler(NextButtonClick);
        }

        private void NextButtonClick(object sender, EventArgs e)
        {
            Server.Transfer("Managment.aspx");
        }
    }
}