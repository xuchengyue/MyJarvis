using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJarvis
{
    public class DBTable
    {
        public string tbName { get; set; }

        public List<DBField> fields { get; set; }
    }

    public class DBField
    {
        public string Name { set; get; }
        public string Type { set; get; }
        public int Length { set; get; }
        public bool IsNull { set; get; }
    }
    
}
