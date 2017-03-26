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
            if (db.IsExistTeam(g))
            {
                team = db.GetTeam(id);
                int currSt = team.CurrentStation;
                if(currSt > db.AmountStation())
                {
                    specialTask = null;
                    return "Jesteś już na mecie";
                }
                Station st = db.GetStation(currSt);
                specialTask = st.SpecialTasks.FirstOrDefault();
                if (specialTask == null)
                    return "Brak";
                return "";
            }
            specialTask = null;
            return "Nie istnieje zespół o zadanym id";

        }

        public string AcceptSpecialTask(string idSpecialTask, string idTeam)
        {
            Guid gSpecialTask;
            Guid gTeam;
            if (!Guid.TryParse(idSpecialTask, out gSpecialTask))
            {
                return "Zły format IdSpecialTask";
            }
            if(!Guid.TryParse(idTeam, out gTeam))
            {
                return "Zły format IdTeam";
            }
            if (db.IsExistTeam(gTeam))
            {
                if (db.GetSpecialTask(idSpecialTask.ToString()) != null)
                {
                    if (db.AddToSpecialTaskLog(gTeam, gSpecialTask))
                    {
                        return "";
                    }
                    else
                    {
                        return "Wystapil wewnetrzny blad, sprobuj ponownie";
                    }
                }
                return "Nie istnieje zadanie specjalne o zadanym ID";
            }
            return "Nie istnieje zespol o zadanym ID";
        }

        public int NumberOfSpecialTask()
        {
            return db.AmountSpecialTask();
        }
    }
}