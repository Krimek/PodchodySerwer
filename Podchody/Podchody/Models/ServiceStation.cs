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
                db.AddToStationLog(id);
                team = db.GetTeam(id);
                station = db.GetStation(team.CurrentStation);
                return "";
            }
            station = null;
            return "Nie znaleziono druzyny o zadanym ID";
        }

        internal bool IsFinish(string id)
        {
            Team team;
            team = db.GetTeam(id);
            if (team.CurrentStation == db.AmountStation())
                return true;
            return false;
        }
    }
}