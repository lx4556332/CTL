using System.Collections.Generic;

namespace CTL.BLL.DTO
{
    public class FlowDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AllCountBudget { get; set; }
        public int AllCountContract { get; set; }
        public int CountSubGroupBudget { get; set; }
        public int CountSubGroupContract { get; set; }
        public string EducationType { get; set; }
        public string EducationForm { get; set; }

        public List<GroupDTO> GroupDTOs { get; set; }
        public List<SubGroupDTO> SubGroupDTOs { get; set; }
    }
}
