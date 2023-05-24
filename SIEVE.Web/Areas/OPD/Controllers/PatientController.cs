using SIEVE.Infrastructure.Models.OPD;
using SIEVE.Infrastructure.Services;
using SIEVE.Infrastructure.Services.OPD;
using SIEVE.Live.Database;
using SIEVE.Web.Areas.OPD.Models;
using SIEVE.Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SIEVE.Web.Areas.OPD.Controllers
{
    public class PatientController : Controller
    {

        private string UserId;
        private readonly PatientService patientService = new PatientService();
        public PatientController()
        {
            UserId = SessionHelper.GetByKey();
        }
        public ActionResult Index()
        {
            var Obj = new Models.OPD_PATIENT_VM();
            Obj.OPD_PATIENT = new List<OPD_PATIENT>();
            return View(Obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OPD_PATIENT_VM Obj)
        {
            EQResultClass<OPD_PATIENT> ObjList = patientService.GetLike<OPD_PATIENT>(Obj.MOBILE_NO,Obj.PAT_NAME);
            Obj.OPD_PATIENT = ObjList.Entity;
            return View(Obj);
        }
        public ActionResult Create(string id)
        {
            OPD_PATIENT Obj = new OPD_PATIENT();
            if (!string.IsNullOrWhiteSpace(id))
            {
                EQResultClass<OPD_PATIENT> dbObj = patientService.GetById<OPD_PATIENT>(id);
                if (dbObj.Result.SUCCESS && dbObj.Result.ROWS > 0)
                {
                    Obj = dbObj.Entity.First();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No Patient Info was found with your selection criteria");
                }
            }
            return View(Obj);
        }

        [HttpPost]
        public ActionResult Create(OPD_PATIENT Obj)
        {
            if (ModelState.IsValid)
            {
                EQResult_v1 dbObj = patientService.Update(Obj, UserId);
                if (dbObj.SUCCESS && dbObj.ROWS > 0)
                {
                    TempData["msg"] = AlertService.SaveSuccess("Patient Info is updated successfully");
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