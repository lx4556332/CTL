using System.Collections.Generic;

namespace CTL.BLL.DTO
{
    public class OtherTypeDTO
    {
        public int Id { get; set; }
        public int Semestr { get; set; }
        public double TotalBudget { get; set; }
        public double TotalContract { get; set; }
        public double TotalHourse { get; set; }

        public int TypeWorkId { get; set; }
        public int SubTypeWorkId { get; set; }

        public int FlowId { get; set; }

        public List<TeacherLoadOtherTypeDTO> TeacherLoadOtherTypeDTO { get; set; }
    }
}
