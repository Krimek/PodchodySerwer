using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.Models
{
    public class ServiceStation
    {
        ServiceDataBase db;
        public ServiceStation()
        {
            db = new ServiceDataBase();
        }

        public string GetNextStation(string idTeam, string idStation, out Station station)
        {
            Team team;
            Guid g, g1;
            if(!Guid.TryParse(idTeam, out g))
            {
                station = null;
                return "Zly format id";
            }
            if (idStation != "start" && !Guid.TryParse(idStation, out g1))
            {
                station = null;
                return "Zly format id";
            }
            if (db.IsExistTeam(g))
            {
                Station st = null;
                team = db.GetTeam(idTeam);
                if (idStation != "start")
                {
                    st = db.GetStation(idStation);
                }
                else
                {
                    st = db.GetStation(1);
                }
                if (st != null)
                {
                    if (idStation != "start")
                    {
                        station = db.GetStation(team.CurrentStation);
                        if (st != station)
                        {
                            station = null;
                            return "Zle id stacji";
                        }
                    }
                    else
                    {
                        if(team.CurrentStation != 0)
                        {
                            station = null;
                            return "Zle id stacji";
                        }
                    }
                    if (team.CurrentStation < db.AmountStation())
                    {
                        db.AddToStationLog(idTeam);
                        station = db.GetStation(team.CurrentStation);
                    }
                    else
                    {
                        station = null;
                        db.AddToStationLog(idTeam);
                        return "Finish";
                    }
                    return "";
                }
                else
                {
                    station = null;
                    return "Nie znaleziono stacji o zadanym ID";
                }
            }
            station = null;
            return "Nie znaleziono druzyny o zadanym ID";
        }

        public int NumberOfStation()
        {
            return db.AmountStation();
        }
    }
}