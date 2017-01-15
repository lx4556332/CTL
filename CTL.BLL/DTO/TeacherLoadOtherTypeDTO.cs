namespace CTL.BLL.DTO
{
    public class TeacherLoadOtherTypeDTO
    {
        public int Id { get; set; }
        public int CountStudentB { get; set; }
        public int CountStudentK { get; set; }
        public double CountHoursB { get; set; }
        public double CountHoursC { get; set; }
        public double Total { get; set; }

        public int TeacherInfoId { get; set; }
        public int OtherTypeId { get; set; }
    }
}
