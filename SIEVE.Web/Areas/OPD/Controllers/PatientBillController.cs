using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIEVE.Web.Areas.OPD.Controllers
{
    public class PatientBillController : Controller
    {
        // GET: OPD/PatientBill
        public ActionResult Index()
        {
            return View();
        }
    }
}