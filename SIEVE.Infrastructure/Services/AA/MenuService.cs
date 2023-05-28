using Oracle.ManagedDataAccess.Client;
using SIEVE.Live.Database;
using SIEVE.Live.Oracle;
using System.Collections.Generic;
using System.Data;

namespace SIEVE.Infrastructure.Services.AA
{
    public class MenuService
    {
       private static IDatabaseExecutor executor = new Execute();
        public static EQResultClass<T> getByRoleId<T>(string RoleId)
        {
            List<object> inParams = new List<object>()
            {
                 new OracleParameter(parameterName: "ROLE_ID", type: OracleDbType.Varchar2, obj: RoleId, direction: ParameterDirection.Input)
            };
            string sql = @"SELECT M.MENU_ID MODULE_ID,M.MENU_NAME_EN MODULE_NAME_EN,M.MENU_NAME_BN MODULE_NAME_BN,M.MENU_ICON MODULE_ICON,M.VIEW_ORDER MODULE_ORDER,PA.MENU_ID PARENT_ID,PA.MENU_NAME_EN PARENT_NAME_EN,PA.MENU_NAME_BN PARENT_NAME_BN,PA.MENU_ICON PARENT_ICON,PA.VIEW_ORDER PARENT_ORDER,ME.MENU_ID,ME.MENU_NAME_EN,ME.MENU_NAME_BN,ME.MENU_ICON,ME.AREA_NAME,ME.CONTROLLER_NAME,ME.ACTION_NAME,ME.VIEW_ORDER MENU_ORDER
            FROM APP_MENU M
            JOIN APP_MENU PA ON PA.PARENT_ID=M.MENU_ID AND PA.IS_ACTIVE=1 AND PA.PARENT_ID!=0 AND PA.CONTROLLER_NAME='PARENT'
            JOIN APP_MENU ME ON PA.MENU_ID=ME.PARENT_ID AND ME.IS_ACTIVE=1
            JOIN APP_MR MR ON ME.MENU_ID=MR.MENU_ID AND MR.IS_ACTIVE=1 AND MR.ROLE_ID=:ROLE_ID
            WHERE M.IS_ACTIVE=1 AND M.PARENT_ID=0 AND M.CONTROLLER_NAME='MODULE' ORDER BY M.VIEW_ORDER,PA.VIEW_ORDER,ME.VIEW_ORDER";
            return executor.Query<T>(sql, inParams);
        }

    }
}
