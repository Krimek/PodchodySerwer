using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.App_Code
{
    public static class Validation
    {
        public static bool isNumber(string text)
        {
            int result;
            if(text == "")
            {
                return false;
            }
            else if (Int32.TryParse(text, out result) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isTime(string text)
        {

            return true;
        }
    }
}