using System;
using System.Windows.Forms;
using System.Drawing;

namespace Nintenlord.GBA_Graphics_Editor
{
    public partial class WriteToROM : Form
    {
        string filter;
        static Point startingPoint = new Point(9, 39);
        static int value = 6;
        WriteToROMDialogResult result;

        public WriteToROM(string filter, 
            bool graphics, bool palette, bool TSA, 
            int graphicsOffset, int paletteOffset, int TSAoffset)
        {
            InitializeComponent();
            graphicsOffsetUD.Maximum = 0x2000000;
            paletteOffsetUD.Maximum = 0x2000000;
            TSAOffsetUD.Maximum = 0x2000000;
            graphicsOffsetUD.Value = graphicsOffset;
            paletteOffsetUD.Value = paletteOffset;
            TSAOffsetUD.Value = TSAoffset;
            this.filter = filter;

            Point endPoint = startingPoint;
            if (graphics)
            {
                groupBox1.Visible = true;
                groupBox1.Location = endPoint;
                endPoint.Y += groupBox1.Height + value;
            }

            if (palette)
            {
                groupBox2.Visible = true;
                groupBox2.Location = endPoint;
                endPoint.Y += groupBox2.Height + value;
            }

            if (TSA)
            {
                groupBox3.Visible = true;
                groupBox3.Location = endPoint;
                endPoint.Y += groupBox3.Height + value;
            }
            endPoint.Y += 63;
            this.Height = endPoint.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setResult();
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setResult();
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            open.Filter = filter;
            open.Title = "";
            if (open.ShowDialog() == DialogResult.OK && open.FileNames.Length > 0)
            {
                textBox1.Text = open.FileName;
            }
        }

        private void setResult()
        {
            result = new WriteToROMDialogResult();
            result.file = this.textBox1.Text;
            result.infos = new WriteInfo[3];
            result.infos[0] = new WriteInfo((int)graphicsOffsetUD.Value, importGraphicsCB.Checked, abortGraphicsCB.Checked, repointGraphicsCB.Checked);
            result.infos[1] = new WriteInfo((int)paletteOffsetUD.Value, importPaletteCB.Checked, abortPaletteCB.Checked, repointPaletteCB.Checked);
            result.infos[2] = new WriteInfo((int)TSAOffsetUD.Value, importTSACB.Checked, abortTSACB.Checked, repointTSACB.Checked);
        }

        public WriteToROMDialogResult getResult()
        {
            return result;
        }
    }

    public struct WriteInfo
    {
        public int offset;
        public bool import;
        public bool repoint;
        public bool abortIfBigger;

        public WriteInfo(int offset, bool import, bool abortIfBigger, bool repoint)
        {
            this.offset = offset;
            this.import = import;
            this.abortIfBigger = abortIfBigger;
            this.repoint = repoint;
        }
    }

    public struct WriteToROMDialogResult
    {
        public WriteInfo[] infos;
        public string file;
    }
}
