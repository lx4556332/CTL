using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class DegreeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Ступінь\" обов'язкове для заповнення ")]
        [Display(Name = "Ступінь")]
        [RegularExpression(@"([А-ЯЁЇІЄҐ]{1,5} |[-])", ErrorMessage = "Невірно введені дані в поле \"Ступінь\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Повна назва ступеню\" обов'язкове для заповнення ")]
        [Display(Name = "Повна назва ступеню")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{1,}\s? |[-])+", ErrorMessage = "Невірно введені дані в поле \"Повна назва ступеню\"")]
        public string FullName { get; set; }
    }
}