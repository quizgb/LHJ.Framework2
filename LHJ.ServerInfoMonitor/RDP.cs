using AxMSTSCLib;
using MSTSCLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.ServerInfoMonitor
{
    internal class RDP : AxMsTscAxNotSafeForScripting
    {
        private static int _CreateID = 0;

        private static int CreateID
        {
            get
            {
                return LHJ.ServerInfoMonitor.RDP._CreateID;
            }
        }

        public override string Server
        {
            get
            {
                return base.Server;
            }
            set
            {
                string[] strArray1 = value.Split(":".ToCharArray());
                string[] strArray2 = strArray1[0].Split("\\".ToCharArray());
                if (strArray2.Length > 1)
                {
                    this.Domain = strArray2[0];
                    base.Server = strArray2[1];
                }
                else
                {
                    this.Domain = "";
                    base.Server = strArray1[0];
                }
                IMsRdpClientAdvancedSettings6 advancedSettings = (IMsRdpClientAdvancedSettings6)this.AdvancedSettings;
                advancedSettings.EnableCredSspSupport = true;
                if (strArray1.Length > 1)
                    advancedSettings.RDPPort = int.Parse(strArray1[1]);
                else
                    advancedSettings.RDPPort = 3389;
            }
        }

        public string ClearTextPassword
        {
            set
            {
                ((IMsTscNonScriptable)this.GetOcx()).ClearTextPassword = value;
            }
        }

        public bool RedirectDrives
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings2)this.AdvancedSettings).RedirectDrives;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings2)this.AdvancedSettings).RedirectDrives = value;
            }
        }

        public bool RedirectClipboard
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings5)this.AdvancedSettings).RedirectClipboard;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings5)this.AdvancedSettings).RedirectClipboard = value;
            }
        }

        public bool RedirectPrinters
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings)this.AdvancedSettings).RedirectPrinters;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings)this.AdvancedSettings).RedirectPrinters = value;
            }
        }

        public bool RedirectPOSDevices
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings5)this.AdvancedSettings).RedirectPOSDevices;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings5)this.AdvancedSettings).RedirectPOSDevices = value;
            }
        }

        public bool FullScreen
        {
            get
            {
                return this.SecuredSettings.FullScreen == 1;
            }
            set
            {
                if (value)
                {
                    this.DesktopWidth = Screen.FromControl((Control)this).Bounds.Width;
                    this.DesktopHeight = Screen.FromControl((Control)this).Bounds.Height;
                    this.SecuredSettings.FullScreen = 1;
                }
                else
                    this.SecuredSettings.FullScreen = 0;
            }
        }

        public bool SmartSizing
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings)this.AdvancedSettings).SmartSizing;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings)this.AdvancedSettings).SmartSizing = value;
            }
        }

        public bool ContainerHandledFullScreen
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings)this.AdvancedSettings).ContainerHandledFullScreen == 1;
            }
            set
            {
                IMsRdpClientAdvancedSettings advancedSettings = (IMsRdpClientAdvancedSettings)this.AdvancedSettings;

                if (value)
                {
                    advancedSettings.ContainerHandledFullScreen = 1;
                }
                else
                {
                    advancedSettings.ContainerHandledFullScreen = 0;
                }
            }
        }

        public override int DesktopWidth
        {
            get
            {
                return base.DesktopWidth;
            }
            set
            {
                try
                {
                    base.DesktopWidth = value;
                }
                catch (Exception ex)
                {
                }
            }
        }

        public override int DesktopHeight
        {
            get
            {
                return base.DesktopHeight;
            }
            set
            {
                try
                {
                    base.DesktopHeight = value;
                }
                catch (Exception ex)
                {
                }
            }
        }

        public override string ConnectingText
        {
            get
            {
                return base.ConnectingText;
            }
            set
            {
                base.ConnectingText = value;
            }
        }

        public override string DisconnectedText
        {
            get
            {
                return base.DisconnectedText;
            }
            set
            {
                base.DisconnectedText = value;
            }
        }

        public bool DisplayConnectionBar
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings)this.AdvancedSettings).DisplayConnectionBar;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings8)this.AdvancedSettings).DisplayConnectionBar = value;
            }
        }

        public bool ConnectionBarShowPinButton
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings5)this.AdvancedSettings).ConnectionBarShowPinButton;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings5)this.AdvancedSettings).ConnectionBarShowPinButton = value;
            }
        }

        public bool ConnectionBarShowMinimizeButton
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings3)this.AdvancedSettings).ConnectionBarShowMinimizeButton;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings3)this.AdvancedSettings).ConnectionBarShowMinimizeButton = value;
            }
        }

        public bool ConnectionBarShowRestoreButton
        {
            get
            {
                return ((IMsRdpClientAdvancedSettings3)this.AdvancedSettings).ConnectionBarShowRestoreButton;
            }
            set
            {
                ((IMsRdpClientAdvancedSettings3)this.AdvancedSettings).ConnectionBarShowRestoreButton = value;
            }
        }

        public int ColorDepth
        {
            get
            {
                return ((IMsRdpClient)this.GetOcx()).ColorDepth;
            }
            set
            {
                IMsRdpClient ocx = (IMsRdpClient)this.GetOcx();
                ocx.ColorDepth = value;
            }
        }

        public bool UseMultimon
        {
            get
            {
                return ((IMsRdpClientNonScriptable5)this.GetOcx()).UseMultimon;
            }
            set
            {
                ((IMsRdpClientNonScriptable5)this.GetOcx()).UseMultimon = value;
            }
        }

        public RDP()
        {
            this.Dock = DockStyle.Fill;
            this.Enabled = true;
            this.Name = string.Format("axMsTscAxNotSafeForScripting{0}", (object)LHJ.ServerInfoMonitor.RDP.CreateID);
        }

        public void ResetPassword()
        {
            ((IMsTscNonScriptable)this.GetOcx()).ResetPassword();
        }

        public override void Connect()
        {
            if ((int)this.Connected != 0)
            {
                return;
            }

            base.Connect();
        }

        public override void Disconnect()
        {
            if ((int)this.Connected != 1)
            {
                return;
            }

            base.Disconnect();
        }
    }
}
