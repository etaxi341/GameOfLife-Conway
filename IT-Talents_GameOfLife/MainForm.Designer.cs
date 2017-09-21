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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clear = new System.Windows.Forms.Button();
            this.randomimg = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.save = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.ToolTipElement = new System.Windows.Forms.ToolTip(this.components);
            this.nextstep = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.randomComboBox.Location = new System.Drawing.Point(9, 19);
            this.randomComboBox.Name = "randomComboBox";
            this.randomComboBox.Size = new System.Drawing.Size(70, 21);
            this.randomComboBox.TabIndex = 10;
            this.ToolTipElement.SetToolTip(this.randomComboBox, "Size of the new Image");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.randomComboBox);
            this.groupBox1.Controls.Add(this.clear);
            this.groupBox1.Controls.Add(this.randomimg);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 88);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generator";
            // 
            // clear
            // 
            this.clear.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_newblank;
            this.clear.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.Location = new System.Drawing.Point(47, 46);
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
            this.randomimg.Location = new System.Drawing.Point(9, 46);
            this.randomimg.Name = "randomimg";
            this.randomimg.Size = new System.Drawing.Size(32, 32);
            this.randomimg.TabIndex = 9;
            this.ToolTipElement.SetToolTip(this.randomimg, "Create new Random Image");
            this.randomimg.UseVisualStyleBackColor = true;
            this.randomimg.Click += new System.EventHandler(this.randomimg_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.save);
            this.groupBox2.Controls.Add(this.import);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 125);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Settings";
            // 
            // save
            // 
            this.save.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_save;
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.save.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Location = new System.Drawing.Point(139, 90);
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
            this.import.Location = new System.Drawing.Point(139, 52);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(32, 32);
            this.import.TabIndex = 7;
            this.ToolTipElement.SetToolTip(this.import, "Import a Grid as Image");
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Delay (ms):";
            // 
            // DelayUpDown
            // 
            this.DelayUpDown.Location = new System.Drawing.Point(80, 172);
            this.DelayUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DelayUpDown.Name = "DelayUpDown";
            this.DelayUpDown.Size = new System.Drawing.Size(56, 20);
            this.DelayUpDown.TabIndex = 16;
            this.DelayUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.DelayUpDown.ValueChanged += new System.EventHandler(this.DelayUpDown_ValueChanged);
            // 
            // nextstep
            // 
            this.nextstep.BackgroundImage = global::IT_Talents_GameOfLife.Properties.Resources.icon_next;
            this.nextstep.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.nextstep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextstep.Location = new System.Drawing.Point(151, 155);
            this.nextstep.Name = "nextstep";
            this.nextstep.Size = new System.Drawing.Size(32, 32);
            this.nextstep.TabIndex = 8;
            this.nextstep.UseVisualStyleBackColor = true;
            this.nextstep.Click += new System.EventHandler(this.nextstep_Click);
            // 
            // start
            // 
            this.start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("start.BackgroundImage")));
            this.start.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Location = new System.Drawing.Point(27, 139);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(32, 32);
            this.start.TabIndex = 6;
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 208);
            this.Controls.Add(this.DelayUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nextstep);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DelayUpDown)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DelayUpDown;
        private System.Windows.Forms.ToolTip ToolTipElement;
    }
}