using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.SignPad
{
    /// <summary>
    /// 서명패드 모듈 종료
    /// </summary>
    internal enum signPadModuleType
    {
        /// <summary>
        /// 없음
        /// </summary>
        None,
        /// <summary>
        /// 금융결제원
        /// </summary>
        KFTC,
        /// <summary>
        /// 한국정보통신
        /// </summary>
        KICC,
        /// <summary>
        /// FirstData
        /// </summary>
        FirstData,
        /// <summary>
        /// 스마트로
        /// </summary>
        Smatro,
        /// <summary>
        /// 한국신용카드결제
        /// </summary>
        Koces,
        /// <summary>
        /// Kis
        /// </summary>
        Kis
    }
}
