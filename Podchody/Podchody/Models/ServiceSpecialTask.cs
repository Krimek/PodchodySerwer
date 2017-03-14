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


            }
            specialTask = null;
            return "Nie istnieje zespół o zadanym id";

        }
        public int NumberOfSpecialTask()
        {
            return db.AmountSpecialTask();
        }
    }
}