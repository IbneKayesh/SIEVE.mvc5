using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEVE.Live.Database
{
    public interface IDatabaseExecutor
    {
        EQResultTable_v1 Query(string sql, List<object> paramList);
        EQResultClass<T> Query<T>(string sql, List<object> paramList);
        EQResultClass<T> SingleOrDefault<T>(string sql, List<object> paramList);
        EQResult_v1 SaveChanges(string sql, List<object> paramList);
        EQResult_v1 SaveChanges(List<string> sqlList);
        EQResult_v1 SaveChanges(List<SQL_PLIST_v1> sqlList);
    }
}
