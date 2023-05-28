using Oracle.ManagedDataAccess.Client;
using SIEVE.Infrastructure.Models.PSM;
using SIEVE.Live.Database;
using SIEVE.Live.Oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SIEVE.Infrastructure.Services.PSM
{
    public class ReferralService
    {
        private static IDatabaseExecutor executor = new Execute();
        dalCommon dalC = new dalCommon(new Execute());
        public  EQResultClass<T> GetById<T>(string Id)
        {
            List<object> inParams = new List<object>()
            {
                 new OracleParameter(parameterName: "REFERRAL_ID", type: OracleDbType.Varchar2, obj: Id, direction: ParameterDirection.Input)
            };
            string sql = @"SELECT * FROM PSM_REFERRAL WHERE REFERRAL_ID=:REFERRAL_ID";
            return executor.Query<T>(sql, inParams);
        }
        public static EQResultClass<T> GetAllByCenterId<T>(string CenterId)
        {
            List<object> inParams = new List<object>()
            {
                 new OracleParameter(parameterName: "CENTER_ID", type: OracleDbType.Varchar2, obj: CenterId, direction: ParameterDirection.Input)
            };
            string sql = @"SELECT * FROM PSM_REFERRAL WHERE IS_ACTIVE=1 AND CENTER_ID=:CENTER_ID";
            return executor.Query<T>(sql, inParams);
        }
        public EQResultClass<T> GetLikeName<T>(string Name)
        {
            var criteria = new List<string>();
            List<object> inParams = new List<object>()
            {
                new OracleParameter(parameterName: "REFERRAL_ID", type: OracleDbType.Varchar2, obj: Name, direction: ParameterDirection.Input)
            };
            criteria.Add("LOWER(REFERRAL_NAME) LIKE '%' || :REFERRAL_NAME || '%'");

            //Generate SQL
            var criteriaString = criteria.Any() ? $"AND {string.Join(" AND ", criteria)}" : "";
            string sql = $@"SELECT * FROM PSM_REFERRAL WHERE IS_ACTIVE=1 {criteriaString}";
            return executor.Query<T>(sql, inParams);
        }
        public EQResult_v1 Update(PSM_REFERRAL obj, string UserId)
        {
            string sql = string.Empty;
            List<object> inParams = new List<object>();
            if (string.IsNullOrWhiteSpace(obj.REFERRAL_ID))
            {
                string id = Guid.NewGuid().ToString();
                new OracleParameter(parameterName: "CENTER_ID", type: OracleDbType.Varchar2, obj: obj.CENTER_ID, direction: ParameterDirection.Input);
                new OracleParameter(parameterName: "REFERRAL_ID", type: OracleDbType.Varchar2, obj: id, direction: ParameterDirection.Input);
                new OracleParameter(parameterName: "REFERRAL_NAME", type: OracleDbType.Varchar2, obj: obj.REFERRAL_NAME, direction: ParameterDirection.Input);
                new OracleParameter(parameterName: "CREATE_USER", type: OracleDbType.Varchar2, obj: UserId, direction: ParameterDirection.Input);
                sql = @"INSERT INTO PSM_REFERRAL(CENTER_ID,REFERRAL_ID,REFERRAL_NAME,CREATE_USER)VALUES(:CENTER_ID,:REFERRAL_ID,:REFERRAL_NAME,:CREATE_USER)";
            }
            else
            {
                new OracleParameter(parameterName: "REFERRAL_NAME", type: OracleDbType.Varchar2, obj: obj.REFERRAL_NAME, direction: ParameterDirection.Input);
                new OracleParameter(parameterName: "UPDATE_USER", type: OracleDbType.Varchar2, obj: UserId, direction: ParameterDirection.Input);
                new OracleParameter(parameterName: "REFERRAL_ID", type: OracleDbType.Varchar2, obj: obj.REFERRAL_ID, direction: ParameterDirection.Input);

                sql = $@"UPDATE PSM_REFERRAL SET REFERRAL_NAME=:REFERRAL_NAME,UPDATE_DATE=sysdate,UPDATE_USER=:UPDATE_USER WHERE REFERRAL_ID=:REFERRAL_ID";
            }
            return executor.SaveChanges(sql, inParams);
        }
    }
}
