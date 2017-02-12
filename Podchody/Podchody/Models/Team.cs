using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.Models
{
    public class Team
    {
        private int id;

        private string nameTeam;

        private string startTime;
        private string finishTime;

        private int amountTips;
        private int amountNextPlace;

        private int currentStation;
        private bool currentStationTips;
        private bool currentStationNextPlace;

        private string[] time;
        private bool[] specialTask;

        private bool onRoad;
        private bool onFinish;

        public int CurrentStation { get { return currentStation; } set { currentStation = value; } }
        public bool CurrentStationTips { get { return currentStationTips; } set { currentStationTips = value; } }
        public bool CurrentStationNextPlace { get { return currentStationNextPlace; } set { currentStationNextPlace = value; } }

        public Team(int id)
        {
            this.id = id;
            time = new string[List.ListStation.amountStation];
            specialTask = new bool[SpecialTask.amountSpecialTask];
        }

        public void AcceptSpecialTask(int numberOfTask)
        {
            specialTask[numberOfTask] = true;
        }

        public void StartTime()
        {
            startTime = DateTime.Now.ToString().Substring(11, 5);
        }

        public void StopTime()
        {
            finishTime = DateTime.Now.ToString().Substring(11, 5);
        }

        public bool GetTips()
        {
            if (!CurrentStationTips)
            {
                CurrentStationTips = true;
                amountTips++;
                return true;
            }
            return false;
        }

        public bool GetNextPlace()
        {
            if(!CurrentStationNextPlace)
            {
                CurrentStationNextPlace = true;
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