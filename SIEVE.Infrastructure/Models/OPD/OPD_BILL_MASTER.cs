using System;
using System.Collections.Generic;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_BILL_MASTER
    {
        public OPD_BILL_MASTER()
        {
            OPD_BILL_DETAIL = new List<OPD.OPD_BILL_DETAIL>();
            BILL_DATE = DateTime.Now;
        }
        public string ID { get; set; }
        public string BILL_DEPT_ID { get; set; }
        public string DEPT_NAME { get; set; }
        public DateTime BILL_DATE { get; set; }
        public string PAT_ID { get; set; }
        public string PAT_NO { get; set; }
        public string PAT_NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string PAT_AGE { get; set; }
        public string GENDER_ID { get; set; }
        public string ADDRESS_1 { get; set; }
        public string SALE_NOTE { get; set; }
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
