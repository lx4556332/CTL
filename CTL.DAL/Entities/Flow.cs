using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CTL.DAL.Entities
{
    public class Flow
    {
        public Flow()
        {
            this.Subject = new HashSet<Subject>();
            this.SubGroup = new HashSet<SubGroup>();
            this.Group = new HashSet<Group>();
            this.OtherType = new HashSet<OtherType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AllCountBudget { get; set; }
        public int AllCountContract { get; set; }
        public int CountSubGroupBudget { get; set; }
        public int CountSubGroupContract { get; set; }
        public string EducationType { get; set; }
        public string EducationForm { get; set; }

        public virtual ICollection<Subject> Subject { get; set; }
        public virtual ICollection<SubGroup> SubGroup { get; set; }
        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<OtherType> OtherType { get; set; }
    }
}