using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Nintenlord.ROMHacking.GBA.Graphics;

namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    public partial class ColourForm : ToolForm
    {
        Color[] palette;
        DataBuffer rawPalette;
        bool update = true;

        public Color[] Palette
        {
            get { return palette; }
            set 
            { 
                palette = value;
                colorIndexUD.Maximum = value.Length == 0 ? 0 : value.Length - 1;
            }
        }
        private Color CurrentColor
        {
            get { return palette[(int)colorIndexUD.Value]; }
        }
        public bool AllowColorEditing
        {
            set 
            {
                RedUD.Enabled = value;
                BlueUD.Enabled = value;
                GreenUD.Enabled = value;
            }
        }

        EventHandler updateEvents;

        public ColourForm(DataBuffer rawPaletteBuffer)
        {
            rawPalette = rawPaletteBuffer;
            InitializeComponent();
            toolStripShortCutKey = Keys.C;
            toolStripName = "Colour Control";
            this.Text = toolStripName;
            this.PaletteBox.Paint += pictureBox2_Paint;
        }
        
        void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            GraphicsContainer container = e.Graphics.BeginContainer();
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.CompositingMode = CompositingMode.SourceCopy;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            int widht = this.PaletteBox.Width / 16;
            int heigth = this.PaletteBox.Height / 16;
            Rectangle rect = new Rectangle(0, 0, widht, heigth);

            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    Color color;
                    if (palette != null && y * 16 + x < palette.Length)
                        color = palette[y * 16 + x];
                    else
                        color = Color.Black;
                    rect.X = x * widht;
                    rect.Y = y * widht;

                    SolidBrush brush = new SolidBrush(color);
                    e.Graphics.FillRectangle(brush, rect);
                }
            }

            if (palette.Length > 0)
            {
                Color antiColor = Color.FromArgb(0xFF - CurrentColor.R, 0xFF - CurrentColor.G, 0xFF - CurrentColor.B);
                Pen pen = new Pen(antiColor);
                Rectangle rect2 = new Rectangle();
                rect2.X = (int)(colorIndexUD.Value % 16) * 8 - 1;
                rect2.Y = (int)(colorIndexUD.Value / 16) * 8 - 1;
                rect2.Height = widht + 1;
                rect2.Width = widht + 1;
                e.Graphics.DrawRectangle(pen, rect2);
            }
            e.Graphics.EndContainer(container);
        }

        public override void Refresh()
        {
            if (rawPalette.Length > 0)
                Palette = GBAPalette.ToPalette(rawPalette.ToArray(), 0, rawPalette.Length / 2);
            else
                Palette = new Color[0];
            numericUpDown1_ValueChanged(null, null);
            base.Refresh();
        }

        public override void SetUpdateEvents(EventHandler updateEvents)
        {
            this.updateEvents = updateEvents;
            //RedUD.ValueChanged += updateEvents;
            //GreenUD.ValueChanged += updateEvents;
            //BlueUD.ValueChanged += updateEvents;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Choose where to save the palette image";
            save.Filter = "PNG files|*.png|Bitmap files|*.bmp|GIF files|*.gif";
            save.OverwritePrompt = true;
            save.AutoUpgradeEnabled = true;
            save.ShowDialog();
            if (save.FileNames.Length > 0)
            {
                Bitmap bitmap = new Bitmap(PaletteBox.Width, PaletteBox.Height);
                this.PaletteBox.DrawToBitmap(bitmap, new Rectangle(new Point(), bitmap.Size));
                ImageFormat im;
                switch (Path.GetExtension(save.FileName).ToUpper())
                {
                    case ".PNG":
                        im = ImageFormat.Png;
                        break;
                    case ".BMP":
                        im = ImageFormat.Bmp;
                        break;
                    case ".GIF":
                        im = ImageFormat.Gif;
                        break;
                    default:
                        MessageBox.Show("Wrong image format.");
                        return;
                }
                bitmap.Save(save.FileName, im);
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentColor(sender, e);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentColor(sender, e);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentColor(sender, e);
        }

        private void UpdateCurrentColor(object sender, EventArgs e)
        {
            if (update)
            {
                ushort newColor = GBAPalette.toGBAcolor((int)RedUD.Value << 3, (int)GreenUD.Value << 3, (int)BlueUD.Value << 3);
                rawPalette[(int)colorIndexUD.Value * 2] = (byte)(newColor & 0xFF);
                rawPalette[(int)colorIndexUD.Value * 2 + 1] = (byte)(newColor >> 8 & 0xFF);
                updateEvents.Invoke(sender, e);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (palette.Length > 0)
            {
                update = false;
                RedUD.Value = CurrentColor.R >> 3;
                GreenUD.Value = CurrentColor.G >> 3;
                BlueUD.Value = CurrentColor.B >> 3;
                this.PaletteBox.Refresh();
                update = true;
            }
        }

        private void PaletteBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            int y = me.Y >> 3;
            int x = me.X >> 3;
            int value = x + y * 16;
            if (value < colorIndexUD.Maximum)
            {
                colorIndexUD.Value = value;
            }
        }
    }
}
