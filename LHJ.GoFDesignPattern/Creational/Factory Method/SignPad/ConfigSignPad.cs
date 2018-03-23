using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Factory_Method.SignPad
{
    /// <summary>
    /// 서명패드 환경설정
    /// </summary>
    internal class ConfigSignPad
    {
        #region == Constants ==
        /// <summary>
        /// 서명패드 환경설정 레지스트리 경로
        /// </summary>
        private const string REG_PATH = "SignPad";
        /// <summary>
        /// 서명패드 사용여부 레지스트리 문자열
        /// </summary>
        private const string REG_IS_USE_SIGNPAD = "IsUseSignPad";
        /// <summary>
        /// 서명패드 모듈 종류
        /// </summary>
        private const string REG_MODULE_TYPE = "ModuleType";
        /// <summary>
        /// 서명패드 사용포트 레지스트리 문자열
        /// </summary>
        private const string REG_PORT = "Port";
        /// <summary>
        /// 서명패드 통신속도 레지스트리 문자열
        /// </summary>
        private const string REG_BAUDRATE = "BaudRate";
        #endregion

        #region == Fields & Properties ==
        /// <summary>
        /// 서명패드 사용여부
        /// </summary>
        private bool _isUseSignPad = false;
        /// <summary>
        /// Gets or Sets the 서명패드 사용여부
        /// </summary>
        internal bool IsUseSignPad
        {
            get { return _isUseSignPad; }
            set { _isUseSignPad = value; }
        }

        /// <summary>
        /// 서명패드 모듈 종류
        /// </summary>
        private signPadModuleType _moduleType = signPadModuleType.None;
        /// <summary>
        /// Gets or Sets the 서명패드 모듈 종류
        /// </summary>
        internal signPadModuleType ModuleType
        {
            get { return _moduleType; }
            set { _moduleType = value; }
        }

        /// <summary>
        /// 서명패드 통신 포트
        /// </summary>
        private int _port = 1;
        /// <summary>
        /// Gets or Sets 서명패드 통신 포트
        /// </summary>
        internal int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        /// <summary>
        /// 서명패드 통신 속도
        /// </summary>
        private int _baudRate = 9600;
        /// <summary>
        /// Gets or Sets 서명패드 통신 속도
        /// </summary>
        public int BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }
        #endregion

        #region == Methods ==
        /// <summary>
        /// 서명패드 사용여부 조회
        /// </summary>
        /// <returns>true:사용, false:미사용</returns>
        internal bool GetUseSignPadOnRegistry()
        {
            //if (!String.IsNullOrEmpty(FKEMRConfig.GetRegValue(REG_IS_USE_SIGNPAD).ToString()))
            //    return Boolean.Parse(FKEMRConfig.GetRegValue(REG_IS_USE_SIGNPAD).ToString());

            return false;
        }

        /// <summary>
        /// 서명패드 사용포트 조회
        /// </summary>
        /// <returns>서명패드 사용포트</returns>
        internal int GetSignPadPortOnRegistry()
        {
            //if (!String.IsNullOrEmpty(FKEMRConfig.GetRegValue(REG_PORT).ToString()))
            //    return Int32.Parse(FKEMRConfig.GetRegValue(REG_PORT).ToString());

            return -1;
        }

        /// <summary>
        /// 서명패드 환경설정을 레지스트리에 저장
        /// </summary>
        /// <param name="isUseSignPad">서명패드 사용여부</param>
        /// <param name="signPadPort">서명패드 사용포트</param>
        /// <returns>true:성공, false:실패</returns>
        internal bool SaveRegistry(bool isUseSignPad, int signPadPort)
        {
            //FKEMRConfig.SetRegValue(REG_IS_USE_SIGNPAD, isUseSignPad.ToString());
            //FKEMRConfig.SetRegValue(REG_PORT, signPadPort.ToString());

            return true;
        }

        /// <summary>
        /// 서명패드 환경설정 조회
        /// </summary>
        /// <returns>서명패드 환경설정 객체</returns>
        internal ConfigSignPad GetSignPadConfiguration()
        {
            ////# 서명패드 사용여부
            //string registryName = FKEMRConfig.EMR_REG_KEY + "\\" + REG_PATH;
            //string isUseSignPad = FKEMRConfig.GetRegValue(REG_IS_USE_SIGNPAD, registryName).ToString();
            //if (String.IsNullOrEmpty(isUseSignPad) || isUseSignPad != "true")
            //{
            //    _isUseSignPad = false;
            //    return this;
            //}
            //_isUseSignPad = true;

            ////# 모듈종류, 포트, 통신속도
            //string moduleType = FKEMRConfig.GetRegValue(REG_MODULE_TYPE, registryName).ToString();
            //if (!String.IsNullOrEmpty(moduleType))
            //    _moduleType = (SignPadMoudleType)Enum.Parse(typeof(SignPadMoudleType), moduleType);

            //string port = FKEMRConfig.GetRegValue(REG_PORT, registryName).ToString();
            //if (!String.IsNullOrEmpty(port))
            //    _port = Int32.Parse(port);

            //string baudRate = FKEMRConfig.GetRegValue(REG_BAUDRATE, registryName).ToString();
            //if (!String.IsNullOrEmpty(baudRate))
            //    _baudRate = Int32.Parse(baudRate);

            return this;
        }

        /// <summary>
        /// 서명패드 환경설정
        /// </summary>
        /// <param name="moduleType">모듈 종류</param>
        /// <param name="port">포트</param>
        internal void SetSignPadConfiguration(signPadModuleType moduleType, int port)
        {
            //string registryName = FKEMRConfig.EMR_REG_KEY + "\\" + REG_PATH;
            //FKEMRConfig.SetRegValue(REG_IS_USE_SIGNPAD, "true", registryName);
            //FKEMRConfig.SetRegValue(REG_MODULE_TYPE, moduleType.ToString(), registryName);
            //FKEMRConfig.SetRegValue(REG_PORT, port.ToString(), registryName);
            //FKEMRConfig.RemoveRegValue(REG_BAUDRATE, registryName);
        }

        /// <summary>
        /// 서명패드 환경설정
        /// </summary>
        /// <param name="moduleType">모듈 종류</param>
        /// <param name="port">포트</param>
        /// <param name="baudRate">속도</param>
        internal void SetSignPadConfiguration(signPadModuleType moduleType, int port, int baudRate)
        {
            //string registryName = FKEMRConfig.EMR_REG_KEY + "\\" + REG_PATH;
            //FKEMRConfig.SetRegValue(REG_IS_USE_SIGNPAD, "true", registryName);
            //FKEMRConfig.SetRegValue(REG_MODULE_TYPE, moduleType.ToString(), registryName);
            //FKEMRConfig.SetRegValue(REG_PORT, port.ToString(), registryName);
            //FKEMRConfig.SetRegValue(REG_BAUDRATE, baudRate.ToString(), registryName);
        }

        /// <summary>
        /// 서명패드 환경설정 초기화
        /// </summary>
        internal void InitializeSignPadConfiguration()
        {
            //string registryName = FKEMRConfig.EMR_REG_KEY + "\\" + REG_PATH;
            //FKEMRConfig.SetRegValue(REG_IS_USE_SIGNPAD, "false", registryName);
            //FKEMRConfig.RemoveRegValue(REG_MODULE_TYPE, registryName);
            //FKEMRConfig.RemoveRegValue(REG_PORT, registryName);
            //FKEMRConfig.RemoveRegValue(REG_BAUDRATE, registryName);
        }
        #endregion
    }
}
