using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class RankViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Звання\" обов'язкове для заповнення ")]
        [Display(Name = "Звання")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,}\.?\s? |[-])+", ErrorMessage = "Невірно введені дані в поле \"Звання\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Повна назва звання\" обов'язкове для заповнення ")]
        [Display(Name = "Повна назва звання")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,}\s? |[-])+", ErrorMessage = "Невірно введені дані в поле \"Повна назва звання\"")]
        public string FullName { get; set; }
    }
}