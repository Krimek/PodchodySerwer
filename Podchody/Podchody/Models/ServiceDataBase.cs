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

        public ServiceDataBase()
        {
            dataBase = new ConnectionDataContext();
        }

        public void AddNewTeam(string name)
        {
            Team newTeam = new Team()
            {
                Id = new Guid().ToString(),
                Name = name
            };

            dataBase.Teams.InsertOnSubmit(newTeam);
            dataBase.SubmitChanges();
        }
    }
}