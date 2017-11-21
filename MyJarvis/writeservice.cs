using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJarvis
{
    public class writeservice : writecode
    {
        public writeservice(DBTable tb) : base(tb)
        {
            _pathname = "/Service";
            _filename = $"/{_tb.tbName.Replace("t_", "")}Service.cs";
        }

        public override List<string> generate()
        {
            List<string> arr = new List<string>();
            string modelName = _tb.tbName.Replace("t_", "");

            arr.Add("using Dapper;");
            arr.Add("using Etocrm.CerryOn.Model;");
            arr.Add("using Etocrm.CerryOn.Utility; ");
            arr.Add("using System.Collections.Generic; ");
            arr.Add("using System.Data; ");
            arr.Add("using System.Data.SqlClient; ");
            arr.Add("using System.Linq; ");
            arr.Add("");
            arr.Add("namespace MyJarvis");
            arr.Add("{");
            arr.Add($"    public partial class {modelName}Service");
            arr.Add("    {");
            // GetList(string cond)
            arr.Add($"        public static List<{modelName}Model> GetList(string cond) ");
            arr.Add("        {");
            arr.Add("            using (IDbConnection db = new SqlConnection(Constants.ConnectionString))");
            arr.Add("            {");
            arr.Add($"                return db.Query<{modelName}Model>(sql).ToList();");
            arr.Add("            }");
            arr.Add("        }");
            arr.Add("");
            arr.Add($"        public static bool Insert({modelName}Model model) ");
            arr.Add("        {");
            arr.Add($"            string sql = \"insert into {_tb.tbName} ({String.Join(",", _tb.fields.Select(x => x.Name))}) values ({String.Join(",", _tb.fields.Select(x => "@" + x.Name))});\";");
            arr.Add("            using (IDbConnection db = new SqlConnection(Constants.ConnectionString))");
            arr.Add("            {");
            arr.Add($"                return db.Execute(sql, model) == 1;");
            arr.Add("            }");
            arr.Add("        }");

            arr.Add("    }");
            arr.Add("}");

            return arr;
        }
    }
}
