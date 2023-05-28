using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_BILL_DETAIL
    {
        public string BM_ID { get; set; }
        public string SALE_DEPT_ID { get; set; }
        public DateTime SALE_DATE { get; set; }
        public string INVES_ID { get; set; }
        public string INVES_NAME { get; set; }
        public decimal INVES_RATE { get; set; }
        public decimal INVES_QTY { get; set; }
        public decimal DISC_PCT { get; set; }
        public decimal DISC_AMT { get; set; }
        public decimal NET_AMT { get; set; }

        public string REFERRAL_ID { get; set; }
        [NotMapped]
        public string REFERRAL_NAME { get; set; }

        public string DOCT_ID { get; set; }
        [NotMapped]
        public string DOCT_NAME { get; set; }

        public string INVES_ROOM { get; set; }        
        public int IS_PAID { get; set; } = 0;
    }
}
