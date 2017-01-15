using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataFacultyController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataFacultyController(IUoWBLL data)
        {
            dataServices = data;
        }

        // Список Факультетів
        // GET: Admin/InputDataFaculty
        public ActionResult Index()
        {
            try
            {
                IEnumerable<FacultyDTO> facultyDTO = dataServices.Faculties.ReadAll();

                List<FacultyViewModel> facultyViewModel = new List<FacultyViewModel>();

                foreach (var item in facultyDTO)
                {
                    facultyViewModel.Add(new FacultyViewModel { Id = item.Id, Name = item.Name, FullName = item.FullName });
                }

                return View(facultyViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення факультету
        // GET: Admin/CreateFaculty
        public ActionResult CreateFaculty()
        {
            return View();
        }

        //Створення факультету
        // POST: Admin/CreateFaculty
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFaculty(FacultyViewModel faculty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var facultyDTO = new FacultyDTO { Name = faculty.Name, FullName = faculty.FullName };
                    dataServices.Faculties.Create(facultyDTO);
                }

                return RedirectToAction("Index", "InputDataFaculty");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(faculty);
        }

        //Редагування факульетету
        // GET: Admin/EditFaculty
        public ActionResult EditFaculty(int? id)
        {
            try
            {
                FacultyViewModel facultyViewModel = new FacultyViewModel();
                if (id != null)
                {
                    var faculty = dataServices.Faculties.Read(id);
                    if (faculty != null)
                    {
                        facultyViewModel.Id = faculty.Id;
                        facultyViewModel.Name = faculty.Name;
                        facultyViewModel.FullName = faculty.FullName;
                    }
                }

                return View(facultyViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування факульетету
        // POST: Admin/EditFaculty
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFaculty(FacultyViewModel faculty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FacultyDTO facultyDTO = new FacultyDTO { Id = faculty.Id, Name = faculty.Name, FullName = faculty.FullName };
                    dataServices.Faculties.Update(facultyDTO);
                }
                else
                {
                    return View(faculty);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataFaculty");
        }

        //Видалення факульетету
        // GET: Admin/DeleteFaculty
        public ActionResult DeleteFaculty(int? id)
        {
            try
            {
                FacultyViewModel facultyViewModel = new FacultyViewModel();
                if (id != null)
                {
                    var faculty = dataServices.Faculties.Read(id);
                    if (faculty != null)
                    {
                        facultyViewModel.Id = faculty.Id;
                        facultyViewModel.Name = faculty.Name;
                        facultyViewModel.FullName = faculty.FullName;
                    }
                }

                return View(facultyViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення факульетету
        // POST: Admin/DeleteFaculty
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFaculty(FacultyViewModel faculty)
        {
            try
            {
                if (faculty != null)
                {
                    FacultyDTO facultyDTO = new FacultyDTO { Id = faculty.Id };
                    dataServices.Faculties.Delete(facultyDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataFaculty");
        }
     
        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}