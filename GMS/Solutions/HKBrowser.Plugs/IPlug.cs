using System;
using System.Collections.Generic;
using System.Text;

namespace HKBrowser.Plugs
{
    public interface IAppContext
    {
        object CallScript(string scriptName, params Object[] args);
        event EventHandler<ScriptCallArgs> ScriptCalling;
    }

    public interface IPlug
    {
        void Load(IAppContext app);
        void Unload();
    }

}
