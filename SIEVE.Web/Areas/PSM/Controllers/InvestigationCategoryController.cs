using SIEVE.Infrastructure.Models.PSM;
using SIEVE.Infrastructure.Services;
using SIEVE.Infrastructure.Services.PSM;
using SIEVE.Live.Database;
using SIEVE.Web.Areas.PSM.Models;
using SIEVE.Web.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace SIEVE.Web.Areas.PSM.Controllers
{
    public class InvestigationCategoryController : Controller
    {
        private string UserId;
        private readonly InvesCategoryService invesCategory = new InvesCategoryService();
        public InvestigationCategoryController()
        {
            UserId = SessionHelper.GetByKey();
        }
        public ActionResult Index()
        {
            var Obj = new PSM_INVES_CATEGORY_VM();
            EQResultClass<PSM_INVES_CATEGORY> ObjList = invesCategory.GetAll<PSM_INVES_CATEGORY>();
            Obj.PSM_INVES_CATEGORY = ObjList.Entity;
            return View(Obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PSM_INVES_CATEGORY_VM Obj)
        {
            EQResultClass<PSM_INVES_CATEGORY> ObjList = invesCategory.GetLikeName<PSM_INVES_CATEGORY>(Obj.CATEGORY_NAME);
            Obj.PSM_INVES_CATEGORY = ObjList.Entity;
            return View(Obj);
        }
        public ActionResult Create(string id)
        {
            PSM_INVES_CATEGORY obj = new PSM_INVES_CATEGORY();
            if (!string.IsNullOrWhiteSpace(id))
            {
                EQResultClass<PSM_INVES_CATEGORY> dbObj = invesCategory.GetById<PSM_INVES_CATEGORY>(id);
                if (dbObj.Result.SUCCESS && dbObj.Result.ROWS > 0)
                {
                    obj = dbObj.Entity.First();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No Category Info was found with your selection criteria");
                }
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(PSM_INVES_CATEGORY Obj)
        {
            if (ModelState.IsValid)
            {
                EQResult_v1 dbObj = invesCategory.Update(Obj, UserId);
                if (dbObj.SUCCESS && dbObj.ROWS > 0)
                {
                    TempData["msg"] = AlertService.SaveSuccess("Category Info is updated successfully");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbObj.MESSAGES);
                }
            }
            return View(Obj);
        }
    }
}