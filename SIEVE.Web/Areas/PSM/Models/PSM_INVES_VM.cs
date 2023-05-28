using SIEVE.Infrastructure.Models.PSM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIEVE.Web.Areas.PSM.Models
{
    public class PSM_INVES_VM
    {

        [Display(Name = "Category")]
        public string CAT_ID { get; set; }
        public List<PSM_INVES> PSM_INVES { get; set; }
    }
}