using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck
{
    public abstract class Factory
    {
        public abstract TableBase CreateTable(string aTableName);
    }

    public class TableFactory : Factory
    {
        public override TableBase CreateTable(string aTableName)
        {
            switch (aTableName)
            {
                case "COE_PTNT_ORD":
                    return new TableList.COE_PTNT_ORD();
                    break;

                case "COE_EXEC_ORD":
                    return new TableList.COE_EXEC_ORD();
                    break;

                default:
                    return null;
                    break;
            }
        }
    }
}
