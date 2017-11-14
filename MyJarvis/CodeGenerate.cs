using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyJarvis
{
    public partial class CodeGenerate : Form
    {
        public string SelectedDataBase { get; set; }
        public CodeGenerate()
        {
            Test();
            InitializeComponent();
            ChangeListContent(GetAllDataBase());
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            SelectedDataBase = this.DataBaseList.SelectedValue.ToString();
            IntoDataBase(SelectedDataBase);
        }

        private void ChangeListContent(List<string> list)
        {
            this.DataBaseList.DataSource = list;
        }

        private List<string> GetAllDataBase()
        {
            string dbLink = "Data Source=10.20.20.19;Initial Catalog=master;User Id = dev;Password = etocrm123;";

            using (IDbConnection db = new SqlConnection(dbLink))
            {
                string sql = "select name from master..sysdatabases";
                List<string> names = db.Query<string>(sql).ToList();
                return names;
            }
        }
        public void IntoDataBase(string baseName)
        {
            try
            {
                string dbLink = $"Data Source=10.20.20.19;Initial Catalog={baseName};User Id = dev;Password = etocrm123;";
                List<string> names = new List<string>();
                using (IDbConnection db = new SqlConnection(dbLink))
                {
                    string sql = @"select TABLE_NAME from INFORMATION_SCHEMA.TABLES";
                    names = db.Query<string>(sql).ToList();
                }
                ChangeListContent(names);
            }
            catch (Exception ex)
            {
                throw new Exception("进入数据库错误");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChangeListContent(GetAllDataBase());
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string table = this.DataBaseList.SelectedValue.ToString();
            string dbLink = $"Data Source=10.20.20.19;Initial Catalog={SelectedDataBase};User Id = dev;Password = etocrm123;";
            using (IDbConnection db = new SqlConnection(dbLink))
            {
                string sql = $"select COLUMN_NAME as Name,DATA_TYPE as Type,CHARACTER_MAXIMUM_LENGTH as Length,case when IS_NULLABLE='YES' then 1 else 0 end as IsNull from INFORMATION_SCHEMA.COLUMNS t where t.TABLE_NAME = '{table}';";
                List<DBField> fields = db.Query<DBField>(sql).ToList();
                writemodel writem = new writemodel(new DBTable { tbName = table, fields = fields });
                writem.write();
            }
        }

        public void Test()
        {
            //var str = File.ReadAllText(System.Environment.CurrentDirectory + "/config.json");
            //SQLiteConnection.CreateFile("MyDatabase.sqlite");
            string connStr = @"Data Source=" + @"D:\jarvis1.0.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";

            using (IDbConnection db = new SQLiteConnection(connStr))
            {
                string sql = "SELECT * FROM t_Test";
                List<object> fields = db.Query<object>(sql).ToList();
            }

        }

        private void DataBaseList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnChoose_Click(sender, e);
        }
    }
}
