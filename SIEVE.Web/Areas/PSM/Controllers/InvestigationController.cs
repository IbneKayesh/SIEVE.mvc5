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
    public class InvestigationController : Controller
    {

        private string UserId;
        public InvestigationController()
        {
            UserId = SessionHelper.GetByKey();
        }
        public ActionResult Index()
        {
            var Obj = new PSM_INVES_VM();          
            EQResultClass<PSM_INVES> ObjList = InvesService.GetAll<PSM_INVES>();
            Obj.PSM_INVES = ObjList.Entity;
            return View(Obj);
        }

        public ActionResult Create(string id)
        {
            Dropdown_Create();
            PSM_INVES obj = new PSM_INVES();
            if (!string.IsNullOrWhiteSpace(id))
            {
                EQResultClass<PSM_INVES> dbObj = InvesService.GetById<PSM_INVES>(id);
                if (dbObj.Result.SUCCESS && dbObj.Result.ROWS > 0)
                {
                    obj = dbObj.Entity.First();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No Info was found with your selection criteria");
                }
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(PSM_INVES Obj)
        {
            Dropdown_Create();
            if (ModelState.IsValid)
            {
                EQResult_v1 dbObj = InvesService.Update(Obj, UserId);
                if (dbObj.SUCCESS && dbObj.ROWS > 0)
                {
                    TempData["msg"] = AlertService.SaveSuccess("Information is updated successfully");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbObj.MESSAGES);
                }
            }
            return View(Obj);
        }
        private void Dropdown_Create()
        {
            EQResultClass<PSM_INVES_CAT> ObjList = InvesCategoryService.GetAll<PSM_INVES_CAT>();
            ViewBag.CAT_ID = new SelectList(ObjList.Entity, "CAT_ID", "CAT_NAME");
        }
        
    }
}