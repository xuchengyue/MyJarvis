using System.Collections.Generic;
using System.IO;

namespace MyJarvis
{
    public abstract class writecode
    {
        protected string _pathname { get; set; }
        protected string _filename { get; set; }

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
            string path = config._writepath + _pathname;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StreamWriter sw = new StreamWriter(path + _filename))
            {

                foreach (string str in _content)
                {
                    sw.WriteLine(str);
                }
            }
        }
    }
}
