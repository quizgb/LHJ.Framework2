using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck
{
    public abstract class TableBase : System.IDisposable
    {
        protected string m_TableName = string.Empty;
        protected string m_TableSpaceName = string.Empty;

        public TableBase(string TableName, string TableSpaceHeader)
        {
            this.m_TableName = TableName;
            this.m_TableSpaceName = TableSpaceHeader;
        }

        ~TableBase()
        {
            Dispose();
        }

        public void Dispose()
        {
            this.m_TableName = string.Empty;
            this.m_TableSpaceName = string.Empty;
        }

        public bool StepRun()
        {
            bool flag = true;

            if (flag)
            {
                flag &= CreateTable();
            }

            if (flag)
            {
                flag &= AddColumn();
            }

            if (flag)
            {
                flag &= AddComment();
            }

            if (flag)
            {
                flag &= AddIndex();
            }

            if (flag)
            {
                flag &= InitDataWork();
            }

            return flag;
        }

        protected abstract bool CreateTable();

        protected abstract bool AddColumn();

        protected abstract bool AddComment();

        protected abstract bool AddIndex();

        protected abstract bool InitDataWork();

    }
}
