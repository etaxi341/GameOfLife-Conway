using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Talents_GameOfLife
{
    class Patterns
    {
        public static int shipwidth = 5;
        public static bool[] ship = new bool[]
        {
            false, true, false, false, true,
            true, false, false, false, false,
            true, false, false, false, true,
            true, true, true, true, false
        };
    }
}
