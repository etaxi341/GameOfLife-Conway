using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IT_Talents_GameOfLife
{
    public partial class MainForm : Form
    {

#region Variables

        //Gridform instance
        GridForm gf;
        //MainForm instance
        public static MainForm instance;

        #endregion

        //Initialize Form
        public MainForm()
        {
            InitializeComponent();
            //Set ImageGenerate Combo Box to index 3 (128x128)
            randomComboBox.SelectedIndex = 3;

            //Set MainForm instance to this
            instance = this;

            //Set GridForm instance and show it
            gf = new GridForm();
            gf.Show();
        }

        //On Movement of Main Form
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            //Set the Grid Form Location relative to the Main Form Location so they look like they were attached to each other
            gf.Location = new Point(this.Location.X + this.Size.Width - 16, this.Location.Y);
        }

        //Click Start Button
        private void start_Click(object sender, EventArgs e)
        {
            //Start Simulation
            gf.StartGrid();
        }

        //Click Next Step Button
        private void nextstep_Click(object sender, EventArgs e)
        {
            //Go to next Step
            gf.NextStep();
        }

        //Click Import Button
        private void import_Click(object sender, EventArgs e)
        {
            //Open File Dialog to select image you want to import
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                //Set Dialog Title
                dlg.Title = "Load Image";
                //Set Filters
                dlg.Filter = "Image files (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp";

                //If User presses okay
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //Import the image at path dlg.FileName
                    gf.ImportImage(dlg.FileName);
                }
            }
        }

        //Click Random Image Button
        private void randomimg_Click(object sender, EventArgs e)
        {
            //Generate Random Image
            gf.RandomImage(randomComboBox.SelectedIndex);
        }

        //Click Clear Image Button
        private void clear_Click(object sender, EventArgs e)
        {
            //Generate White Image
            gf.ClearImage(randomComboBox.SelectedIndex);
        }

        //Click Save Image Button
        private void save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog savefile = new SaveFileDialog())
            {
                //Set Dialog Title
                savefile.Title = "Save Grid Image";
                //Set Default Filename
                savefile.FileName = "GridImage.bmp";
                //Set Filters
                savefile.Filter = "Bitmap (*.bmp)|*.bmp|Conway's GoL Format (*.cogol)|*.cogol";

                //If User presses okay
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    //Save the Grid Image at the path savefile.FileName
                    gf.SaveImage(savefile.FileName);
                }
            }
        }

        //On Form Closing
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Stop Game
            if (gf.updateThread != null)
                gf.updateThread.Abort();
        }

        //Changing Delay of Cycles
        private void DelayUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Set Cycle Delay to Value of NumericUpDown
            gf.cycleDelay = (int)DelayUpDown.Value;
        }

        private void paintmode_ship_Click(object sender, EventArgs e)
        {
            gf.paintMode = GridForm.paintmode.ship;
        }
    }
}
