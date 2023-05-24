using SIEVE.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIEVE.Web.Controllers
{
    public static class SessionHelper
    {
        public static void SetUserSession(USER_SESSION_DATA userSessionData)
        {
            HttpContext.Current.Session["userSessionData"] = userSessionData;
        }

        public static USER_SESSION_DATA GetUserSession()
        {
            return HttpContext.Current.Session["userSessionData"] as USER_SESSION_DATA;
        }
        public static bool IsPermittedMenu(int menuId)
        {
            List<APP_MENU> objList = HttpContext.Current.Session["_menu"] as List<APP_MENU>;
            return objList.Where(x => x.MENU_ID == menuId).Any();
        }
        public static string GetByKey(string Key= "UserId")
        {
            return HttpContext.Current.Session[Key]?.ToString() ?? "KAYESH";
        }
    }
}