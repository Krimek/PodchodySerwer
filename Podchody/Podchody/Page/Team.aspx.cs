using Podchody.Models;
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
        string[] headerStationTable = { "Numer stacji", "Godzina", "Id", "Id Stacji" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!App_Code.Properties.LogIn)
            {
                Server.Transfer("Index.aspx");
            }
            ServiceDataBase sdb = new ServiceDataBase();
            Models.Team team = sdb.GetTeam(Request["id"]);
            idLabel.Text += team.Id;
            nameLabel.Text += team.Name;
            startTimeLabel.Text += team.StartTime;
            finishTimeLabel.Text += team.FinishTime;
            amountHintLabel.Text += team.AmountHint;
            amountFullHintLabel.Text += team.AmountNextPlace;
            currentStationLabel.Text += team.CurrentStation;
            scoreLabel.Text += team.Points;
            List<StationLog> st = sdb.GetStationLogByTeamId(team.Id);

            DataTable dt = new DataTable();
            DataRow dr = null;
            for (int i = 0; i < headerStationTable.Count(); i++)
            {
                dt.Columns.Add(new DataColumn(headerStationTable[i], typeof(string)));
            }
            foreach (StationLog stlog in st)
            {
                dr = dt.NewRow();
                dr[0] = stlog.Station.NumberOfStation;
                dr[1] = stlog.Time;
                dr[2] = stlog.Id;
                dr[3] = stlog.IdStation;
                dt.Rows.Add(dr);
            }
            stationGridView.Controls.Clear();
            stationGridView.DataSource = dt;
            stationGridView.DataBind();

        }
    }
}