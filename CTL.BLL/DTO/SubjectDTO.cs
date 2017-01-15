using System.Collections.Generic;

namespace CTL.BLL.DTO
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Semestr { get; set; }

        public int? SubjectInfoBId { get; set; }
        public int? SubjectInfoKId { get; set; }
        public int? FlowId { get; set; }
        public string FlowName { get; set; }

        public List<TeacherLoadDTO> TeacherLoadDTO { get; set; }
    }
}
