namespace CTL.BLL.DTO
{
    public class CathedraDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
    }
}
