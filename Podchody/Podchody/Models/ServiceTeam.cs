using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.Models
{
    public class ServiceTeam
    {
        ServiceDataBase db;
        App_Code.Security security;
        public ServiceTeam()
        {
            db = new ServiceDataBase();
            security = new App_Code.Security();
        }

        public Guid AddTeam(string name, string code, out string currentStationId)
        {
            
            if (db.IsExistTeam(name, code))
            {
                return db.AddNewTeam(name, code, true, out currentStationId);
            }
            else if (db.IsExistTeamName(name))
            {
                currentStationId = "";
                return Guid.Empty;
            }
            else
            {
                return db.AddNewTeam(name, code, false, out currentStationId);
            }
        }

        public string AddTip(string id)
        {
            Guid g;
            if (!Guid.TryParse(id, out g))
            {
                return "Zly format id";
            }
            if (db.IsExistTeam(g))
            {
                db.AddToHintLog(g.ToString(), true, false);
                return "";
            }
            return "Wrong id Team";
        }

        public string AddFullTip(string id)
        {
            Guid g;
            if (!Guid.TryParse(id, out g))
            {
                return "Zly format id";
            }
            if (db.IsExistTeam(g))
            {
                db.AddToHintLog(g.ToString(), false, true);
                return "";
            }
            return "Wrong id Team";
        }

        public string GetCurrentStation(string id)
        {
            Team team = db.GetTeam(id);
            if(team.CurrentStation == 0)
            {
                return "start";
            }
            else
            {
                Station station = db.GetStation(team.CurrentStation);
                return station.Id;
            }
        }
    }
}