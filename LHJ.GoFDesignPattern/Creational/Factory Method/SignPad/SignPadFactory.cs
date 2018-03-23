using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.SignPad
{
    /// <summary>
    /// 서명패드 팩토리 클래스
    /// </summary>
    internal class SignPadFactory
    {
        #region == Methods ==
        /// <summary>
        /// 서명패드 인스턴스 생성
        /// </summary>
        /// <param name="configSignPad">서명패드 환경설정 객체</param>
        /// <returns>서명패드 인스턴스</returns>
        internal static SignPadBase CreateInstance(ConfigSignPad configSignPad)
        {
            if (configSignPad == null)
                throw new ArgumentNullException("configSignPad");

            if (!configSignPad.IsUseSignPad || configSignPad.ModuleType == signPadModuleType.None)
                throw new ArgumentException("서명패드 환경설정 정보가 없습니다.");

            SignPadBase signPad = null;

            switch (configSignPad.ModuleType)
            {
                case signPadModuleType.Kis: 
                    signPad = new SignPadKis(configSignPad);
                    break;
                case signPadModuleType.Koces:
                    signPad = new SignPadKoces(configSignPad);
                    break;
                default:
                    throw new ArgumentException("지원하지 않는 서명패드 모듈 입니다.");
                    break;
            }

            return signPad;
        }
        #endregion
    }
}
