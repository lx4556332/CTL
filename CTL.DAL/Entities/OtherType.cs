using System.Collections.Generic;

namespace CTL.DAL.Entities
{
    public class OtherType
    {
        public OtherType()
        {
            this.TeacherLoadOtherType = new HashSet<TeacherLoadOtherType>();
        }
        public int Id { get; set; }
        public int Semestr { get; set; }
        public double TotalBudget { get; set; }
        public double TotalContract { get; set; }
        public double TotalHourse { get; set; }

        public virtual TypeWork TypeWork { get; set; }
        public virtual SubTypeWork SubTypeWork { get; set; }

        public virtual Flow Flow { get; set; }

        public virtual ICollection<TeacherLoadOtherType> TeacherLoadOtherType { get; set; }
    }
}