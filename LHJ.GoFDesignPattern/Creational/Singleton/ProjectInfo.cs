using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Singleton 
{
    public class ProjectInfo
    {
        public ProjectInfo()
        {

        }

        public void GetProjectInfo()
        {
            System.Windows.Forms.MessageBox.Show("Get ProjectInfo");
        }
    }
}
