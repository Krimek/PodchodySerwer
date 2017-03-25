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

        public string GetNextStation(string id, out Station station)
        {
            Team team;
            Guid g;
            if(!Guid.TryParse(id, out g))
            {
                station = null;
                return "Zly format id";
            }

            if (db.IsExistTeam(g))
            {
                team = db.GetTeam(id);
                
                if (team.CurrentStation < db.AmountStation())
                {
                    db.AddToStationLog(id);
                    station = db.GetStation(team.CurrentStation);
                }
                else
                {
                    station = null;
                    db.AddToStationLog(id);
                    return "Finish";
                }
                return "";
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