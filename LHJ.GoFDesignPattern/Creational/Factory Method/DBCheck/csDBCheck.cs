using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck
{
    public class csDBCheck
    {
        public csDBCheck()
        {
            bool ErrFlag = true;
            csTable TableObj = null;

            if (ErrFlag)
            {
                if (ErrFlag) TableObj = new Table.COE_PTNT_ORD(ref ErrFlag);
                if (ErrFlag) TableObj = new Table.COE_EXEC_ORD(ref ErrFlag);
            }
        }
    }
}
