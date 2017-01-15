namespace CTL.BLL.DTO
{
    public class PaymentForYearsDTO
    {
        public int Id { get; set; }
        public int Allowance { get; set; }
        public int Percentage { get; set; }

        public int YearsCountId { get; set; }
        public int PaymentId { get; set; }
    }
}
