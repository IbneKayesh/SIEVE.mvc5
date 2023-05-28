using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_BILL_MASTER
    {
        public OPD_BILL_MASTER()
        {
            OPD_BILL_DETAIL = new List<OPD_BILL_DETAIL>();
            BILL_DATE = DateTime.Now;
        }
        public string BM_ID { get; set; }

        [Display(Name = "Bill To")]
        [Required(ErrorMessage = "{0} is required")]
        public string BILL_DEPT_ID { get; set; }

        [Display(Name = "Sale To")]
        [Required(ErrorMessage = "{0} is required")]
        [NotMapped]
        public string SALE_DEPT_ID { get; set; }

        [NotMapped]
        public string DEPT_NAME { get; set; }

        [Display(Name = "Discount Type")]
        [Required(ErrorMessage = "{0} is required")]
        public string DISC_TYPE { get; set; }


        [Display(Name = "Bill Date")]
        public DateTime BILL_DATE { get; set; }

        [Display(Name = "Patient Id")]
        [Required(ErrorMessage = "{0} is required")]
        public string PAT_ID { get; set; }

        [Display(Name = "Patient Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string PAT_NAME { get; set; }

        [Display(Name = "Mobile No")]
        [StringLength(maximumLength: 11, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string MOBILE_NO { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 11, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string PAT_AGE { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 4)]
        public string GENDER_ID { get; set; }

        [Display(Name = "Address")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string ADDRESS_1 { get; set; }

        [Display(Name = "Note")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string SALE_NOTE { get; set; }




        [Display(Name = "Staff Id")]
        //[Required(ErrorMessage = "{0} is required")]
        public string STAFF_ID { get; set; }

        [Display(Name = "Staff Name")]
        //[Required(ErrorMessage = "{0} is required")]
        public string STAFF_NAME { get; set; }

        [Display(Name = "Card No")]
        //[Required(ErrorMessage = "{0} is required")]
        public string STAFF_CARD { get; set; }

        /// <summary>
        /// 0 Due, 1 Cash, 2 Credit
        /// </summary>
        public int IS_CREDIT { get; set; } = 0;
        /// <summary>
        /// 0 Open, 1 Closed
        /// </summary>
        public int IS_CLOSED { get; set; } = 0;

        public List<OPD_BILL_DETAIL> OPD_BILL_DETAIL { get; set; }
        
    }
}
