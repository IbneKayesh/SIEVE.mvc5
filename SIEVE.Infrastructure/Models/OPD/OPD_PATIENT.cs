using System;
using System.ComponentModel.DataAnnotations;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_PATIENT
    {
        public OPD_PATIENT()
        {
            ID = "0";
            PAT_NO = "0";
        }
        public string ID { get; set; }

        [Display(Name = "Patient Id")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string PAT_NO { get; set; }

        [Display(Name = "Patient Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string PAT_NAME { get; set; }

        [Display(Name = "For")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 3)]
        public string PAT_BONDING { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 4)]
        public string GENDER_ID { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "{0} is required")]
        public Nullable<DateTime> DATE_OF_BIRTH { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 5)]
        public string PAT_ADDRESS_1 { get; set; }

        [Display(Name = "Address (2)")]
        [StringLength(maximumLength: 11, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string PAT_ADDRESS_2 { get; set; }

        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 11, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 11)]
        public string MOBILE_NUMBER_1 { get; set; }

        [Display(Name = "Mobile No (2)")]
        [StringLength(maximumLength: 11, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string MOBILE_NUMBER_2 { get; set; }

        [Display(Name = "Email")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        [DataType(DataType.EmailAddress)]
        public string EMAIL_ADDRESS_1 { get; set; }

        [Display(Name = "Email (2)")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        [DataType(DataType.EmailAddress)]
        public string EMAIL_ADDRESS_2 { get; set; }

        [Display(Name = "Blood Group")]
        [StringLength(maximumLength: 5, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string BLOOD_GROUP { get; set; }

        [Display(Name = "Religion")]
        [StringLength(maximumLength: 11, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string RELIGION { get; set; }

        [Display(Name = "Relationship")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string RELATIONSHIP { get; set; }

        [Display(Name = "Gurdian Name")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string GUARDIAN_NAME { get; set; }

        [Display(Name = "Gurdian Mobile")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string GUARDIAN_MOBILE { get; set; }

        [Display(Name = "Relationship with Gurdian")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string RELATION_WITH_GUARDIAN { get; set; }

        [Display(Name = "Department")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 0)]
        public string DEPT_ID { get; set; }

        [Display(Name = "Registration Date")]
        public Nullable<DateTime> REGISTRATION_DATE { get; set; }
    }
}
