using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.Net.NetworkInformation;
using System.Drawing;

namespace LHJ.Common.Common.Com
{
    public class Util
    {
        #region 1.Variable
        private static string _scriptTempFilename;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public Util()
        {
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {

        }
        #endregion 5.Set Initialize


        #region 6.Method
        /// <summary>
        /// 윈도우 작업스케줄러 등록
        /// </summary>
        /// <param name="aDisplayName"></param>
        /// <param name="aDescription"></param>
        /// <param name="aProgramPath"></param>
        /// <param name="aArguments"></param>
        public static void SetTaskScheduler(string aDisplayName, string aDescription, string aProgramPath, string aArguments)
        {
            using (TaskService taskService = new TaskService())
            {
                TaskDefinition taskDefinition = taskService.NewTask();

                // 일반
                taskDefinition.Principal.DisplayName = aDisplayName;
                taskDefinition.RegistrationInfo.Description = aDescription;

                // 트리거
                LogonTrigger logTrg = new LogonTrigger();
                taskDefinition.Principal.UserId = string.Concat(Environment.UserDomainName, "\\", Environment.UserName);
                taskDefinition.Principal.LogonType = TaskLogonType.InteractiveToken;
                taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;
                taskDefinition.Triggers.Add(logTrg);

                //TimeTrigger timeTrigger = new TimeTrigger();
                //timeTrigger.StartBoundary = DateTime.Parse("2015-01-01 01:00:00");
                //taskDefinition.Triggers.Add(timeTrigger);

                //DailyTrigger dailyTrigger = new DailyTrigger();
                //dailyTrigger.StartBoundary = DateTime.Parse("2015-01-01 01:00:00");
                //dailyTrigger.DaysInterval = 1;
                //taskDefinition.Triggers.Add(dailyTrigger);

                //조건
                taskDefinition.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;
                taskDefinition.Settings.DisallowStartIfOnBatteries = false;
                taskDefinition.Settings.StopIfGoingOnBatteries = false;
                taskDefinition.Settings.AllowHardTerminate = false;
                taskDefinition.Settings.StartWhenAvailable = false;
                taskDefinition.Settings.RunOnlyIfNetworkAvailable = false;
                taskDefinition.Settings.IdleSettings.StopOnIdleEnd = false;
                taskDefinition.Settings.IdleSettings.RestartOnIdle = false;

                //설정
                taskDefinition.Settings.AllowDemandStart = false;
                taskDefinition.Settings.Enabled = true;
                taskDefinition.Settings.Hidden = false;
                taskDefinition.Settings.RunOnlyIfIdle = false;
                taskDefinition.Settings.ExecutionTimeLimit = TimeSpan.Zero;
                taskDefinition.Settings.Priority = System.Diagnostics.ProcessPriorityClass.High;

                taskDefinition.Actions.Add(new ExecAction(aProgramPath, aArguments, string.Empty));

                // 등록
                taskService.RootFolder.RegisterTaskDefinition(aDisplayName, taskDefinition);
            }
        }

        public static void DeleteTaskScheduler(string aDisplayName)
        {
            using (TaskService taskService = new TaskService())
                taskService.RootFolder.DeleteTask(aDisplayName);
        }

        public static void RemoveDesktopShortcut(string aShortCutName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), aShortCutName + ".lnk");

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static void RemoveStartUpShortCut(string aShortCutName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), aShortCutName + ".lnk");

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Creates a shortcut at the specified path with the given target and
        /// arguments.
        /// </summary>
        /// <param name="path">The path where the shortcut will be created. This should
        ///     be a file with the LNK extension.</param>
        /// <param name="target">The target of the shortcut, e.g. the program or file
        ///     or folder which will be opened.</param>
        /// <param name="aArguments">The additional command line arguments passed to the
        ///     target.</param>
        public static bool CreateDesktopShortCut(string aShortCutName, string aSourcePath, string aArguments)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), aShortCutName + ".lnk");

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            // Check if link path ends with LNK or URL
            string extension = Path.GetExtension(path).ToUpper();

            if (extension != ".LNK" && extension != ".URL")
            {
                throw new ArgumentException("The path of the shortcut must have the extension .lnk or .url.");
            }

            // Get temporary file name with correct extension
            _scriptTempFilename = Path.GetTempFileName();

            File.Move(_scriptTempFilename, _scriptTempFilename += ".vbs");

            // Generate script and write it in the temporary file
            File.WriteAllText(_scriptTempFilename, String.Format(@"Dim WSHShell
Set WSHShell = WScript.CreateObject({0}WScript.Shell{0})
Dim Shortcut
Set Shortcut = WSHShell.CreateShortcut({0}{1}{0})
Shortcut.TargetPath = {0}{2}{0}
Shortcut.WorkingDirectory = {0}{3}{0}
Shortcut.Arguments = {0}{4}{0}
Shortcut.Save",
                "\"", path, aSourcePath, Path.GetDirectoryName(aSourcePath), aArguments),
                Encoding.Unicode);

            // Run the script and delete it after it has finished
            Process process = new Process();
            process.StartInfo.FileName = _scriptTempFilename;
            process.Start();
            process.WaitForExit();

            File.Delete(_scriptTempFilename);

            return true;
        }

        public static bool CreateStartUpShortCut(string aShortCutName, string aSourcePath, string aArguments)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), aShortCutName + ".lnk");

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            // Check if link path ends with LNK or URL
            string extension = Path.GetExtension(path).ToUpper();

            if (extension != ".LNK" && extension != ".URL")
            {
                throw new ArgumentException("The path of the shortcut must have the extension .lnk or .url.");
            }

            // Get temporary file name with correct extension
            _scriptTempFilename = Path.GetTempFileName();
            File.Move(_scriptTempFilename, _scriptTempFilename += ".vbs");

            // Generate script and write it in the temporary file
            File.WriteAllText(_scriptTempFilename, String.Format(@"Dim WSHShell
Set WSHShell = WScript.CreateObject({0}WScript.Shell{0})
Dim Shortcut
Set Shortcut = WSHShell.CreateShortcut({0}{1}{0})
Shortcut.TargetPath = {0}{2}{0}
Shortcut.WorkingDirectory = {0}{3}{0}
Shortcut.Arguments = {0}{4}{0}
Shortcut.Save",
                "\"", path, aSourcePath, Path.GetDirectoryName(aSourcePath), aArguments),
                Encoding.Unicode);

            // Run the script and delete it after it has finished
            Process process = new Process();
            process.StartInfo.FileName = _scriptTempFilename;
            process.Start();
            process.WaitForExit();

            File.Delete(_scriptTempFilename);

            return true;
        }

        public static bool PingTest(string aIPAddr)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply reply = p.Send(aIPAddr);

            return reply.Status.Equals(IPStatus.Success) ? true : false;
        }

        /// <summary>
        /// 폰트 설치여부 조회(폰트명은 한글명으로 넣어야 함)
        /// </summary>
        /// <param name="aFontName"></param>
        /// <returns></returns>
        public static bool IsFontInstalled(string aFontName)
        {
            using (var testFont = new Font(aFontName, 8))
            {
                return aFontName.Equals(testFont.Name, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        /// <summary>
        /// 폰트설치(참조에 Shell32.dll 추가)
        /// </summary>
        /// <param name="aFontPath"></param>
        public static void FontInstall(string aFontPath)
        {
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder fontFolder = shell.NameSpace(0x14);
            fontFolder.CopyHere(aFontPath, 16);
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
