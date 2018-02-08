namespace LHJ.SetPrjLocalCopyFalse
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFolderOpen = new System.Windows.Forms.Button();
            this.fbdFolderOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.dgvCsProjPath = new System.Windows.Forms.DataGridView();
            this.pnlTop2 = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbxFailed = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxSuccess = new System.Windows.Forms.TextBox();
            this.pbgWork = new Jcobs.Controls.ProgressBars.ProgressBar();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnWorkPause = new System.Windows.Forms.Button();
            this.btnWork = new System.Windows.Forms.Button();
            this.bgwWork = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDllName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsProjPath)).BeginInit();
            this.pnlTop2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFolderOpen
            // 
            this.btnFolderOpen.Location = new System.Drawing.Point(844, 3);
            this.btnFolderOpen.Name = "btnFolderOpen";
            this.btnFolderOpen.Size = new System.Drawing.Size(75, 23);
            this.btnFolderOpen.TabIndex = 0;
            this.btnFolderOpen.Text = "폴더선택";
            this.btnFolderOpen.UseVisualStyleBackColor = true;
            this.btnFolderOpen.Click += new System.EventHandler(this.btnFolderOpen_Click);
            // 
            // dgvCsProjPath
            // 
            this.dgvCsProjPath.AllowUserToAddRows = false;
            this.dgvCsProjPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsProjPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCsProjPath.Location = new System.Drawing.Point(0, 0);
            this.dgvCsProjPath.MultiSelect = false;
            this.dgvCsProjPath.Name = "dgvCsProjPath";
            this.dgvCsProjPath.ReadOnly = true;
            this.dgvCsProjPath.RowTemplate.Height = 23;
            this.dgvCsProjPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCsProjPath.ShowEditingIcon = false;
            this.dgvCsProjPath.Size = new System.Drawing.Size(1084, 257);
            this.dgvCsProjPath.TabIndex = 2;
            this.dgvCsProjPath.DataSourceChanged += new System.EventHandler(this.dgvCsProjPath_DataSourceChanged);
            // 
            // pnlTop2
            // 
            this.pnlTop2.Controls.Add(this.dgvCsProjPath);
            this.pnlTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop2.Location = new System.Drawing.Point(0, 49);
            this.pnlTop2.Name = "pnlTop2";
            this.pnlTop2.Size = new System.Drawing.Size(1084, 257);
            this.pnlTop2.TabIndex = 4;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.pbgWork);
            this.pnlMain.Controls.Add(this.pnlTop2);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1084, 513);
            this.pnlMain.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1084, 184);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbxFailed);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1078, 74);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "에러목록";
            // 
            // tbxFailed
            // 
            this.tbxFailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxFailed.Location = new System.Drawing.Point(3, 17);
            this.tbxFailed.Multiline = true;
            this.tbxFailed.Name = "tbxFailed";
            this.tbxFailed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxFailed.Size = new System.Drawing.Size(1072, 54);
            this.tbxFailed.TabIndex = 7;
            this.tbxFailed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSuccess_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxSuccess);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1078, 90);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "변경목록";
            // 
            // tbxSuccess
            // 
            this.tbxSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxSuccess.Location = new System.Drawing.Point(3, 17);
            this.tbxSuccess.Multiline = true;
            this.tbxSuccess.Name = "tbxSuccess";
            this.tbxSuccess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxSuccess.Size = new System.Drawing.Size(1072, 70);
            this.tbxSuccess.TabIndex = 6;
            this.tbxSuccess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSuccess_KeyDown);
            // 
            // pbgWork
            // 
            this.pbgWork.BackColor = System.Drawing.Color.Transparent;
            this.pbgWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbgWork.EndColor = System.Drawing.Color.OrangeRed;
            this.pbgWork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pbgWork.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(63)))), ((int)(((byte)(102)))));
            this.pbgWork.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pbgWork.Location = new System.Drawing.Point(0, 306);
            this.pbgWork.Maximum = 100;
            this.pbgWork.Name = "pbgWork";
            this.pbgWork.ShowPercent = true;
            this.pbgWork.Size = new System.Drawing.Size(1084, 23);
            this.pbgWork.StartColor = System.Drawing.Color.LimeGreen;
            this.pbgWork.StartPosition = Jcobs.Controls.ProgressBars.ProgressBar.StartPositionType.Left;
            this.pbgWork.TabIndex = 5;
            this.pbgWork.TabStop = false;
            this.pbgWork.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.pbgWork.Value = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtDllName);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnClear);
            this.pnlTop.Controls.Add(this.btnWorkPause);
            this.pnlTop.Controls.Add(this.btnWork);
            this.pnlTop.Controls.Add(this.btnFolderOpen);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1084, 49);
            this.pnlTop.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnWorkPause
            // 
            this.btnWorkPause.Enabled = false;
            this.btnWorkPause.Location = new System.Drawing.Point(1006, 3);
            this.btnWorkPause.Name = "btnWorkPause";
            this.btnWorkPause.Size = new System.Drawing.Size(75, 23);
            this.btnWorkPause.TabIndex = 2;
            this.btnWorkPause.Text = "작업중지";
            this.btnWorkPause.UseVisualStyleBackColor = true;
            this.btnWorkPause.Click += new System.EventHandler(this.btnWorkPause_Click);
            // 
            // btnWork
            // 
            this.btnWork.Enabled = false;
            this.btnWork.Location = new System.Drawing.Point(925, 3);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(75, 23);
            this.btnWork.TabIndex = 1;
            this.btnWork.Text = "작업시작";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // bgwWork
            // 
            this.bgwWork.WorkerReportsProgress = true;
            this.bgwWork.WorkerSupportsCancellation = true;
            this.bgwWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWork_DoWork);
            this.bgwWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwWork_ProgressChanged);
            this.bgwWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWork_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "검색할 DLL";
            // 
            // txtDllName
            // 
            this.txtDllName.Location = new System.Drawing.Point(84, 24);
            this.txtDllName.Name = "txtDllName";
            this.txtDllName.Size = new System.Drawing.Size(253, 21);
            this.txtDllName.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 513);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "프로젝트 로컬복사 변경(True -> False)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsProjPath)).EndInit();
            this.pnlTop2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFolderOpen;
        private System.Windows.Forms.FolderBrowserDialog fbdFolderOpen;
        private System.Windows.Forms.DataGridView dgvCsProjPath;
        private System.Windows.Forms.Panel pnlTop2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnWork;
        private Jcobs.Controls.ProgressBars.ProgressBar pbgWork;
        private System.ComponentModel.BackgroundWorker bgwWork;
        private System.Windows.Forms.Button btnWorkPause;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbxFailed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxSuccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDllName;
    }
}

