using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_BILL_DETAIL
    {
        public string LINE_ID { get; set; }
        public string BILL_MASTER_ID { get; set; }
        public string SALE_DEPT_ID { get; set; }
        public DateTime SALE_DATE { get; set; }
        public string EXEC_DEPT_ID { get; set; }
        public string INVES_ID { get; set; }
        public string INVES_NAME { get; set; }
        public decimal INVES_RATE { get; set; }
        public decimal INVES_QTY { get; set; }
        public decimal DISC_PCT { get; set; }
        public decimal DISC_AMT { get; set; }
        public string REFERRAL_ID { get; set; }
        public string DOCT_ID { get; set; }
        public string DOCT_NAME { get; set; }
        public string ROOM_NAME { get; set; }
    }
}
