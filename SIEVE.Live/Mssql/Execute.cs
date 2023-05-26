using SIEVE.Live.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIEVE.Live.Mssql
{
    public class Execute : IDatabaseExecutor
    {
        private readonly string connectionString;
        public Execute(string _connectionString = "default")
        {
            if (_connectionString == "default")
            {
                connectionString = ConfigurationManager.ConnectionStrings["ProdDbCon"].ConnectionString;
            }
            else
            {
                this.connectionString = ConfigurationManager.ConnectionStrings[_connectionString].ConnectionString; ;
            }
        }
        //Select
        public EQResultClass<T> Query<T>(string sql, List<object> paramList)
        {
            EQResult_v1 result = new EQResult_v1();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (paramList != null)
                {
                    cmd.Parameters.AddRange(paramList.ToArray());
                }
                cmd.CommandTimeout = int.MaxValue;
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                result.SUCCESS = false;
                result.MESSAGES = ex.Message;
                result.ROWS = 0;
                return new EQResultClass<T>() { Entity = new List<T>(), Result = result };
            }
            finally
            {
                con.Close();
            }
            result.ROWS = ds.Tables[0].Rows.Count;
            if (result.ROWS > 0)
            {
                result.MESSAGES = $"{result.ROWS} rows found";
                return new EQResultClass<T>()
                {
                    Entity = ConvertToList<T>(ds.Tables[0]),
                    Result = result
                };
            }
            else
            {
                result.MESSAGES = "No rows found";
                return new EQResultClass<T>()
                {
                    Entity = new List<T>(),
                    Result = result
                };
            }
        }
        public EQResultClass<T> SingleOrDefault<T>(string sql, List<object> paramList)
        {
            throw new NotImplementedException();
        }
        private List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            //return dt.AsEnumerable().Select(row =>
            //{
            //    var objT = Activator.CreateInstance<T>();
            //    foreach (var pro in properties)
            //    {
            //        if (columnNames.Contains(pro.Name))
            //        {
            //            PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
            //            pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
            //        }
            //    }
            //    return objT;
            //}).ToList();

            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        var value = row[pro.Name];
                        if (value == DBNull.Value)
                        {
                            pro.SetValue(objT, null);  // Assign null to nullable types
                        }
                        else
                        {
                            Type propertyType = pI.PropertyType;
                            propertyType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;  // Get the underlying type if propertyType is nullable
                            pro.SetValue(objT, Convert.ChangeType(value, propertyType));
                        }
                    }
                }
                return objT;
            }).ToList();
        }

        //Insert, Update, Delete
        public EQResult_v1 SaveChanges(string sql, List<object> paramList)
        {
            EQResult_v1 result = new EQResult_v1();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn;
            con.Open();
            cmd.Connection = con;
            cmd.CommandTimeout = int.MaxValue;
            trn = con.BeginTransaction();
            cmd.Transaction = trn;
            try
            {
                if (paramList != null || paramList.Count > 0)
                {
                    cmd.Parameters.AddRange(paramList.ToArray());
                }
                cmd.CommandText = sql;
                result.ROWS = cmd.ExecuteNonQuery();
                trn.Commit();
            }
            catch (SqlException ex)
            {
                trn.Rollback();
                result.SUCCESS = false;
                result.MESSAGES = ex.Message;
                result.ROWS = 0;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public EQResult_v1 SaveChanges(List<string> sqlList)
        {
            EQResult_v1 result = new EQResult_v1();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn;
            con.Open();
            cmd.Connection = con;
            cmd.CommandTimeout = int.MaxValue;
            trn = con.BeginTransaction();
            cmd.Transaction = trn;
            try
            {
                int r = 0;
                foreach (string _command in sqlList)
                {
                    cmd.CommandText = _command;
                    r += cmd.ExecuteNonQuery();
                }
                trn.Commit();

                result.SUCCESS = true;
                result.MESSAGES = AppKeys_v1.SUCCESS_MESSAGES;
                result.ROWS = r;
            }
            catch (SqlException ex)
            {
                trn.Rollback();
                result.SUCCESS = false;
                result.MESSAGES = ex.Message;
                result.ROWS = 0;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public EQResult_v1 SaveChanges(List<SQL_PLIST_v1> sqlList)
        {
            EQResult_v1 result = new EQResult_v1();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn;
            con.Open();
            cmd.Connection = con;
            cmd.CommandTimeout = int.MaxValue;
            trn = con.BeginTransaction();
            cmd.Transaction = trn;
            try
            {
                int r = 0;

                foreach (SQL_PLIST_v1 sf in sqlList)
                {
                    cmd.CommandText = sf.SQL;
                    if (sf.iPARAMS != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(sf.iPARAMS);
                        r += cmd.ExecuteNonQuery();
                    }
                }

                trn.Commit();

                result.SUCCESS = true;
                result.MESSAGES = AppKeys_v1.SUCCESS_MESSAGES;
                result.ROWS = r;
            }
            catch (SqlException ex)
            {
                trn.Rollback();
                result.SUCCESS = false;
                result.MESSAGES = ex.Message;
                result.ROWS = 0;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public EQResultTable_v1 Query(string sql, List<object> paramList)
        {
            EQResult_v1 result = new EQResult_v1();
            result.SUCCESS = true;
            result.MESSAGES = AppKeys_v1.SUCCESS_MESSAGES;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (paramList != null)
                {
                    cmd.Parameters.AddRange(paramList.ToArray());
                }
                cmd.CommandTimeout = int.MaxValue;
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                result.SUCCESS = false;
                result.MESSAGES = ex.Message;
                result.ROWS = 0;
                return new EQResultTable_v1() { Table = new DataTable(), Result = result };
            }
            finally
            {
                con.Close();
            }
            result.ROWS = ds.Tables[0].Rows.Count;
            return new EQResultTable_v1() { Table = ds.Tables[0], Result = result };
        }
    }
}
