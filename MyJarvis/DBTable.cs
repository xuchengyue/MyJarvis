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
        // 是否主键
        public bool IsPK { set; get; }
        // 是否自增长
        public bool IsGenerate { set; get; }
        public string Name { set; get; }
        public string SqlType { set; get; }
        public string NetType
        {
            get
            {
                string type = "string";
                switch (SqlType)
                {
                    case "nvarchar":
                    case "varchar":
                        type = "string";
                        break;
                    case "uniqueidentifier":
                        type = "Guid";
                        break;
                    case "datetime":
                    case "date":
                        type = "DateTime";
                        break;
                    case "bigint":
                        type = "int";
                        break;
                    case "bit":
                        type = "bool";
                        break;
                }
                return type;
            }
        }
        public int Length { set; get; }
        public bool IsNull { set; get; }
    }

}
