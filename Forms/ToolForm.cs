using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nintenlord.GBA_Graphics_Editor.Forms
{
    /// <summary>
    /// Can't be abstract due to Form designer.
    /// </summary>
    public partial class ToolForm : Form
    {
        public const int DefaultSnapProximity = 20;
        public const int DefaultSnapDistance = 5;
        private DockStyle snapDirection;

        protected string toolStripName;
        protected Keys toolStripShortCutKey;
        protected int toolStripIndex = -1;

        public string ToolStripName
        {
            get { return toolStripName; }
        }
        public Keys ToolStripShortCutKey
        {
            get { return toolStripShortCutKey; }
        }

        public DockStyle SnapDirection
        {
            get { return snapDirection; }
            set { snapDirection = value; }
        }
        public bool IsSnapped
        {
            get { return snapDirection != DockStyle.None; }
        }

        public ToolForm()
        {
            InitializeComponent();
        }

        public virtual void SetUpdateEvents(EventHandler updateEvents)
        {
            throw new InvalidOperationException("");
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            MainForm form = Owner as MainForm;
            if (form != null)
            {
                if (toolStripIndex < 0)
                {
                    toolStripIndex = 0;
                    while (toolStripIndex < form.OwnedForms.Length
                        && form.OwnedForms[toolStripIndex] != this)
                    {
                        toolStripIndex++;
                    }
                }

                if (toolStripIndex < form.OwnedForms.Length)
                    form.ChangeToolStripCheckedState(toolStripIndex, Visible);

            }
        }

        protected override void OnMove(EventArgs e)
        {            
            if (this.Owner != null && this.WindowState == FormWindowState.Normal && this.Owner.WindowState == FormWindowState.Normal)
            {
                snapDirection = isWithinSnapDistance(this.Owner);
                Point location = this.Location;
                switch (snapDirection)
                {
                    case DockStyle.Right:
                        location.X = this.Owner.Location.X + this.Owner.Size.Width + DefaultSnapDistance;
                        break;
                    case DockStyle.Left:
                        location.X = this.Owner.Location.X - this.Width - DefaultSnapDistance;
                        break;
                    case DockStyle.Bottom:
                        location.Y = this.Owner.Location.Y + this.Owner.Size.Height + DefaultSnapDistance;
                        break;
                    case DockStyle.Top:
                        location.Y = this.Owner.Location.Y - this.Height - DefaultSnapDistance;
                        break;
                    default:
                        break;
                }
                this.Location = location;  
            }
            base.OnMove(e);
        }

        private DockStyle isWithinSnapDistance(Form form)
        {
            int dx = form.Location.X - this.Location.X;
            int dy = form.Location.Y - this.Location.Y;

            if (dx - this.Width < DefaultSnapProximity && 
                dx - this.Width > -DefaultSnapProximity &&
                dy < this.Height &&
                dy > -form.Height) 
            {
                return DockStyle.Left;
            } 
            if (dx + form.Width < DefaultSnapProximity &&
                dx + form.Width > -DefaultSnapProximity &&
                dy < this.Height &&
                dy > -form.Height)
            {
                return DockStyle.Right; 
            }
            if (dy - this.Height < DefaultSnapProximity &&
                dy - this.Height > -DefaultSnapProximity &&
                dx < this.Width &&
                dx > -form.Width)
            {
                return DockStyle.Top; 
            } 
            if (dy + form.Height < DefaultSnapProximity &&
                dy + form.Height > -DefaultSnapProximity &&
                dx < this.Width &&
                dx > -form.Width)
            {
                return DockStyle.Bottom; 
            }
            return DockStyle.None;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    this.Visible = false;
                    break;
                default:
                    base.OnFormClosing(e);
                    break;
            }
        }

    }
}
