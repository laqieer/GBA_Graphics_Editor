using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    public partial class TileForm : ToolForm
    {
        public bool UseTSA
        {
            get { return checkBox4.Checked; }
        }
        public bool HeadTSA
        {
            get { return checkBox5.Checked; }
        }
        public bool CompressedTSA
        {
            get { return checkBox3.Checked; }
        }
        public bool CanUseCompressedTSA
        {
            set 
            {
                if (!value)
                    checkBox3.Checked = false;
                checkBox3.Enabled = value; 
            }
        }
        public int TSAOffset
        {
            get { return (int)numericUpDown3.Value; }
            set { numericUpDown3.Value = value; }
        }
        public int TSAWidth
        {
            get { return 32; }
        }
        public int TSAHeigth
        {
            get { return 32; }
        }
        public int MaxTSAOffset
        {
            get { return (int)numericUpDown3.Maximum; }
            set { numericUpDown3.Maximum = value; }
        }
        public int AmountOfBytesToIngore
        {
            get { return (int)numericUpDown4.Value; }
        }
        public int TileIndex
        {
            get { return (int)numericUpDown2.Value; }
            set 
            {
                if (value <= numericUpDown2.Maximum)
                    numericUpDown2.Value = value; 
            }
        }
        public bool AllowTSAEditing 
        {
            set 
            {
                tileGraphicsUD.Enabled = value;
                tilePaletteUD.Enabled = value;
                flipGB.Enabled = value; 
            }
        }

        bool update = true;
        DataBuffer rawTSABuffer;

        public TileForm(DataBuffer rawTSABuffer)
        {
            InitializeComponent();
            this.rawTSABuffer = rawTSABuffer;
            toolStripShortCutKey = Keys.T;
            toolStripName = "Tile Control";
            this.Text = toolStripName;
        }

        public override void Refresh()
        {
            UpdateCurrentTile();
            base.Refresh();
        }

        public override void SetUpdateEvents(EventHandler updateEvents)
        {
            tileGraphicsUD.ValueChanged += updateEvents;
            numericUpDown2.ValueChanged += updateEvents;
            numericUpDown3.ValueChanged += updateEvents;
            numericUpDown4.ValueChanged += updateEvents;
            tilePaletteUD.ValueChanged += updateEvents;
            checkBox1.CheckedChanged += updateEvents;
            checkBox2.CheckedChanged += updateEvents;
            checkBox3.CheckedChanged += updateEvents;
            checkBox4.CheckedChanged += updateEvents;
            checkBox5.CheckedChanged += updateEvents;
            button1.Click += updateEvents;
            button2.Click += updateEvents;
        }

        private void UpdateCurrentTile()
        {
            numericUpDown2.Maximum = rawTSABuffer.Length / 2;
            if (rawTSABuffer.Length > 0 && !HeadTSA)
            {
                int TSA = rawTSABuffer[(int)numericUpDown2.Value * 2] 
                    + (rawTSABuffer[(int)numericUpDown2.Value * 2 + 1] << 8);
                update = false;
                tileGraphicsUD.Value = TSA & 0x3FF;
                tilePaletteUD.Value = TSA >> 12 & 0xF;
                checkBox1.Checked = ((TSA >> 11) & 1) == 1;
                checkBox2.Checked = ((TSA >> 10) & 1) == 1;
                update = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateRaw();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            UpdateRaw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRaw();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRaw();
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRaw();
        }

        private void UpdateRaw()
        {
            if (update)
            {
                byte lowerByte = (byte)((int)tileGraphicsUD.Value & 0xFF);
                byte higherByte = (byte)((int)tileGraphicsUD.Value >> 8);
                higherByte += (byte)((int)tilePaletteUD.Value << 4);
                if (checkBox1.Checked)
                    higherByte += 0x8;
                if (checkBox2.Checked)
                    higherByte += 0x4;
                if (rawTSABuffer[(int)numericUpDown2.Value * 2] != lowerByte ||
                rawTSABuffer[(int)numericUpDown2.Value * 2 + 1] != higherByte)
                {
                    rawTSABuffer[(int)numericUpDown2.Value * 2] = lowerByte;
                    rawTSABuffer[(int)numericUpDown2.Value * 2 + 1] = higherByte;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rawTSABuffer.Length / 2; i++)
            {
                rawTSABuffer[i * 2 + 1] ^= 0x8;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rawTSABuffer.Length / 2; i++)
            {
                rawTSABuffer[i * 2 + 1] ^= 0x4;
            }
        }
    }
}
