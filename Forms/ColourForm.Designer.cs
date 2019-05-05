namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    partial class ColourForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorIndexUD = new System.Windows.Forms.NumericUpDown();
            this.BlueUD = new System.Windows.Forms.NumericUpDown();
            this.GreenUD = new System.Windows.Forms.NumericUpDown();
            this.PaletteBox = new System.Windows.Forms.PictureBox();
            this.RedUD = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndexUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Color to edit:";
            // 
            // colorIndexUD
            // 
            this.colorIndexUD.Location = new System.Drawing.Point(84, 146);
            this.colorIndexUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorIndexUD.Name = "colorIndexUD";
            this.colorIndexUD.Size = new System.Drawing.Size(41, 20);
            this.colorIndexUD.TabIndex = 45;
            this.colorIndexUD.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // BlueUD
            // 
            this.BlueUD.Location = new System.Drawing.Point(188, 120);
            this.BlueUD.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.BlueUD.Name = "BlueUD";
            this.BlueUD.Size = new System.Drawing.Size(38, 20);
            this.BlueUD.TabIndex = 44;
            this.BlueUD.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // GreenUD
            // 
            this.GreenUD.Location = new System.Drawing.Point(188, 64);
            this.GreenUD.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.GreenUD.Name = "GreenUD";
            this.GreenUD.Size = new System.Drawing.Size(38, 20);
            this.GreenUD.TabIndex = 43;
            this.GreenUD.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // PaletteBox
            // 
            this.PaletteBox.Location = new System.Drawing.Point(12, 12);
            this.PaletteBox.Name = "PaletteBox";
            this.PaletteBox.Size = new System.Drawing.Size(128, 128);
            this.PaletteBox.TabIndex = 38;
            this.PaletteBox.TabStop = false;
            this.PaletteBox.Click += new System.EventHandler(this.PaletteBox_Click);
            // 
            // RedUD
            // 
            this.RedUD.Location = new System.Drawing.Point(188, 18);
            this.RedUD.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RedUD.Name = "RedUD";
            this.RedUD.Size = new System.Drawing.Size(38, 20);
            this.RedUD.TabIndex = 40;
            this.RedUD.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Blue";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Green";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Red";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Save palette image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ColourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 176);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorIndexUD);
            this.Controls.Add(this.BlueUD);
            this.Controls.Add(this.GreenUD);
            this.Controls.Add(this.PaletteBox);
            this.Controls.Add(this.RedUD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "ColourForm";
            this.Text = "ColourForm";
            ((System.ComponentModel.ISupportInitialize)(this.colorIndexUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown colorIndexUD;
        private System.Windows.Forms.NumericUpDown BlueUD;
        private System.Windows.Forms.NumericUpDown GreenUD;
        private System.Windows.Forms.PictureBox PaletteBox;
        private System.Windows.Forms.NumericUpDown RedUD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}