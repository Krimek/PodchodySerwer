using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTservice.Models
{
    public class Team
    {
        private int id;

        private string nameTeam;

        private TimeSpan startTime;
        private TimeSpan finishTime;

        private int amountTips;
        private int amountNextPlace;

        private int currentStation;
        private bool currentStationTips;
        private bool currentStationNextPlace;

        private bool[] specialTask;

        public Team(int id)
        {
            DateTime now = DateTime.Now;
            this.id = id;
            startTime = new TimeSpan(now.Hour, now.Minute, now.Second);
            finishTime = new TimeSpan();
        }

        public void AcceptSpecialTask(int numberOfTask)
        {
            specialTask[numberOfTask] = true;
        }

        public void StopTime()
        {
            DateTime now = DateTime.Now;
            finishTime = new TimeSpan(now.Hour, now.Minute, now.Second);
        }

        public bool GetTips()
        {
            if (!currentStationTips)
            {
                currentStationTips = true;
                amountTips++;
                return true;
            }
            return false;
        }

        public bool GetNextPlace()
        {
            if(!currentStationNextPlace)
            {
                currentStationNextPlace = true;
                amountNextPlace++;
                return true;
            }
            return false;
        }

        public bool Equals(int id)
        {
            if (this.id == id)
                return true;
            else
                return false;
        }

        private void ChangeSum()
        {

        }
    }
}