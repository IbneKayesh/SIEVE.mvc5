using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIEVE.Web.Controllers
{
    public class ErrorController : Controller
    {
        string userId = "";
        public ActionResult Index()
        {
            return View("Error");
        }
        public ActionResult NotFound(string aspxerrorpath)
        {
            if (aspxerrorpath == "/bundles/jqueryval")
            {
                return View("NotFound");
            }
            userId = (string)Session["uUserId"];
            userId = string.IsNullOrWhiteSpace(userId) ? "NA" : userId;
            //EQResult_v1 dbObj = Services.Admin.ErrService.Update("NotFound", aspxerrorpath, userId);
            return View("NotFound");
        }

        public ActionResult InternalServerError()
        {
            return View("InternalServerError");
        }
    }
}