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

        public void ClearAllTable()
        {
            string[] table = { "TEAM", "STATION", "STATIONLOG", "SPECIALTASK", "SPECIALTASKLOG", "HINTLOG" };
            foreach (string s in table)
            {
                dataBase.ExecuteCommand("DELETE FROM {0}", s);
            }
        }

        public void ClearTable(string nameTable)
        {
            string s = "DELETE FROM " + nameTable;
            dataBase.ExecuteCommand(s);
        }

        #region Dodawanie przy tworzeniu nowej instancji
        public string AddNewTeam(string name)
        {
            guid = Guid.NewGuid();
            Team newTeam = new Team()
            {
                Id = guid.ToString(),
                Name = name,
                AmountHint = 0,
                AmountNextPlace = 0,
                CurrentStation = 0
            };
            

            dataBase.Teams.InsertOnSubmit(newTeam);
            dataBase.SubmitChanges();

            return guid.ToString();
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

        public bool AddNewSpecialTask(string description, int bonus, int numberOfStation, string name, int numberSpecialTask)
        {
            if (numberOfStation <= AmountTeam() && numberOfStation > 0)
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
                    NumberOfSpecialTask = numberSpecialTask
                };

                dataBase.SpecialTasks.InsertOnSubmit(newSpecialTask);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Dodawanie rekordów to tabel z logami
        public bool AddToStationLog(string id)
        {
            Team team = GetTeam(id);

            Station station = GetStation(team.CurrentStation);

            HintLog hintLogNew = new HintLog()
            {
                IdTeam = team.Id,
                IdStation = station.Id,
                Time = DateTime.Now
            };

            dataBase.HintLogs.InsertOnSubmit(hintLogNew);
            dataBase.SubmitChanges();

            return true;
        }


        public bool AddToSpecialTaskLog(string id)
        {
            if (!IsExistTeam(id))
                return false;
            return true;
        }

        private int AmountTeam()
        {
            return dataBase.Stations.Count(); 
        }

        /// <summary>
        /// Metoda dodająca zdarzenie do logów podpowiedzi
        /// </summary>
        public void AddToHintLog(string id, bool hint, bool nextPlace)
        {

        }

#endregion


        public List<int> GetStationNumber()
        {
            IEnumerable<int> data = from st in dataBase.Stations
                                    orderby st.NumberOfStation
                                    select st.NumberOfStation;

            return data.ToList();
        }


        private Team GetTeam(string id)
        {
            IEnumerable<Team> data = from team in dataBase.Teams
                                     where team.Id == id
                                     select team;

            return data.Single();
        }

        public List<string> GetSpecialTaskName()
        {
            IEnumerable<string> data = from sp in dataBase.SpecialTasks
                                       orderby sp.Name
                                       select sp.Name;

            return data.ToList();
        }

        public Station GetStation(int numberOfStation)
        {
            IEnumerable<Station> data = from st in dataBase.Stations
                                        where st.NumberOfStation == numberOfStation
                                        select st;
            return data.Single();
        }

        private Station GetStation(string id)
        {
            IEnumerable<Station> station = from st in dataBase.Stations
                                           where st.Id == id
                                           select st;
            return station.Single();
        }

        public List<StationLog> GetStationLog()
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           select d;

            return data.ToList();
        }

        public List<StationLog> GetStationLogByTeamId(string id)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdTeam == id
                                           select d;

            return data.ToList();
        }

        public List<StationLog> GetStationLogByStationId(string id)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdStation == id
                                           select d;

            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLog()
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               select d;


            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLogByTeamId(string id)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               where d.IdTeam == id
                                               select d;

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
                                     orderby d.Name
                                     select d;

            return data.ToList();
        }
        
        /// <summary>
        /// Nie dokończona jeszcze metoda. Sprawdza czy zespół o zadanym id istnieje w bazie
        /// </summary>
        public bool IsExistTeam(string id)
        {
            return true;
        }

    }
}