﻿namespace CTL.DAL.Entities
{
    public class PaymentForYears
    {
        public int Id { get; set; }
        public int Allowance { get; set; }
        public int Percentage { get; set; }

        public virtual YearsCount YearsCount { get; set; }
        public virtual Payment Payment { get; set; }
    }
}