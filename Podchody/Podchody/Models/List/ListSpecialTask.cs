using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.Models.List
{
    public class ListSpecialTask
    {
        private static List<SpecialTask> listSpecialTask = new List<SpecialTask>();

        public bool Add(SpecialTask specialTask)
        {
            listSpecialTask.Add(specialTask);
            return true;
        }
        
    }
}