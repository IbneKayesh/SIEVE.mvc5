using SIEVE.Infrastructure.Models.OPD;
using SIEVE.Infrastructure.Models.PSM;
using SIEVE.Infrastructure.Services.OPD;
using SIEVE.Infrastructure.Services.PSM;
using SIEVE.Live.Database;
using SIEVE.Web.Areas.OPD.Models;
using SIEVE.Web.Controllers;
using SIEVE.Web.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SIEVE.Web.Areas.OPD.Controllers
{
    public class PatientBillController : Controller
    {
        private string UserId;
        private string CenterId;
        private readonly BillMasterService billMasterService = new BillMasterService();
        //private readonly DeptService deptService = new DeptService();
        //private readonly InvesService invesService = new InvesService();
        //private readonly DoctService doctService = new DoctService();
        //private readonly ReferralService referralService = new ReferralService();
        public PatientBillController()
        {
            UserId = SessionHelper.GetByKey();
            CenterId = SessionHelper.GetByKey("CenterId");
        }
        public ActionResult Index()
        {
            EQResultClass<OPD_BILL_MASTER> ObjList = billMasterService.GetAllPending<OPD_BILL_MASTER>(UserId);
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
            EQResultClass<PSM_DEPT> ObjList = DeptService.GetBillDeptByUserId<PSM_DEPT>(UserId);
            ViewBag.BILL_DEPT_ID = new SelectList(ObjList.Entity, "DEPT_ID", "DEPT_NAME");

            EQResultClass<PSM_DEPT> ObjList1 = DeptService.GetSaleDeptByUserId<PSM_DEPT>(UserId);
            ViewBag.SALE_DEPT_ID = new SelectList(ObjList.Entity, "DEPT_ID", "DEPT_NAME");

            ViewBag.DISC_TYPE = SelectListService.GetDiscType();
            ViewBag.GENDER_ID = SelectListService.GetGender();

            EQResultClass<PSM_REFERRAL> ObjList2 = ReferralService.GetAllByCenterId<PSM_REFERRAL>(CenterId);
            ViewBag.REFERRAL_ID = ObjList2.Entity.Select(s => new SelectListItem() { Text = s.REFERRAL_NAME, Value = s.REFERRAL_ID }).ToList();

            EQResultClass<PSM_DOCT> ObjList3 = DoctService.GetAllByCenterId<PSM_DOCT>(CenterId);
            ViewBag.DOCT_ID = ObjList3.Entity.Select(s => new SelectListItem() { Text = s.DOCT_NAME, Value = s.DOCT_ID }).ToList();
        }


        [HttpPost]
        public JsonResult GetItems1(string name, string deptId, string discType)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(deptId) ||
                string.IsNullOrWhiteSpace(discType)
               )
            {
                return Json(new List<PSM_INVES_DISC_VM>(), JsonRequestBehavior.AllowGet);
            }
            EQResultClass<PSM_INVES_DISC_VM> ObjList = InvesService.GetByNameDeptIdDiscType<PSM_INVES_DISC_VM>(name, deptId, discType);
            return Json(ObjList.Entity, JsonRequestBehavior.AllowGet);
            //if (!string.IsNullOrWhiteSpace(itemId))
            //{
            //    userId = (string)Session["uUserId"];
            //    

            //    objList = SevEF_v1.ConvertToList<TNDR_ITEM_MASTER>(dbObj.Table);

            //    return Json(objList, JsonRequestBehavior.AllowGet);
            //}
            ////var Name = (from N in autoList select new { N.Name });
        }



        public ActionResult Payment(string id)
        {
            return View();
        }






        public ActionResult AddBillService()
        {
            OPD_BILL_MASTER Obj = new OPD_BILL_MASTER();

            Dropdown_Create();
            return View(Obj);
        }
    }
}