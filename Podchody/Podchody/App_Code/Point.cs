using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podchody.App_Code
{
    public class Point
    {
        private int y;
        private int x;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
    }
}