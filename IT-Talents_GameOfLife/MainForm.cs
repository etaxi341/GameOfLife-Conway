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
using System.Diagnostics;

namespace IT_Talents_GameOfLife
{
    public partial class MainForm : Form
    {

#region Variables

        //Gridform instance
        GridForm gf;
        //MainForm instance
        public static MainForm instance;

        public static Color livingcolor = Color.Black;
        public static Color deadcolor = Color.White;

        //Current Generation
        int generation;

        //Buttons for Patterns
        List<Button> patternButtons = new List<Button>();

        //Button currently rightclicked
        string buttonNameRightClicked = "";

        #endregion

        //Initialize Form
        public MainForm()
        {
            InitializeComponent();
            //Set ImageGenerate Combo Box to index 3 (128x128)
            randomComboBox.SelectedIndex = 3;

            //Set MainForm instance to this
            instance = this;

            //Set Dead and Living Colors from User Settings
            livingcolor = Properties.Settings.Default.livingColor;
            livingColor.BackColor = Properties.Settings.Default.livingColor;
            deadcolor = Properties.Settings.Default.deadColor;
            deadColor.BackColor = Properties.Settings.Default.deadColor;

            //Set GridForm instance and show it
            gf = new GridForm();
            gf.Show();

            //Initialize Pattern Buttons
            InitializePatternButtons();
        }

        private void InitializePatternButtons()
        {
            foreach(Button btn in patternButtons)
            {
                this.Controls.Remove(btn);
            }
            patternButtons.Clear();

            foreach (string name in Patterns.GetAllPatternNames())
            {
                Debug.WriteLine(name);
                Bitmap bmp = Patterns.GetBitmap(name);

                if (bmp != null)
                    AddPatternButton(name, Patterns.GenerateIcon(name));
            }

            UpdateAddPatternButton();
        }

        //On Movement of Main Form
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            //Set the Grid Form Location relative to the Main Form Location so they look like they were attached to each other
            gf.Location = new Point(this.Location.X + this.Size.Width - 16, this.Location.Y);
            gf.Activate();
            
        }

        //Click Start Button
        private void start_Click(object sender, EventArgs e)
        {
            if (gf.started)
                start.BackgroundImage = Properties.Resources.icon_start;
            else
                start.BackgroundImage = Properties.Resources.icon_pause;

            //Start Simulation
            gf.StartGrid();
        }

        /// <summary>
        /// Updates the Texture of StartButton to either Pause Or Play
        /// </summary>
        public void UpdateStartButton()
        {
            if (gf.started)
                start.BackgroundImage = Properties.Resources.icon_pause;
            else
                start.BackgroundImage = Properties.Resources.icon_start;
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
                savefile.Filter = "Bitmap (*.bmp)|*.bmp";

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

        //Click Paintmode Ship
        private void paintmode_ship_Click(object sender, EventArgs e)
        {
            //Set Paintmode to Ship
            gf.paintMode = GridForm.paintmode.ship;
        }

        //Set Living Color
        private void livingColor_Click(object sender, EventArgs e)
        {
            //Show Color Dialog
            ColorDialog cd = new ColorDialog();
            DialogResult result = cd.ShowDialog();

            //Check for result
            if (result == DialogResult.OK)
            {
                //Set livingcolor to result
                livingcolor = cd.Color;
                livingColor.BackColor = cd.Color;

                Properties.Settings.Default.livingColor = cd.Color;
                Properties.Settings.Default.Save();

                gf.initializeGridFromCells();
                gf.syncImage();
            }
        }

        //Set Dead Color
        private void deadColor_Click(object sender, EventArgs e)
        {
            //Show Color Dialog
            ColorDialog cd = new ColorDialog();
            DialogResult result = cd.ShowDialog();

            //Check for result
            if (result == DialogResult.OK)
            {
                //Set deadcolor to result
                deadcolor = cd.Color;
                deadColor.BackColor = cd.Color;

                Properties.Settings.Default.deadColor = cd.Color;
                Properties.Settings.Default.Save();

                gf.initializeGridFromCells();
                gf.syncImage();
            }
        }

        /// <summary>
        /// Set Current Generation
        /// </summary>
        public void SetGeneration(int gen)
        {
            if (gen < 0)
                gen = 0;
            generation = gen;


            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    //Set Generation Label
                    generationLabel.Text = gen.ToString();
                });
            }
            else
                //Set Generation Label
                generationLabel.Text = gen.ToString();
        }

        /// <summary>
        /// Get Current Generation
        /// </summary>
        public int GetGeneration()
        {
            return generation;
        }

        /// <summary>
        /// Set Current Population
        /// </summary>
        public void SetPopulation(int pop)
        {
            if (pop < 0)
                pop = 0;

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    //Set Population Label
                    populationLabel.Text = pop.ToString();
                });
            }
            else
                //Set Population Label
                populationLabel.Text = pop.ToString();
        }

        //Set Paintmode to drawing
        private void paintmode_draw_Click(object sender, EventArgs e)
        {
            //Set DrawMode
            gf.paintMode = GridForm.paintmode.draw;
        }

        //Set Paintmode to glider
        private void paintmode_glider_Click(object sender, EventArgs e)
        {
            //Set DrawMode
            gf.paintMode = GridForm.paintmode.glider;
        }

        //Add new Paintmode
        private void paintmode_add_Click(object sender, EventArgs e)
        {
            //Open File Dialog to select pattern you want to import
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                //Set Dialog Title
                dlg.Title = "Load Pattern";
                //Set Filters
                dlg.Filter = "Image files (*.jpg, *.png, *.bmp) | *.jpg; *.png; *.bmp";

                //If User presses okay
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string namePattern = Microsoft.VisualBasic.Interaction.InputBox("Name your Pattern", "New Pattern", "Patternname"); ;
                    namePattern.Replace("_", " ");

                    if (Patterns.HasName(namePattern))
                        return;

                    if (namePattern != "" && namePattern != null)
                    {
                        Patterns.AddPattern(dlg.FileName, namePattern);
                        AddPatternButton(namePattern, Patterns.GenerateIcon(namePattern));
                    }
                }
            }
        }

        /// <summary>
        /// Add new Button for a new Pattern
        /// </summary>
        private void AddPatternButton(string nameOfButton, Bitmap icon)
        {
            //Generate new Button
            Button patternButton = new Button();
            patternButtons.Add(patternButton);
            this.Controls.Add(patternButton);


            //Get Some Variables for New Button Parameters
            int xPosNew = 4;
            if ((patternButtons.Count + 1) % 2 != 0)
                xPosNew = 42;

            //Set new Button Parameters
            patternButton.BackgroundImage = icon;
            patternButton.BackgroundImageLayout = ImageLayout.Center;
            patternButton.FlatAppearance.BorderColor = Color.DarkGray;
            patternButton.FlatStyle = FlatStyle.Flat;
            patternButton.Location = new Point(xPosNew, 277 + (38 * (int)((patternButtons.Count + 1) / 2))); ;
            patternButton.Name = nameOfButton + "_" + patternButtons.Count;
            patternButton.Size = paintmode_add.Size;
            patternButton.TabIndex = paintmode_add.TabIndex;
            ToolTipElement.SetToolTip(patternButton, "Add " + nameOfButton + " to Grid");
            patternButton.UseVisualStyleBackColor = true;
            patternButton.Click += new System.EventHandler(paintmode_custom_Click);
            patternButton.MouseDown += new System.Windows.Forms.MouseEventHandler(paintmode_custom_MouseRightClick);

            UpdateAddPatternButton();
        }

        /// <summary>
        /// Update the Position of the "Add Pattern" Button
        /// </summary>
        private void UpdateAddPatternButton()
        {
            //Get Some Variables for Add Button Parameters
            int xPosAdd = 4;
            if ((patternButtons.Count + 1) % 2 == 0)
                xPosAdd = 42;
            int yPos = 277 + (38 * (int)((patternButtons.Count + 2) / 2));

            //Set Add Button Parameters new
            paintmode_add.Location = new Point(xPosAdd, yPos);
            paintmode_add.TabIndex++;

            //Resize MainForm if too many buttons
            if (yPos > 354)
            {
                this.Size = new Size(this.Size.Width, yPos + 128);
            }
            else
            {
                this.Size = new Size(this.Size.Width, 481);
            }
        }

        //Set Paintmode to custom
        private void paintmode_custom_Click(object sender, EventArgs e)
        {
            string senderName = ((Button)sender).Name.Split('_')[0];

            gf.currentCustomPattern = Patterns.GetPattern(senderName);
            gf.paintMode = GridForm.paintmode.custom;
        }

        //Trigger Remove Menu
        private void paintmode_custom_MouseRightClick(object sender, MouseEventArgs e)
        {
            string senderName = ((Button)sender).Name.Split('_')[0];

            Debug.WriteLine(senderName);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;

                case MouseButtons.Right:

                    ContextMenuPatternsElement.Show(Cursor.Position);
                    buttonNameRightClicked = senderName;

                    break;
            }
        }

        //Removes a Pattern
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Patterns.RemovePattern(buttonNameRightClicked);

            InitializePatternButtons();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            gf.ArrowInput(keyData);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void paintmode_select_Click(object sender, EventArgs e)
        {
            gf.paintMode = GridForm.paintmode.select;
        }
    }
}
