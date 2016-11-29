using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class CathedraViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва кафедри")]
        //[RegularExpression(@"[А-Я]{2,10}", ErrorMessage = "Помилка заповнення поля \"Назва кафедри\"")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Повна назва кафедри")]
        //[RegularExpression(@"[а-яА-Я]{5,}", ErrorMessage = "Помилка заповнення поля \"Повна назва кафедри\"")]
        public string FullName { get; set; }

        public int FacultyId { get; set; }

        [Display(Name = "Факультет")]
        public string FacultyName { get; set; }
    }
}