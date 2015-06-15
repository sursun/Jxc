using System;
using System.Collections.Generic;
using System.Text;

namespace HKBrowser.Plugs
{
    public class ScriptCallArgs : EventArgs
    {
        public string Method { set; get; }

        public string Args { set; get; }
        
        public object Result { set; get; }
    }
}
