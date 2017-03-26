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
            string[] table = { "STATION", "STATIONLOG", "SPECIALTASKLOG", "SPECIALTASK", "HINTLOG" };
            foreach (string s in table)
            {
                string st = "DELETE FROM " + s;
                dataBase.ExecuteCommand(st);
            }
        }

        public void ClearTable(string nameTable)
        {
            string s = "DELETE FROM " + nameTable;
            dataBase.ExecuteCommand(s);
        }

        #region Dodawanie przy tworzeniu nowej instancji
        public Guid AddNewTeam(string name)
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

            return guid;
        }

        public void AddNewStation(string desciption, string hint, string nextPlace, string localization, int numberStation)
        {
            guid = Guid.NewGuid();
            App_Code.Security sec = new App_Code.Security();
            Station newStation = new Station()
            {
                Id = guid.ToString(),
                Description = desciption,
                Hint = hint,
                NextPlace = nextPlace,
                Location = localization,
                NumberOfStation = numberStation,
                Code = sec.GenerateStationCode()
            };

            dataBase.Stations.InsertOnSubmit(newStation);
            dataBase.SubmitChanges();
        }

        public bool AddNewSpecialTask(string description, int bonus, int numberOfStation, string name, int numberSpecialTask)
        {
            if (numberOfStation <= AmountStation() && numberOfStation > 0)
            {
                guid = Guid.NewGuid();
                Station station = GetStation(numberOfStation);
                App_Code.Security sec = new App_Code.Security();
                SpecialTask newSpecialTask = new SpecialTask()
                {
                    Id = guid.ToString(),
                    Description = description,
                    Bonus = bonus,
                    Name = name,
                    IdStation = station.Id,
                    NumberOfSpecialTask = numberSpecialTask,
                    Code = sec.GenerateStationCode()
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

            if(team.CurrentStation == 0)
            {
                team.StartTime = DateTime.Now;
            }
            else if(team.CurrentStation == AmountStation())
            {
                team.FinishTime = DateTime.Now;
                team.CurrentStation = AmountStation() + 1;
                dataBase.SubmitChanges();
                return true;
            }
            else if(team.CurrentStation >AmountStation())
            {
                return true;
            }

            team.CurrentStation++;
            Station station = GetStation(team.CurrentStation);

            guid = Guid.NewGuid();

            StationLog stationLogNew = new StationLog()
            {
                Id = guid.ToString(),
                IdTeam = team.Id,
                IdStation = station.Id,
                Time = DateTime.Now
            };

            
            dataBase.StationLogs.InsertOnSubmit(stationLogNew);

            dataBase.SubmitChanges();

            return true;
        }


        public bool AddToSpecialTaskLog(Guid idTeam, Guid idSpecialTask)
        {
            guid = Guid.NewGuid();
            SpecialTaskLog specialTaskLogNew = new SpecialTaskLog()
            {
                Id = guid.ToString(),
                IdTeam = idTeam.ToString(),
                IdSpecialTask = idSpecialTask.ToString(),
                Time = DateTime.Now
            };

            dataBase.SpecialTaskLogs.InsertOnSubmit(specialTaskLogNew);
            dataBase.SubmitChanges();
            return true;
        }

        /// <summary>
        /// Metoda dodająca zdarzenie do logów podpowiedzi
        /// </summary>
        public bool AddToHintLog(string id, bool hint, bool nextPlace)
        {
            Team team = GetTeam(id);

            if (team.CurrentStation > AmountStation() || team.CurrentStation == 0)
            {
                return false;
            }

            Station station = GetStation(team.CurrentStation);
            
            if (hint && !IsHint(station.Id, team.Id, true, false))
            {
                team.AmountHint++;
            }
            else if (nextPlace && !IsHint(station.Id, team.Id, false, true))
            {
                team.AmountNextPlace++;
            }

            guid = Guid.NewGuid();

            HintLog hintLogNew = new HintLog()
            {
                Id = guid.ToString(),
                IdStation = station.Id,
                IdTeam = team.Id,
                Time = DateTime.Now
            };

            if (hint)
                hintLogNew.Hint = true;

            if (nextPlace)
                hintLogNew.NextPlace = true;

            dataBase.HintLogs.InsertOnSubmit(hintLogNew);
            dataBase.SubmitChanges();

            return true;
        }

        #endregion
        
        public int AmountStation()
        {
            return dataBase.Stations.Count();
        }

        internal int AmountSpecialTask()
        {
            return dataBase.SpecialTasks.Count();
        }

        public List<Station> GetAllStation()
        {
            IEnumerable<Station> data = from st in dataBase.Stations
                                    orderby st.NumberOfStation
                                    select st;

            return data.ToList();
        }


        public Team GetTeam(string id)
        {
            IEnumerable<Team> data = from team in dataBase.Teams
                                     where team.Id == id
                                     select team;

            return data.Single();
        }

        public List<SpecialTask> GetAllSpecialTask()
        {
            IEnumerable<SpecialTask> data = from sp in dataBase.SpecialTasks
                                            orderby sp.Name
                                            select sp;

            return data.ToList();
        }

        public Station GetStation(int numberOfStation)
        {
            IEnumerable<Station> data = from st in dataBase.Stations
                                        where st.NumberOfStation == numberOfStation
                                        select st;
            return data.Single();
        }

        public Station GetStation(string id)
        {
            IEnumerable<Station> station = from st in dataBase.Stations
                                           where st.Id == id
                                           select st;
            return station.Single();
        }

        public List<StationLog> GetStationLog()
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           orderby d.Time descending
                                           select d;

            return data.ToList();
        }

        public List<StationLog> GetStationLogByTeamId(string id)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdTeam == id
                                           orderby d.Time descending
                                           select d;

            return data.ToList();
        }

        public List<StationLog> GetStationLogByStationId(string id)
        {
            IEnumerable<StationLog> data = from d in dataBase.StationLogs
                                           where d.IdStation == id
                                           orderby d.Time descending
                                           select d;

            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLog()
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               orderby d.Time descending
                                               select d;
            
            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLogByTeamId(string id)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               where d.IdTeam == id
                                               orderby d.Time descending
                                               select d;

            return data.ToList();
        }

        public List<SpecialTaskLog> GetSpecialTaskLogByStationId(string id)
        {
            IEnumerable<SpecialTaskLog> data = from d in dataBase.SpecialTaskLogs
                                               where d.IdSpecialTask == id
                                               orderby d.Time descending
                                               select d;

            return data.ToList();

        }

        public List<HintLog> GetHintList()
        {
            IEnumerable<HintLog> data = from d in dataBase.HintLogs
                                        orderby d.Time descending
                                        select d;

            return data.ToList();
        }

        public bool IsHint(string idStation, string idTeam, bool hint, bool nextPlace)
        {
            IEnumerable<HintLog> data = from d in dataBase.HintLogs
                                        where d.IdTeam == idTeam.ToString()
                                        where d.IdStation == idStation.ToString()
                                        select d;
            if (data.Count() > 0)
            {
                if (hint)
                {
                    foreach (HintLog h in data)
                    {
                        if (h.Hint)
                        {
                            return true;
                        }
                    }
                }
                if (nextPlace)
                {
                    foreach (HintLog h in data)
                    {
                        if (h.NextPlace)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public SpecialTask GetSpecialTaskFromStation(string idStation)
        {
            IEnumerable<SpecialTask> data = from d in dataBase.SpecialTasks
                                            where d.IdStation == idStation
                                            select d;

            return data.SingleOrDefault();
        }

        public List<Team> GetAllTeam()
        {
            IEnumerable<Team> data = from d in dataBase.Teams
                                     orderby d.Name
                                     select d;

            return data.ToList();
        }

        public SpecialTask GetSpecialTask(string id)
        {
            foreach (SpecialTask specialTask in dataBase.SpecialTasks)
            {
                if (specialTask.Id == id)
                    return specialTask;
            }
            return null;
        }
        
        /// <summary>
        /// Sprawdza czy zespół o zadanym id lub nazwie istnieje w bazie
        /// </summary>
        public bool IsExistTeam(Guid id)
        {
            List<Team> listTeam = GetAllTeam();
            foreach (Team team in listTeam)
            {
                if (team.Id == id.ToString())
                    return true;
            }
            return false;
        }

        public bool IsExistTeam(string name)
        {
            int length = name.Length;
            for (int i = length; i < 50; i++)
                name = name + " ";
            List<Team> listTeam = GetAllTeam();
            foreach(Team team in listTeam)
            {
                if (team.Name == name)
                    return true;
            }
            return false;
        }
        

    }
}