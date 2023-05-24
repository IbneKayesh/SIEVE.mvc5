using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_BILL_PAY_STAFF
    {
        public string BILL_MASTER_ID { get; set; }
        public string STAFF_ID { get; set; }
        public string STAFF_NAME { get; set; }
        public string CARD_NO { get; set; }
        public decimal PAY_AMT { get; set; }


        public string SECT_NAME { get; set; }
        public string DEPT_NAME { get; set; }
        public string LOC_NAME { get; set; }
    }
}
