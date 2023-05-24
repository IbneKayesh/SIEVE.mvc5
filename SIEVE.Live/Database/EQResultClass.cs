using System.Collections.Generic;

namespace SIEVE.Live.Database
{
    public class EQResultClass<T>
    {
        public List<T> Entity { get; set; }
        public EQResult_v1 Result = new EQResult_v1();
    }
}
