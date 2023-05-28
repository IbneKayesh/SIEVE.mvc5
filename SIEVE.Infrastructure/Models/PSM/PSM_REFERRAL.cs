using System.ComponentModel.DataAnnotations;

namespace SIEVE.Infrastructure.Models.PSM
{
    public class PSM_REFERRAL
    {
        [Display(Name = "Center Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string CENTER_ID { get; set; }

        [Display(Name = "Referral Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string REFERRAL_ID { get; set; }

        [Display(Name = "Referral Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 10)]
        public string REFERRAL_NAME { get; set; }
    }
}
