namespace SIEVE.Infrastructure.Models.PSM
{
    public class PSM_INVES
    {
        public string ID { get; set; }
        public string INVES_NAME { get; set; }
        public string INVES_DESC { get; set; }
        public decimal INVES_RATE { get; set; }
        public string CAT_ID { get; set; }
        public string UNIT_ID { get; set; } = "0";
        public int HAS_SAMPLE { get; set; } = 0;
    }
}
