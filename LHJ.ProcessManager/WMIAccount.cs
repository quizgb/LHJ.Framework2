using System.Management;

namespace LHJ.ProcessManager
{
    public class WMIAccount
    {
        private string _HostIP;
        private string _Account;
        private string _Password;

        public WMIAccount()
        {
            this._HostIP = "localhost";
            this._Account = string.Empty;
            this._Password = string.Empty;
        }

        public WMIAccount(string pHostIP, string pAccount, string pPassword)
        {
            this._HostIP = pHostIP;
            this._Account = pAccount;
            this._Password = pPassword;
        }

        public ManagementScope ManagementScope()
        {
            return new ManagementScope(new ManagementPath(string.Format("\\\\{0}\\root\\cimv2", this._HostIP)), new ConnectionOptions()
            {
                Username = this._Account,
                Password = this._Password
            });
        }
    }

}
