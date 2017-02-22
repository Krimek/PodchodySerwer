using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Podchody.Models
{
    public class ServiceDataBase
    {
        ConnectionDataContext dataBase = new ConnectionDataContext();
        Guid guid;

        public ServiceDataBase()
        {
            dataBase = new ConnectionDataContext();
        }

        public void ClearTable()
        {
            string[] table = { "TEAM", "TEAMDETAIL", "STATION", "STATIONLOG", "SPECIALTASK", "SPECIALTASKLOG" };
            foreach (string s in table)
            {
                dataBase.ExecuteCommand("DELETE FROM {0}", s);
            }
        }
        #region Dodawanie przy tworzeniu nowej instancji
        public void AddNewTeam(string name)
        {
            guid = Guid.NewGuid();
            Team newTeam = new Team()
            {
                Id = guid.ToString(),
                Name = name
            };

            TeamDetail newTeamDetails = new TeamDetail()
            {
                Id = guid.ToString(),
                AmountHint = 0,
                AmountNextPlace = 0,
                CurrentStation = 0
            };

            dataBase.Teams.InsertOnSubmit(newTeam);
            dataBase.TeamDetails.InsertOnSubmit(newTeamDetails);
            dataBase.SubmitChanges();
        }

        public void AddNewStation(string desciption, string hint, string nextPlace, string localization, int numberStation)
        {
            guid = Guid.NewGuid();
            Station newStation = new Station()
            {
                Id = guid.ToString(),
                Description = desciption,
                Hint = hint,
                NextPlace = nextPlace,
                Location = localization,
                NumberOfStation = numberStation
            };

            dataBase.Stations.InsertOnSubmit(newStation);
            dataBase.SubmitChanges();
        }

        public void AddNewSpecialTask(string description, int bonus, int numberOfStation, string name)
        {
            guid = Guid.NewGuid();
            Station station = GetStation(numberOfStation);
            SpecialTask newSpecialTask = new SpecialTask()
            {
                Id = guid.ToString(),
                Description = description,
                Bonus = bonus,
                Name = name,
                IdStation = station.Id,
            };

            dataBase.SpecialTasks.InsertOnSubmit(newSpecialTask);
            dataBase.SubmitChanges();
        }
        #endregion

        public Station GetStation(int numberOfStation)
        {
            IEnumerable<Station> data = from st in dataBase.Stations
                                        where st.NumberOfStation == numberOfStation
                                        select st;
            return data.First();
        }

        public List<StationLog> GetStationLog(int amount)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           select d;

            if (data.Count() > amount)
                return data.Take(amount).ToList();
            else
                return data.ToList();
        }

        public List<StationLog> GetStationLog()
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           select d;

            return data.ToList();
        }

        public List<StationLog> GetStationLogByTeamId(string id, int amount)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdTeam == id
                                           select d;

            if (data.Count() > amount)
                return data.Take(amount).ToList();
            else
                return data.ToList();
        }

        public List<StationLog> GetStationLogByTeamId(string id)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdTeam == id
                                           select d;

            return data.ToList();
        }

        public List<StationLog> GetStationLogByStationId(string id, int amount)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdStation == id
                                           select d;

            if (data.Count() > amount)
                return data.Take(amount).ToList();
            else
                return data.ToList();
        }

        public List<StationLog> GetStationLogByStationId(string id)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdStation == id
                                           select d;

            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLog(int amount)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               select d;

            if (data.Count() > amount)
                return data.Take(amount).ToList();
            else
                return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLog()
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               select d;


            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLogByTeamId(string id, int amount)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               where d.IdTeam == id
                                               select d;

            if (data.Count() > amount)
                return data.Take(amount).ToList();
            else
                return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLogByTeamId(string id)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               where d.IdTeam == id
                                               select d;

            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLogByStationId(string id, int amount)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               where d.IdSpecialTask == id
                                               select d;

            if (data.Count() > amount)
                return data.Take(amount).ToList();
            else
                return data.ToList();

        }

        public List<SpecialTaskLog> GetSpecialTaskLogByStationId(string id)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               where d.IdSpecialTask == id
                                               select d;

            return data.ToList();

        }

        public List<Team> GetAllTeam()
        {
            IEnumerable<Team> data = from d in dataBase.Teams
                                     select d;

            return data.ToList();
        }


        public List<TeamDetail> GetAllTeamDetails()
        {
            IEnumerable<TeamDetail> data = from d in dataBase.TeamDetails
                                           select d;

            return data.ToList();
        }
    }
}