using Oracle.ManagedDataAccess.Client;
using SIEVE.Infrastructure.Models.PSM;
using SIEVE.Live.Database;
using SIEVE.Live.Oracle;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIEVE.Infrastructure.Services.PSM
{
    public class DoctService
    {
       private static IDatabaseExecutor executor = new Execute();
        dalCommon dalC = new dalCommon(new Execute());
      
        public EQResultClass<T> GetById<T>(string Id)
        {
            string sql = @"SELECT * FROM PSM_DEPT WHERE ID=@ID";
            List<object> inParams = new List<object>()
            {
                new SqlParameter(parameterName: "@ID", value: Id)
            };

            return executor.Query<T>(sql, inParams);
        }
        public static EQResultClass<T> GetAllByCenterId<T>(string CenterId)
        {
            List<object> inParams = new List<object>()
            {
                 new OracleParameter(parameterName: "CENTER_ID", type: OracleDbType.Varchar2, obj: CenterId, direction: ParameterDirection.Input)
            };
            string sql = @"SELECT D.* 
            FROM PSM_DOCT D
            JOIN PSM_DOCT_CENT DC ON D.DOCT_ID=DC.DOCT_ID AND DC.IS_ACTIVE=1
            WHERE D.IS_ACTIVE=1
            AND DC.CENTER_ID=:CENTER_ID";
            return executor.Query<T>(sql, inParams);
        }
        public EQResultClass<T> GetLikeName<T>(string Name)
        {
            List<object> inParams = new List<object>()
            {
                new SqlParameter(parameterName: "@DEPT_NAME", value: Name)
            };
            string sql = @"SELECT * FROM PSM_DEPT WHERE IS_ACTIVE=1 AND DEPT_NAME LIKE '%' + @DEPT_NAME + '%'";
            return executor.Query<T>(sql, inParams);
        }
        public EQResult_v1 Update(PSM_DEPT obj, string UserId)
        {
            string sql = string.Empty;
            List<object> inParams = new List<object>();
            if (string.IsNullOrWhiteSpace(obj.DEPT_ID))
            {
                string id = dalC.NextTableMaxToNumber("ID", "PSM_DEPT");
                inParams.Add(new SqlParameter(parameterName: "@ID", value: id));
                inParams.Add(new SqlParameter(parameterName: "@DEPT_NAME", value: obj.DEPT_NAME));
                inParams.Add(new SqlParameter(parameterName: "@CREATE_USER", value: UserId));

                sql = @"INSERT INTO PSM_DEPT(ID,DEPT_NAME,CREATE_USER)VALUES(@ID,@DEPT_NAME,@CREATE_USER)";
            }
            else
            {
                inParams.Add(new SqlParameter(parameterName: "@DEPT_NAME", value: obj.DEPT_NAME));
                inParams.Add(new SqlParameter(parameterName: "@UPDATE_USER", value: UserId));
                inParams.Add(new SqlParameter(parameterName: "@ID", value: obj.DEPT_ID));

                sql = $@"UPDATE PSM_DEPT SET DEPT_NAME=@DEPT_NAME,UPDATE_DATE=GetDate(),UPDATE_USER=@UPDATE_USER WHERE ID=@ID";
            }
            return executor.SaveChanges(sql, inParams);
        }
    }
}
