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
            DBField pk = _tb.fields.Where(x => x.IsPK == true).FirstOrDefault();

            arr.Add("using Dapper;");
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
            arr.Add($"        public static List<{modelName}Model> GetList(string sql) ");
            arr.Add("        {");
            arr.Add("            using (IDbConnection db = new SqlConnection(Constants.ConnectionString))");
            arr.Add("            {");
            arr.Add($"                return db.Query<{modelName}Model>(sql).ToList();");
            arr.Add("            }");
            arr.Add("        }");
            arr.Add("");
            // Insert()
            arr.Add($"        public static bool Insert({modelName}Model model) ");
            arr.Add("        {");
            arr.Add($"            string sql = \"insert into {_tb.tbName} ({String.Join(",", _tb.fields.Where(x => x.IsGenerate == false).Select(x => x.Name))}) values ({String.Join(",", _tb.fields.Where(x => x.IsGenerate == false).Select(x => "@" + x.Name))});\";");
            arr.Add("            using (IDbConnection db = new SqlConnection(Constants.ConnectionString))");
            arr.Add("            {");
            arr.Add($"                return db.Execute(sql, model) == 1;");
            arr.Add("            }");
            arr.Add("        }");
            arr.Add("");
            // Update()
            arr.Add($"        public static bool Update({modelName}Model model) ");
            arr.Add("        {");
            arr.Add($"            string sql = \"update {_tb.tbName} set {String.Join(",", _tb.fields.Where(x => x.IsGenerate == false).Select(x => x.Name + "=@" + x.Name))} where {pk.Name}=@{pk.Name};\";");
            arr.Add("            using (IDbConnection db = new SqlConnection(Constants.ConnectionString))");
            arr.Add("            {");
            arr.Add($"                return db.Execute(sql, model) == 1;");
            arr.Add("            }");
            arr.Add("        }");
            arr.Add("");
            // Delete()
            arr.Add($"        public static bool Delete({pk.NetType} {pk.Name}) ");
            arr.Add("        {");
            arr.Add($"            string sql = \"delete from {_tb.tbName} where {pk.Name} = @{pk.Name};\";");
            arr.Add("            using (IDbConnection db = new SqlConnection(Constants.ConnectionString))");
            arr.Add("            {");
            arr.Add($"                return db.Execute(sql, model) == 1;");
            arr.Add("            }");
            arr.Add("        }");
            arr.Add("");

            arr.Add("    }");
            arr.Add("}");

            return arr;
        }
    }
}
