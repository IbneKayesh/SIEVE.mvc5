using SIEVE.Infrastructure.Models.PSM;
using SIEVE.Live.Database;
using SIEVE.Live.Oracle;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SIEVE.Infrastructure.Services.PSM
{
    public class InvesCategoryService
    {
      private static  IDatabaseExecutor executor = new Execute();
       private static dalCommon dalC = new dalCommon(new Execute());
        public static EQResultClass<T> GetById<T>(string Id)
        {
            string sql = @"SELECT * FROM PSM_INVES_CATEGORY WHERE ID=@ID";
            List<object> inParams = new List<object>()
            {
                new SqlParameter(parameterName: "@ID", value: Id)
            };

            return executor.Query<T>(sql, inParams);
        }
        public static EQResultClass<T> GetAll<T>()
        {
            string sql = @"SELECT * FROM PSM_INVES_CAT WHERE IS_ACTIVE=1";
            return executor.Query<T>(sql, new List<object>());
        }
        public static EQResultClass<T> GetLikeName<T>(string Name)
        {
            List<object> inParams = new List<object>()
            {
                new SqlParameter(parameterName: "@CATEGORY_NAME", value: Name)
            };
            string sql = @"SELECT * FROM PSM_INVES_CATEGORY WHERE IS_ACTIVE=1 AND CATEGORY_NAME LIKE '%' + @CATEGORY_NAME + '%'";
            return executor.Query<T>(sql, inParams);
        }
        public static EQResult_v1 Update(PSM_INVES_CAT obj, string UserId)
        {
            string sql = string.Empty;
            List<object> inParams = new List<object>();
            if (string.IsNullOrWhiteSpace(obj.CAT_ID))
            {
                string id = dalC.NextTableMaxToNumber("ID", "PSM_INVES_CATEGORY");
                inParams.Add(new SqlParameter(parameterName: "@ID", value: id));
                inParams.Add(new SqlParameter(parameterName: "@CATEGORY_NAME", value: obj.CAT_NAME));
                inParams.Add(new SqlParameter(parameterName: "@CREATE_USER", value: UserId));

                sql = @"INSERT INTO PSM_INVES_CATEGORY(ID,CATEGORY_NAME,CREATE_USER)VALUES(@ID,@CATEGORY_NAME,@CREATE_USER)";
            }
            else
            {
                inParams.Add(new SqlParameter(parameterName: "@CATEGORY_NAME", value: obj.CAT_NAME));
                inParams.Add(new SqlParameter(parameterName: "@UPDATE_USER", value: UserId));
                inParams.Add(new SqlParameter(parameterName: "@ID", value: obj.CAT_ID));

                sql = $@"UPDATE PSM_INVES_CATEGORY SET CATEGORY_NAME=@CATEGORY_NAME,UPDATE_DATE=GetDate(),UPDATE_USER=@UPDATE_USER WHERE ID=@ID";
            }
            return executor.SaveChanges(sql, inParams);
        }
    }
}
