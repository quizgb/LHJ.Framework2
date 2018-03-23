using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.SignPad
{
    internal class SignPadKis : SignPadBase
    {
        private void CheckOCX()
        {
            try
            {
                string path = Application.StartupPath + "\\temp.cmd";
                string result = string.Format("regsvr32 /s {0}", Application.StartupPath + @"\System\KisvanMS3.ocx");

                FileStream fs = File.Open(path, FileMode.Create);//저장할 파일을 만든다
                Byte[] by_Text = System.Text.Encoding.UTF8.GetBytes(result);
                fs.Write(by_Text, 0, by_Text.Length);
                fs.Close();

                {//이제 만들어진 cmd 파일을 관리자 권한을 얻어서 실행시키고
                    ProcessStartInfo proInfo = new ProcessStartInfo();
                    Process pro = new Process();
                    proInfo.FileName = path;
                    proInfo.Verb = "runas";//관리자 권한으로
                    proInfo.CreateNoWindow = true;
                    pro.StartInfo = proInfo;
                    pro.Start();
                    pro.WaitForExit();
                }

                File.Delete(path);//지워버리자.
            }
            catch (Exception ex)
            {
            }
        }

        #region == Constructors ==
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="configSignPad">서명패드 환경설정 객체</param>
        public SignPadKis(ConfigSignPad configSignPad)
        {
            _configSignPad = configSignPad;
        }
        #endregion

        #region == Implement the members of the SignPadBase class ==
        /// <summary>
        /// 서명요청
        /// </summary>
        /// <returns>서명이 포함된 이미지 파일</returns>
        internal override Bitmap RequestSign()
        {
            this.CheckOCX();

            MessageBox.Show("KIS 서명");

            return null;
        }
        #endregion
    }
}
