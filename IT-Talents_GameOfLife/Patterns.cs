using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;

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

        public static void AddPattern(string path, string name)
        {
            Properties.Settings.Default.patterns += path + "|" + name + ";";
            Properties.Settings.Default.Save();
        }

        public static bool[,] GetPattern(string name)
        {
            string[] patterns = Properties.Settings.Default.patterns.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Bitmap bmp = null;

            foreach (string pattern in patterns)
            {
                string[] pathAndName = pattern.Split('|');

                if (pathAndName[1] == name)
                    bmp = new Bitmap(pathAndName[0]);
            }

            if (bmp == null)
                return null;

            bool[,] patternGrid = new bool[bmp.Height, bmp.Width];

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int darkness = c.R + c.G + c.B;

                    if (darkness >= 384)
                        patternGrid[y, x] = false;
                    else
                        patternGrid[y, x] = true;
                }

            }

            return patternGrid;
        }

        public static bool hasName(string name)
        {
            string[] patterns = Properties.Settings.Default.patterns.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string pattern in patterns)
            {
                string[] pathAndName = pattern.Split('|');

                if (pathAndName[1] == name)
                    return true;
            }
            return false;
        }

        public static void RemovePattern(string name)
        {
            string[] patterns = Properties.Settings.Default.patterns.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string newPatterns = "";

            for (int i = 0; i < patterns.Length; i++)
            {
                string[] pathAndName = patterns[i].Split('|');

                if (pathAndName[1] != name)
                    newPatterns += patterns[i] + ";";
            }

            Properties.Settings.Default.patterns = newPatterns;

            Properties.Settings.Default.Save();
        }
    }
}
