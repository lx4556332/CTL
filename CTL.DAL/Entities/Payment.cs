using System.Collections.Generic;

namespace CTL.DAL.Entities
{
    public class Payment
    {
        public Payment()
        {
            this.PaymentForYearses = new HashSet<PaymentForYears>();
        }
        public int Id { get; set; }
        public string AppointmentSub { get; set; }
        public int Salary { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual ICollection<PaymentForYears> PaymentForYearses { get; set; }
    }
}