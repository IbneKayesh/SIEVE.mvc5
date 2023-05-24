using SIEVE.Infrastructure.Models.OPD;
using SIEVE.Live.Database;
using SIEVE.Live.Mssql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SIEVE.Infrastructure.Services.OPD
{
    public class PatientService
    {
        IDatabaseExecutor executor = new Execute();
        dalCommon dalC = new dalCommon(new Execute());
        public EQResultClass<T> GetById<T>(string Id)
        {
            string sql = @"SELECT * FROM OPD_PATIENT WHERE ID=@ID";
            List<object> inParams = new List<object>()
            {
                new SqlParameter(parameterName: "@ID", value: Id)
            };

            return executor.Query<T>(sql, inParams);
        }
        //public EQResultClass<T> GetAll<T>()
        //{
        //    string sql = @"SELECT * FROM OPD_PATIENT WHERE IS_ACTIVE=1";
        //    return executor.Query<T>(sql, new List<object>());
        //}
        public EQResultClass<T> GetLike<T>(string MOBILE_NO, string PAT_NAME)
        {
            var criteria = new List<string>();
            List<object> inParams = new List<object>();

            if (!string.IsNullOrWhiteSpace(MOBILE_NO))
            {
                criteria.Add("MOBILE_NO LIKE '%' + @MOBILE_NO + '%'");
                inParams.Add(new SqlParameter(parameterName: "@MOBILE_NO", value: MOBILE_NO));
            }
            if (!string.IsNullOrWhiteSpace(PAT_NAME))
            {
                criteria.Add("PAT_NAME LIKE '%' + @PAT_NAME + '%'");
                inParams.Add(new SqlParameter(parameterName: "@PAT_NAME", value: PAT_NAME));
            }
            var criteriaString = criteria.Any() ? $"AND {string.Join(" AND ", criteria)}" : "";

            string sql = $@"SELECT * FROM OPD_PATIENT T WHERE T.IS_ACTIVE=1 {criteriaString} ";
            return executor.Query<T>(sql, inParams);
        }
        public EQResult_v1 Update(OPD_PATIENT obj, string UserId)
        {
            string id = dalC.NextTableMaxToNumber("ID", "OPD_PATIENT");
            List<object> inParams = new List<object>
            {
                new SqlParameter("@ID", id),
                new SqlParameter("@CREATE_USER", UserId),
                new SqlParameter("@PAT_ID", (object)obj.PAT_ID ?? DBNull.Value),
                new SqlParameter("@MOBILE_NO", (object)obj.MOBILE_NO ?? DBNull.Value),
                new SqlParameter("@PAT_NAME", (object)obj.PAT_NAME ?? DBNull.Value)
            };

            string sql = @"INSERT INTO OPD_PATIENT (ID, PAT_ID, MOBILE_NO, PAT_NAME, CREATE_USER)VALUES (@ID, @PAT_ID, @MOBILE_NO, @PAT_NAME, @CREATE_USER)";
            return executor.SaveChanges(sql, inParams);
        }

        //public EQResult_v1 Update(OPD_PATIENT obj, string UserId)
        //{
        //    string sql = string.Empty;
        //    List<object> inParams = new List<object>();
        //    if (string.IsNullOrWhiteSpace(obj.ID))
        //    {
        //        string id = dalC.NextTableMaxToNumber("ID", "OPD_PATIENT");
        //        inParams.Add(new SqlParameter(parameterName: "@ID", value: id));
        //        inParams.Add(new SqlParameter(parameterName: "@PAT_ID", value: obj.PAT_ID));
        //        inParams.Add(new SqlParameter(parameterName: "@MOBILE_NO", value: obj.MOBILE_NO));
        //        inParams.Add(new SqlParameter(parameterName: "@PAT_NAME", value: obj.PAT_NAME));

        //        inParams.Add(new SqlParameter(parameterName: "@CREATE_USER", value: UserId));

        //        sql = @"INSERT INTO OPD_PATIENT(ID,PAT_ID,MOBILE_NO,PAT_NAME,CREATE_USER)VALUES(@ID,@PAT_ID,@MOBILE_NO,@PAT_NAME,@CREATE_USER)";
        //    }
        //    else
        //    {
        //        inParams.Add(new SqlParameter(parameterName: "@CATEGORY_NAME", value: obj.PAT_NAME));
        //        inParams.Add(new SqlParameter(parameterName: "@UPDATE_USER", value: UserId));
        //        inParams.Add(new SqlParameter(parameterName: "@ID", value: obj.ID));

        //        sql = $@"UPDATE OPD_PATIENT SET CATEGORY_NAME=@CATEGORY_NAME,UPDATE_DATE=GetDate(),UPDATE_USER=@UPDATE_USER WHERE ID=@ID";
        //    }
        //    return executor.SaveChanges(sql, inParams);
        //}
    }
}
