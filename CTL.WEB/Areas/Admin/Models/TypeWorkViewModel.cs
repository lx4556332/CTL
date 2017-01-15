using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class TypeWorkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Вид робіт\" обов'язкове для заповнення ")]
        [Display(Name = "Вид робіт")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{1,}\s?)+", ErrorMessage = "Невірно введені дані в поле \"Вид робіт\"")]
        public string Name { get; set; }
    }
}