using System;
using System.Collections.Generic;
using System.Text;
using HKBrowser.Plugs;

namespace HKBrowser.PrintPlug
{
    public class OrderPrint:IPlug
    {
        private const string APPCALL_PREFIX = ":app";

        public void Load(IAppContext app)
        {
            app.ScriptCalling += new EventHandler<ScriptCallArgs>(app_ScriptCalling);
        }

        public void Unload()
        {
            throw new NotImplementedException();
        }

        void app_ScriptCalling(object sender, ScriptCallArgs e)
        {
            if (e.Method == "PrintOrder")
            {
                //try
                //{
                //    var item = m_Repository.GetReceiveSmsContentAndPrisoner(e.Args);
                //    if (item != null)
                //    {
                //        SmsPrint sp = new SmsPrint();
                //        sp.PrintSms(item.Prisoner, item.Item, this);
                //        e.Result = "{success:true }";
                //    }
                //    else
                //    {
                //        e.Result = "{ success:false, error:\"该短信已经不存在！\" }";
                //    }
                //}
                //catch (System.Exception ex)
                //{
                //    e.Result = string.Format("{{success:false, error:'{0}' }}", ex.Message);
                //    AddLog(string.Format("{0}\r\n{1}", ex.Message, ex.StackTrace));
                //}


            }
        }
        
    }
}
