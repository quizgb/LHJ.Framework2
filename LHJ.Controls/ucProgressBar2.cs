using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LHJ.Controls
{
    public class ucProgressBar2 : System.Windows.Forms.Control
    {
        private StringFormat sf = new StringFormat();
        private ucProgressBar2.StartPositionType m_StartPosition = ucProgressBar2.StartPositionType.Left;
        private LinearGradientMode m_GradientMode = LinearGradientMode.Horizontal;
        private Color m_FrameColor = Color.FromArgb(24, 63, 102);
        private Color m_StartColor = Color.LimeGreen;
        private Color m_EndColor = Color.OrangeRed;
        private ContentAlignment m_TextAlignment = ContentAlignment.MiddleLeft;
        private int m_Maximum = 100;
        private int m_Value = 30;
        private bool m_ShowPercent = true;
        private IContainer components = (IContainer)null;

        public ucProgressBar2.StartPositionType StartPosition
        {
            get
            {
                return this.m_StartPosition;
            }
            set
            {
                this.m_StartPosition = value;
                this.Invalidate();
            }
        }

        public LinearGradientMode GradientMode
        {
            get
            {
                return this.m_GradientMode;
            }
            set
            {
                this.m_GradientMode = value;
                this.Invalidate();
            }
        }

        public Color FrameColor
        {
            get
            {
                return this.m_FrameColor;
            }
            set
            {
                this.m_FrameColor = value;
                this.Invalidate();
            }
        }

        public Color StartColor
        {
            get
            {
                return this.m_StartColor;
            }
            set
            {
                this.m_StartColor = value;
                this.Invalidate();
            }
        }

        public Color EndColor
        {
            get
            {
                return this.m_EndColor;
            }
            set
            {
                this.m_EndColor = value;
                this.Invalidate();
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                this.Invalidate();
            }
        }

        public ContentAlignment TextAlignment
        {
            get
            {
                return this.m_TextAlignment;
            }
            set
            {
                this.m_TextAlignment = value;
                this.Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return this.m_Maximum;
            }
            set
            {
                this.m_Maximum = value;
                this.Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                this.m_Value = value;
                this.Invalidate();
            }
        }

        public bool ShowPercent
        {
            get
            {
                return this.m_ShowPercent;
            }
            set
            {
                this.m_ShowPercent = value;
                this.Invalidate();
            }
        }

        public ucProgressBar2()
        {
            this.InitializeComponent();
            this.InitializeUi();
            this.ForeColor = Color.FromArgb(50, 50, 50);
        }

        private void InitializeUi()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.FixedHeight | ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
            this.TabStop = false;
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            this.DrawProgressBar(graphics);
            this.DrawPercent(graphics);
            this.DrawText(graphics);
            this.DrawFrame(graphics);
            base.OnPaint(pe);
        }

        private void DrawProgressBar(Graphics g)
        {
            if (this.Value > this.Maximum)
            {
                this.Value = this.Maximum;
            }
            else
            {
                int maximum = this.Maximum;
                if (maximum <= 0)
                    return;
                Rectangle clientRectangle = this.ClientRectangle;
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(clientRectangle, this.StartColor, this.EndColor, this.GradientMode);
                float x = 0.0f;
                float y = 0.0f;
                float width = 0.0f;
                float height = 0.0f;
                switch (this.StartPosition)
                {
                    case ucProgressBar2.StartPositionType.Left:
                        width = (float)(this.Width * this.Value / maximum);
                        height = (float)this.Height;
                        x = 0.0f;
                        y = 0.0f;
                        linearGradientBrush = new LinearGradientBrush(clientRectangle, this.StartColor, this.EndColor, this.GradientMode);
                        break;
                    case ucProgressBar2.StartPositionType.Top:
                        width = (float)this.Width;
                        height = (float)(this.Height * this.Value / maximum);
                        x = 0.0f;
                        y = 0.0f;
                        linearGradientBrush = new LinearGradientBrush(clientRectangle, this.StartColor, this.EndColor, this.GradientMode);
                        break;
                    case ucProgressBar2.StartPositionType.Right:
                        width = (float)(this.Width * this.Value / maximum);
                        height = (float)this.Height;
                        x = (float)this.Width - width;
                        y = 0.0f;
                        linearGradientBrush = new LinearGradientBrush(clientRectangle, this.EndColor, this.StartColor, this.GradientMode);
                        break;
                    case ucProgressBar2.StartPositionType.Bottom:
                        width = (float)this.Width;
                        height = (float)(this.Height * this.Value / maximum);
                        x = 0.0f;
                        y = (float)this.Height - height;
                        linearGradientBrush = new LinearGradientBrush(clientRectangle, this.EndColor, this.StartColor, this.GradientMode);
                        break;
                }
                RectangleF rect = new RectangleF(x, y, width, height);
                g.FillRectangle((Brush)linearGradientBrush, rect);
            }
        }

        private void DrawFrame(Graphics g)
        {
            Rectangle rect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            Pen pen = new Pen(this.FrameColor, 2f);
            g.DrawRectangle(pen, rect);
        }

        private void DrawPercent(Graphics g)
        {
            if (!this.ShowPercent)
                return;
            Font font = new Font(this.Font.FontFamily, (float)(this.Height / 2), FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(70, 70, 70));
            string s = ((float)Math.Min(100, this.Value * 100 / Math.Max(1, this.Maximum))).ToString() + "%";
            g.DrawString(s, font, (Brush)solidBrush, (RectangleF)this.ClientRectangle, this.sf);
        }

        private void DrawText(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(this.ForeColor);
            Rectangle rectangle = new Rectangle(2, 2, this.Width - 4, this.Height - 3);
            StringFormat format = new StringFormat();
            switch (this.TextAlignment)
            {
                case ContentAlignment.BottomCenter:
                    format.LineAlignment = StringAlignment.Far;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomRight:
                    format.LineAlignment = StringAlignment.Far;
                    format.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleRight:
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomLeft:
                    format.LineAlignment = StringAlignment.Far;
                    format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopLeft:
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                    format.LineAlignment = StringAlignment.Near;
                    format.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleLeft:
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleCenter:
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;
            }
            g.DrawString(this.Text, this.Font, (Brush)solidBrush, (RectangleF)rectangle, format);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
        }

        [Flags]
        public enum StartPositionType
        {
            Left = 0,
            Top = 1,
            Right = 2,
            Bottom = Right | Top,
        }
    }
}
