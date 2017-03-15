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

        public string GenerateStationCode()
        {
            Random rand = new Random();
            
            string code = "";
            const int lengthCode = 10;
            for(int i = 0; i < lengthCode; i++)
            {
                code += (char)('A' + rand.Next(0, 26));
            }
            return code;
        }

        public bool CheckedStartCode(string code)
        {
            if (code.Length != 8)
                return false;

            return true;
        }
    }
}