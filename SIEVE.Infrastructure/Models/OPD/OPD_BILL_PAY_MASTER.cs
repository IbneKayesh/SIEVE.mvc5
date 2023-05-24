using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEVE.Infrastructure.Models.OPD
{
    public class OPD_BILL_PAY_MASTER
    {
        public string ID { get; set; }
        public string BILL_MASTER_ID { get; set; }
        public decimal PAY_AMT { get; set; }
        public decimal DISC_AMT { get; set; }
        public decimal DUE_AMT { get; set; }
    }
}
