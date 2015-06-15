using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using HKBrowser.Plugs;

namespace HKBrowser
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class FormExternal
    {
        private static MainForm m_mainWindow = null;

        public FormExternal(MainForm mainWindow)
        {
            m_mainWindow = mainWindow;
        }

        public void CloseApplication()
        {
            m_mainWindow.Close();
        }

        /// <summary>
        /// 从浏览器脚本发起的调用
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string ScriptCall(string method, string args)
        {
            var eventargs = new ScriptCallArgs { Method = method, Args = args };
           
             m_mainWindow.OnScriptCall(eventargs);
             return eventargs.Result.ToString();
        }
    }
}
