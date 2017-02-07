using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTservice.Models
{
    public static class ListTeam
    {
        private static List<Team> listTeam = new List<Team>();

        private static Team GetTeam(int id)
        {
            foreach (Team team in listTeam)
                if (team.Equals(id))
                    return team;
            return null;
        }
    }
}