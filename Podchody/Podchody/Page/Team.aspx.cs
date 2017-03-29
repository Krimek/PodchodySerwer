using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Podchody.Page
{
    public partial class Team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Models.ServiceDataBase sdb = new Models.ServiceDataBase();
            Models.Team team = sdb.GetTeam(Request["id"]);
            idLabel.Text += team.Id;
            nameLabel.Text += team.Name;
            startTimeLabel.Text += team.StartTime;
            finishTimeLabel.Text += team.FinishTime;
            amountHintLabel.Text += team.AmountHint;
            amountFullHintLabel.Text += team.AmountNextPlace;
            currentStationLabel.Text += team.CurrentStation;
            scoreLabel.Text += team.Points;
            foreach(Models.StationLog st in team.StationLogs)
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
            }
        }
    }
}