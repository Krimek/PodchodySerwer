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
        List<int> stationNumberList;
        List<string> specialTaskNameList;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompleteDropList();
            CompleteDataGrid();
        }

        private void CompleteDataGrid()
        {
            
        }

        private void CompleteDropList()
        {
            ServiceDataBase sdb = new ServiceDataBase();

            teamList = sdb.GetAllTeam();
            stationNumberList = sdb.GetStationNumber();
            specialTaskNameList = sdb.GetSpecialTaskName();

            TeamDropDownList.Items.Clear();
            TeamDropDownList.Items.Add("Wszystko");
            foreach (Team team in teamList)
            {
                TeamDropDownList.Items.Add(team.Name);
            }

            StationDropDownList.Items.Clear();
            StationDropDownList.Items.Add("Wszystko");
            foreach (int station in stationNumberList)
            {
                StationDropDownList.Items.Add(station.ToString());
            }

            SpecialTaskDropDownList.Items.Clear();
            SpecialTaskDropDownList.Items.Add("Wszystko");
            foreach(string specialTask in specialTaskNameList)
            {
                SpecialTaskDropDownList.Items.Add(specialTask);
            }
        }

        protected void TeamDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string       selected = TeamDropDownList.Text;
            if(selected == "Wszyscy")
            {

            }
        }
    }
}