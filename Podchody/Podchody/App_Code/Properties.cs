using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.App_Code
{
    public static class Properties
    {
        private static readonly string login = "Krimek";
        private static readonly string password = "bimber1";
        private static bool logIn = false;
        private static int penaltyHint;
        private static int penaltyFullHint;

        public static string Password
        {
            get
            {
                return password;
            }
        }

        public static string Login
        {
            get
            {
                return login;
            }
        }

        public static bool LogIn
        {
            get
            {
                return logIn;
            }

            set
            {
                logIn = value;
            }
        }

        public static int PenaltyHint
        {
            get
            {
                return penaltyHint;
            }

            set
            {
                penaltyHint = value;
            }
        }

        public static int PenaltyFullHint
        {
            get
            {
                return penaltyFullHint;
            }

            set
            {
                penaltyFullHint = value;
            }
        }
    }
}