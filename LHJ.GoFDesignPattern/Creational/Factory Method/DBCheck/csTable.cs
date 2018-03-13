using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck
{
    public abstract class csTable : System.IDisposable
    {
        protected string m_TableName = string.Empty;
        protected string m_TableSpaceName = string.Empty;

        public csTable(string TableName, string TableSpaceHeader)
        {
            this.m_TableName = TableName;
            this.m_TableSpaceName = TableSpaceHeader;
        }

        ~csTable()
        {
            Dispose();
        }

        public void Dispose()
        {
            this.m_TableName = string.Empty;
            this.m_TableSpaceName = string.Empty;
        }

        protected void StepRun(ref bool ErrFlag)
        {
            if (ErrFlag) ErrFlag = CreateTable();
            if (ErrFlag) ErrFlag = AddColumn();
            if (ErrFlag) ErrFlag = AddComment();
            if (ErrFlag) ErrFlag = AddIndex();
            if (ErrFlag) InitDataWork(); 
        }

        protected abstract bool CreateTable();

        protected abstract bool AddColumn();

        protected abstract bool AddComment();

        protected abstract bool AddIndex();

        protected abstract void InitDataWork();

    }
}
