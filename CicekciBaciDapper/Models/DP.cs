using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CicekciBaciDapper.Models
{
    public static class DP
    {
        private static string connectionString = "Server = LAPTOP-DI6H08K1; Database = CicekciBaci; Integrated Security= true;";

        public static void ExReturn(string procadi, DynamicParameters param= null)
        {
            using (SqlConnection baglan =  new SqlConnection(connectionString))
            {
                baglan.Open();
                baglan.Execute(procadi, param, commandType:CommandType.StoredProcedure);
            }
        }
        public static IEnumerable<T> ReturnList<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglan = new SqlConnection(connectionString))
            {
                baglan.Open();
                return baglan.Query<T>(procadi, param, commandType: CommandType.StoredProcedure);

            }
        }
    }
}