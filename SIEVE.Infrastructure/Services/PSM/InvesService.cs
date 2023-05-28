
using Oracle.ManagedDataAccess.Client;
using SIEVE.Infrastructure.Models.PSM;
using SIEVE.Live.Database;
using SIEVE.Live.Oracle;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIEVE.Infrastructure.Services.PSM
{
    public class InvesService
    {
        private static IDatabaseExecutor executor = new Execute();
        private static dalCommon dalC = new dalCommon(new Execute());

        public static EQResultClass<T> GetByNameDeptIdDiscType<T>(string Name, string DeptId, string DiscType)
        {
            List<object> inParams = new List<object>()
            {
            new OracleParameter(parameterName: "DISC_TYPE", type: OracleDbType.Varchar2, obj: DiscType, direction: ParameterDirection.Input),
            new OracleParameter(parameterName: "DEPT_ID", type: OracleDbType.Varchar2, obj: DeptId, direction: ParameterDirection.Input),
            new OracleParameter(parameterName: "INVES_NAME", type: OracleDbType.Varchar2, obj: Name, direction: ParameterDirection.Input)
            };
            string sql = @"SELECT INV.INVES_ID,INV.INVES_NAME,NVL(DINV.INVES_RATE,INV.INVES_RATE)INVES_RATE,DINV.INVES_ROOM,NVL(INVD.DISC_PCT,0)DISC_PCT
            FROM PSM_INVES INV
            JOIN PSM_DEPT_INVES DINV ON INV.INVES_ID=DINV.INVES_ID AND DINV.IS_ACTIVE=1
            JOIN PSM_DEPT DPT ON DINV.DEPT_ID=DPT.DEPT_ID
            LEFT JOIN PSM_INVES_DISC INVD ON INV.INVES_ID=INVD.INVES_ID AND DPT.CENTER_ID=INVD.CENTER_ID AND INVD.IS_ACTIVE=1
            AND INVD.DISC_TYPE=:DISC_TYPE
            WHERE INV.IS_ACTIVE=1
            AND DINV.DEPT_ID=:DEPT_ID
            AND LOWER(INV.INVES_NAME) LIKE '%' || :INVES_NAME || '%'";

            return executor.Query<T>(sql, inParams);
        }


        public static EQResultClass<T> GetById<T>(string Id)
        {
            List<object> inParams = new List<object>()
            {
             new OracleParameter(parameterName: "INVES_ID", type: OracleDbType.Varchar2, obj: Id, direction: ParameterDirection.Input),
            };
            string sql = @"SELECT * FROM PSM_INVES WHERE INVES_ID=:INVES_ID";
            return executor.Query<T>(sql, inParams);
        }
        public static EQResultClass<T> GetAll<T>()
        {
            string sql = @"SELECT INV.*,C.CAT_NAME FROM PSM_INVES INV JOIN PSM_INVES_CAT C ON INV.CAT_ID=C.CAT_ID WHERE INV.IS_ACTIVE=1";
            return executor.Query<T>(sql, new List<object>());
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
        public static EQResult_v1 Update(PSM_INVES obj, string UserId)
        {
            string sql = string.Empty;
            List<object> inParams = new List<object>();
            if (string.IsNullOrWhiteSpace(obj.INVES_ID))
            {
                string id = dalC.NextTableMaxToNumber("INVES_ID", "PSM_INVES");

                inParams.Add(new OracleParameter(parameterName: "INVES_ID", type: OracleDbType.Varchar2, obj: id, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "INVES_NAME", type: OracleDbType.Varchar2, obj: obj.INVES_NAME, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "INVES_DESC", type: OracleDbType.Varchar2, obj: obj.INVES_DESC, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "INVES_RATE", type: OracleDbType.Varchar2, obj: obj.INVES_RATE, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "CAT_ID", type: OracleDbType.Varchar2, obj: obj.CAT_ID, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "UNIT_ID", type: OracleDbType.Varchar2, obj: obj.UNIT_ID, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "HAS_SAMPLE", type: OracleDbType.Varchar2, obj: obj.HAS_SAMPLE, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "CREATE_USER", type: OracleDbType.Varchar2, obj: UserId, direction: ParameterDirection.Input));
                sql = @"INSERT INTO PSM_INVES(INVES_ID,INVES_NAME,INVES_DESC,INVES_RATE,CAT_ID,UNIT_ID,HAS_SAMPLE,CREATE_USER)VALUES(:INVES_ID,:INVES_NAME,:INVES_DESC,:INVES_RATE,:CAT_ID,:UNIT_ID,:HAS_SAMPLE,:CREATE_USER)";
            }
            else
            {

                inParams.Add(new OracleParameter(parameterName: "INVES_RATE", type: OracleDbType.Varchar2, obj: obj.INVES_RATE, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "UPDATE_USER", type: OracleDbType.Varchar2, obj: obj.UPDATE_USER, direction: ParameterDirection.Input));
                inParams.Add(new OracleParameter(parameterName: "INVES_ID", type: OracleDbType.Varchar2, obj: obj.INVES_ID, direction: ParameterDirection.Input));
                sql = $@"UPDATE PSM_INVES SET INVES_RATE=:INVES_RATE,UPDATE_DATE=sysdate,UPDATE_USER=:UPDATE_USER WHERE INVES_ID=:INVES_ID";
            }
            return executor.SaveChanges(sql, inParams);
        }
    }
}
