using CTL.BLL.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class FlowViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Назва потоку\" обов'язкове для заповнення ")]
        [Display(Name = "Назва потоку")]
        [RegularExpression(@"(([А-ЯЁЇІЄҐ]{2}\-[0-9]{2}\s?)+([а-я]{1}\s?)?){1,}", ErrorMessage = "Невірно введено поле \"Назва потоку\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Кіл-сть бюджет\" обов'язкове для заповнення ")]
        [Display(Name = "Кіл-сть бюджет")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Кіл-сть бюджет\"")]
        public int AllCountBudget { get; set; }

        [Required(ErrorMessage = "Поле \"Кіл-сть контракт\" обов'язкове для заповнення ")]
        [Display(Name = "Кіл-сть контракт")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Кіл-сть контракт\"")]
        public int AllCountContract { get; set; }

        [Required(ErrorMessage = "Поле \"Кіл-сть підгруп бюджет\" обов'язкове для заповнення ")]
        [Display(Name = "Кіл-сть підгруп бюджет")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Кіл-сть підгруп бюджет\"")]
        public int CountSubGroupBudget { get; set; }

        [Required(ErrorMessage = "Поле \"Кіл-сть підгруп контракт\" обов'язкове для заповнення ")]
        [Display(Name = "Кіл-сть підгруп контракт")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Кіл-сть підгруп контракт\"")]
        public int CountSubGroupContract { get; set; }

        [Required(ErrorMessage = "Поле \"Тип навчання\" обов'язкове для заповнення ")]
        [Display(Name = "Тип навчання")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,15})", ErrorMessage = "Невірно введено поле \"Тип навчання\"")]
        public string EducationType { get; set; }

        [Required(ErrorMessage = "Поле \"Форма навчання\" обов'язкове для заповнення ")]
        [Display(Name = "Форма навчання")]
        [RegularExpression(@"([А-Яа-яёЁЇїІіЄєҐґ]{2,15})", ErrorMessage = "Невірно введено поле \"Форма навчання\"")]
        public string EducationForm { get; set; }

        public List<GroupDTO> selectedGroupList { get; set; }
        public List<SubGroupDTO> subGroupList { get; set; }

    }
}