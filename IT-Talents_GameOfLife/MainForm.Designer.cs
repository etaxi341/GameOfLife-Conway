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
            this.livingColor = new System.Windows.Forms.Button();
            this.deadColor = new System.Windows.Forms.Button();
            this.paintmode_glider = new System.Windows.Forms.Button();
            this.paintmode_draw = new System.Windows.Forms.Button();
            this.paintmode_ship = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.randomimg = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.nextstep = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.paintmode_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.generationLabel = new System.Windows.Forms.Label();
            this.populationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ContextMenuPatternsElement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paintmode_select = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DelayUpDown)).BeginInit();
            this.ContextMenuPatternsElement.SuspendLayout();
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
            this.randomComboBox.Location = new System.Drawing.Point(4, 172);
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
            // livingColor
            // 
            this.livingColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.deadColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            // paintmode_glider
            // 
            this.paintmode_glider.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_pattern_glider;
            this.paintmode_glider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.paintmode_glider.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.paintmode_glider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintmode_glider.Location = new System.Drawing.Point(42, 277);
            this.paintmode_glider.Name = "paintmode_glider";
            this.paintmode_glider.Size = new System.Drawing.Size(32, 32);
            this.paintmode_glider.TabIndex = 26;
            this.ToolTipElement.SetToolTip(this.paintmode_glider, "Add Glider to Grid");
            this.paintmode_glider.UseVisualStyleBackColor = true;
            this.paintmode_glider.Click += new System.EventHandler(this.paintmode_glider_Click);
            // 
            // paintmode_draw
            // 
            this.paintmode_draw.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_cursor;
            this.paintmode_draw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.paintmode_draw.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.paintmode_draw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintmode_draw.Location = new System.Drawing.Point(4, 239);
            this.paintmode_draw.Name = "paintmode_draw";
            this.paintmode_draw.Size = new System.Drawing.Size(32, 32);
            this.paintmode_draw.TabIndex = 25;
            this.ToolTipElement.SetToolTip(this.paintmode_draw, "Add Ship to Grid");
            this.paintmode_draw.UseVisualStyleBackColor = true;
            this.paintmode_draw.Click += new System.EventHandler(this.paintmode_draw_Click);
            // 
            // paintmode_ship
            // 
            this.paintmode_ship.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_pattern_ship;
            this.paintmode_ship.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.paintmode_ship.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.paintmode_ship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintmode_ship.Location = new System.Drawing.Point(4, 277);
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
            this.clear.Location = new System.Drawing.Point(42, 199);
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
            this.randomimg.Location = new System.Drawing.Point(4, 199);
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
            this.start.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_start;
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
            // paintmode_add
            // 
            this.paintmode_add.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_pattern_add;
            this.paintmode_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.paintmode_add.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.paintmode_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintmode_add.Location = new System.Drawing.Point(4, 315);
            this.paintmode_add.Name = "paintmode_add";
            this.paintmode_add.Size = new System.Drawing.Size(32, 32);
            this.paintmode_add.TabIndex = 29;
            this.ToolTipElement.SetToolTip(this.paintmode_add, "Add Pattern");
            this.paintmode_add.UseVisualStyleBackColor = true;
            this.paintmode_add.Click += new System.EventHandler(this.paintmode_add_Click);
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
            this.label2.Location = new System.Drawing.Point(-9, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 2);
            this.label2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(-9, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 2);
            this.label3.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Generation:";
            // 
            // generationLabel
            // 
            this.generationLabel.Location = new System.Drawing.Point(4, 119);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(70, 13);
            this.generationLabel.TabIndex = 24;
            this.generationLabel.Text = "0";
            this.generationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // populationLabel
            // 
            this.populationLabel.Location = new System.Drawing.Point(4, 150);
            this.populationLabel.Name = "populationLabel";
            this.populationLabel.Size = new System.Drawing.Size(70, 14);
            this.populationLabel.TabIndex = 28;
            this.populationLabel.Text = "0";
            this.populationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Population:";
            // 
            // ContextMenuPatternsElement
            // 
            this.ContextMenuPatternsElement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.ContextMenuPatternsElement.Name = "ContextMenuPatternsElement";
            this.ContextMenuPatternsElement.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // paintmode_select
            // 
            this.paintmode_select.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_cursor;
            this.paintmode_select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.paintmode_select.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.paintmode_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintmode_select.Location = new System.Drawing.Point(42, 239);
            this.paintmode_select.Name = "paintmode_select";
            this.paintmode_select.Size = new System.Drawing.Size(32, 32);
            this.paintmode_select.TabIndex = 30;
            this.ToolTipElement.SetToolTip(this.paintmode_select, "Add Ship to Grid");
            this.paintmode_select.UseVisualStyleBackColor = true;
            this.paintmode_select.Click += new System.EventHandler(this.paintmode_select_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(78, 442);
            this.Controls.Add(this.paintmode_select);
            this.Controls.Add(this.paintmode_add);
            this.Controls.Add(this.populationLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.paintmode_glider);
            this.Controls.Add(this.paintmode_draw);
            this.Controls.Add(this.generationLabel);
            this.Controls.Add(this.label4);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tool Box";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DelayUpDown)).EndInit();
            this.ContextMenuPatternsElement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Button paintmode_draw;
        private System.Windows.Forms.Button paintmode_glider;
        private System.Windows.Forms.Label populationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button paintmode_add;
        private System.Windows.Forms.ContextMenuStrip ContextMenuPatternsElement;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button paintmode_select;
    }
}