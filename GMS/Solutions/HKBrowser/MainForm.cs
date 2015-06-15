using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HKBrowser.Plugs;

namespace HKBrowser
{
    public partial class MainForm : Form, IAppContext
    {
        private const string APPCALL_PREFIX = ":app";

        public delegate object DelegateCallScript(string str, params object[] args);

        public MainForm()
        {
            InitializeComponent();

            this.webBrowser1.ObjectForScripting = new FormExternal(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (var item in PlugManager.GetPlugs())
            {
                item.Load(this);
            }

            //初始化浏览器
            var rooturl = ConfigurationManager.AppSettings.Get("Root");
           
            if (!rooturl.EndsWith("/"))
            {
                rooturl += "/";
            }

            this.webBrowser1.Navigate(rooturl);

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (webBrowser1.Document != null)
                {
                    var obj = webBrowser1.Document.InvokeScript("onCloseApp");
                    if (obj != null && obj is bool)
                    {
                        e.Cancel = (bool)obj;
                    }
                }
            }
            catch
            {

            }

            PlugManager.Clear();
        }

        public object CallScript(string scriptName, params object[] args)
        {
            try
            {
                if (this.InvokeRequired)
                {                
                    return this.Invoke(new DelegateCallScript(CallScript), scriptName, args);
                }

                if (scriptName.StartsWith(APPCALL_PREFIX))
                {
                    return AppCall(scriptName.Substring(APPCALL_PREFIX.Length));
                }

                if (webBrowser1.Document == null)
                {
                    return null;
                }

                foreach (HtmlWindow o in webBrowser1.Document.Window.Frames)
                {
                    o.Document.InvokeScript(scriptName, args);
                }

                return webBrowser1.Document.InvokeScript(scriptName, args);
            }
            catch
            {
                return null;

            }
        }

        public object AppCall(string scriptName, params object[] args)
        {
            switch (scriptName)
            {
                case "getcookie":
                    return webBrowser1.Document == null ? "" : webBrowser1.Document.Cookie;

            }
            return null;
        }

        public event EventHandler<ScriptCallArgs> ScriptCalling;

        public object OnScriptCall(ScriptCallArgs e)
        {
            if (ScriptCalling != null)
                ScriptCalling(this, e);
            return e;
        }
    }
}
