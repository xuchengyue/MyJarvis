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
        {
            _pathname = "/Models";
            _filename = $"/{_tb.tbName.Replace("t_","")}Model.cs";
        }

        public override List<string> generate()
        {
            List<string> arr = new List<string>();
            string modelName = _tb.tbName.Replace("t_", "");

            arr.Add("using System;");
            arr.Add("");
            arr.Add("namespace MyJarvis");
            arr.Add("{");
            arr.Add($"    public partial class {modelName}Model");
            arr.Add("    {");
            arr.Add("        public " + modelName + "Model() { }");
            arr.Add("");
            foreach (DBField item in _tb.fields)
            {                
                arr.Add($"        public {item.NetType} {item.Name} " + "{ set; get; }");
                arr.Add("");
            }
            arr.Add("    }");
            arr.Add("}");

            return arr;
        }        
    }
}
