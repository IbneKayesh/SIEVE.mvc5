using SIEVE.Infrastructure.Models.OPD;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIEVE.Web.Areas.OPD.Models
{
    public class OPD_PATIENT_VM
    {

        [Display(Name = "Mobile")]
        public string MOBILE_NO { get; set; }

        [Display(Name = "Patient Name")]
        public string PAT_NAME { get; set; }

        public List<OPD_PATIENT> OPD_PATIENT { get; set; }
        
    }
}