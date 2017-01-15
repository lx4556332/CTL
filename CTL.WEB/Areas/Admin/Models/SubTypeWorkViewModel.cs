using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class SubTypeWorkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Під вид робіт\" обов'язкове для заповнення ")]
        [Display(Name = "Під вид робіт")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{1,}\s?)+", ErrorMessage = "Невірно введені дані в поле \"Під вид робіт\"")]
        public string Name { get; set; }
    }
}