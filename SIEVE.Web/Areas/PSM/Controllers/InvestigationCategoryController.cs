﻿using SIEVE.Infrastructure.Models.PSM;
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
        public InvestigationCategoryController()
        {
            UserId = SessionHelper.GetByKey();
        }
        public ActionResult Index()
        {
            var Obj = new PSM_INVES_CATEGORY_VM();
            EQResultClass<PSM_INVES_CAT> ObjList = InvesCategoryService.GetAll<PSM_INVES_CAT>();
            Obj.PSM_INVES_CATEGORY = ObjList.Entity;
            return View(Obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PSM_INVES_CATEGORY_VM Obj)
        {
            EQResultClass<PSM_INVES_CAT> ObjList = InvesCategoryService.GetLikeName<PSM_INVES_CAT>(Obj.CAT_NAME);
            Obj.PSM_INVES_CATEGORY = ObjList.Entity;
            return View(Obj);
        }
        public ActionResult Create(string id)
        {
            PSM_INVES_CAT obj = new PSM_INVES_CAT();
            if (!string.IsNullOrWhiteSpace(id))
            {
                EQResultClass<PSM_INVES_CAT> dbObj = InvesCategoryService.GetById<PSM_INVES_CAT>(id);
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
        public ActionResult Create(PSM_INVES_CAT Obj)
        {
            if (ModelState.IsValid)
            {
                EQResult_v1 dbObj = InvesCategoryService.Update(Obj, UserId);
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