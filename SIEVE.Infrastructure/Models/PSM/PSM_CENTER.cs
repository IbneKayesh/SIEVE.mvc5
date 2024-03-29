﻿using System.ComponentModel.DataAnnotations;

namespace SIEVE.Infrastructure.Models.PSM
{
    public class PSM_CENTER : TABLE_COMMON
    {
        [Display(Name = "Center Id")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string CENTER_ID { get; set; }


        [Display(Name = "Center Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 10)]
        public string CENTER_NAME { get; set; }
    }
}
