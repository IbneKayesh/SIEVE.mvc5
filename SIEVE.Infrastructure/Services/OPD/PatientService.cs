using SIEVE.Infrastructure.Models.OPD;
using SIEVE.Live.Database;
using SIEVE.Live.Oracle;
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
                new SqlParameter("@PAT_NO", (object)obj.PAT_ID ?? DBNull.Value),
                new SqlParameter("@PAT_NAME",obj.PAT_NAME),
                new SqlParameter("@PAT_BONDING",obj.PAT_BONDING),
                new SqlParameter("@GENDER_ID",obj.GENDER_ID),
                new SqlParameter("@DATE_OF_BIRTH",(object)obj.DATE_OF_BIRTH ?? DBNull.Value),
                new SqlParameter("@PAT_ADDRESS_1",(object)obj.PAT_ADDRESS_1 ?? DBNull.Value),
                new SqlParameter("@PAT_ADDRESS_2",(object)obj.PAT_ADDRESS_2 ?? DBNull.Value),
                new SqlParameter("@MOBILE_NUMBER_1",(object)obj.MOBILE_NUMBER_1 ?? DBNull.Value),
                new SqlParameter("@MOBILE_NUMBER_2",(object)obj.MOBILE_NUMBER_2 ?? DBNull.Value),
                new SqlParameter("@EMAIL_ADDRESS_1",(object)obj.EMAIL_ADDRESS_1 ?? DBNull.Value),
                new SqlParameter("@EMAIL_ADDRESS_2",(object)obj.EMAIL_ADDRESS_2 ?? DBNull.Value),
                new SqlParameter("@BLOOD_GROUP",(object)obj.BLOOD_GROUP ?? DBNull.Value),
                new SqlParameter("@RELIGION",(object)obj.RELIGION ?? DBNull.Value),
                new SqlParameter("@RELATIONSHIP",(object)obj.RELATIONSHIP ?? DBNull.Value),
                new SqlParameter("@GUARDIAN_NAME",(object)obj.GUARDIAN_NAME ?? DBNull.Value),
                new SqlParameter("@GUARDIAN_MOBILE",(object)obj.GUARDIAN_MOBILE ?? DBNull.Value),
                new SqlParameter("@RELATION_WITH_GUARDIAN",(object)obj.RELATION_WITH_GUARDIAN ?? DBNull.Value),
                new SqlParameter("@DEPT_ID",(object)obj.DEPT_ID ?? DBNull.Value)
            };
            string sql = @"INSERT INTO OPD_PATIENT(ID,PAT_NO,PAT_NAME,PAT_BONDING,GENDER_ID,DATE_OF_BIRTH,PAT_ADDRESS_1,PAT_ADDRESS_2,MOBILE_NUMBER_1,MOBILE_NUMBER_2,EMAIL_ADDRESS_1,EMAIL_ADDRESS_2,BLOOD_GROUP,RELIGION,RELATIONSHIP,GUARDIAN_NAME,GUARDIAN_MOBILE,RELATION_WITH_GUARDIAN,DEPT_ID,CREATE_USER)VALUES(@ID,@PAT_NO,@PAT_NAME,@PAT_BONDING,@GENDER_ID,@DATE_OF_BIRTH,@PAT_ADDRESS_1,@PAT_ADDRESS_2,@MOBILE_NUMBER_1,@MOBILE_NUMBER_2,@EMAIL_ADDRESS_1,@EMAIL_ADDRESS_2,@BLOOD_GROUP,@RELIGION,@RELATIONSHIP,@GUARDIAN_NAME,@GUARDIAN_MOBILE,@RELATION_WITH_GUARDIAN,@DEPT_ID,@CREATE_USER)";
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
