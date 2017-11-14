using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJarvis
{
    public class writemodel : writecode
    {
        public writemodel(DBTable tb) : base(tb)
        { }

        public override List<string> generate()
        {
            List<string> arr = new List<string>();
            string modelName = _tb.tbName.Replace("t_", "");

            arr.Add("using System;");
            arr.Add("");
            arr.Add("namespace Test");
            arr.Add("{");
            arr.Add($"    public partial class {modelName}");
            arr.Add("    {");
            arr.Add("        public " + modelName + "() { }");
            arr.Add("");
            foreach (DBField item in _tb.fields)
            {
                string type = item.Type;
                switch (item.Type)
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
                arr.Add($"        public {type} {item.Name} " + "{ set; get; }");
                arr.Add("");
            }
            arr.Add("    }");
            arr.Add("}");

            return arr;
        }        
    }
}
