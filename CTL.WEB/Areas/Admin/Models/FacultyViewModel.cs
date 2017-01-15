using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class FacultyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Назва факультету\" обов'язкове для заповнення ")]
        [Display(Name = "Назва факультету")]
        [RegularExpression(@"([А-ЯЁЇІЄҐ]{2,15})", ErrorMessage = "Невірно введені дані в поле \"Назва факультету\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Повна назва факультету\" обов'язкове для заповнення ")]
        [Display(Name = "Повна назва кафедри")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{1,}\s?)+", ErrorMessage = "Невірно введені дані в поле \"Повна назва факультету\"")]
        public string FullName { get; set; }

    }
}