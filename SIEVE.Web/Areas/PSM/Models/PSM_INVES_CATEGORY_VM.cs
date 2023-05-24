using SIEVE.Infrastructure.Models.PSM;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIEVE.Web.Areas.PSM.Models
{
    public class PSM_INVES_CATEGORY_VM
    {

        [Display(Name = "Category Name")]
        public string CATEGORY_NAME { get; set; }
        public List<PSM_INVES_CATEGORY> PSM_INVES_CATEGORY { get; set; }
    }
}