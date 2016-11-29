using System.ComponentModel.DataAnnotations;

namespace CTL.WEB.Areas.Admin.Models
{
    public class FacultyViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва факультету")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Повна назва факультету")]
        public string FullName { get; set; }
    }
}