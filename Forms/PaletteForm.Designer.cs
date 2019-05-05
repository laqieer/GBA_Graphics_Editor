namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    partial class PaletteForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PalIndexUD = new System.Windows.Forms.NumericUpDown();
            this.UseGrayScale = new System.Windows.Forms.CheckBox();
            this.compROMPalette = new System.Windows.Forms.CheckBox();
            this.UsePALFile = new System.Windows.Forms.CheckBox();
            this.ROMPALoffsetUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ColorMode16 = new System.Windows.Forms.RadioButton();
            this.ColorMode256 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PalIndexUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROMPALoffsetUD)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PalIndexUD);
            this.groupBox1.Controls.Add(this.UseGrayScale);
            this.groupBox1.Controls.Add(this.compROMPalette);
            this.groupBox1.Controls.Add(this.UsePALFile);
            this.groupBox1.Controls.Add(this.ROMPALoffsetUD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(138, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 157);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Palette control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Palette index";
            // 
            // PalIndexUD
            // 
            this.PalIndexUD.Location = new System.Drawing.Point(114, 116);
            this.PalIndexUD.Name = "PalIndexUD";
            this.PalIndexUD.Size = new System.Drawing.Size(69, 20);
            this.PalIndexUD.TabIndex = 13;
            // 
            // UseGrayScale
            // 
            this.UseGrayScale.AutoSize = true;
            this.UseGrayScale.Location = new System.Drawing.Point(6, 19);
            this.UseGrayScale.Name = "UseGrayScale";
            this.UseGrayScale.Size = new System.Drawing.Size(76, 17);
            this.UseGrayScale.TabIndex = 3;
            this.UseGrayScale.Text = "Gray scale";
            this.UseGrayScale.UseVisualStyleBackColor = true;
            // 
            // compROMPalette
            // 
            this.compROMPalette.AutoSize = true;
            this.compROMPalette.Location = new System.Drawing.Point(6, 65);
            this.compROMPalette.Name = "compROMPalette";
            this.compROMPalette.Size = new System.Drawing.Size(144, 17);
            this.compROMPalette.TabIndex = 12;
            this.compROMPalette.Text = "Compressed ROMpalette";
            this.compROMPalette.UseVisualStyleBackColor = true;
            // 
            // UsePALFile
            // 
            this.UsePALFile.AutoSize = true;
            this.UsePALFile.Enabled = false;
            this.UsePALFile.Location = new System.Drawing.Point(6, 42);
            this.UsePALFile.Name = "UsePALFile";
            this.UsePALFile.Size = new System.Drawing.Size(147, 17);
            this.UsePALFile.TabIndex = 9;
            this.UsePALFile.Text = "Use palettes from PAL file";
            this.UsePALFile.UseVisualStyleBackColor = true;
            // 
            // ROMPALoffsetUD
            // 
            this.ROMPALoffsetUD.Hexadecimal = true;
            this.ROMPALoffsetUD.Location = new System.Drawing.Point(114, 90);
            this.ROMPALoffsetUD.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ROMPALoffsetUD.Name = "ROMPALoffsetUD";
            this.ROMPALoffsetUD.Size = new System.Drawing.Size(69, 20);
            this.ROMPALoffsetUD.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ROM Palette(s) offset";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.ColorMode16);
            this.groupBox2.Controls.Add(this.ColorMode256);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 121);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graphics mode";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 94);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Truecolour bitmap";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 70);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Indexed bitmap";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // ColorMode16
            // 
            this.ColorMode16.AutoSize = true;
            this.ColorMode16.Checked = true;
            this.ColorMode16.Location = new System.Drawing.Point(6, 19);
            this.ColorMode16.Name = "ColorMode16";
            this.ColorMode16.Size = new System.Drawing.Size(101, 17);
            this.ColorMode16.TabIndex = 4;
            this.ColorMode16.TabStop = true;
            this.ColorMode16.Text = "4bit tile graphics";
            this.ColorMode16.UseVisualStyleBackColor = true;
            // 
            // ColorMode256
            // 
            this.ColorMode256.AutoSize = true;
            this.ColorMode256.Location = new System.Drawing.Point(6, 46);
            this.ColorMode256.Name = "ColorMode256";
            this.ColorMode256.Size = new System.Drawing.Size(101, 17);
            this.ColorMode256.TabIndex = 5;
            this.ColorMode256.Text = "8bit tile graphics";
            this.ColorMode256.UseVisualStyleBackColor = true;
            // 
            // PaletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 182);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "PaletteForm";
            this.Text = "PaletteForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PalIndexUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROMPALoffsetUD)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PalIndexUD;
        private System.Windows.Forms.CheckBox UseGrayScale;
        private System.Windows.Forms.CheckBox UsePALFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ColorMode16;
        private System.Windows.Forms.RadioButton ColorMode256;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.NumericUpDown ROMPALoffsetUD;
        public System.Windows.Forms.CheckBox compROMPalette;
    }
}