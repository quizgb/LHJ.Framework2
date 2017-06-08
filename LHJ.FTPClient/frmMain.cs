using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.FTPClient
{
    public partial class frmMain : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmMain()
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
            this.SetLastBuildDate();
            this.Icon = Properties.Resources._1496929034_Location_FTP;
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void SetLastBuildDate()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

            this.tsslLastBulidDate.Text = " [Last Build : " + buildDate.ToString("yyyy-MM-dd") + "]";
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
