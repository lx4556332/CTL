using System.Collections.Generic;

namespace CTL.BLL.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string AppointmentSub { get; set; }
        public int Salary { get; set; }

        public int AppointmentId { get; set; }

        public List<PaymentForYearsDTO> PaymentForYearsesDTO { get; set; }
    }
}
