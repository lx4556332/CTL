using System.Collections.Generic;

namespace CTL.DAL.Entities
{
    public class Group
    {
        public Group()
        {
            this.Flow = new HashSet<Flow>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCountBudget { get; set; }
        public int StudentsCountContract { get; set; }
        public string EducationForm { get; set; }
        public string EducationType { get; set; }
        public int Course { get; set; }

        public virtual ICollection<Flow> Flow { get; set; }
        public virtual QualificationLevel QualificationLevel { get; set; }
        public virtual Cathedra Cathedra { get; set; }
    }
}