namespace IT_Talents_GameOfLife
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.randomComboBox = new System.Windows.Forms.ComboBox();
            this.DelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.ToolTipElement = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.paintmode_ship = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.randomimg = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.nextstep = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.livingColor = new System.Windows.Forms.Button();
            this.deadColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DelayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // randomComboBox
            // 
            this.randomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.randomComboBox.FormattingEnabled = true;
            this.randomComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.randomComboBox.Items.AddRange(new object[] {
            "16x16",
            "32x32",
            "64x64",
            "128x128",
            "256x256",
            "512x512"});
            this.randomComboBox.Location = new System.Drawing.Point(4, 110);
            this.randomComboBox.Name = "randomComboBox";
            this.randomComboBox.Size = new System.Drawing.Size(70, 21);
            this.randomComboBox.TabIndex = 10;
            this.ToolTipElement.SetToolTip(this.randomComboBox, "Size of the new Image");
            // 
            // DelayUpDown
            // 
            this.DelayUpDown.Location = new System.Drawing.Point(4, 82);
            this.DelayUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DelayUpDown.Name = "DelayUpDown";
            this.DelayUpDown.Size = new System.Drawing.Size(70, 20);
            this.DelayUpDown.TabIndex = 16;
            this.ToolTipElement.SetToolTip(this.DelayUpDown, "Delay between Simulation Cycles");
            this.DelayUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.DelayUpDown.ValueChanged += new System.EventHandler(this.DelayUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 2);
            this.label1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-9, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 2);
            this.label2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-9, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 2);
            this.label3.TabIndex = 19;
            // 
            // paintmode_ship
            // 
            this.paintmode_ship.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_pattern_ship;
            this.paintmode_ship.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.paintmode_ship.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.paintmode_ship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintmode_ship.Location = new System.Drawing.Point(42, 177);
            this.paintmode_ship.Name = "paintmode_ship";
            this.paintmode_ship.Size = new System.Drawing.Size(32, 32);
            this.paintmode_ship.TabIndex = 20;
            this.ToolTipElement.SetToolTip(this.paintmode_ship, "Add Ship to Grid");
            this.paintmode_ship.UseVisualStyleBackColor = true;
            this.paintmode_ship.Click += new System.EventHandler(this.paintmode_ship_Click);
            // 
            // clear
            // 
            this.clear.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_newblank;
            this.clear.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.Location = new System.Drawing.Point(42, 137);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(32, 32);
            this.clear.TabIndex = 11;
            this.ToolTipElement.SetToolTip(this.clear, "Create new Blank Image");
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // randomimg
            // 
            this.randomimg.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_newrandom;
            this.randomimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.randomimg.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.randomimg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.randomimg.Location = new System.Drawing.Point(4, 137);
            this.randomimg.Name = "randomimg";
            this.randomimg.Size = new System.Drawing.Size(32, 32);
            this.randomimg.TabIndex = 9;
            this.ToolTipElement.SetToolTip(this.randomimg, "Create new Random Image");
            this.randomimg.UseVisualStyleBackColor = true;
            this.randomimg.Click += new System.EventHandler(this.randomimg_Click);
            // 
            // save
            // 
            this.save.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_save;
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.save.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Location = new System.Drawing.Point(42, 4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(32, 32);
            this.save.TabIndex = 12;
            this.ToolTipElement.SetToolTip(this.save, "Save Grid as Image");
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // import
            // 
            this.import.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_import;
            this.import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.import.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.import.Location = new System.Drawing.Point(4, 4);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(32, 32);
            this.import.TabIndex = 7;
            this.ToolTipElement.SetToolTip(this.import, "Import a Grid as Image");
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // nextstep
            // 
            this.nextstep.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_next;
            this.nextstep.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.nextstep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextstep.Location = new System.Drawing.Point(42, 44);
            this.nextstep.Name = "nextstep";
            this.nextstep.Size = new System.Drawing.Size(32, 32);
            this.nextstep.TabIndex = 8;
            this.ToolTipElement.SetToolTip(this.nextstep, "Simulate one Cycle");
            this.nextstep.UseVisualStyleBackColor = true;
            this.nextstep.Click += new System.EventHandler(this.nextstep_Click);
            // 
            // start
            // 
            this.start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("start.BackgroundImage")));
            this.start.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Location = new System.Drawing.Point(4, 44);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(32, 32);
            this.start.TabIndex = 6;
            this.ToolTipElement.SetToolTip(this.start, "Play the Simulation");
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // livingColor
            // 
            this.livingColor.BackColor = System.Drawing.Color.Black;
            this.livingColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.livingColor.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.livingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.livingColor.Location = new System.Drawing.Point(4, 406);
            this.livingColor.Name = "livingColor";
            this.livingColor.Size = new System.Drawing.Size(32, 32);
            this.livingColor.TabIndex = 21;
            this.ToolTipElement.SetToolTip(this.livingColor, "Living Color");
            this.livingColor.UseVisualStyleBackColor = false;
            this.livingColor.Click += new System.EventHandler(this.livingColor_Click);
            // 
            // deadColor
            // 
            this.deadColor.BackColor = System.Drawing.Color.White;
            this.deadColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deadColor.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.deadColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deadColor.Location = new System.Drawing.Point(42, 406);
            this.deadColor.Name = "deadColor";
            this.deadColor.Size = new System.Drawing.Size(32, 32);
            this.deadColor.TabIndex = 22;
            this.ToolTipElement.SetToolTip(this.deadColor, "Dead Color");
            this.deadColor.UseVisualStyleBackColor = false;
            this.deadColor.Click += new System.EventHandler(this.deadColor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(78, 442);
            this.Controls.Add(this.deadColor);
            this.Controls.Add(this.livingColor);
            this.Controls.Add(this.paintmode_ship);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.randomComboBox);
            this.Controls.Add(this.randomimg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DelayUpDown);
            this.Controls.Add(this.save);
            this.Controls.Add(this.import);
            this.Controls.Add(this.nextstep);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DelayUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox randomComboBox;
        private System.Windows.Forms.Button randomimg;
        private System.Windows.Forms.Button nextstep;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.NumericUpDown DelayUpDown;
        private System.Windows.Forms.ToolTip ToolTipElement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button paintmode_ship;
        private System.Windows.Forms.Button livingColor;
        private System.Windows.Forms.Button deadColor;
    }
}