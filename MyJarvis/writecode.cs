using System.Collections.Generic;
using System.IO;

namespace MyJarvis
{
    public abstract class writecode
    {
        protected DBTable _tb { get; set; }

        public writecode(DBTable tb)
        {
            _tb = tb;
        }

        private List<string> _content { get; set; }

        public abstract List<string> generate();

        public void write()
        {
            _content = generate();
            using (StreamWriter sw = new StreamWriter(config._writepath + _tb.tbName + ".cs"))
            {
                foreach (string str in _content)
                {
                    sw.WriteLine(str);
                }
            }
        }
    }
}
