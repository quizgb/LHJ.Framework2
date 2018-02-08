using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Build.Construction;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace LHJ.SetPrjLocalCopyFalse
{
    public partial class frmMain : Form
    {
        private DataTable _CsProjTable = null;
        private delegate void ProgressCountUpDelegate(int pCount);
        private delegate void SetTextDelegate(string pText, TextBox pTbx);

        public frmMain()
        {
            InitializeComponent();

            this.SetInitialize();
        }

        private void ClearCsProjTable()
        {
            this._CsProjTable = new DataTable();
            this._CsProjTable.Columns.Add("PATH");
        }

        private void SetInitialize()
        {
            this.Clear();
        }

        private void SetPrivateFalse(string pCsProjPath)
        {
            try
            {
                bool successState = false;

                if (File.Exists(pCsProjPath))
                {
                    var project = ProjectRootElement.Open(pCsProjPath);
                    var referenceElements = project.Items.
                        Where(x => x.ItemType.ToUpper().Contains("REFERENCE"));

                    foreach (var projectItemElement in referenceElements)
                    {
                        if (projectItemElement.Include.ToUpper().Contains(this.txtDllName.Text))
                        {
                            var copyLocalElement = projectItemElement.Metadata.FirstOrDefault(x => x.Name.ToUpper().Equals("PRIVATE"));

                             if (copyLocalElement != null)
                            {
                                if (copyLocalElement.Value.ToUpper().Equals("TRUE"))
                                {
                                    if (!successState)
                                    {
                                        this.SetText(string.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), pCsProjPath), this.tbxSuccess);
                                        successState = true;
                                    }

                                    copyLocalElement.Value = "False";
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            else
                            {
                                //projectItemElement.AddMetadata("Private", "false");
                            }
                        }
                    }

                    project.Save();
                }
            }
            catch (Exception e)
            {
                this.SetText(string.Format("[{0}] {1} / 에러 메시지 : {2}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), pCsProjPath, e.Message), this.tbxFailed);
            }
        }

        private void btnFolderOpen_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdFolderOpen.ShowDialog();

            if (dr == DialogResult.OK)
            {
                this.Clear();
                this.FileSearch(fbdFolderOpen.SelectedPath);

                this.btnWork.Enabled = this._CsProjTable.Rows.Count > 0 ? true : false;
            }
        }

        private void Clear()
        {
            this.btnWork.Enabled = false;
            this.btnWorkPause.Enabled = false;  
            this.pbgWork.Value = 0;

            this.dgvCsProjPath.DataSource = null;

            this.ClearCsProjTable();
        }

        private void FileSearch(string pFilePath)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.dgvCsProjPath.SuspendLayout();

                string[] Directories = Directory.GetDirectories(pFilePath);
                string[] Files = Directory.GetFiles(pFilePath);

                foreach (string directory in Directories)
                {
                    this.FileSearch(directory);
                }

                foreach (string Fi in Files)
                {
                    if (Regex.IsMatch(Fi, @"\.(csproj)$"))
                    {
                        DataRow newRow = this._CsProjTable.NewRow();
                        newRow["PATH"] = Fi;

                        this._CsProjTable.Rows.Add(newRow);
                    }
                }

                this.dgvCsProjPath.DataSource = this._CsProjTable;
            }
            catch (Exception e)
            {
                this.Clear();
            }
            finally
            {
                this.dgvCsProjPath.ResumeLayout();
                this.Cursor = Cursors.Default;
            }
        }

        private void dgvCsProjPath_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv != null)
            {
                if (dgv.DataSource != null)
                {
                    dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private bool CheckCsProjWorkBefore()
        {
            if (this._CsProjTable.Rows.Count < 1)
            {
                MessageBox.Show("작업할 내역이 존재하지 않습니다.");
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDllName.Text))
            {
                this.txtDllName.Focus();
                MessageBox.Show("검색할 DLL 이름을 입력하세요.");
                return false;
            }

            return true;
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            if (!this.CheckCsProjWorkBefore())
            {
                return;
            }

            this.btnWork.Enabled = false;
            this.btnWorkPause.Enabled = true;
            this.pbgWork.Maximum = this._CsProjTable.Rows.Count;

            this.Cursor = Cursors.WaitCursor;

            this.bgwWork.RunWorkerAsync();
        }

        private void SetText(string pText, TextBox pTbx)
        {
            try
            {
                if (this.InvokeRequired == false)
                {
                    if (string.IsNullOrEmpty(pTbx.Text))
                    {
                        pTbx.Text = pText;
                    }
                    else
                    {
                        pTbx.Text += Environment.NewLine + pText;
                    }
                }
                else
                {
                    SetTextDelegate std = new SetTextDelegate(this.SetText);
                    this.Invoke(std, pText, pTbx);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void ProgressCountUp(int pCount)
        {
            try
            {
                if (this.InvokeRequired == false)
                {
                    this.pbgWork.Value += pCount;
                }
                else
                {
                    ProgressCountUpDelegate pcd = new ProgressCountUpDelegate(this.ProgressCountUp);
                    this.Invoke(pcd, pCount);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void EndWork(bool pCancelled)
        {
            this.Cursor = Cursors.Default;

            Thread.Sleep(500);

            if (pCancelled)
            {
                MessageBox.Show("작업 중지");
            }
            else
            {
                MessageBox.Show("작업 완료");
            }

            this.Clear();
        }

        private void bgwWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.EndWork(e.Cancelled);
            }
            else if (e.Error != null)
            {
                this.EndWork(true);
                throw e.Error;
            }
            else
            {
                this.EndWork(false);
            }
        }

        private void bgwWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ProgressCountUp(e.ProgressPercentage);
        }

        private void bgwWork_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (DataRow row in this._CsProjTable.Rows)
            {
                if (this.bgwWork.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                this.SetPrivateFalse(row["PATH"].ToString());
                this.bgwWork.ReportProgress(1);
            }
        }

        private void btnWorkPause_Click(object sender, EventArgs e)
        {
            if (this.bgwWork.IsBusy)
            {
                if (DialogResult.Yes.Equals(MessageBox.Show("작업을 중지하시겠습니까?", "알림", MessageBoxButtons.YesNo)))
                {
                    this.bgwWork.CancelAsync();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();

            this.tbxSuccess.Text = string.Empty;
            this.tbxFailed.Text = string.Empty;
        }

        private void tbxSuccess_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (tbx != null)
            {
                if (e.Control && (e.KeyCode == Keys.A))
                {
                    tbx.SelectAll();
                }
            }
        }
    }
}
