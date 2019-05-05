using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nintenlord.ROMHacking.GBA.Graphics;


namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    public partial class ImageForm : ToolForm
    {
        private int amountEmptyGraphicsBlocks;

        public bool CompressedGraphics
        {
            get { return CompressedCheckBox.Checked; }
            set { CompressedCheckBox.Checked = value; }
        }
        public bool CanUseCompGraphics
        {
            set 
            {
                if (!value)
                    CompressedCheckBox.Checked = false;
                CompressedCheckBox.Enabled = value; 
            } 
        }
        public int Offset
        {
            get { return (int)OffsetUD.Value; }
            set { OffsetUD.Value = value; }
        }
        public int MaxOffset
        {
            set { this.OffsetUD.Maximum = value; }
        }
        public int ImageIndex
        {
            get { return (int)ImageIndexUD.Value; }
            set 
            {
                ImageIndexUD.Value = value;
            }
        }
        public int MaxImageIndex
        {
            set { this.ImageIndexUD.Maximum = value; }
        }
        public int ImageWidth
        {
            get { return (int)WidhtUD.Value; }
        }
        public int ImageHeigth
        {
            get { return (int)HeightUD.Value; }
        }
        public int AmountEmptyGraphicsBlocks
        {
            get { return amountEmptyGraphicsBlocks; }
            set
            {
                amountEmptyGraphicsBlocks = value;
                AddedBlocksText.Text = "Amount of added\nblocks: " + value;
            }
        }

        public ImageForm()
        {
            InitializeComponent();
            toolStripShortCutKey = Keys.I;
            toolStripName = "Image Control";
            this.Text = toolStripName;
        }

        public override void SetUpdateEvents(EventHandler updateEvents)
        {
            OffsetUD.ValueChanged += updateEvents;
            CompressedCheckBox.CheckedChanged += updateEvents;
            ImageIndexUD.ValueChanged += updateEvents;
            WidhtUD.ValueChanged += updateEvents;
            HeightUD.ValueChanged += updateEvents;
            ImportBitmap.Click += updateEvents;
            LoadRaw.Click += updateEvents;
            button1.Click += updateEvents;
            button2.Click += updateEvents;
            button3.Click += updateEvents;
            button4.Click += updateEvents;
            button5.Click += updateEvents;
            button6.Click += updateEvents;
        }

        private void SaveAsBitmap_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Choose where to save the image";
            save.Filter = "PNG files|*.png|Bitmap files|*.bmp|GIF files|*.gif";
            save.OverwritePrompt = true;
            save.AutoUpgradeEnabled = true;
            save.ShowDialog();
            if (save.FileNames.Length > 0)
            {
                Program.SaveBitmap(save.FileName);                
            }
        }

        private void ImportBitmap_Click(object sender, EventArgs e)
        {
            Program.InsertBitmap();
        }

        private void RawDump_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Choose where to save the raw graphics";
            save.Filter = "GBA files|*.gba|Bibary files|*.bin|All files|*";
            save.OverwritePrompt = true;
            save.AutoUpgradeEnabled = true;
            save.ShowDialog();
            if (save.FileNames.Length > 0)
            {
                Program.DumpRawGraphics(save.FileName);
            }
        }

        private void LoadRaw_Click(object sender, EventArgs e)
        {
            Program.InsertRawGraphics();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.OffsetUD.Value + GetBlockSize() > this.OffsetUD.Maximum)
                this.OffsetUD.Value = this.OffsetUD.Maximum;
            else
                this.OffsetUD.Value += GetBlockSize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.OffsetUD.Value - GetBlockSize() < this.OffsetUD.Minimum)
                this.OffsetUD.Value = this.OffsetUD.Minimum;
            else
                this.OffsetUD.Value -= GetBlockSize();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.OffsetUD.Value + GetLineSize() > this.OffsetUD.Maximum)
                this.OffsetUD.Value = this.OffsetUD.Maximum;
            else
                this.OffsetUD.Value += GetLineSize();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.OffsetUD.Value - GetLineSize() < this.OffsetUD.Minimum)
                this.OffsetUD.Value = this.OffsetUD.Minimum;
            else
                this.OffsetUD.Value -= GetLineSize();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.OffsetUD.Value + GetScreenSize() > this.OffsetUD.Maximum)
                this.OffsetUD.Value = this.OffsetUD.Maximum;
            else
                this.OffsetUD.Value += GetScreenSize();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.OffsetUD.Value - GetScreenSize() < this.OffsetUD.Minimum)
                this.OffsetUD.Value = this.OffsetUD.Minimum;
            else
                this.OffsetUD.Value -= GetScreenSize();
        }

        int GetBlockSize()
        {
            GraphicsMode mode = Program.GetMode();
            switch (mode)
            {
                case GraphicsMode.Tile8bit:
                    return 64;
                case GraphicsMode.Tile4bit:
                    return 32;
                case GraphicsMode.BitmapTrueColour:
                    return 2;
                case GraphicsMode.Bitmap8bit:
                    return 1;
            }
            return 0;
        }

        int GetLineSize()
        {
            GraphicsMode mode = Program.GetMode();
            int result = (int)(this.WidhtUD.Value);
            switch (mode)
            {
                case GraphicsMode.Tile8bit:
                    result *= 64;
                    break;
                case GraphicsMode.Tile4bit:
                    result *= 32;
                    break;
                case GraphicsMode.BitmapTrueColour:
                    result *= 2 * 8;
                    break;
                case GraphicsMode.Bitmap8bit:
                    result *= 8;
                    break;
            }
            return result;
        }

        int GetScreenSize()
        {
            GraphicsMode mode = Program.GetMode();
            int result = (int)(this.WidhtUD.Value * this.HeightUD.Value);
            switch (mode)
            {
                case GraphicsMode.Tile8bit:
                    result *= 64;
                    break;
                case GraphicsMode.Tile4bit:
                    result *= 32;
                    break;
                case GraphicsMode.BitmapTrueColour:
                    result *= 2 * 8 * 8;
                    break;
                case GraphicsMode.Bitmap8bit:
                    result *= 8 * 8;
                    break;
            }
            return result;
        }

    }
}
