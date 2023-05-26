using SIEVE.Infrastructure.Models.OPD;
using SIEVE.Infrastructure.Models.PSM;
using SIEVE.Infrastructure.Services.OPD;
using SIEVE.Infrastructure.Services.PSM;
using SIEVE.Live.Database;
using SIEVE.Web.Controllers;
using SIEVE.Web.Extension;
using System.Web.Mvc;

namespace SIEVE.Web.Areas.OPD.Controllers
{
    public class PatientBillController : Controller
    {
        private string UserId;
        private readonly BillMasterService billMasterService = new BillMasterService();
        private readonly DeptService deptService = new DeptService();
        public PatientBillController()
        {
            UserId = SessionHelper.GetByKey();
        }
        public ActionResult Index()
        {
            EQResultClass<OPD_BILL_MASTER> ObjList = billMasterService.GetAllPending<OPD_BILL_MASTER>();
            return View(ObjList.Entity);
        }
        public ActionResult NewBillService()
        {
            OPD_BILL_MASTER Obj = new OPD_BILL_MASTER();

            Dropdown_Create();
            return View(Obj);
        }
        [HttpPost]
        public ActionResult NewBillService(OPD_BILL_MASTER obj)
        {
            OPD_BILL_MASTER Obj = new OPD_BILL_MASTER();

            Dropdown_Create();
            return View(Obj);
        }
        private void Dropdown_Create()
        {
            EQResultClass<PSM_DEPT> ObjList = deptService.GetAll<PSM_DEPT>();
            ViewBag.BILL_DEPT_ID = new SelectList(ObjList.Entity, "ID", "DEPT_NAME");
            ViewBag.GENDER_ID = SelectListService.GetGender();
        }











        public ActionResult AddBillService()
        {
            OPD_BILL_MASTER Obj = new OPD_BILL_MASTER();

            Dropdown_Create();
            return View(Obj);
        }
    }
}