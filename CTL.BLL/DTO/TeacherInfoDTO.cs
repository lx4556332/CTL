using System.Collections.Generic;

namespace CTL.BLL.DTO
{
    public class TeacherInfoDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Initials { get; set; }
        public int Allowance { get; set; }

        public int RankId { get; set; }
        public string RankName { get; set; }

        public int AppointmentId { get; set; }
        public string AppointmentName { get; set; }

        public int DegreeId { get; set; }
        public string DegreeName { get; set; }

        public int CathedraId { get; set; }
        public string CathedraName { get; set; }

        public List<TeacherLoadDTO> TeacherLoadDTO { get; set; }
        public List<TeacherLoadOtherTypeDTO> TeacherLoadOtherTypeDTO { get; set; }
    }
}
