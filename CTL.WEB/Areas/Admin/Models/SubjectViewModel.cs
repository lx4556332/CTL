using CTL.BLL.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Назва дисципліни\" обов'язкове для заповнення ")]
        [Display(Name = "Назва")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ']{2,}\.?\s?)+", ErrorMessage = "Невірно введені дані в поле \"Назва дисципліни\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Скорочена назва дисципліни\" обов'язкове для заповнення ")]
        [Display(Name = "Скорочена назва")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,}\.?\s?)+", ErrorMessage = "Невірно введені дані в поле \"Скорочена назва дисципліни\"")]
        public string ShortName { get; set; }

        [Display(Name = "Семестр")]
        public int Semestr { get; set; }

        public int? SubjectInfoBId { get; set; }
        public int? SubjectInfoKId { get; set; }
        public int? FlowId { get; set; }

        [Display(Name = "Потік")]
        public string FlowName { get; set; }

        public List<TeacherLoadDTO> TeacherLoadDTO { get; set; }
    }
}