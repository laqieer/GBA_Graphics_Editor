using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    public unsafe partial class Palette_editor : Form
    {
        private PictureBox[] colors;
        private ToolTip[] colourValues;
        private Label[] labels;
        private Button Exit;
        static Color[] controlPalette;
        int clickedPalette = -1;
        int AmountOfColour;

        const string PictureBoxName = "pictureBox";
        const string LableName = "label";
        const BorderStyle selected = BorderStyle.FixedSingle;
        const BorderStyle unSelected = BorderStyle.Fixed3D;

        public Palette_editor(Color[] palette, int widht, int height)
        {
            AmountOfColour = palette.Length - palette.Length % widht + widht;
            if (AmountOfColour > 0x100)
            {
                AmountOfColour = 0x100;
            }
            List<Color> colorList = new List<Color>(palette);
            while (colorList.Count < AmountOfColour)
                colorList.Add(Color.Black);

            controlPalette = colorList.ToArray();
            InitializeComponent();
        }
        
        private void setTooltips()
        {
            for (int i = 0; i < colourValues.Length; i++)
            {
                this.colourValues[i].SetToolTip(this.colors[i], "Red: " + controlPalette[i].R + " Green: " + controlPalette[i].G + " Blue: " + controlPalette[i].B);
            }
            
        }

        private void ChangePalette(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            int newClickedColor = Convert.ToInt32(box.Name.Substring(PictureBoxName.Length));
            if (clickedPalette < 0)
            {
                clickedPalette = newClickedColor;
                box.BorderStyle = selected;
            }
            else
            {
                if (clickedPalette != newClickedColor)
                {
                    Color swap = controlPalette[clickedPalette];
                    controlPalette[clickedPalette] = controlPalette[newClickedColor];
                    controlPalette[newClickedColor] = swap;
                    UpdateColors();
                }
                colors[clickedPalette].BorderStyle = unSelected;
                clickedPalette = -1;
            }
            
        }

        private void UpdateColors()
        {
            for (int i = 0; i < colors.Length; i++)
            {                
                if (i < controlPalette.Length)
                    this.colors[i].BackColor = controlPalette[i];
                else
                    this.colors[i].BackColor = Color.Black;
            }
            setTooltips();
        }

        private void exitPaletteEditor(object sender, EventArgs e)
        {
            this.Close();
        }

        public Color[] getPalette()
        {
            return controlPalette;
        }
    }
}
