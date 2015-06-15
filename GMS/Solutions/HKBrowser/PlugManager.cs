using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using HKBrowser.Plugs;

namespace HKBrowser
{
    public class PlugManager
    {
        private static string PlugInterfaceName
        {
            get
            {
                return typeof(IPlug).Name;
            }
        }

        static IList<IPlug> plugs;
        public static IList<IPlug> GetPlugs()
        {
            LoadPlug();
            return plugs;
        }

        private static void LoadPlug()
        {
            if (plugs != null)
            {
                return;
            }
            plugs = new List<IPlug>();

            string str = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugs");
            if (!Directory.Exists(str)) return;

            foreach (var file in Directory.GetFiles(str, "*.dll"))
            {
                var ass = Assembly.LoadFile(file);
                var types = ass.GetTypes();

                foreach (var tp in types)
                {

                    if (tp.GetInterface(PlugInterfaceName) != null)
                    {
                        var item = Activator.CreateInstance(tp) as IPlug;
                        plugs.Add(item);
                    }
                }
            }
        }

        public static void Clear()
        {
            foreach (var item in GetPlugs())
            {
                try
                {
                    item.Unload();
                }
                catch
                {

                }

            }
        }
    }
}
