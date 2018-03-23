using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.SignPad
{
    /// <summary>
    /// 서명패드 베이스 클래스
    /// </summary>
    internal abstract class SignPadBase
    {
        #region == Fields & Properties ==
        /// <summary>
        /// 서명패드 환경설정 객체
        /// </summary>
        protected ConfigSignPad _configSignPad = null;
        #endregion

        #region == Abstract methods ==
        /// <summary>
        /// 서명패드 서명 요청
        /// </summary>
        /// <returns>서명 이미지</returns>
        internal abstract Bitmap RequestSign();
        #endregion
    }
}
