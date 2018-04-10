using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LHJ.Practice.XML
{
    public partial class PCM_REGIST
    {

        private reportSetPCM rEPORT_SETField;

        /// <remarks/>
        public reportSetPCM REPORT_SET
        {
            get
            {
                return this.rEPORT_SETField;
            }
            set
            {
                this.rEPORT_SETField = value;
            }
        }
    }

    public partial class LINE
    {
        private string uSR_RPT_ID_NOField;

        private string uSR_RPT_LN_ID_NOField;

        private string sTORGE_NOField;

        private string mVMN_TY_CDField;

        private string pRDUCT_CDField;

        private string mNF_NOField;

        private string mNF_SEQField;

        private string mIN_DISTB_QYField;

        private string pRD_MIN_DISTB_UNITField;

        private string pCE_QYField;

        private string pRD_PCE_UNITField;

        private string pRDUCT_NMField;

        private string pRD_SGTINField;

        private string pRD_MIN_DISTB_QYField;

        private string pRD_TOT_PCE_QYField;

        private string pRD_VALID_DEField;

        private string fILE_CREAT_DTField;

        /// <remarks/>
        public string USR_RPT_ID_NO
        {
            get
            {
                return this.uSR_RPT_ID_NOField;
            }
            set
            {
                this.uSR_RPT_ID_NOField = value;
            }
        }

        /// <remarks/>
        public string USR_RPT_LN_ID_NO
        {
            get
            {
                return this.uSR_RPT_LN_ID_NOField;
            }
            set
            {
                this.uSR_RPT_LN_ID_NOField = value;
            }
        }

        /// <remarks/>
        public string STORGE_NO
        {
            get
            {
                return this.sTORGE_NOField;
            }
            set
            {
                this.sTORGE_NOField = value;
            }
        }

        /// <remarks/>
        public string MVMN_TY_CD
        {
            get
            {
                return this.mVMN_TY_CDField;
            }
            set
            {
                this.mVMN_TY_CDField = value;
            }
        }

        /// <remarks/>
        public string PRDUCT_CD
        {
            get
            {
                return this.pRDUCT_CDField;
            }
            set
            {
                this.pRDUCT_CDField = value;
            }
        }

        /// <remarks/>
        public string MNF_NO
        {
            get
            {
                return this.mNF_NOField;
            }
            set
            {
                this.mNF_NOField = value;
            }
        }

        /// <remarks/>
        public string MNF_SEQ
        {
            get
            {
                return this.mNF_SEQField;
            }
            set
            {
                this.mNF_SEQField = value;
            }
        }

        /// <remarks/>
        public string MIN_DISTB_QY
        {
            get
            {
                return this.mIN_DISTB_QYField;
            }
            set
            {
                this.mIN_DISTB_QYField = value;
            }
        }

        /// <remarks/>
        public string PRD_MIN_DISTB_UNIT
        {
            get
            {
                return this.pRD_MIN_DISTB_UNITField;
            }
            set
            {
                this.pRD_MIN_DISTB_UNITField = value;
            }
        }

        /// <remarks/>
        public string PCE_QY
        {
            get
            {
                return this.pCE_QYField;
            }
            set
            {
                this.pCE_QYField = value;
            }
        }

        /// <remarks/>
        public string PRD_PCE_UNIT
        {
            get
            {
                return this.pRD_PCE_UNITField;
            }
            set
            {
                this.pRD_PCE_UNITField = value;
            }
        }

        /// <remarks/>
        public string PRDUCT_NM
        {
            get
            {
                return this.pRDUCT_NMField;
            }
            set
            {
                this.pRDUCT_NMField = value;
            }
        }

        /// <remarks/>
        public string PRD_SGTIN
        {
            get
            {
                return this.pRD_SGTINField;
            }
            set
            {
                this.pRD_SGTINField = value;
            }
        }

        /// <remarks/>
        public string PRD_MIN_DISTB_QY
        {
            get
            {
                return this.pRD_MIN_DISTB_QYField;
            }
            set
            {
                this.pRD_MIN_DISTB_QYField = value;
            }
        }

        /// <remarks/>
        public string PRD_TOT_PCE_QY
        {
            get
            {
                return this.pRD_TOT_PCE_QYField;
            }
            set
            {
                this.pRD_TOT_PCE_QYField = value;
            }
        }

        /// <remarks/>
        public string PRD_VALID_DE
        {
            get
            {
                return this.pRD_VALID_DEField;
            }
            set
            {
                this.pRD_VALID_DEField = value;
            }
        }

        /// <remarks/>
        public string FILE_CREAT_DT
        {
            get
            {
                return this.fILE_CREAT_DTField;
            }
            set
            {
                this.fILE_CREAT_DTField = value;
            }
        }
    }

    public partial class headerPCM
    {

        private string hDR_DEField;

        private string bSSH_CDField;

        private string rPT_SE_CDField;

        private string uSR_RPT_ID_NOField;

        private string rEF_USR_RPT_ID_NOField;

        private string rPT_TY_CDField;

        private string rMKField;

        private string rPTR_NMField;

        private string rPTR_ENTRPS_NMField;

        private string cHRG_NMField;

        private string cHRG_TEL_NOField;

        private string cHRG_MP_NOField;

        private string rND_DTL_RPT_CNTField;

        private string oPP_BSSH_NMField;

        private string oPP_BSSH_CDField;

        private string oPP_STORGE_NOField;

        private string aTCH_FILE_COField;

        private string rEGISTER_IDField;

        private string fILE_CREAT_DTField;

        private List<LINE> lINESField;

        private List<string> aTCH_FILESField;

        /// <remarks/>
        public string HDR_DE
        {
            get
            {
                return this.hDR_DEField;
            }
            set
            {
                this.hDR_DEField = value;
            }
        }

        /// <remarks/>
        public string BSSH_CD
        {
            get
            {
                return this.bSSH_CDField;
            }
            set
            {
                this.bSSH_CDField = value;
            }
        }

        /// <remarks/>
        public string RPT_SE_CD
        {
            get
            {
                return this.rPT_SE_CDField;
            }
            set
            {
                this.rPT_SE_CDField = value;
            }
        }

        /// <remarks/>
        public string USR_RPT_ID_NO
        {
            get
            {
                return this.uSR_RPT_ID_NOField;
            }
            set
            {
                this.uSR_RPT_ID_NOField = value;
            }
        }

        /// <remarks/>
        public string REF_USR_RPT_ID_NO
        {
            get
            {
                return this.rEF_USR_RPT_ID_NOField;
            }
            set
            {
                this.rEF_USR_RPT_ID_NOField = value;
            }
        }

        /// <remarks/>
        public string RPT_TY_CD
        {
            get
            {
                return this.rPT_TY_CDField;
            }
            set
            {
                this.rPT_TY_CDField = value;
            }
        }

        /// <remarks/>
        public string RMK
        {
            get
            {
                return this.rMKField;
            }
            set
            {
                this.rMKField = value;
            }
        }

        /// <remarks/>
        public string RPTR_NM
        {
            get
            {
                return this.rPTR_NMField;
            }
            set
            {
                this.rPTR_NMField = value;
            }
        }

        /// <remarks/>
        public string RPTR_ENTRPS_NM
        {
            get
            {
                return this.rPTR_ENTRPS_NMField;
            }
            set
            {
                this.rPTR_ENTRPS_NMField = value;
            }
        }

        /// <remarks/>
        public string CHRG_NM
        {
            get
            {
                return this.cHRG_NMField;
            }
            set
            {
                this.cHRG_NMField = value;
            }
        }

        /// <remarks/>
        public string CHRG_TEL_NO
        {
            get
            {
                return this.cHRG_TEL_NOField;
            }
            set
            {
                this.cHRG_TEL_NOField = value;
            }
        }

        /// <remarks/>
        public string CHRG_MP_NO
        {
            get
            {
                return this.cHRG_MP_NOField;
            }
            set
            {
                this.cHRG_MP_NOField = value;
            }
        }

        /// <remarks/>
        public string RND_DTL_RPT_CNT
        {
            get
            {
                return this.rND_DTL_RPT_CNTField;
            }
            set
            {
                this.rND_DTL_RPT_CNTField = value;
            }
        }

        /// <remarks/>
        public string OPP_BSSH_NM
        {
            get
            {
                return this.oPP_BSSH_NMField;
            }
            set
            {
                this.oPP_BSSH_NMField = value;
            }
        }

        /// <remarks/>
        public string OPP_BSSH_CD
        {
            get
            {
                return this.oPP_BSSH_CDField;
            }
            set
            {
                this.oPP_BSSH_CDField = value;
            }
        }

        /// <remarks/>
        public string OPP_STORGE_NO
        {
            get
            {
                return this.oPP_STORGE_NOField;
            }
            set
            {
                this.oPP_STORGE_NOField = value;
            }
        }

        /// <remarks/>
        public string ATCH_FILE_CO
        {
            get
            {
                return this.aTCH_FILE_COField;
            }
            set
            {
                this.aTCH_FILE_COField = value;
            }
        }

        /// <remarks/>
        public string REGISTER_ID
        {
            get
            {
                return this.rEGISTER_IDField;
            }
            set
            {
                this.rEGISTER_IDField = value;
            }
        }

        /// <remarks/>
        public string FILE_CREAT_DT
        {
            get
            {
                return this.fILE_CREAT_DTField;
            }
            set
            {
                this.fILE_CREAT_DTField = value;
            }
        }

        /// <remarks/>
        public List<LINE> LINES
        {
            get
            {
                return this.lINESField;
            }
            set
            {
                this.lINESField = value;
            }
        }

        /// <remarks/>
        public List<string> ATCH_FILES
        {
            get
            {
                return this.aTCH_FILESField;
            }
            set
            {
                this.aTCH_FILESField = value;
            }
        }
    }

    public partial class reportSetPCM
    {
        private string uIDField;
        private headerPCM hEADERField;

        ///// <remarks/>
        //public string UID
        //{
        //    get
        //    {
        //        return this.uIDField;
        //    }
        //    set
        //    {
        //        this.uIDField = value;
        //    }
        //}

        [XmlElement("UID", typeof(XmlCDataSection))]
        public XmlCDataSection UID
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                return doc.CreateCDataSection(uIDField);
            }
            set { uIDField = value.Value; }
        }

        /// <remarks/>
        public headerPCM HEADER
        {
            get
            {
                return this.hEADERField;
            }
            set
            {
                this.hEADERField = value;
            }
        }
    }
}
