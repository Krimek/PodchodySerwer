using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTservice.Models.List
{
    public class ListStation
    {
        private static List<Station> listStation = new List<Station>();

        public bool IsGoodStation(int number, int code)
        {
            //if(listStation.ElementAt(number))
            return true;
        }
    }
}