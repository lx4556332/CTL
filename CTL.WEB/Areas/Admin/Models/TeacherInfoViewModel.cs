using CTL.BLL.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class TeacherInfoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Прізвище\" обов'язкове для заповнення ")]
        [Display(Name = "Прізвище")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,30})", ErrorMessage = "Невірно введені дані в поле \"Прізвище\"")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле \"Ім'я\" обов'язкове для заповнення ")]
        [Display(Name = "Ім'я")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,25})", ErrorMessage = "Невірно введені дані в поле \"Ім'я\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"По-батькові\" обов'язкове для заповнення ")]
        [Display(Name = "По-батькові")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,30})", ErrorMessage = "Невірно введені дані в поле \"По-батькові\"")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Поле \"Ініціали\" обов'язкове для заповнення ")]
        [Display(Name = "Ініціали")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,30}\s)+([А-Я]{1}\.)+([А-Я]{1}\.)", ErrorMessage = "Невірно введені дані в поле \"Ініціали\"")]
        public string Initials { get; set; }

        [Required(ErrorMessage = "Поле \"Сума\" обов'язкове для заповнення")]
        [Display(Name = "Сума")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Сума\"")]
        public int Allowance { get; set; }

        public int RankId { get; set; }

        [Display(Name = "Звання")]
        public string RankName { get; set; }

        public int AppointmentId { get; set; }

        [Display(Name = "Посада")]
        public string AppointmentName { get; set; }

        public int DegreeId { get; set; }

        [Display(Name = "Ступінь")]
        public string DegreeName { get; set; }

        public int CathedraId { get; set; }

        [Display(Name = "Кафедра")]
        public string CathedraName { get; set; }

        public List<TeacherLoadDTO> TeacherLoadDTO { get; set; }
        public List<TeacherLoadOtherTypeDTO> TeacherLoadOtherTypeDTO { get; set; }
    }
}