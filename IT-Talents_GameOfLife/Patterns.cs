using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace IT_Talents_GameOfLife
{
    class Patterns
    {
        /// <summary>
        /// Ship Pixels
        /// </summary>
        public static bool[,] ship = new bool[4 , 5]
        {
            { false, true, false, false, true },
            { true, false, false, false, false},
            { true, false, false, false, true},
            { true, true, true, true, false}
        };

        /// <summary>
        /// Glider Pixels
        /// </summary>
        public static bool[,] glider = new bool[3, 3]
        {
            { true, false, true },
            { false, true, true },
            { false, true, false }
        };

        /// <summary>
        /// Rotate any Pattern by 90 Degrees to the right
        /// </summary>
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

        /// <summary>
        /// Add a new Pattern with path and name
        /// </summary>
        public static void AddPattern(string path, string name)
        {
            Bitmap bmp = new Bitmap(path);
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);

            //Make sure its 32bppRgb;
            bmp = bmp.Clone(rectangle, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            //Default Max and Min Values
            int minX = bmp.Width - 1;
            int maxX = 0;
            int minY = bmp.Height - 1;
            int maxY = 0;

            //Crop the image so no useless white spots are on it
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (x < minX || x > maxX || y < minY || y > maxY)
                    {
                        Color c = bmp.GetPixel(x, y);
                        int darkness = c.R + c.G + c.B;

                        if (darkness < 384)
                        {
                            if (x < minX)
                                minX = x;
                            if (x > maxX)
                                maxX = x;

                            if (y < minY)
                                minY = y;
                            if (y > maxY)
                                maxY = y;
                        }
                    }
                }
            }

            rectangle = new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
            //Change image format to 1bpp so it uses less storage and crop
            bmp = bmp.Clone(rectangle, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

            string savePath = GetSaveFolder() + name + ".bmp";
            if (!Directory.Exists(GetSaveFolder()))
                Directory.CreateDirectory(GetSaveFolder());
            bmp.Save(savePath);
        }

        /// <summary>
        /// Get Patternpixels by name
        /// </summary>
        public static bool[,] GetPattern(string name)
        {
            Bitmap bmp = GetBitmap(name);

            if (bmp == null)
                return null;

            bool[,] patternGrid = new bool[bmp.Height, bmp.Width];

            //Make BMP to bool Matrix
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

        /// <summary>
        /// Get Bitmap of Pattern by name
        /// </summary>
        public static Bitmap GetBitmap(string name)
        {
            string savePath = GetSaveFolder() + name + ".bmp";
            
            Bitmap bmp = new Bitmap(savePath);
            Rectangle rectangle = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //Make Bitmap 32Bpprgb because 1bpp cannot be edited with setpixel
            bmp = bmp.Clone(rectangle, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            return bmp;
        }

        /// <summary>
        /// Remove Pattern by name
        /// </summary>
        public static void RemovePattern(string name)
        {
            string savePath = GetSaveFolder() + name + ".bmp";

            //Collect Garbage so file is not locked anymore
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //Delete it
            File.Delete(savePath);
        }

        /// <summary>
        /// Get All Paths where a Pattern is at
        /// </summary>
        public static string[] GetAllPatternLocations()
        {
            string savePath = GetSaveFolder();
            savePath = new Uri(savePath).LocalPath;

            //If no savefolder exists then there cannot be any patterns so return empty string array
            if (!Directory.Exists(savePath))
                return new string[0];

            string[] allFiles = Directory.GetFiles(savePath);

            //Every file thats not an bmp will be ignored
            for(int i = 0; i < allFiles.Length; i++)
            {
                if (!allFiles[i].EndsWith(".bmp"))
                    allFiles[i] = "";
            }

            //Remove ignored files from array (remove empty entrys)
            allFiles = allFiles.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            return allFiles;
        }

        /// <summary>
        /// Get All Names of existing Patterns
        /// </summary>
        public static string[] GetAllPatternNames()
        {
            string[] paths = GetAllPatternLocations();

            for (int i = 0; i < paths.Length; i++)
            {
                int idx = paths[i].LastIndexOf('\\');

                paths[i] = paths[i].Substring(idx + 1).Split('.')[0];
            }

            return paths;
        }

        /// <summary>
        /// Check if Pattern exists by name
        /// </summary>
        public static bool HasName(string name)
        {
            foreach(string str in GetAllPatternNames())
            {
                if (str == name)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Get Folder where Patterns are saved in
        /// </summary>
        private static string GetSaveFolder()
        {
            return Path.GetDirectoryName(Application.ExecutablePath) + "\\patterns\\";
        }

        /// <summary>
        /// Generates an Icon as Bitmap from Pattern by name
        /// </summary>
        public static Bitmap GenerateIcon(string name)
        {
            string savePath = GetSaveFolder() + name + ".bmp";
            
            Bitmap bmp = new Bitmap(savePath);
            float aspectRatio = (float)bmp.Width / (float)bmp.Height;

            //Default width / Max width
            int width = 26;
            int height = 26;

            //If wider than high then make height smaller. If higher than wide than make width smaller
            if (aspectRatio > 1)
            {
                height = (int)(width / aspectRatio);
            }
            else if (aspectRatio < 1)
            {
                width = (int)(width * aspectRatio);
            }

            //Scaled Bitmap instance
            Bitmap scaledMap = new Bitmap(width, height);

            Graphics graph = Graphics.FromImage(scaledMap);

            //Set PixelOffsetMode to Half so the left and top row get scaled correctly
            graph.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            //Set Interpolate to NearestNeighbour so the pixels are hard and not interpolated
            graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //Scale Image
            graph.DrawImage(bmp, 0, 0, width, height);

            //Recolor to match button colors
            for (int y = 0; y < scaledMap.Height; y++)
            {
                for (int x = 0; x < scaledMap.Width; x++)
                {
                    Color c = scaledMap.GetPixel(x, y);
                    int darkness = c.R + c.G + c.B;

                    if (darkness >= 384)
                        scaledMap.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                    else
                        scaledMap.SetPixel(x, y, Color.FromArgb(149, 149, 149));
                }

            }

            return scaledMap;
        }
    }
}
