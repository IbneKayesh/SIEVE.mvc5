using System.ComponentModel.DataAnnotations;

namespace SIEVE.Infrastructure.Models.PSM
{
    public class PSM_DEPT_CATEGORY
    {
        public string ID { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string CATEGORY_NAME { get; set; }
    }
}
