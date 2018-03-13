using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Singleton
{
    public class UserInfo
    {
        public UserInfo()
        {

        }

        public void GetUserInfo()
        {
            System.Windows.Forms.MessageBox.Show("Get UserInfo");
        }
    }
}
