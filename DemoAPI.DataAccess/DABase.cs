using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.DataAccess
{
    public class DABase
    {
        protected string GetSqlInsert<T>(T collection)
        {
            string sqlInsertEmployee = "INSERT INTO " + collection.GetType().Name + " (";
            foreach (var item in collection.GetType().GetProperties())
            {
                sqlInsertEmployee += (item.Name != "Id" && item.Name != "IsUsed") ? item.Name + "," : string.Empty;
            }
            sqlInsertEmployee = sqlInsertEmployee.Substring(0, sqlInsertEmployee.Length - 1);
            sqlInsertEmployee += ") VALUES (";
            foreach (var item in collection.GetType().GetProperties())
            {
                sqlInsertEmployee += (item.Name != "Id" && item.Name != "IsUsed") ? "@" + item.Name + "," : string.Empty;
            }
            sqlInsertEmployee = sqlInsertEmployee.Substring(0, sqlInsertEmployee.Length - 1);
            sqlInsertEmployee += ")";
            return sqlInsertEmployee;
        }
    }
}
