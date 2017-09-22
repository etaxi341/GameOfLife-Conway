using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Collections;

namespace IT_Talents_GameOfLife
{
    public partial class GridForm : Form
    {
#region Variables

        //Thread that updates the grid
        public Thread updateThread;

        //Call status (Alive Or Dead)
        BitArray cells;

        //selfKill = Only one run in updateThread then Kill itself (For "Next Step" Button)
        bool selfKill = false;

        //Painting Varuables
        bool isPainting = false;
        Color paintColor = Color.Black;
        int mouseDownX, mouseDownY;
        //Set Running again when game was running before painting
        bool wasRunningBeforePaint = false;

        //Grid width defined by image size
        public int width;
        public int height;

        //Max image size that can be imported otherwise it will be downscaled for performance reasons
        int maxSize = 512;

        //Delay Between Game Cycles in ms
        public int cycleDelay = 50;

        //Grid raw image without scaling (One Pixel = One Cell)
        Bitmap image;
        //Grid scaled image for displaying
        Bitmap scaledMap;

        //Is Simulation started
        public bool started = false;

        //Current painting mode
        public paintmode paintMode = paintmode.draw;

#endregion

#region Enums

        public enum paintmode
        {
            draw,
            ship,
            glider
        }

#endregion

#region Buttons and Other Functions

        //Initialize Form
        public GridForm()
        {
            InitializeComponent();

            //Check if user had opened a pic before and if it still exists.
            if (Properties.Settings.Default.lastImagePath == "" || !File.Exists(Properties.Settings.Default.lastImagePath))
            {
                //No image available to load, so Generate a random image with size 128x128
                generateRandomImage(128, 128);
                //Make Cells to Image
                initializeGridFromCells();
            }
            else
            {
                //Image found. Loading Image and if its bigger than maxSize Variable then downscale
                rescaleImage(Properties.Settings.Default.lastImagePath);
                //Make Image to Cells
                initializeGridFromImage();
            }


            //Display the image on the Grid Form
            syncImage();

        }

        /// <summary>
        /// Starts the Update Thread of the Grid (Starts the Game)
        /// </summary>
        public void StartGrid()
        {
            //If not started means that the updateThread is not running
            if (!started)
            {
                //If really no updateThread runs, then make a new one and start it
                if (updateThread == null || !updateThread.IsAlive)
                {
                    updateThread = new Thread(UpdateThread);
                    updateThread.Start();
                }
            }
            else
            {

                //If there is an updateThread then stop it and make it null
                if (updateThread != null)
                    updateThread.Abort();
                updateThread = null;
            }

            started = !started;
        }

        /// <summary>
        /// Only updates the Grid in one cycle (Goes to next Step in Game)
        /// </summary>
        public void NextStep()
        {
            //If really no updateThread runs, then go forward by one step
            if (updateThread == null || !updateThread.IsAlive)
            {

                //Self kill the updateThread after one Cycle
                selfKill = true;

                //Create Thread
                updateThread = new Thread(UpdateThread);
                updateThread.Start();
            }
        }

        /// <summary>
        /// Only updates the Grid in one cycle (Goes to next Step in Game)
        /// </summary>
        public void ImportImage(string path)
        {
            //Set not started
            started = false;

            //Stop game
            if (updateThread != null)
                updateThread.Abort();
            updateThread = null;

            //Update Start/Pause Button
            MainForm.instance.UpdateStartButton();

            //Loading Image and if its bigger than maxSize Variable then downscale
            rescaleImage(path);
            //Make Image Black And White and set "bool[] cells" to living or dead
            initializeGridFromImage();
            //Reset Generation
            MainForm.instance.SetGeneration(0);
            //Display the image on the Grid Form
            syncImage();
        }

        /// <summary>
        /// Save current state of Grid as BMP. Will be automatically loaded on next start of programm or can be manually loaded with ImportImage(path)
        /// </summary>
        public void SaveImage(string path)
        {
            //If path somehow does not end with .bmp then add .bmp as extention
            if (!path.EndsWith(".bmp", true, null))
                path += ".bmp";

            //Normalize Image for saving
            initializeGridFromCells(Color.Black, Color.White);

            //Save Image to Path
            image.Save(path);

            //Set Image back to defined colors
            initializeGridFromCells();

            //Set lastImagePath variable to path so the programm can import the image again on restart
            Properties.Settings.Default.lastImagePath = path;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Generates Random Picture of a size determed by "16 * 2^selectedIndex"
        /// </summary>
        public void RandomImage(int selectedIndex)
        {
            //Set not started
            started = false;

            //Stop game
            if (updateThread != null)
                updateThread.Abort();
            updateThread = null;

            //Update Start/Pause Button
            MainForm.instance.UpdateStartButton();

            //Calculate Image size
            int size = 16 * (int)Math.Pow(2, selectedIndex);
            //Generate Random Image with size
            generateRandomImage(size, size);
            //Reset Generation
            MainForm.instance.SetGeneration(0);
            //Display the image on the Grid Form
            syncImage();
        }

        /// <summary>
        /// Generates a pure White Picture of a size determed by "16 * 2^selectedIndex"
        /// </summary>
        public void ClearImage(int selectedIndex)
        {
            //Set not started
            started = false;

            //Stop game
            if (updateThread != null)
                updateThread.Abort();
            updateThread = null;

            //Update Start/Pause Button
            MainForm.instance.UpdateStartButton();

            //Calculate Image size
            int size = 16 * (int)Math.Pow(2, selectedIndex);
            //Generate Random Image with size
            generateClearImage(size, size);
            //Reset Generation
            MainForm.instance.SetGeneration(0);
            //Display the image on the Grid Form
            syncImage();
        }

        //On Form Closing
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Stop game
            if (updateThread != null)
                updateThread.Abort();

            //Close Main Form
            MainForm.instance.Close();
        }

        //On Movement of Grid Form
        private void GridForm_LocationChanged(object sender, EventArgs e)
        {
            //Set the Main Form Location relative to the Grid Form Location so they look like they were attached to each other
            MainForm.instance.Location = new Point(this.Location.X - MainForm.instance.Size.Width + 16, this.Location.Y);
        }

#endregion

#region Big Calculations

        /// <summary>
        /// Gets image from path and then rescales it to maxSize if it is too big
        /// </summary>
        private void rescaleImage(string filename)
        {
            //Get image
            image = new Bitmap(filename);
            //Calculate Aspectratio
            float aspectratio = (float)image.Width / (float)image.Height;

            //Downscaling image if too big
            if (image.Width > maxSize || image.Height > maxSize)
            {
                //New Bitmap for downscaled image
                Bitmap scaledMap;

                //Check if Width is too big or height is too big
                if (aspectratio < 1f)
                    scaledMap = new Bitmap((int)(maxSize * aspectratio), maxSize);
                else
                    scaledMap = new Bitmap(maxSize, (int)(maxSize / aspectratio));

                //Make Graphic from image
                Graphics graph = Graphics.FromImage(scaledMap);
                //Set interpolationMode to NearestNeighbor so it does not look that washed out
                graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                //Check if Width is too big or height is too big, then Downscale the image correctly
                if (aspectratio < 1f)
                    graph.DrawImage(image, 0, 0, (int)(maxSize * aspectratio), maxSize);
                else
                    graph.DrawImage(image, 0, 0, maxSize, (int)(maxSize / aspectratio));

                //Set image to the downscaled image
                image = scaledMap;
            }

            //Make sure that lastImagePath was saved to be able to reload it when programm starts again
            Properties.Settings.Default.lastImagePath = filename;
            Properties.Settings.Default.Save();

            this.width = image.Width;
            this.height = image.Height;

            //Fitting the Form to image aspect ratio
            rescaleFormToImage();
        }

        /// <summary>
        /// Scaling the Grid Form fitting to the imagesize in the picturebox
        /// </summary>
        private void rescaleFormToImage()
        {
            float aspectratio = (float)image.Width / (float)image.Height;
            this.Size = new Size((int)((this.Size.Height - 39) * aspectratio) + 16, this.Size.Height);
            gridPictureBox.Size = new Size((int)((this.Size.Height - 39) * aspectratio), this.Size.Height -39);
        }

        /// <summary>
        /// Make Image Black And White and set "bool[] cells" to living or dead
        /// </summary>
        public void initializeGridFromImage()
        {
            width = image.Width;
            height = image.Height;

            cells = new BitArray(width * height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = image.GetPixel(x, y);
                    int darkness = c.R + c.G + c.B;

                    Color val = MainForm.livingcolor;
                    if (darkness >= 384)
                    {
                        val = MainForm.deadcolor;
                        cells[(y * width + x)] = false;
                    }
                    else
                        cells[(y * width + x)] = true;

                    image.SetPixel(x, y, val);
                }
            }
        }

        /// <summary>
        /// Create Image from Cells
        /// </summary>
        public void initializeGridFromCells(Color living, Color dead)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color val = living;
                    if (!cells[(y * width + x)])
                        val = dead;

                    image.SetPixel(x, y, val);
                }
            }
        }

        /// <summary>
        /// Create Image from Cells
        /// </summary>
        public void initializeGridFromCells()
        {
            initializeGridFromCells(MainForm.livingcolor, MainForm.deadcolor);
        }

        /// <summary>
        /// Update Grid by one Cycle
        /// </summary>
        private void processRun()
        {
            //Making tempcell variable so we still have cell data before the change
            BitArray tempcells = (BitArray)cells.Clone();

            Color val;
            int neighbourLifes;

            //Every Row of Image
            for (int y = 0; y < height; y++)
            {
                //Every Collumn of Image
                for (int x = 0; x < width; x++)
                {
                    //Amount of living neighbours
                    neighbourLifes = 0;

                    //Every Row around me
                    for (int yn = -1; yn <= 1; yn++)
                    {
                        //Every Collumn around me
                        for (int xn = -1; xn <= 1; xn++)
                        {
                            //If not me then
                            if (xn != 0 || yn != 0)
                            {
                                int yoffset = 0;
                                int xoffset = 0;


                                //Make infinity work (Check if out of bounds. If yes subtract/add height/width)
                                if (y == 0 && yn < 0)
                                    yoffset = height;
                                if (y == height - 1 && yn > 0)
                                    yoffset = -height;

                                if (x == 0 && xn < 0)
                                    xoffset = width;
                                if (x == width - 1 && xn > 0)
                                    xoffset = -width;


                                //If cell at Array-Position "(y + yn + yoffset) * width + (x + xn + xoffset)" is alive then add one neighbourLife
                                if (cells[(y + yn + yoffset) * width + (x + xn + xoffset)])
                                    neighbourLifes++;
                            }
                        }
                    }

                    //Cell color black
                    val = MainForm.livingcolor;

                    //If less than 2 or more than 3 neighbours then kill cell
                    if (neighbourLifes < 2 || neighbourLifes > 3)
                        tempcells[y * width + x] = false;

                    //If exactly 3 neighbours then revive cell
                    else if (neighbourLifes == 3)
                        tempcells[y * width + x] = true;

                    //If cell is dead then make val = 255 for white color
                    if (!tempcells[y * width + x])
                        val = MainForm.deadcolor;

                    //Set image pixel to cellcolor
                    image.SetPixel(x, y, val);
                }
            }

            //Update the original cells with a copy of tempcells
            cells = tempcells;
        }

        /// <summary>
        /// Sync cellimage with displayed Image in pictureBox
        /// </summary>
        public void syncImage()
        {
            //Make new Bitmap for the displayImage (Could be scaled) Only do this once so we save about 120MB Memory (Garbage Collector takes some time until he destroys it)
            if (scaledMap == null)
                scaledMap = new Bitmap(gridPictureBox.Width, gridPictureBox.Height);

            Graphics graph = Graphics.FromImage(scaledMap);

            //Set PixelOffsetMode to Half so the left and top row get scaled correctly
            graph.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            //Set Interpolate to NearestNeighbour so the pixels are hard and not interpolated
            graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //Scale Image
            graph.DrawImage(image, 0, 0, gridPictureBox.Width, gridPictureBox.Height);
            //If its called in a Thread then invoke. If not dont invoke
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    //Set picturebox to scaled Bitmap

                    gridPictureBox.Image = scaledMap;
                });
            }
            else
            {
                //Set picturebox to scaled Bitmap
                gridPictureBox.Image = scaledMap;
            }
        }

        /// <summary>
        /// Method that is used as UpdateThread. Initializing image and then runs the grid turns over and over again
        /// </summary>
        private void UpdateThread()
        {
            //Make Image Black And White and set "bool[] cells" to living or dead
            initializeGridFromCells();

            //bool for While cycle
            bool running = true;
            
            //CYCLE
            while (running)
            {
                //Sleep for some ms because otherwise its too fast on small grids
                Thread.Sleep(cycleDelay);
                //Make a Turn
                processRun();
                 
                //Set Generation number;
                MainForm.instance.SetGeneration(MainForm.instance.GetGeneration() + 1);

                //Display the image on the Grid Form
                syncImage();

                //If process should only be ran once then kill it after one turn
                if (selfKill)
                {
                    selfKill = false;
                    running = false;
                }
            }

        }

        /// <summary>
        /// Generates Random Picture by width and height
        /// </summary>
        private void generateRandomImage(int width, int height)
        {
            //Create new Bitmap for noisemap
            image = new Bitmap(width, height);

            this.width = width;
            this.height = height;

            //Set new cell amount
            cells = new BitArray(width * height);

            //Create a Random
            Random rnd = new Random();

            //Every Row of Image
            for (int x = 0; x < width; x++)
            {
                //Every Collumn of Image
                for (int y = 0; y < height; y++)
                {
                    //Generate if Cell is alive or not
                    int num = rnd.Next(0, 2);
                    if (num == 1)
                        cells[y * width + x] = true;
                }
            }

            //Reset lastImagePath because the currently displayed image does not exist as a file
            Properties.Settings.Default.lastImagePath = "";
            Properties.Settings.Default.Save();

            //Set Grid Form Size to correct Size
            this.Size = new Size(512 + 16, 512 + 39);


            //Make Image Black And White and set "bool[] cells" to living or dead
            initializeGridFromCells();
            //Fitting the Form to image aspect ratio
            rescaleFormToImage();
        }

        /// <summary>
        /// Generates White Picture by width and height
        /// </summary>
        private void generateClearImage(int width, int height)
        {
            //Create new Bitmap for white Image
            image = new Bitmap(width, height);

            this.width = width;
            this.height = height;

            //Set new cell amount
            cells = new BitArray(width * height);

            //Set Grid Form Size to correct Size
            this.Size = new Size(512 + 16, 512 + 39);


            //Make Image Black And White and set "bool[] cells" to living or dead
            initializeGridFromCells();
            //Fitting the Form to image aspect ratio
            rescaleFormToImage();
        }

        #endregion

#region Painting

        //Check if Mouse Down
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //If simulation is running then pause it
            if (updateThread != null && updateThread.IsAlive)
            {
                started = false;

                updateThread.Abort();

                //Update Start/Pause Button
                MainForm.instance.UpdateStartButton();

                //Set variable wasRunningBeforePaint so it restarts when stop painting
                wasRunningBeforePaint = true;
            }

            //Check if Left or Right Mousebutton
            switch (e.Button)
            {
                case MouseButtons.Left:
                    //Set Color Black
                    paintColor = MainForm.livingcolor;
                    break;

                case MouseButtons.Right:
                    //Set Color White
                    paintColor = MainForm.deadcolor;
                    break;
            }

            //Check if user wants to draw by hand
            if (paintMode == paintmode.draw)
            {
                //Set startpoint for holding Control to make straight lines
                mouseDownX = e.X;
                mouseDownY = e.Y;

                //Set in Painting Mode
                isPainting = true;

                //Set a Dot at Mouse Position
                PaintAt(e.X, e.Y);
            }
            //Check if user wants to paint a ship and is using leftclick (color livingcolor = leftclick)
            else if (paintMode != paintmode.draw && paintColor == MainForm.livingcolor)
            {
                //Calculate pattern size
                int he = Patterns.ship.GetLength(0);
                int wi = Patterns.ship.GetLength(1);

                bool[,] pattern = Patterns.ship;

                //Check Paintmode
                if (paintMode == paintmode.glider)
                {
                    he = Patterns.glider.GetLength(0);
                    wi = Patterns.glider.GetLength(1);

                    pattern = Patterns.glider;
                }

                //Every row of pattern
                for (int y = 0; y < he; y++)
                {
                    //Every collumn of pattern
                    for (int x = 0; x < wi; x++)
                    {

                        //Calculate mousePosition on image
                        float widthMultiplicator = (float)image.Width / (float)gridPictureBox.Width;
                        float heightMultiplicator = (float)image.Height / (float)gridPictureBox.Height;
                        int mouseX = (int)(e.X * widthMultiplicator);
                        int mouseY = (int)(e.Y * heightMultiplicator);


                        int yoffset = 0;
                        int xoffset = 0;

                        //Make infinity work (Check if out of bounds. If yes subtract/add height/width)
                        if (mouseY + y >= height && y > 0)
                            yoffset = -height;
                        if (mouseX + x >= width && x > 0)
                            xoffset = -width;


                        //If pattern has on position x and y a living cell then add it to the grid
                        if (pattern[y, x])
                            PaintAt(mouseX + x + xoffset, mouseY + y + yoffset, true);
                    }
                }
            }

            //Reset paintmode to hand
            paintMode = paintmode.draw;
        }

        //Check if Mouse Up
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Stop Painting
            StopPainting();
        }

        //Check if Mouse Left
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //Stop Painting
            StopPainting();
        }

        /// <summary>
        /// Stops the Painting Mode and restarts simulation if it was running before
        /// </summary>
        private void StopPainting()
        {
            //If the simulation was running before painting then restart it
            if (wasRunningBeforePaint && (updateThread == null || !updateThread.IsAlive))
            {
                //Create Thread
                updateThread = new Thread(UpdateThread);
                updateThread.Start();

                started = true;

                //Update Start/Pause Button
                MainForm.instance.UpdateStartButton();

                //Set wasRunningBeforePaint back to false
                wasRunningBeforePaint = false;
            }

            //Stop Painting Mode
            isPainting = false;
        }

        //Check if Mouse Moves
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //If Painting Mode is on (Mouse is held down)
            if (isPainting)
            {
                //If Control is held down for straight lines then draw Straight lines
                if (Control.ModifierKeys == Keys.Control)
                {
                    //If Mouse if farther away from Startpoint on X or on Y
                    if (Math.Abs(e.X - mouseDownX) > Math.Abs(e.Y - mouseDownY))
                    {
                        //Make Horizontal Line
                        PaintAt(e.X, mouseDownY);
                    }
                    else
                    {
                        //Make Vertical Line
                        PaintAt(mouseDownX, e.Y);
                    }
                }
                else
                    //Else just paint a dot at Mouse Position
                    PaintAt(e.X, e.Y);
            }
        }

        /// <summary>
        /// Paints at Position X,Y with variable paintColor
        /// </summary>
        private void PaintAt(int x, int y, bool imagePos = false)
        {
            //Try because sometimes by fast clicking it crashes because multiple threads try to get picturebox width
            try
            {
                int mouseX = x;
                int mouseY = y;

                //If pos has not been calculated for imagepos then calculate here
                if (!imagePos)
                {
                    //Variables to calculate from displayPosition to actuall Cell Position
                    float widthMultiplicator = (float)image.Width / (float)gridPictureBox.Width;
                    float heightMultiplicator = (float)image.Height / (float)gridPictureBox.Height;

                    mouseX = (int)(x * widthMultiplicator);
                    mouseY = (int)(y * heightMultiplicator);
                }


                //If really inside the Cell Grid then
                if (mouseY >= 0 && mouseX >= 0 && cells.Length > mouseY * image.Width + mouseX)
                {
                    //Check if Paint Color means alive or dead
                    if (paintColor == MainForm.livingcolor)
                        //Set cell alive
                        cells[mouseY * image.Width + mouseX] = true;
                    else
                        //Set cell dead
                        cells[mouseY * image.Width + mouseX] = false;

                    //If really inside Image
                    if (mouseX < image.Width && mouseY < image.Height)
                        //Set Pixel in paintColor at Mouse Position
                        image.SetPixel(mouseX, mouseY, paintColor);

                    //Display the image on the Grid Form
                    syncImage();
                }
            }
            catch
            {

            }
        }
#endregion
    }
}
