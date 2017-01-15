using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Назва групи\" обов'язкове для заповнення ")]
        [Display(Name = "Назва групи")]
        [RegularExpression(@"(([А-ЯЁЇІЄҐ]{2}\-[0-9]{2}\s?)+([а-я]{1}\s?)?)", ErrorMessage = "Невірно введені дані в поле \"Назва групи\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Кіл-сть студентів бюджет\" обов'язкове для заповнення ")]
        [Display(Name = "Кіл-сть студентів бюджет")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Кіл-сть студентів бюджет\"")]
        public int StudentsCountBudget { get; set; }

        [Required(ErrorMessage = "Поле \"Кіл-сть студентів контракт\" обов'язкове для заповнення ")]
        [Display(Name = "Кіл-сть студентів контракт")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Кіл-сть студентів контракт\"")]
        public int StudentsCountContract { get; set; }

        [Required(ErrorMessage = "Поле \"Загалом студентів\" обов'язкове для заповнення ")]
        [Display(Name = "Загалом студентів")]
        [RegularExpression(@"([0-9]{1,})", ErrorMessage = "Невірно введені дані в поле \"Загалом студентів\"")]
        public int StudentsCountTotal { get; set; }

        [Display(Name = "Форма навчання")]
        public string EducationForm { get; set; }

        [Display(Name = "Тип навчання")]
        public string EducationType { get; set; }

        [Display(Name = "Курс")]
        public int Course { get; set; }

        public int QualificationLevelId { get; set; }

        [Display(Name = "ОКР")]
        public string QualificationLevelName { get; set; }

        public int CathedraId { get; set; }

        [Display(Name = "Назва кафедри")]
        public string CathedraName { get; set; }
    }
}