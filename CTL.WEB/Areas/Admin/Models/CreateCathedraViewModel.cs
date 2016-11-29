using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Models
{
    public class CreateCathedraViewModel
    {
        public CathedraViewModel Cathedra { get; set; }
        public List<SelectListItem> FacultyListItem { get; set; }
    }
}