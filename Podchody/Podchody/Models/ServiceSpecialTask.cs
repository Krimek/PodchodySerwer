using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.Models
{
    public class ServiceSpecialTask
    {
        ServiceDataBase db;
        public ServiceSpecialTask()
        {
            db = new ServiceDataBase();
        }

        public string GetSpecialTask(string id, out SpecialTask specialTask)
        {
            Team team;
            Guid g;
            if (!Guid.TryParse(id, out g))
            {
                specialTask = null;
                return "Zly format id";
            }
            if (db.IsExistTeam(g.ToString()))
            {
                team = db.GetTeam(id);
                int currSt = team.CurrentStation;
                if(currSt > db.AmountStation())
                {
                    specialTask = null;
                    return "Jesteś już na mecie";
                }
                Station st = db.GetStation(currSt);
                specialTask = db.GetSpecialTaskFromStation(st.Id);
                if (specialTask == null)
                    return "Brak";
                return "";
            }
            specialTask = null;
            return "Nie istnieje zespół o zadanym id";

        }

        public bool AcceptSpecialTask(string id, string idTeam)
        {
            Team team;
            Guid g;
            if (!Guid.TryParse(id, out g))
            {
                return false;
            }
            if (db.IsExistTeam(g.ToString()))
            {
                team = db.GetTeam(id);

                return true;
            }
            return true;
        }

        public int NumberOfSpecialTask()
        {
            return db.AmountSpecialTask();
        }
    }
}