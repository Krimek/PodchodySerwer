using System;
using Podchody.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Podchody.Page
{
    public partial class Managment : System.Web.UI.Page
    {
        string[] headerTeamGridView = { "Id", "Nazwa druzyny", "Godzina startu", "Godzina mety", "Ilosc podpowiedzi", "Ilosc pelnych podpowiedzi", "Aktualna stacja", "Wynik" };
        string[] headerStationLogGridView = { "Id", "Godzina", "Id drużyny", "Nazwa drużyny", "Id stacji", "Numer stacji" };
        string[] headerSpecialTaskGridView = { "Id", "Godzina", "Id drużyny", "Nazwa drużyny", "Id zadania specjalnego", "Nazwa zadania" };
        string[] headerHintLogGridView = { "Id", "Godzina", "Id drużyny", "Nazwa drużyny", "Id stacji", "Numer stacji", "Podpowiedź", "Pełna podpowiedź" };
        List<Models.Team> teamList;
        List<Station> stationList;
        List<SpecialTask> specialTaskList;
        List<HintLog> hintLogList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServiceDataBase sdb = new ServiceDataBase();
                List<StationLog> stationLogList = sdb.GetStationLog();
                List<SpecialTaskLog> specialTaskLogList = sdb.GetSpecialTaskLog();
                List<HintLog> hintLogList = sdb.GetHintList();
                CompleteDropList();
                CompleteTeamGridView();
                RefreshStationGridView(stationLogList);
                RefreshSpecialTaskGridView(specialTaskLogList);
                RefreshHintGridView(hintLogList);
            }
        }

        private void CompleteTeamGridView()
        {
            ServiceDataBase sdb = new ServiceDataBase();
            teamList = sdb.GetAllTeam();
            DataTable dt = new DataTable();
            DataRow dr = null;
            for (int i = 0; i < headerTeamGridView.Count(); i++)
            {
                dt.Columns.Add(new DataColumn(headerTeamGridView[i], typeof(string)));
            }
            for (int i = 0; i < teamList.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = teamList.ElementAt(i).Id;
                dr[1] = teamList.ElementAt(i).Name;
                dr[2] = teamList.ElementAt(i).StartTime;
                dr[3] = teamList.ElementAt(i).FinishTime;
                dr[4] = teamList.ElementAt(i).AmountHint;
                dr[5] = teamList.ElementAt(i).AmountNextPlace;
                if (sdb.AmountStation() < teamList.ElementAt(i).CurrentStation)
                {
                    dr[6] = "Meta";
                }
                else
                {
                    dr[6] = teamList.ElementAt(i).CurrentStation;
                }
                dr[7] = teamList.ElementAt(i).Points;
                dt.Rows.Add(dr);
            }
            TeamGridView.Controls.Clear();
            TeamGridView.DataSource = dt;
            TeamGridView.DataBind();
        }

        private void RefreshStationGridView(List<StationLog> stationLogList)
        {
            ServiceDataBase sdb = new ServiceDataBase();
            DataTable dt = new DataTable();
            DataRow dr = null;
            for (int i = 0; i < headerStationLogGridView.Count(); i++)
            {
                dt.Columns.Add(new DataColumn(headerStationLogGridView[i], typeof(string)));
            }
            for (int i = 0; i < stationLogList.Count; i++)
            {
                Models.Team team = sdb.GetTeam(stationLogList.ElementAt(i).IdTeam);
                Station station = sdb.GetStation(stationLogList.ElementAt(i).IdStation);
                dr = dt.NewRow();
                dr[0] = stationLogList.ElementAt(i).Id;
                dr[1] = stationLogList.ElementAt(i).Time;
                dr[2] = stationLogList.ElementAt(i).IdTeam;
                dr[3] = team.Name;
                dr[4] = stationLogList.ElementAt(i).IdStation;
                dr[5] = station.NumberOfStation;
                dt.Rows.Add(dr);
            }
            StationGridView.Controls.Clear();
            StationGridView.DataSource = dt;
            StationGridView.DataBind();
        }

        private void RefreshSpecialTaskGridView(List<SpecialTaskLog> specialTaskLogList)
        {
            ServiceDataBase sdb = new ServiceDataBase();
            DataTable dt = new DataTable();
            DataRow dr = null;
            for (int i = 0; i < headerSpecialTaskGridView.Count(); i++)
            {
                dt.Columns.Add(new DataColumn(headerSpecialTaskGridView[i], typeof(string)));
            }
            for (int i = 0; i < specialTaskLogList.Count; i++)
            {
                Models.Team team = sdb.GetTeam(specialTaskLogList.ElementAt(i).IdTeam);
                SpecialTask specialTask = sdb.GetSpecialTask(specialTaskLogList.ElementAt(i).IdSpecialTask);
                dr = dt.NewRow();
                dr[0] = specialTaskLogList.ElementAt(i).Id;
                dr[1] = specialTaskLogList.ElementAt(i).Time;
                dr[2] = specialTaskLogList.ElementAt(i).IdTeam;
                dr[3] = team.Name;
                dr[4] = specialTaskLogList.ElementAt(i).IdSpecialTask;
                dr[5] = specialTask.Name;
                dt.Rows.Add(dr);
            }
            SpecialTaskGridView.Controls.Clear();
            SpecialTaskGridView.DataSource = dt;
            SpecialTaskGridView.DataBind();
        }

        private void RefreshHintGridView(List<HintLog> hintLogList)
        {
            ServiceDataBase sdb = new ServiceDataBase();
            DataTable dt = new DataTable();
            DataRow dr = null;
            for (int i = 0; i < headerHintLogGridView.Count(); i++)
            {
                dt.Columns.Add(new DataColumn(headerHintLogGridView[i], typeof(string)));
            }
            for (int i = 0; i < hintLogList.Count; i++)
            {
                Models.Team team = sdb.GetTeam(hintLogList.ElementAt(i).IdTeam);
                Station station = sdb.GetStation(hintLogList.ElementAt(i).IdStation);
                dr = dt.NewRow();
                dr[0] = hintLogList.ElementAt(i).Id;
                dr[1] = hintLogList.ElementAt(i).Time;
                dr[2] = hintLogList.ElementAt(i).IdTeam;
                dr[3] = team.Name;
                dr[4] = hintLogList.ElementAt(i).IdStation;
                dr[5] = station.NumberOfStation;
                if (hintLogList.ElementAt(i).Hint)
                {
                    dr[6] = "x";
                }

                if (hintLogList.ElementAt(i).NextPlace)
                {
                    dr[7] = "x";
                }

                dt.Rows.Add(dr);
            }
            HintGridView.Controls.Clear();
            HintGridView.DataSource = dt;
            HintGridView.DataBind();
        }

        private void CompleteDropList()
        {
            ServiceDataBase sdb = new ServiceDataBase();

            teamList = sdb.GetAllTeam();
            stationList = sdb.GetAllStation();
            specialTaskList = sdb.GetAllSpecialTask();

            StationDropDownList.Items.Clear();
            StationDropDownList.Items.Add("Wszystko");
            foreach (Station station in stationList)
            {
                StationDropDownList.Items.Add(station.NumberOfStation.ToString());
            }

            SpecialTaskDropDownList.Items.Clear();
            SpecialTaskDropDownList.Items.Add("Wszystko");
            foreach(SpecialTask specialTask in specialTaskList)
            {
                SpecialTaskDropDownList.Items.Add(specialTask.Name);
            }

            HintDropDownList.Items.Clear();
            HintDropDownList.Items.Add("Wszystko");
            foreach (Models.Team team in teamList)
            {
                HintDropDownList.Items.Add(team.Name);
            }

        }

        protected void StationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SpecialTaskDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void NewGameButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewGame.aspx");
        }

        protected void TeamDataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = TeamGridView.Rows[TeamGridView.SelectedIndex].Cells[0].ToString();
            Server.Transfer("team.aspx?id=" + id);
        }
    }
}