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

        public Station GetNextStation(string id)
        {
            Team team;
            Station station;
            db.AddToStationLog(id);
            team = db.GetTeam(id);
            station = db.GetStation(team.CurrentStation);
            return station;
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