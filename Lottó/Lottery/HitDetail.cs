using System;

namespace Lottó
{
    public class HitDetail
    {
        public int Hit { get; set; }

        public decimal Amount { get; set; }

        public HitDetail(int hit, decimal amount)
        {
            Hit = hit;
            Amount = amount;
        }

        public override string ToString()
        {
            return String.Format("{0} hit, {1} Ft", Hit, Amount);
        }
    }
}
