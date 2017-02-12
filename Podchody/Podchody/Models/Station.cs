using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.Models
{
    public class Station
    {
        string description;
        string tip;
        string place;

        private int code;
        public string fullLocation;

        public bool Equals(int code)
        {
            if (this.code == code)
                return true;
            else
                return false;
        }

        public bool Equals(string fullLocation)
        {
            return true;
        }
    }
}