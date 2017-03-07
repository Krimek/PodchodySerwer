﻿using System;
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

        public Guid AddTeam(string name)
        {
            if (db.IsExistTeam(name))
                return Guid.Empty;

            return db.AddNewTeam(name);
        }

        public string AddTip(string g)
        {
            if(db.IsExistTeam(g))
            {
                db.AddToHintLog(g.ToString(), true, false);
                return "OK";
            }
            return "Wrong id Team";
        }

        public string AddFullTip(string g)
        {
            if (db.IsExistTeam(g))
            {
                db.AddToHintLog(g.ToString(), false, true);
                return "OK";
            }
            return "Wrong id Team";
        }
    }
}