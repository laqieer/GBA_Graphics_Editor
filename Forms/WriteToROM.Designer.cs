namespace Nintenlord.GBA_Graphics_Editor
{
    partial class WriteToROM
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
            this.abortGraphicsCB = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.repointGraphicsCB = new System.Windows.Forms.CheckBox();
            this.importPaletteCB = new System.Windows.Forms.CheckBox();
            this.importGraphicsCB = new System.Windows.Forms.CheckBox();
            this.graphicsOffsetUD = new System.Windows.Forms.NumericUpDown();
            this.paletteOffsetUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.abortPaletteCB = new System.Windows.Forms.CheckBox();
            this.repointPaletteCB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TSAOffsetUD = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.repointTSACB = new System.Windows.Forms.CheckBox();
            this.abortTSACB = new System.Windows.Forms.CheckBox();
            this.importTSACB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphicsOffsetUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffsetUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSAOffsetUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Graphics Offset";
            // 
            // abortGraphicsCB
            // 
            this.abortGraphicsCB.AutoSize = true;
            this.abortGraphicsCB.Checked = true;
            this.abortGraphicsCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.abortGraphicsCB.Location = new System.Drawing.Point(6, 63);
            this.abortGraphicsCB.Name = "abortGraphicsCB";
            this.abortGraphicsCB.Size = new System.Drawing.Size(216, 17);
            this.abortGraphicsCB.TabIndex = 2;
            this.abortGraphicsCB.Text = "Abort if new graphics are bigger than old";
            this.abortGraphicsCB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(9, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(170, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // repointGraphicsCB
            // 
            this.repointGraphicsCB.AutoSize = true;
            this.repointGraphicsCB.Location = new System.Drawing.Point(6, 86);
            this.repointGraphicsCB.Name = "repointGraphicsCB";
            this.repointGraphicsCB.Size = new System.Drawing.Size(146, 17);
            this.repointGraphicsCB.TabIndex = 5;
            this.repointGraphicsCB.Text = "Repoint graphics pointers";
            this.repointGraphicsCB.UseVisualStyleBackColor = true;
            // 
            // importPaletteCB
            // 
            this.importPaletteCB.AutoSize = true;
            this.importPaletteCB.Checked = true;
            this.importPaletteCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.importPaletteCB.Location = new System.Drawing.Point(11, 40);
            this.importPaletteCB.Name = "importPaletteCB";
            this.importPaletteCB.Size = new System.Drawing.Size(90, 17);
            this.importPaletteCB.TabIndex = 6;
            this.importPaletteCB.Text = "Import palette";
            this.importPaletteCB.UseVisualStyleBackColor = true;
            // 
            // importGraphicsCB
            // 
            this.importGraphicsCB.AutoSize = true;
            this.importGraphicsCB.Checked = true;
            this.importGraphicsCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.importGraphicsCB.Location = new System.Drawing.Point(6, 40);
            this.importGraphicsCB.Name = "importGraphicsCB";
            this.importGraphicsCB.Size = new System.Drawing.Size(100, 17);
            this.importGraphicsCB.TabIndex = 7;
            this.importGraphicsCB.Text = "Import Graphics";
            this.importGraphicsCB.UseVisualStyleBackColor = true;
            // 
            // graphicsOffsetUD
            // 
            this.graphicsOffsetUD.Hexadecimal = true;
            this.graphicsOffsetUD.Location = new System.Drawing.Point(92, 14);
            this.graphicsOffsetUD.Name = "graphicsOffsetUD";
            this.graphicsOffsetUD.Size = new System.Drawing.Size(131, 20);
            this.graphicsOffsetUD.TabIndex = 8;
            // 
            // paletteOffsetUD
            // 
            this.paletteOffsetUD.Hexadecimal = true;
            this.paletteOffsetUD.Location = new System.Drawing.Point(94, 14);
            this.paletteOffsetUD.Name = "paletteOffsetUD";
            this.paletteOffsetUD.Size = new System.Drawing.Size(120, 20);
            this.paletteOffsetUD.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Palette offset";
            // 
            // abortPaletteCB
            // 
            this.abortPaletteCB.AutoSize = true;
            this.abortPaletteCB.Location = new System.Drawing.Point(11, 63);
            this.abortPaletteCB.Name = "abortPaletteCB";
            this.abortPaletteCB.Size = new System.Drawing.Size(200, 17);
            this.abortPaletteCB.TabIndex = 11;
            this.abortPaletteCB.Text = "Abort if new palette is bigger than old";
            this.abortPaletteCB.UseVisualStyleBackColor = true;
            // 
            // repointPaletteCB
            // 
            this.repointPaletteCB.AutoSize = true;
            this.repointPaletteCB.Location = new System.Drawing.Point(11, 86);
            this.repointPaletteCB.Name = "repointPaletteCB";
            this.repointPaletteCB.Size = new System.Drawing.Size(138, 17);
            this.repointPaletteCB.TabIndex = 12;
            this.repointPaletteCB.Text = "Repoint palette pointers";
            this.repointPaletteCB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "TSA offset";
            // 
            // TSAOffsetUD
            // 
            this.TSAOffsetUD.Location = new System.Drawing.Point(69, 14);
            this.TSAOffsetUD.Name = "TSAOffsetUD";
            this.TSAOffsetUD.Size = new System.Drawing.Size(120, 20);
            this.TSAOffsetUD.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "File";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(171, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Browse...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.importGraphicsCB);
            this.groupBox1.Controls.Add(this.abortGraphicsCB);
            this.groupBox1.Controls.Add(this.repointGraphicsCB);
            this.groupBox1.Controls.Add(this.graphicsOffsetUD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 111);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphics";
            this.groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.paletteOffsetUD);
            this.groupBox2.Controls.Add(this.importPaletteCB);
            this.groupBox2.Controls.Add(this.abortPaletteCB);
            this.groupBox2.Controls.Add(this.repointPaletteCB);
            this.groupBox2.Location = new System.Drawing.Point(10, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 111);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Palette";
            this.groupBox2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.repointTSACB);
            this.groupBox3.Controls.Add(this.abortTSACB);
            this.groupBox3.Controls.Add(this.importTSACB);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TSAOffsetUD);
            this.groupBox3.Location = new System.Drawing.Point(9, 273);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 108);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TSA";
            this.groupBox3.Visible = false;
            // 
            // repointTSACB
            // 
            this.repointTSACB.AutoSize = true;
            this.repointTSACB.Location = new System.Drawing.Point(9, 86);
            this.repointTSACB.Name = "repointTSACB";
            this.repointTSACB.Size = new System.Drawing.Size(127, 17);
            this.repointTSACB.TabIndex = 2;
            this.repointTSACB.Text = "Repoint TSA pointers";
            this.repointTSACB.UseVisualStyleBackColor = true;
            // 
            // abortTSACB
            // 
            this.abortTSACB.AutoSize = true;
            this.abortTSACB.Location = new System.Drawing.Point(9, 63);
            this.abortTSACB.Name = "abortTSACB";
            this.abortTSACB.Size = new System.Drawing.Size(189, 17);
            this.abortTSACB.TabIndex = 1;
            this.abortTSACB.Text = "Abort if new TSA is bigger than old";
            this.abortTSACB.UseVisualStyleBackColor = true;
            // 
            // importTSACB
            // 
            this.importTSACB.AutoSize = true;
            this.importTSACB.Location = new System.Drawing.Point(9, 40);
            this.importTSACB.Name = "importTSACB";
            this.importTSACB.Size = new System.Drawing.Size(79, 17);
            this.importTSACB.TabIndex = 0;
            this.importTSACB.Text = "Import TSA";
            this.importTSACB.UseVisualStyleBackColor = true;
            // 
            // WriteToROM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 418);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WriteToROM";
            this.Text = "Write options";
            ((System.ComponentModel.ISupportInitialize)(this.graphicsOffsetUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paletteOffsetUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TSAOffsetUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox abortGraphicsCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox importPaletteCB;
        private System.Windows.Forms.CheckBox importGraphicsCB;
        private System.Windows.Forms.NumericUpDown graphicsOffsetUD;
        private System.Windows.Forms.NumericUpDown paletteOffsetUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox abortPaletteCB;
        private System.Windows.Forms.CheckBox repointPaletteCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TSAOffsetUD;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox repointTSACB;
        private System.Windows.Forms.CheckBox abortTSACB;
        private System.Windows.Forms.CheckBox importTSACB;
        private System.Windows.Forms.CheckBox repointGraphicsCB;
    }
}