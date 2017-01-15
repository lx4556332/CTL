using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataDegreeController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataDegreeController(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список ступенів
        // GET: Admin/InputDataDegree
        public ActionResult Index()
        {
            try
            {
                IEnumerable<DegreeDTO> degreeDTO = dataServices.Degrees.ReadAll();

                List<DegreeViewModel> degreeViewModel = new List<DegreeViewModel>();

                foreach (var item in degreeDTO)
                {
                    degreeViewModel.Add(new DegreeViewModel { Id = item.Id, Name = item.Name, FullName = item.FullName });
                }

                return View(degreeViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення ступеню
        // GET: Admin/CreateDegree
        public ActionResult CreateDegree()
        {
            return View();
        }

        //Створення ступеню
        // POST: Admin/CreateDegree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDegree(DegreeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var degreeDTO = new DegreeDTO { Name = model.Name, FullName = model.FullName };
                    dataServices.Degrees.Create(degreeDTO);
                }

                return RedirectToAction("Index", "InputDataDegree");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        //Редагування ступеню
        // GET: Admin/EditDegree
        public ActionResult EditDegree(int? id)
        {
            try
            {
                DegreeViewModel degreeViewModel = new DegreeViewModel();
                if (id != null)
                {
                    var degree = dataServices.Degrees.Read(id);
                    if (degree != null)
                    {
                        degreeViewModel.Id = degree.Id;
                        degreeViewModel.Name = degree.Name;
                        degreeViewModel.FullName = degree.FullName;
                    }
                }

                return View(degreeViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування ступеню
        // POST: Admin/EditDegree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDegree(DegreeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DegreeDTO degreeDTO = new DegreeDTO { Id = model.Id, Name = model.Name, FullName = model.FullName };
                    dataServices.Degrees.Update(degreeDTO);
                }
                else
                {
                    return View(model);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataDegree");
        }

        //Видалення ступеню
        // GET: Admin/DeleteDegree
        public ActionResult DeleteDegree(int? id)
        {
            try
            {
                DegreeViewModel degreeViewModel = new DegreeViewModel();
                if (id != null)
                {
                    var degree = dataServices.Degrees.Read(id);
                    if (degree != null)
                    {
                        degreeViewModel.Id = degree.Id;
                        degreeViewModel.Name = degree.Name;
                        degreeViewModel.FullName = degree.FullName;
                    }
                }

                return View(degreeViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення ступеню
        // POST: Admin/DeleteDegree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDegree(DegreeViewModel model)
        {
            try
            {
                if (model != null)
                {
                    DegreeDTO degreeDTO = new DegreeDTO { Id = model.Id };
                    dataServices.Degrees.Delete(degreeDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataDegree");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}