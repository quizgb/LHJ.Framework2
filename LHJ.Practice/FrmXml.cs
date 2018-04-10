using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LHJ.Practice
{
    public partial class FrmXml : Form
    {
        public FrmXml()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XML.PCM_REGIST pcm = this.createPCM();
            string strXml = LHJ.Common.Common.Com.Util.ToXML(pcm);
            //strXml = File.ReadAllText(@"C:\TYPE1.XML");

            Object obj = LHJ.Common.Common.Com.Util.XMLToObject(strXml, typeof(XML.PCM_REGIST));

            if (obj != null)
            {
                if (obj.GetType().Equals(typeof(XML.PCM_REGIST)))
                {
                    XML.PCM_REGIST pcm2 = obj as XML.PCM_REGIST;
                }
            }
        }

        private XML.PCM_REGIST createPCM()
        {
            XML.PCM_REGIST pcm_reg = new XML.PCM_REGIST();
            pcm_reg.REPORT_SET = new XML.reportSetPCM();
            pcm_reg.REPORT_SET.UID = new XmlDocument().CreateCDataSection("TEST_CRKEY_001");

            XML.headerPCM hdpcm = new XML.headerPCM();
            hdpcm.ATCH_FILE_CO = "0";
            hdpcm.BSSH_CD = string.Empty;
            pcm_reg.REPORT_SET.HEADER = hdpcm;

            List<XML.LINE> lines = new List<XML.LINE>();

            XML.LINE line = new XML.LINE();
            line.FILE_CREAT_DT = "20171116052906";

            XML.LINE line2 = new XML.LINE();
            line2.FILE_CREAT_DT = "20171116052906";

            lines.Add(line);
            lines.Add(line2);

            pcm_reg.REPORT_SET.HEADER.LINES = lines;

            return pcm_reg;
        }
    }
}
