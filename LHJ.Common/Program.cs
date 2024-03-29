﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LHJ.Common
{
    public class Program
    {
        public Program()
        {
            ///어셈블리 로드가 실패 하였을 경우 해당 이벤트가 발생됨
            ///컴파일 시 또는 실행시 해당 응용 프로그램의 리소스에 포함되어 있는 dll을 가져와 로드 시킴
            AppDomain.CurrentDomain.AssemblyResolve += (sender, bargs) =>
            {
                string dllName = new AssemblyName(bargs.Name).Name + ".dll";
                var assem = Assembly.GetExecutingAssembly();
                string resourceName = null;
                foreach (string str in assem.GetManifestResourceNames())
                {
                    if (str.IndexOf(dllName) != -1)
                    {
                        resourceName = str;
                        break;
                    }
                }
                if (resourceName == null) return null;
                using (var stream = assem.GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }
    }
}
