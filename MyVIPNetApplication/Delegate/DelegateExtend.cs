using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Delegate
{


    /// <summary>
    /// Action 就是一个委托
    /// </summary>
    public static class DelegateExtend
    {
        public static void SafeInvoke(this Action act)
        {
            try
            {
                act.Invoke();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }


        /*
         委托的数据库调用方式，
         1.实现了对象的返回
         2.事务的开始，提交，回滚
         3.泛型
         4.T在这里是一个返回值
        */

        public static T Excute<T>(string sql, Func<SqlCommand, T> fun)
        {
            using (SqlConnection conn = new SqlConnection(""))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    SqlCommand command = new SqlCommand(sql,conn);

                    T t = fun(command);

                    trans.Commit();
                    return t;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    trans.Rollback();
                    throw ex;
                }
            }
        }
    }
}
