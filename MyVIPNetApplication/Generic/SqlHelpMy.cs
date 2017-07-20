using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Generic
{
    /*ORM实现一个查询的封装，用到泛型 反射*/
    public class SqlHelpMy
    {
        public T Find<T>(int id) where T : ModeBase
        {
            Type type = typeof(T);

            string columnString = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]", p.Name)));

            string sql = string.Format("SELECT {0} FROM [{1}] WHERE Id = {2}", columnString, type.Name, id);

            T t = (T)Activator.CreateInstance(type);

            using (SqlConnection conn = new SqlConnection(""))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    foreach (var propetry in type.GetProperties())
                    {
                        if(dataReader[propetry.Name] != DBNull.Value)
                        {
                            propetry.SetValue(t, dataReader[propetry.Name]);
                        }
                    }
                }
            }
            return t;

        }
    }
}
