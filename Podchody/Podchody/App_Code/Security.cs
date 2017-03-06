using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.App_Code
{
    public class Security
    {
        public Security()
        {

        }

        public bool CheckedStartCode(string code)
        {
            if (code.Length != 8)
                return false;

            return true;
        }
    }
}