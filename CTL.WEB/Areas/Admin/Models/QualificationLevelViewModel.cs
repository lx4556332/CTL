using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class QualificationLevelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обов'язкове для заповнення ")]
        [Display(Name = "ОКР")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{4,12})", ErrorMessage = "Невірно введені дані в поле \"Освітньо-кваліфікаційний рівень\" ")]
        public string Name { get; set; }
    }
}