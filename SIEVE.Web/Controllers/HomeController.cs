using SIEVE.Infrastructure.Services.AA;
using SIEVE.Live.Database;
using SIEVE.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SIEVE.Web.Controllers
{
    public class HomeController : Controller
    {
        private MenuService menuService = new MenuService();
        public ActionResult Index()
        {
            SideBar();
            return View();
        }

        public void SideBar()
        {
            //if (Session["uRole"] == null)
            //{
            //    return;
            //}
            List<APP_MENU> objList = new List<APP_MENU>();
            if (Session["_menu"] != null && Session["_menu"] is List<APP_MENU>)
            {
                //need to check user role
                objList = (List<APP_MENU>)Session["_menu"];
                return;
            }
            else
            {
                //EQResultClass<APP_MENU> dbObj = menuService.getByRoleId<APP_MENU>(Session["uRole"].ToString());
                EQResultClass<APP_MENU> dbObj = menuService.getByRoleId<APP_MENU>("ADMIN");
                if (dbObj.Result.SUCCESS && dbObj.Result.ROWS > 0)
                {
                    objList = dbObj.Entity;
                }
                Session["_menu"] = objList.OrderBy(x => x.PARENT_ID).OrderBy(x => x.MENU_ORDER).ToList();
            }
        }
    }
}