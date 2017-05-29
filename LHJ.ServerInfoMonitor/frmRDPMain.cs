﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace LHJ.ServerInfoMonitor
{
    public partial class frmRDPMain : Form
    {
        #region 1.Variable
        private Point mImageLocation = new Point(15, 5);
        private Point mImgHitArea = new Point(13, 2);
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmRDPMain()
        {
            InitializeComponent();

            this.SetInitialize();
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {
            this.SetInnerDoubleBuffered((Control)this, true);

            // set the Mode of Drawing as Owner Drawn
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.tabControl1.ItemSize = new Size(80, 20);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;

            // Add the Handler to draw the Image on Tab Pages
            this.tabControl1.DrawItem += TabControl1_DrawItem;

            frmServerList serverFrm = new frmServerList();
            serverFrm.TopLevel = false;
            serverFrm.Dock = DockStyle.Fill;
            serverFrm.ServerItemDoubleClicked += new Common.Definition.EventHandler.ServerListDoubleClickEventHandler(this.ServerListDoubleClicked);

            this.splitContainer1.Panel1.Controls.Add(serverFrm);
            serverFrm.Show();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void StartRDP(ServerListParam aParam)
        {
            TabPage newPage = new TabPage();
            LHJ.ServerInfoMonitor.RDP _RDP = new LHJ.ServerInfoMonitor.RDP();

            newPage.Text = aParam.A_서버명칭 + "  ";
            newPage.Controls.Add((Control)_RDP);

            this.tabControl1.TabPages.Add(newPage);
            this.tabControl1.SelectedTab = newPage;

            _RDP.BringToFront();
            _RDP.Server = aParam.B_IP주소;
            _RDP.UserName = aParam.C_사용자이름;
            _RDP.ClearTextPassword = aParam.D_비밀번호;
            _RDP.RedirectDrives = aParam.B_RedirectDrives;
            _RDP.RedirectClipboard = aParam.C_RedirectClipboard;
            _RDP.RedirectPrinters = aParam.D_RedirectPrinters;
            _RDP.SmartSizing = aParam.E_SmartSizing;
            _RDP.FullScreen = aParam.A_FullScreen;
            _RDP.ContainerHandledFullScreen = false;
            _RDP.ConnectionBarShowMinimizeButton = false;

            Point desktopSize = this.GetDesktopSize(_RDP, aParam.F_DesktopSize, aParam.A_FullScreen);
            _RDP.DesktopWidth = desktopSize.X;
            _RDP.DesktopHeight = desktopSize.Y;

            _RDP.ConnectingText = string.Format("연결중...{0}[{1}]", aParam.A_서버명칭, aParam.B_IP주소);
            _RDP.DisconnectedText = string.Format("연결해제...{0}[{1}]", aParam.A_서버명칭, aParam.B_IP주소);

            if (aParam.G_ColorDepth.Contains("8"))
            {
                _RDP.ColorDepth = 8;
            }
            else if (aParam.G_ColorDepth.Contains("16"))
            {
                _RDP.ColorDepth = 16;
            }
            else if (aParam.G_ColorDepth.Contains("24"))
            {
                _RDP.ColorDepth = 24;
            }
            else if (aParam.G_ColorDepth.Contains("32"))
            {
                _RDP.ColorDepth = 32;
            }

            _RDP.Connect();
        }

        private Point GetDesktopSize(LHJ.ServerInfoMonitor.RDP aRDP, string aDesktopSize, bool aIsFullScreen)
        {
            int width;
            int height;

            if (aDesktopSize.Equals(string.Empty))
            {
                if (aIsFullScreen)
                {
                    width = Screen.FromControl((Control)this).Bounds.Width;
                    height = Screen.FromControl((Control)this).Bounds.Height;
                }
                else
                {
                    width = aRDP.Width;
                    height = aRDP.Height;
                }
            }
            else if (aDesktopSize.Contains("X"))
            {
                string[] strArray = aDesktopSize.Split("X".ToCharArray());
                width = int.Parse(strArray[0]);
                height = int.Parse(strArray[1]);
            }
            else
            {
                string str = aDesktopSize;

                if (!(str == "FullScreen"))
                {
                    if (str == "CurrentViewSize")
                    {
                        width = aRDP.Width;
                        height = aRDP.Height;
                    }
                    else
                    {
                        width = aRDP.Width;
                        height = aRDP.Height;
                    }
                }
                else
                {
                    Rectangle bounds = Screen.FromControl((Control)this).Bounds;
                    width = bounds.Width;
                    bounds = Screen.FromControl((Control)this).Bounds;
                    height = bounds.Height;
                }
            }

            return new Point(width, height);
        }

        private void SetInnerDoubleBuffered(Control Control, bool DoubleBuffered)
        {
            foreach (Control control in (ArrangedElementCollection)Control.Controls)
            {
                if (control.Controls.Count > 0)
                    this.SetInnerDoubleBuffered(control, DoubleBuffered);
                this.SetDoubleBuffered(control, DoubleBuffered);
            }
        }

        private void SetDoubleBuffered(Control Control, bool DoubleBuffered)
        {
            Control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object)Control, (object)DoubleBuffered, (object[])null);
        }
        #endregion 6.Method


        #region 7.Event
        private void ServerListDoubleClicked(object sender, Common.Definition.EventHandler.ServerListDoubleClickEventArgs e)
        {
            if (e.ServerListParam is ServerListParam)
            {
                ServerListParam param = e.ServerListParam as ServerListParam;
                this.StartRDP(param);
            }
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                // Close Image to draw
                Image img = new Bitmap(Properties.Resources._1495539349_Close_Icon);
                Rectangle r = e.Bounds;
                r = this.tabControl1.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                string title = this.tabControl1.TabPages[e.Index].Text;
                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
                e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - mImageLocation.X), mImageLocation.Y));
            }
            catch (Exception)
            {
            }
        }

        private void 즐겨찾기ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            if (tsmi != null)
            {
                if (tsmi.Checked)
                {
                    this.splitContainer1.SplitterDistance = 300;
                }
                else
                {
                    this.splitContainer1.SplitterDistance = 0;
                }
            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tabControl1.GetTabRect(tc.SelectedIndex).Width - (mImgHitArea.X);
            Rectangle r = this.tabControl1.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, mImgHitArea.Y);
            r.Width = 16;
            r.Height = 16;

            if (r.Contains(p))
            {
                TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];

                if (TabP.Controls[0] is LHJ.ServerInfoMonitor.RDP)
                {
                    LHJ.ServerInfoMonitor.RDP _RDP = TabP.Controls[0] as LHJ.ServerInfoMonitor.RDP;
                    _RDP.Disconnect();
                }

                tc.TabPages.Remove(TabP);
            }
        }

        private void frmRDPMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.splitContainer1.Panel1.Controls[0] is frmServerList)
            {
                frmServerList serverFrm = this.splitContainer1.Panel1.Controls[0] as frmServerList;
                serverFrm.SaveServerList();
            }
        }

        private void frmRDPMain_Shown(object sender, EventArgs e)
        {
            this.즐겨찾기ToolStripMenuItem.Checked = true;
        }
        #endregion 7.Event  
    }
}
