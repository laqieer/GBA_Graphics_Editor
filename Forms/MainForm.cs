using System;

using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    public partial class MainForm : Form
    {
        private bool update = true;
        public Bitmap BitmapToDraw
        {
            get { return this.pictureBox1.Image as Bitmap; }
            set 
            {
                value.RotateFlip(GetRotationType());
                this.pictureBox1.Image = value; 
            }
        }
        ToolStripMenuItem[] itemsToCheck;

        private Point oldPosition;

        public MainForm(ToolForm[] childForms)
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
            Point point = this.Location;
            point.X += this.Width;
            EventHandler updateEvents = new EventHandler(UpdateScreen);

            for (int i = 0; i < childForms.Length; i++)
            {
                childForms[i].Location = point;
                this.AddOwnedForm(childForms[i]);
                childForms[i].SetUpdateEvents(updateEvents);
                point.Y += 100;
                childForms[i].SnapDirection = DockStyle.Left;
            }
            ToolStripMenuItem[] tools = new ToolStripMenuItem[childForms.Length];
            for (int i = 0; i < tools.Length; i++)
            {
                tools[i] = new ToolStripMenuItem();
                tools[i].Name = childForms[i].ToolStripName;
                tools[i].Text = childForms[i].ToolStripName;
                tools[i].ShortcutKeys = childForms[i].ToolStripShortCutKey | Keys.Control;
                tools[i].Size = new Size(194, 22);
                tools[i].CheckOnClick = true;
                tools[i].CheckedChanged += changeToolWindowSettings;

            }
            windowsToolStripMenuItem.DropDownItems.AddRange(tools);
            itemsToCheck = new ToolStripMenuItem[4];
            itemsToCheck[0] = toolStripMenuItem2;
            itemsToCheck[1] = toolStripMenuItem3;
            itemsToCheck[2] = toolStripMenuItem4;
            itemsToCheck[3] = toolStripMenuItem5;
            toolStripMenuItem2.CheckedChanged += updateEvents;
            toolStripMenuItem3.CheckedChanged += updateEvents;
            toolStripMenuItem4.CheckedChanged += updateEvents;
            toolStripMenuItem5.CheckedChanged += updateEvents;
            verticallyToolStripMenuItem.CheckedChanged += updateEvents;
            horizontallyToolStripMenuItem.CheckedChanged += updateEvents;
        }

        public override void Refresh()
        {
            if (update)
            {
                update = false;
                Program.Update();
                foreach (Form item in OwnedForms)
                {
                    item.Refresh();
                }
                base.Refresh();
                Program.UpdateGraphics();
                update = true;
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            this.Refresh();
        }

        protected override void OnMove(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                for (int i = 0; i < OwnedForms.Length; i++)
                {
                    ToolForm toolForm = OwnedForms[i] as ToolForm;
                    if (toolForm.IsSnapped && toolForm.WindowState == FormWindowState.Normal)
                    {
                        Point location = toolForm.Location;
                        location = new Point(location.X + this.Location.X - oldPosition.X,
                            location.Y + this.Location.Y - oldPosition.Y);
                        toolForm.Location = location;
                    }
                }
                oldPosition = this.Location;
            }
            base.OnMove(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !Program.Exit();
            Program.SaveNLZFile();
            base.OnClosing(e);
        }

        public void ChangeToolStripCheckedState(int index, bool value)
        {
            ((ToolStripMenuItem)windowsToolStripMenuItem.DropDownItems[index]).Checked = value;
        }
        
        #region Tool strip

        private void loadROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open the ROM to edit.";
            open.Filter = "GBA ROMs|*.gba|Binary files|*.bin|All files|*";
            open.Multiselect = false;
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            open.ShowDialog();
            if (open.FileNames.Length > 0)
            {
                Program.LoadROM(open.FileName);
                windowsToolStripMenuItem.Enabled = true;
                rotateflipImageToolStripMenuItem.Enabled = true;
                loadAPaletteFileToolStripMenuItem.Enabled = true;
                loadNonDefaulsNlzToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                saveChangesToROMToolStripMenuItem.Enabled = true;
                reScanToolStripMenuItem.Enabled = true;
                deepScanToolStripMenuItem.Enabled = true;
                UpdateScreen(sender, e);
            }
        }

        private void loadNonDefaulsNlzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Choose NLZ file to load.";
            open.Filter = "NLZ Files|*.nlz|All files|*";
            open.Multiselect = false;
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            open.ShowDialog();
            if (open.FileNames.Length > 0)
            {
                Program.LoadNLZFile(open.FileName);
                UpdateScreen(sender, e);
            }
        }

        private void loadAPaletteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select PAL file to load.";
            open.Filter = "Palette file|*.pal|All files|*";
            open.Multiselect = false;
            open.CheckFileExists = true;
            open.CheckPathExists = true;
            open.ShowDialog();
            if (open.FileNames.Length > 0)
            {
                Program.LoadPalFile(open.FileName);
                UpdateScreen(sender, e);
            }
        }

        private void reScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Scan(0x20);
            UpdateScreen(sender, e);
        }

        private void deepScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Scan(1);
            UpdateScreen(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void saveChangesToROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WriteToROM();
            MessageBox.Show("Finished");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Choose where to save the file.";
            save.Filter = "GBA ROMs|*.gba|All files|*";
            save.OverwritePrompt = true;
            save.ShowDialog();
            if (save.FileNames.Length > 0)
            {
                Program.WriteToROM(save.FileName);
                MessageBox.Show("Finished");
            }
        }

        private void changeToolWindowSettings(object sender, EventArgs e)
        {
            for (int i = 0; i < OwnedForms.Length && i < windowsToolStripMenuItem.DropDownItems.Count; i++)
            {
                this.OwnedForms[i].Visible = ((ToolStripMenuItem)windowsToolStripMenuItem.DropDownItems[i]).Checked;
            }
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            int y = me.Y >> 3;
            int x = me.X >> 3;
            Program.ChangeTSAIndex(x, y);
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null && item.Checked)
                for (int i = 0; i < itemsToCheck.Length; i++)
                    if (itemsToCheck[i] != sender)
                        itemsToCheck[i].Checked = false;
        }

        private RotateFlipType GetRotationType()
        {
            RotateFlipType result = RotateFlipType.RotateNoneFlipNone;
            if (horizontallyToolStripMenuItem.Checked && verticallyToolStripMenuItem.Checked)
            {
                if (toolStripMenuItem2.Checked)
                    result = RotateFlipType.RotateNoneFlipXY;
                else if (toolStripMenuItem3.Checked)
                    result = RotateFlipType.Rotate90FlipXY;
                else if (toolStripMenuItem4.Checked)
                    result = RotateFlipType.Rotate180FlipXY;
                else if (toolStripMenuItem5.Checked)
                    result = RotateFlipType.Rotate270FlipXY;
            }
            else if (horizontallyToolStripMenuItem.Checked)
            {
                if (toolStripMenuItem2.Checked)
                    result = RotateFlipType.RotateNoneFlipX;
                else if (toolStripMenuItem3.Checked)
                    result = RotateFlipType.Rotate90FlipX;
                else if (toolStripMenuItem4.Checked)
                    result = RotateFlipType.Rotate180FlipX;
                else if (toolStripMenuItem5.Checked)
                    result = RotateFlipType.Rotate270FlipX;
            }
            else if (verticallyToolStripMenuItem.Checked)
            {
                if (toolStripMenuItem2.Checked)
                    result = RotateFlipType.RotateNoneFlipY;
                else if (toolStripMenuItem3.Checked)
                    result = RotateFlipType.Rotate90FlipY;
                else if (toolStripMenuItem4.Checked)
                    result = RotateFlipType.Rotate180FlipY;
                else if (toolStripMenuItem5.Checked)
                    result = RotateFlipType.Rotate270FlipY;
            }
            else
            {
                if (toolStripMenuItem2.Checked)
                    result = RotateFlipType.RotateNoneFlipNone;
                else if (toolStripMenuItem3.Checked)
                    result = RotateFlipType.Rotate90FlipNone;
                else if (toolStripMenuItem4.Checked)
                    result = RotateFlipType.Rotate180FlipNone;
                else if (toolStripMenuItem5.Checked)
                    result = RotateFlipType.Rotate270FlipNone;
            }
            return result;
        }
    }
}
