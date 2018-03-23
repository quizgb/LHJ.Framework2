using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck
{
    public class CreateTable
    {
        private Factory _DBFactory = new TableFactory();
        private List<string> _TableNameLIst = new List<string>();

        private void CreateDataBaseLayout()
        {
            bool flag = true;

            foreach (string tblName in this._TableNameLIst)
            {
                if (flag)
                {
                    flag = _DBFactory.CreateTable(tblName).StepRun();
                }
                else
                {
                    break;
                }
            }

            if (flag)
            {
                System.Windows.Forms.MessageBox.Show("작업 성공");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("작업 실패");
            }
        }

        private void SetInitialize()
        {
            this._TableNameLIst.Add("COE_PTNT_ORD");
            this._TableNameLIst.Add("COE_EXEC_ORD");
        }

        public CreateTable()
        {
            this.SetInitialize();

            this.CreateDataBaseLayout();
        }
    }
}
