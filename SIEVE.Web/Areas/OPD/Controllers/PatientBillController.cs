using SIEVE.Infrastructure.Models.OPD;
using SIEVE.Infrastructure.Services.OPD;
using SIEVE.Live.Database;
using SIEVE.Web.Controllers;
using System.Web.Mvc;

namespace SIEVE.Web.Areas.OPD.Controllers
{
    public class PatientBillController : Controller
    {
        private string UserId;
        private readonly BillMasterService billMasterService = new BillMasterService();
        public PatientBillController()
        {
            UserId = SessionHelper.GetByKey();
        }
        public ActionResult Index()
        {
            EQResultClass<OPD_BILL_MASTER> ObjList = billMasterService.GetAllPending<OPD_BILL_MASTER>();
            return View(ObjList.Entity);
        }
        public ActionResult AddBillService()
        {
            OPD_BILL_MASTER Obj = new OPD_BILL_MASTER();
            return View(Obj);
        }
    }
}