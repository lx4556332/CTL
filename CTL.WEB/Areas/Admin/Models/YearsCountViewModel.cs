using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class YearsCountViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Кіл-сть років\" обов'язкове для заповнення ")]
        [Display(Name = "Кіл-сть років")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ0-9]{1,}\s?)+", ErrorMessage = "Невірно введені дані в поле \"Кіл-сть років\"")]
        public string Name { get; set; }
    }
}