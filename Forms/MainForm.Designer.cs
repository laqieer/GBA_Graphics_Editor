namespace Nintenlord.GBA_Graphics_Editor.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rOMLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNonDefaulsNlzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAPaletteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deepScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChangesToROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateflipImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rOMLoadingToolStripMenuItem
            // 
            this.rOMLoadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadROMToolStripMenuItem,
            this.loadNonDefaulsNlzToolStripMenuItem,
            this.loadAPaletteFileToolStripMenuItem,
            this.reScanToolStripMenuItem,
            this.deepScanToolStripMenuItem,
            this.saveChangesToROMToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.rOMLoadingToolStripMenuItem.Name = "rOMLoadingToolStripMenuItem";
            this.rOMLoadingToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.rOMLoadingToolStripMenuItem.Text = "File";
            // 
            // loadROMToolStripMenuItem
            // 
            this.loadROMToolStripMenuItem.Name = "loadROMToolStripMenuItem";
            this.loadROMToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadROMToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadROMToolStripMenuItem.Text = "Open ROM";
            this.loadROMToolStripMenuItem.Click += new System.EventHandler(this.loadROMToolStripMenuItem_Click);
            // 
            // loadNonDefaulsNlzToolStripMenuItem
            // 
            this.loadNonDefaulsNlzToolStripMenuItem.Enabled = false;
            this.loadNonDefaulsNlzToolStripMenuItem.Name = "loadNonDefaulsNlzToolStripMenuItem";
            this.loadNonDefaulsNlzToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadNonDefaulsNlzToolStripMenuItem.Text = "Load a .nlz file";
            this.loadNonDefaulsNlzToolStripMenuItem.Click += new System.EventHandler(this.loadNonDefaulsNlzToolStripMenuItem_Click);
            // 
            // loadAPaletteFileToolStripMenuItem
            // 
            this.loadAPaletteFileToolStripMenuItem.Enabled = false;
            this.loadAPaletteFileToolStripMenuItem.Name = "loadAPaletteFileToolStripMenuItem";
            this.loadAPaletteFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadAPaletteFileToolStripMenuItem.Text = "Load a palette file";
            this.loadAPaletteFileToolStripMenuItem.Click += new System.EventHandler(this.loadAPaletteFileToolStripMenuItem_Click);
            // 
            // reScanToolStripMenuItem
            // 
            this.reScanToolStripMenuItem.Enabled = false;
            this.reScanToolStripMenuItem.Name = "reScanToolStripMenuItem";
            this.reScanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reScanToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.reScanToolStripMenuItem.Text = "Re Scan";
            this.reScanToolStripMenuItem.Click += new System.EventHandler(this.reScanToolStripMenuItem_Click);
            // 
            // deepScanToolStripMenuItem
            // 
            this.deepScanToolStripMenuItem.Enabled = false;
            this.deepScanToolStripMenuItem.Name = "deepScanToolStripMenuItem";
            this.deepScanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.deepScanToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.deepScanToolStripMenuItem.Text = "Deep Scan";
            this.deepScanToolStripMenuItem.Click += new System.EventHandler(this.deepScanToolStripMenuItem_Click);
            // 
            // saveChangesToROMToolStripMenuItem
            // 
            this.saveChangesToROMToolStripMenuItem.Enabled = false;
            this.saveChangesToROMToolStripMenuItem.Name = "saveChangesToROMToolStripMenuItem";
            this.saveChangesToROMToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveChangesToROMToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveChangesToROMToolStripMenuItem.Text = "Save";
            this.saveChangesToROMToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToROMToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rOMLoadingToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.rotateflipImageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(256, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "Rotate/flip image";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Enabled = false;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // rotateflipImageToolStripMenuItem
            // 
            this.rotateflipImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotate90ToolStripMenuItem,
            this.flipToolStripMenuItem});
            this.rotateflipImageToolStripMenuItem.Enabled = false;
            this.rotateflipImageToolStripMenuItem.Name = "rotateflipImageToolStripMenuItem";
            this.rotateflipImageToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.rotateflipImageToolStripMenuItem.Text = "Rotate/flip image";
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            this.rotate90ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rotate90ToolStripMenuItem.Text = "Rotate";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem2.Text = "0";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.CheckOnClick = true;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem3.Text = "90";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.CheckOnClick = true;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem4.Text = "180";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.CheckOnClick = true;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem5.Text = "270";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticallyToolStripMenuItem,
            this.horizontallyToolStripMenuItem});
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            this.flipToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.flipToolStripMenuItem.Text = "Flip";
            // 
            // verticallyToolStripMenuItem
            // 
            this.verticallyToolStripMenuItem.CheckOnClick = true;
            this.verticallyToolStripMenuItem.Name = "verticallyToolStripMenuItem";
            this.verticallyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.verticallyToolStripMenuItem.Text = "Vertically";
            // 
            // horizontallyToolStripMenuItem
            // 
            this.horizontallyToolStripMenuItem.CheckOnClick = true;
            this.horizontallyToolStripMenuItem.Name = "horizontallyToolStripMenuItem";
            this.horizontallyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.horizontallyToolStripMenuItem.Text = "Horizontally";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 280);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "GBA Graphics Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem rOMLoadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNonDefaulsNlzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAPaletteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deepScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateflipImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontallyToolStripMenuItem;
    }
}

