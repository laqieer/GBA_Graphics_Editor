namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    partial class ImageForm
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.OffsetUD = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HeightUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.WidhtUD = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ImageIndexUD = new System.Windows.Forms.NumericUpDown();
            this.AddedBlocksText = new System.Windows.Forms.Label();
            this.LoadRaw = new System.Windows.Forms.Button();
            this.RawDump = new System.Windows.Forms.Button();
            this.SaveAsBitmap = new System.Windows.Forms.Button();
            this.ImportBitmap = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CompressedCheckBox = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetUD)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidhtUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageIndexUD)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(196, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 23);
            this.button4.TabIndex = 42;
            this.button4.Text = "+Line";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(196, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 41;
            this.button3.Text = "-Line";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "+Block";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "-Block";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OffsetUD
            // 
            this.OffsetUD.Hexadecimal = true;
            this.OffsetUD.Location = new System.Drawing.Point(51, 29);
            this.OffsetUD.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OffsetUD.Name = "OffsetUD";
            this.OffsetUD.Size = new System.Drawing.Size(85, 20);
            this.OffsetUD.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.HeightUD);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.WidhtUD);
            this.groupBox2.Location = new System.Drawing.Point(139, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 75);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Height";
            // 
            // HeightUD
            // 
            this.HeightUD.Location = new System.Drawing.Point(54, 46);
            this.HeightUD.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.HeightUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightUD.Name = "HeightUD";
            this.HeightUD.Size = new System.Drawing.Size(47, 20);
            this.HeightUD.TabIndex = 18;
            this.HeightUD.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Width";
            // 
            // WidhtUD
            // 
            this.WidhtUD.Location = new System.Drawing.Point(54, 19);
            this.WidhtUD.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.WidhtUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidhtUD.Name = "WidhtUD";
            this.WidhtUD.Size = new System.Drawing.Size(47, 20);
            this.WidhtUD.TabIndex = 17;
            this.WidhtUD.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ImageIndexUD);
            this.groupBox1.Controls.Add(this.AddedBlocksText);
            this.groupBox1.Location = new System.Drawing.Point(9, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 75);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compressed controls";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Image";
            // 
            // ImageIndexUD
            // 
            this.ImageIndexUD.Location = new System.Drawing.Point(72, 14);
            this.ImageIndexUD.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ImageIndexUD.Name = "ImageIndexUD";
            this.ImageIndexUD.Size = new System.Drawing.Size(46, 20);
            this.ImageIndexUD.TabIndex = 19;
            // 
            // AddedBlocksText
            // 
            this.AddedBlocksText.AutoSize = true;
            this.AddedBlocksText.Location = new System.Drawing.Point(6, 37);
            this.AddedBlocksText.Name = "AddedBlocksText";
            this.AddedBlocksText.Size = new System.Drawing.Size(88, 26);
            this.AddedBlocksText.TabIndex = 22;
            this.AddedBlocksText.Text = "Amount of added\r\nblocks:";
            // 
            // LoadRaw
            // 
            this.LoadRaw.Location = new System.Drawing.Point(108, 95);
            this.LoadRaw.Name = "LoadRaw";
            this.LoadRaw.Size = new System.Drawing.Size(80, 23);
            this.LoadRaw.TabIndex = 34;
            this.LoadRaw.Text = "Load raw";
            this.LoadRaw.UseVisualStyleBackColor = true;
            this.LoadRaw.Click += new System.EventHandler(this.LoadRaw_Click);
            // 
            // RawDump
            // 
            this.RawDump.Location = new System.Drawing.Point(108, 66);
            this.RawDump.Name = "RawDump";
            this.RawDump.Size = new System.Drawing.Size(80, 23);
            this.RawDump.TabIndex = 31;
            this.RawDump.Text = "Raw dump";
            this.RawDump.UseVisualStyleBackColor = true;
            this.RawDump.Click += new System.EventHandler(this.RawDump_Click);
            // 
            // SaveAsBitmap
            // 
            this.SaveAsBitmap.Location = new System.Drawing.Point(9, 66);
            this.SaveAsBitmap.Name = "SaveAsBitmap";
            this.SaveAsBitmap.Size = new System.Drawing.Size(93, 23);
            this.SaveAsBitmap.TabIndex = 30;
            this.SaveAsBitmap.Text = "Save as bitmap";
            this.SaveAsBitmap.UseVisualStyleBackColor = true;
            this.SaveAsBitmap.Click += new System.EventHandler(this.SaveAsBitmap_Click);
            // 
            // ImportBitmap
            // 
            this.ImportBitmap.Location = new System.Drawing.Point(10, 95);
            this.ImportBitmap.Name = "ImportBitmap";
            this.ImportBitmap.Size = new System.Drawing.Size(93, 23);
            this.ImportBitmap.TabIndex = 32;
            this.ImportBitmap.Text = "Import a bitmap";
            this.ImportBitmap.UseVisualStyleBackColor = true;
            this.ImportBitmap.Click += new System.EventHandler(this.ImportBitmap_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Offset:";
            // 
            // CompressedCheckBox
            // 
            this.CompressedCheckBox.AutoSize = true;
            this.CompressedCheckBox.Location = new System.Drawing.Point(9, 6);
            this.CompressedCheckBox.Name = "CompressedCheckBox";
            this.CompressedCheckBox.Size = new System.Drawing.Size(127, 17);
            this.CompressedCheckBox.TabIndex = 35;
            this.CompressedCheckBox.Text = "Compressed graphics";
            this.CompressedCheckBox.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(193, 66);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(56, 23);
            this.button5.TabIndex = 43;
            this.button5.Text = "+Screen";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(193, 95);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(56, 23);
            this.button6.TabIndex = 44;
            this.button6.Text = "-Screen";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 206);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OffsetUD);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadRaw);
            this.Controls.Add(this.RawDump);
            this.Controls.Add(this.SaveAsBitmap);
            this.Controls.Add(this.ImportBitmap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CompressedCheckBox);
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            ((System.ComponentModel.ISupportInitialize)(this.OffsetUD)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidhtUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageIndexUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown HeightUD;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown WidhtUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AddedBlocksText;
        private System.Windows.Forms.Button LoadRaw;
        private System.Windows.Forms.Button RawDump;
        private System.Windows.Forms.Button SaveAsBitmap;
        private System.Windows.Forms.Button ImportBitmap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CompressedCheckBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.NumericUpDown OffsetUD;
        public System.Windows.Forms.NumericUpDown ImageIndexUD;
    }
}