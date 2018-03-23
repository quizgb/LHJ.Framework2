using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.SignPad
{
    internal class SignPadKoces : SignPadBase
    {
        #region == Constructors ==
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="configSignPad">서명패드 환경설정 객체</param>
        public SignPadKoces(ConfigSignPad configSignPad)
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
            System.Windows.Forms.MessageBox.Show("KOCES 서명");

            return null;
        }
        #endregion
    }
}
