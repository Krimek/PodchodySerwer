using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.Models.List
{
    public class ListStation
    {
        private int amountStation;

        private static List<Station> listStation = new List<Station>();

        public bool IsGoodStation(int number, int code)
        {
            if (listStation.ElementAt(number).Equals(code))
                return true;
            else
                return false;
        }

        public bool IsGoodStation(int number, string place)
        {
            if (listStation.ElementAt(number).Equals(place))
                return true;
            else
                return false;
        }
    }
}