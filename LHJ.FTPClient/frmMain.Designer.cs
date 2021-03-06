﻿namespace LHJ.FTPClient
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSQLWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSchemaBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSessionView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableSpaceViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.창ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCascadeWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileVerticalWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileHorizontalWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiArrangeIconsWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAllWindowClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbxHost = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbxUserName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tbxPassword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tbxPort = new System.Windows.Forms.ToolStripTextBox();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView1 = new LHJ.FTPClient.DragAndDropListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslLastBulidDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnsMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.sessionToolStripMenuItem,
            this.toolsMenuItem,
            this.창ToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnsMain.Size = new System.Drawing.Size(1264, 24);
            this.mnsMain.TabIndex = 12;
            this.mnsMain.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnect,
            this.tsmiDisconnect,
            this.toolStripSeparator3,
            this.tsmiExit});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(57, 20);
            this.fileMenuItem.Text = "파일(&F)";
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(147, 22);
            this.tsmiConnect.Text = "Connect ...";
            // 
            // tsmiDisconnect
            // 
            this.tsmiDisconnect.Name = "tsmiDisconnect";
            this.tsmiDisconnect.Size = new System.Drawing.Size(147, 22);
            this.tsmiDisconnect.Text = "Disconnect ...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(144, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(147, 22);
            this.tsmiExit.Text = "E&xit";
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSQLWindow,
            this.tsmiSchemaBrowser,
            this.tsmiSessionView,
            this.tsmiTableSpaceViewer});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.sessionToolStripMenuItem.Text = "보기(&V)";
            // 
            // tsmiSQLWindow
            // 
            this.tsmiSQLWindow.Name = "tsmiSQLWindow";
            this.tsmiSQLWindow.Size = new System.Drawing.Size(174, 22);
            this.tsmiSQLWindow.Text = "SQL Window";
            // 
            // tsmiSchemaBrowser
            // 
            this.tsmiSchemaBrowser.Name = "tsmiSchemaBrowser";
            this.tsmiSchemaBrowser.Size = new System.Drawing.Size(174, 22);
            this.tsmiSchemaBrowser.Text = "Schema Browser";
            // 
            // tsmiSessionView
            // 
            this.tsmiSessionView.Name = "tsmiSessionView";
            this.tsmiSessionView.Size = new System.Drawing.Size(174, 22);
            this.tsmiSessionView.Text = "Session View";
            // 
            // tsmiTableSpaceViewer
            // 
            this.tsmiTableSpaceViewer.Name = "tsmiTableSpaceViewer";
            this.tsmiTableSpaceViewer.Size = new System.Drawing.Size(174, 22);
            this.tsmiTableSpaceViewer.Text = "TableSpace Viewer";
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(57, 20);
            this.toolsMenuItem.Text = "도구(&T)";
            // 
            // 창ToolStripMenuItem
            // 
            this.창ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCascadeWindow,
            this.tsmiTileVerticalWindow,
            this.tsmiTileHorizontalWindow,
            this.tsmiArrangeIconsWindow,
            this.tsmiAllWindowClose,
            this.toolStripSeparator2});
            this.창ToolStripMenuItem.Name = "창ToolStripMenuItem";
            this.창ToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.창ToolStripMenuItem.Text = "창(&W)";
            // 
            // tsmiCascadeWindow
            // 
            this.tsmiCascadeWindow.Name = "tsmiCascadeWindow";
            this.tsmiCascadeWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiCascadeWindow.Text = "계단식 배열";
            // 
            // tsmiTileVerticalWindow
            // 
            this.tsmiTileVerticalWindow.Name = "tsmiTileVerticalWindow";
            this.tsmiTileVerticalWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiTileVerticalWindow.Text = "세로 바둑판식 배열";
            // 
            // tsmiTileHorizontalWindow
            // 
            this.tsmiTileHorizontalWindow.Name = "tsmiTileHorizontalWindow";
            this.tsmiTileHorizontalWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiTileHorizontalWindow.Text = "가로 바둑판식 배열";
            // 
            // tsmiArrangeIconsWindow
            // 
            this.tsmiArrangeIconsWindow.Name = "tsmiArrangeIconsWindow";
            this.tsmiArrangeIconsWindow.Size = new System.Drawing.Size(178, 22);
            this.tsmiArrangeIconsWindow.Text = "아이콘 정렬";
            // 
            // tsmiAllWindowClose
            // 
            this.tsmiAllWindowClose.Name = "tsmiAllWindowClose";
            this.tsmiAllWindowClose.Size = new System.Drawing.Size(178, 22);
            this.tsmiAllWindowClose.Text = "모두 닫기";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbxHost,
            this.toolStripLabel2,
            this.tbxUserName,
            this.toolStripLabel3,
            this.tbxPassword,
            this.toolStripLabel4,
            this.tbxPort,
            this.tsbConnect});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1264, 25);
            this.tsMain.TabIndex = 15;
            this.tsMain.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel1.Text = " 호스트 : ";
            // 
            // tbxHost
            // 
            this.tbxHost.Name = "tbxHost";
            this.tbxHost.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel2.Text = " 사용자명 : ";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel3.Text = " 비밀번호 : ";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel4.Text = " 포트 : ";
            // 
            // tbxPort
            // 
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbConnect
            // 
            this.tsbConnect.Image = global::LHJ.FTPClient.Properties.Resources._1496929365_knetworkconf;
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(51, 22);
            this.tsbConnect.Text = "연결";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1264, 72);
            this.textBox1.TabIndex = 16;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 689);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 17;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1264, 613);
            this.splitContainer2.SplitterDistance = 475;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(1264, 475);
            this.splitContainer3.SplitterDistance = 634;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.treeView1);
            this.splitContainer4.Panel1.Controls.Add(this.comboBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.listView1);
            this.splitContainer4.Size = new System.Drawing.Size(634, 475);
            this.splitContainer4.SplitterDistance = 202;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer5.Size = new System.Drawing.Size(626, 475);
            this.splitContainer5.SplitterDistance = 202;
            this.splitContainer5.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(634, 182);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(634, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.AllowDrag = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(634, 269);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLastBulidDate});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 738);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1264, 24);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslLastBulidDate
            // 
            this.tsslLastBulidDate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslLastBulidDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslLastBulidDate.Name = "tsslLastBulidDate";
            this.tsslLastBulidDate.Size = new System.Drawing.Size(92, 19);
            this.tsslLastBulidDate.Text = "(LastBulidDate)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnsMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LHJ.FTP_Client";
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSQLWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiSchemaBrowser;
        private System.Windows.Forms.ToolStripMenuItem tsmiSessionView;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableSpaceViewer;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 창ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCascadeWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileVerticalWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileHorizontalWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiArrangeIconsWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllWindowClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbxHost;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbxUserName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tbxPassword;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tbxPort;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslLastBulidDate;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DragAndDropListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

