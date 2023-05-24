using SIEVE.Live.Database;
using SIEVE.Live.Mssql;
using System;

namespace SIEVE.Infrastructure.Services
{
    public class dalCommon
    {
        IDatabaseExecutor executor;
        public dalCommon(Execute execute)
        {
            executor = execute;
        }
        string sql = "";
        public string NextTableMaxNumber(string idColumn, string tableName)
        {
            sql = $"select max({idColumn})max_id from {tableName}";
            EQResultTable_v1 obj = executor.Query(sql, new System.Collections.Generic.List<object>());
            if (obj.Result.ROWS == 1)
            {
                return (Convert.ToInt32(obj.Table.Rows[0]["max_id"]) + 1).ToString();
            }
            return "0";
        }
        public string NextTableMaxToNumber(string idColumn, string tableName)
        {
            //Msssql
            sql = $"select max({idColumn})max_id from {tableName}";

            //Oracle
            //sql = $"select max(to_number({idColumn}))max_id from {tableName}";

            EQResultTable_v1 obj = executor.Query(sql, new System.Collections.Generic.List<object>());
            if (obj.Result.ROWS == 1)
            {
                return (Convert.ToInt32(obj.Table.Rows[0]["max_id"]) + 1).ToString();
            }
            return "0";
        }
    }
}
