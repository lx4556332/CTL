using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Посада\" обов'язкове для заповнення ")]
        [Display(Name = "Посада")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,}\.?\s? |[-])+", ErrorMessage = "Невірно введені дані в поле \"Посада\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Повна назва посади\" обов'язкове для заповнення ")]
        [Display(Name = "Повна назва посади")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,}\s? |[-])+", ErrorMessage = "Невірно введені дані в поле \"Повна назва посади\"")]
        public string FullName { get; set; }
    }
}