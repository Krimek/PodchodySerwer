using System;
using Podchody.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Podchody.Page
{
    public partial class Managment : System.Web.UI.Page
    {
        List<Team> teamList;
        List<TeamDetail> teamDetailList;
        List<StationLog> stationList;
        List<SpecialTaskLog> specialTaskList;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CompleteDropList()
        {
            ServiceDataBase sdb = new ServiceDataBase();
            teamList = sdb.GetAllTeam();
            teamDetailList = sdb.GetAllTeamDetails();
            stationList = sdb.GetStationLog();
            specialTaskList = sdb.GetSpecialTaskLog();

            TeamDropDownList.Items.Clear();
            TeamDropDownList.Items.Add("Wszystko");
            foreach (Team team in teamList)
            {
                TeamDropDownList.Items.Add(team.Name);
            }

            StationDropDownList.Items.Clear();
            StationDropDownList.Items.Add("Wszystko");
            foreach (StationLog station in stationList)
            {
                //TeamDropDownList.Items.Add(station);
            }
        }
    }
}