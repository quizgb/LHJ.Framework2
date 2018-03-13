using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.DBCheck.Table
{
    sealed class COE_PTNT_ORD : csTable
    {
        public COE_PTNT_ORD(ref bool ErrFlag)
            : base("COE_PTNT_ORD", "OCS")
        {
            base.StepRun(ref ErrFlag);
        }

        protected override bool CreateTable()
        {
            bool ErrFlag = true;

            return ErrFlag;

            //            string StrSQL =
            //                " CREATE TABLE " + m_TableName + "           ";

            //            StrSQL += @"
            //(
            //   KTASCD               VARCHAR2(5)          not null,
            //   KTASCD1              VARCHAR2(1),
            //   KTASCD2              VARCHAR2(1),
            //   KTASCD3              VARCHAR2(1),
            //   KTASCD4              VARCHAR2(2),
            //   KTASLVLCD            VARCHAR2(1),
            //   KTASNAME             VARCHAR2(500)        not null,
            //   LVL                  NUMBER(4)            not null,
            //   RGB                  VARCHAR2(7),
            //   KTASCMT_AGENT        VARCHAR2(500),
            //   LINKURL              VARCHAR2(1000),
            //   LINKTXT              VARCHAR2(50),
            //   VER                  NUMBER(5,2),
            //   VERDT                VARCHAR2(8),
            //   constraint PK_COD_KTASCD primary key (KTASCD)
            //)   ";

            //            return m_DBFunc.CreateTable(StrSQL, m_TableName, m_TableSpaceName);
        }

        protected override bool AddColumn()
        {
            bool ErrFlag = true;

            return ErrFlag;
        }

        protected override bool AddComment()
        {
            bool ErrFlag = true;

            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Table(m_TableName, "KTAS (한국형중증질환분류코드)");

            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASCD", "KTAS코드 - 5자리");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASCD1", "KTAS1단계-환자나이분류 - 15세 미만/이상 (조회용)");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASCD2", "KTAS2단계 (조회용)");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASCD3", "KTAS3단계 (조회용)");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASCD4", "KTAS4단계 (조회용)");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASLVLCD", "KTAS레벨");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASNAME", "KTAS코드명");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "LVL", "KTAS 레벨");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "RGB", "KTAS색깔");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "KTASCMT_AGENT", "AGENT용 설명문구");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "LINKURL", "KTAS연계링크");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "LINKTXT", "KTAS링크명");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "VER", "KTAS코드 버젼");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddComment_Column(m_TableName, "VERDT", "버젼적용일  ex)YYYYMMDD");

            return ErrFlag;
        }

        protected override bool AddIndex()
        {
            bool ErrFlag = true;

            //if (ErrFlag) ErrFlag = m_DBFunc.AddIndex(m_TableName, "INX_COD_KTASCD_01", "LVL ASC, KTASCD1 ASC, KTASCD2 ASC, KTASCD3 ASC, KTASCD4 ASC");
            //if (ErrFlag) ErrFlag = m_DBFunc.AddIndex(m_TableName, "INX_COD_KTASCD_02", "LVL ASC, KTASCD ASC");

            return ErrFlag;
        }

        protected override void InitDataWork()
        {

        }
    }
}
