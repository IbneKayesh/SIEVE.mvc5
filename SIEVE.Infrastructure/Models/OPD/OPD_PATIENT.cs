using System;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_PATIENT
    {
        public string ID { get; set; }
        public string PAT_ID { get; set; }
        public string MOBILE_NO { get; set; }
        public string PAT_NAME { get; set; }
        public string PAT_BONDING { get; set; }
        public string GENDER_ID { get; set; }
        public DateTime DATE_OF_BIRTH { get; set; }
        public string PAT_ADDRESS_1 { get; set; }
        public string PAT_ADDRESS_2 { get; set; }
        public string MOBILE_NUMBER_2 { get; set; }
        public string EMAIL_ADDRESS_1 { get; set; }
        public string EMAIL_ADDRESS_2 { get; set; }
        public string BLOOD_GROUP { get; set; }
        public string RELIGION { get; set; }
        public string RELATIONSHIP { get; set; }
        public string GUARDIAN_NAME { get; set; }
        public string GUARDIAN_MOBILE { get; set; }
        public string RELATION_WITH_GUARDIAN { get; set; }
        public string DEPT_ID { get; set; }
    }
}
