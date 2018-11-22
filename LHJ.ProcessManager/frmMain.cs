using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace LHJ.ProcessManager
{
    public partial class frmMain : Form
    {
        #region 1.Variable
        private WMIAccount _Wmi;
        private System.Timers.Timer _TmrWmi;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmMain()
        {
            InitializeComponent();
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
            this._Wmi = new WMIAccount();

            this.StartWmiTimer();
        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void StartWmiTimer()
        {
            this._TmrWmi = new System.Timers.Timer();
            this._TmrWmi.Elapsed += new System.Timers.ElapsedEventHandler(this.TmrWmi_Elapsed);
            this._TmrWmi.Interval = 1000;

            this._TmrWmi.Start();
        }

        private void GetWmiInfo()
        {
            Dictionary<string, object> dicWmiInfo = new Dictionary<string, object>();

            try
            {
                foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher(this._Wmi.ManagementScope(), new ObjectQuery(ConstStr.WMI_QUERY.OperatingSystem)).Get())
                {
                    foreach (PropertyData prop in managementBaseObject.Properties)
                    {
                        dicWmiInfo.Add(prop.Name, prop.Value);
                    }
                }
            }
            catch(Exception e)
            {
                    
            }

            label1.Text = dicWmiInfo["CAPTION"].ToString();
        }
        #endregion 6.Method


        #region 7.Event
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.SetInitialize();
        }

        private void TmrWmi_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.GetWmiInfo();
        }
        #endregion 7.Event
    }
}
