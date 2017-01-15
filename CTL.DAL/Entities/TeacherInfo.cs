using System.Collections.Generic;

namespace CTL.DAL.Entities
{
    public class TeacherInfo
    {
        public TeacherInfo()
        {
            this.TeacherLoad = new HashSet<TeacherLoad>();
            this.TeacherLoadOtherType = new HashSet<TeacherLoadOtherType>();
        }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Initials { get; set; }
        public int Allowance { get; set; }

        public virtual Rank Rank { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Degree Degree { get; set; }
        public virtual Cathedra Cathedra { get; set; }

        public virtual ICollection<TeacherLoad> TeacherLoad { get; set; }
        public virtual ICollection<TeacherLoadOtherType> TeacherLoadOtherType { get; set; }
    }
}
