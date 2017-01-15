namespace CTL.BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCountBudget { get; set; }
        public int StudentsCountContract { get; set; }
        public string EducationForm { get; set; }
        public string EducationType { get; set; }
        public int Course { get; set; }

        public int QualificationLevelId { get; set; }
        public string QualificationLevelName { get; set; }

        public int CathedraId { get; set; }
        public string CathedraName { get; set; }
    }
}
