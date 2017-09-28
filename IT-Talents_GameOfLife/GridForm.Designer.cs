namespace IT_Talents_GameOfLife
{
    partial class GridForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridForm));
            this.gridPictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuElementSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectionAsPatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridPictureBox)).BeginInit();
            this.contextMenuElementSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPictureBox
            // 
            this.gridPictureBox.Location = new System.Drawing.Point(0, 0);
            this.gridPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.gridPictureBox.Name = "gridPictureBox";
            this.gridPictureBox.Size = new System.Drawing.Size(512, 512);
            this.gridPictureBox.TabIndex = 0;
            this.gridPictureBox.TabStop = false;
            this.gridPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.gridPictureBox.MouseEnter += new System.EventHandler(this.gridPictureBox_MouseEnter);
            this.gridPictureBox.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.gridPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.gridPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // contextMenuElementSelected
            // 
            this.contextMenuElementSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionAsPatternToolStripMenuItem});
            this.contextMenuElementSelected.Name = "contextMenuElementSelected";
            this.contextMenuElementSelected.Size = new System.Drawing.Size(178, 48);
            // 
            // selectionAsPatternToolStripMenuItem
            // 
            this.selectionAsPatternToolStripMenuItem.Name = "selectionAsPatternToolStripMenuItem";
            this.selectionAsPatternToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectionAsPatternToolStripMenuItem.Text = "Selection as Pattern";
            this.selectionAsPatternToolStripMenuItem.Click += new System.EventHandler(this.selectionAsPatternToolStripMenuItem_Click);
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.gridPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridForm";
            this.Text = "Grid";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.LocationChanged += new System.EventHandler(this.GridForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridPictureBox)).EndInit();
            this.contextMenuElementSelected.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gridPictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuElementSelected;
        private System.Windows.Forms.ToolStripMenuItem selectionAsPatternToolStripMenuItem;
    }
}

