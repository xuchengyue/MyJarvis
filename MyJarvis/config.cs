using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyJarvis
{
    public static class config
    {
        public static string _dbpath = configdata.getstring("dbpath");

        public static string _writepath = configdata.getstring("writepath");

    }

    public static class configdata
    {
        private static JObject _item;

        private static JObject item
        {
            get
            {
                if (_item == null) builditem();
                return _item;
            }
        }

        private static void builditem()
        {
            var str = File.ReadAllText(System.Environment.CurrentDirectory + "/config.json");
            _item = JObject.Parse(str);
        }

        public static T getvalue<T>(string key)
        {
            return item[key].Value<T>();
        }

        public static String getstring(string key)
        {
            return item[key].Value<String>();
        }
        public static int getint(string key)
        {
            return item[key].Value<int>();
        }
        public static List<String> getstringlist(string key)
        {
            return item[key].Select(x => x.Value<String>()).ToList();
        }
    }

}
