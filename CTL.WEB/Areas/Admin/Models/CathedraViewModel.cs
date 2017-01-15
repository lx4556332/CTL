using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class CathedraViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Назва кафедри\" обов'язкове для заповнення ")]
        [Display(Name = "Назва кафедри")]
        [RegularExpression(@"([А-ЯЁЇІЄҐ]{2,10})", ErrorMessage = "Невірно введені дані в поле \"Назва кафедри\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Повна назва кафедри\" обов'язкове для заповнення ")]
        [Display(Name = "Повна назва кафедри")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{1,}\s?)+", ErrorMessage = "Невірно введені дані в поле \"Повна назва кафедри\"")]
        public string FullName { get; set; }

        public int FacultyId { get; set; }

        [Display(Name = "Факультет")]
        public string FacultyName { get; set; }
    }
}