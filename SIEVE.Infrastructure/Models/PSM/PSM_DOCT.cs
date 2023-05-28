using System.ComponentModel.DataAnnotations;

namespace SIEVE.Infrastructure.Models.PSM
{
    public class PSM_DOCT : TABLE_COMMON
    {
        [Display(Name = "Doct Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string DOCT_ID { get; set; }


        [Display(Name = "Doct Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string DOCT_NAME { get; set; }
    }
}
