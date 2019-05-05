using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nintenlord.ROMHacking.GBA.Graphics;
using System.ComponentModel;


namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    public partial class PaletteForm : ToolForm
    {
        public GraphicsMode GraphicsMode
        {
            get
            {
                if (ColorMode16.Checked)
                    return GraphicsMode.Tile4bit;
                else if( ColorMode256.Checked)
                    return GraphicsMode.Tile8bit;
                else if (radioButton1.Checked)
                    return GraphicsMode.Bitmap8bit;
                else if (radioButton2.Checked)
                    return GraphicsMode.BitmapTrueColour;
                else
                    throw new InvalidEnumArgumentException();
            }
        }
        public bool GrayScale
        {
            get { return UseGrayScale.Checked; }
        }
        public bool PALfilePalette
        {
            get { return UsePALFile.Checked; }
        }
        public bool CompressedPalette
        {
            get { return compROMPalette.Checked; }
            set { compROMPalette.Checked = value; }
        }
        public bool CanUseCompPalette
        {
            set
            {
                if (!value)
                    compROMPalette.Checked = false;
                compROMPalette.Enabled = value;
            }
        }
        public int PaletteOffset
        {
            get { return (int)ROMPALoffsetUD.Value; }
            set { ROMPALoffsetUD.Value = value; }
        }
        public int MaxPaletteOffset
        {
            get { return (int)ROMPALoffsetUD.Maximum; }
            set { ROMPALoffsetUD.Maximum = value; }
        }
        public int PaletteIndex
        {
            get { return (int)PalIndexUD.Value; }
        }
        public int MaxPaletteIndex
        {
            get { return (int)PalIndexUD.Maximum; }
            set { PalIndexUD.Maximum = value; }
        }

        public PaletteForm()
        {
            InitializeComponent();
            toolStripShortCutKey = Keys.P;
            toolStripName = "Palette Control";
            this.Text = toolStripName;
            EventHandler paletteIndexUpdateEvent = new EventHandler(paletteIndexUpdate);
            ColorMode16.CheckedChanged += paletteIndexUpdateEvent;
            ColorMode256.CheckedChanged += paletteIndexUpdateEvent;
            radioButton1.CheckedChanged += paletteIndexUpdateEvent;
            radioButton2.CheckedChanged += paletteIndexUpdateEvent;
            paletteIndexUpdate(this, null);
        }

        private void paletteIndexUpdate(object sender, EventArgs e)
        {
            switch (GraphicsMode)
            {
                case GraphicsMode.Tile4bit:
                    MaxPaletteIndex = 15;
                    break;
                default:
                    MaxPaletteIndex = 0;
                    break;
            }
        }

        public override void SetUpdateEvents(EventHandler updateEvents)
        {
            ColorMode16.CheckedChanged += updateEvents;
            ColorMode256.CheckedChanged += updateEvents;
            radioButton1.CheckedChanged += updateEvents;
            radioButton2.CheckedChanged += updateEvents;
            UseGrayScale.CheckedChanged += updateEvents;
            UsePALFile.CheckedChanged += updateEvents;
            compROMPalette.CheckedChanged += updateEvents;
            PalIndexUD.ValueChanged += updateEvents;
            ROMPALoffsetUD.ValueChanged += updateEvents;
        }
    }
}
