using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Talents_GameOfLife
{
    class Patterns
    {
        public static bool[,] ship = new bool[4 , 5]
        {
            { false, true, false, false, true },
            { true, false, false, false, false},
            { true, false, false, false, true},
            { true, true, true, true, false}
        };

        public static bool[,] glider = new bool[3, 3]
        {
            { true, false, true },
            { false, true, true },
            { false, true, false }
        };

        public static bool[,] RotatePatternBy90(bool[,] mat)
        {
            int M = mat.GetLength(0);
            int N = mat.GetLength(1);
            bool[,] ret = new bool[N,M];
            for (int r = 0; r < M; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    ret[c,M - 1 - r] = mat[r,c];
                }
            }
            return ret;
        }
    }
}
