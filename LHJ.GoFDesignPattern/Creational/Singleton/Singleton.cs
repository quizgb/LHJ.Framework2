using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.GoFDesignPattern.Creational.Singleton
{
    //싱글톤 클래스
    public class Singleton
    {
        private static Singleton _instance;
        private static object _syncObject = new Object();

        //  'protected' 로 생성자를 만듦
        protected Singleton()
        {
        }

        // 'static'으로 메서드를 생성
        public static Singleton Instance()
        {
            //다중쓰레드에서는 정상적으로 동작안하는 코드입니다.
            //다중 쓰레드 경우에는 동기화가 필요합니다.
            //if (_instance == null)
            //{
            //    _instance = new Singleton();
            //}

            /// 다중 쓰레드 환경일 경우 Lock 필요
            if (_instance == null)
            {
                lock (_syncObject)
                {
                    _instance = new Singleton();
                }
            }

            return _instance;
        }

        /// <summary>
        /// 프로젝트 정보
        /// </summary>
        private readonly ProjectInfo m_ProjectInfo = new ProjectInfo();
        public ProjectInfo ProjectInfo
        {
            get { return m_ProjectInfo; }
        }

        /// <summary>
        /// 사용자 정보
        /// </summary>
        private readonly UserInfo m_UserInfo = new UserInfo();
        public UserInfo UserInfo
        {
            get { return m_UserInfo; }
        }
    }
}
