using System.ComponentModel.DataAnnotations;

namespace SIEVE.Infrastructure.Models.PSM
{
    public class PSM_DEPT : TABLE_COMMON
    {
        [Display(Name = "Dept Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string DEPT_ID { get; set; }

        [Display(Name = "Dept Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 10)]
        public string DEPT_NAME { get; set; }

        [Display(Name = "Dept Address")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string DEPT_ADDRESS { get; set; }

        [Display(Name = "Hotline")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string HOT_LINE { get; set; }

        [Display(Name = "Center Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string CENTER_ID { get; set; }

        [Display(Name = "Cat Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string CAT_ID { get; set; }
    }
}
