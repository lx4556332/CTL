using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataCathedraController : Controller
    {
        private IUoWBLL dataServices;
        public InputDataCathedraController(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список кафедр
        // GET: Admin/InputDataCathedra
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CathedraDTO> cathedraDTO = dataServices.Cathedras.ReadAll();

                List<CathedraViewModel> cathedraViewModel = new List<CathedraViewModel>();

                foreach (var item in cathedraDTO)
                {
                    cathedraViewModel.Add(new CathedraViewModel { Id = item.Id, Name = item.Name, FullName = item.FullName, FacultyId = item.FacultyId, FacultyName = item.FacultyName });
                }

                return View(cathedraViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення кафедри
        // GET: Admin/CreateCathedra
        public ActionResult CreateCathedra()
        {
            try
            {
                var model = GetFacultys(new CathedraViewModel());

                return View(model);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення кафедри
        // POST: Admin/CreateCathedra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCathedra(CreateCathedraViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    var cathedraDTO = new CathedraDTO { Name = model.Cathedra.Name, FullName = model.Cathedra.FullName, FacultyId = model.Cathedra.FacultyId };
                    dataServices.Cathedras.Create(cathedraDTO);
                }
                
                return RedirectToAction("Index", "InputDataCathedra");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            var oldModel = GetFacultys(model.Cathedra);

            return View(oldModel);
        }

        //Редагування кафедри
        // GET: Admin/EditCathedra
        public ActionResult EditCathedra(int? id)
        {
            try
            {
                CathedraViewModel cathedraViewModel = new CathedraViewModel();
                if (id != null)
                {
                    var cathedra = dataServices.Cathedras.Read(id);
                    if (cathedra != null)
                    {
                        cathedraViewModel.Id = cathedra.Id;
                        cathedraViewModel.Name = cathedra.Name;
                        cathedraViewModel.FullName = cathedra.FullName;
                        cathedraViewModel.FacultyId = cathedra.FacultyId;
                        cathedraViewModel.FacultyName = cathedra.FacultyName;
                    }
                }
            
                var model = GetFacultys(cathedraViewModel);

                return View(model);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування кафедри
        // POST: Admin/EditCathedra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCathedra(CreateCathedraViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CathedraDTO cathedraDTO = new CathedraDTO { Id = model.Cathedra.Id, Name = model.Cathedra.Name, FullName = model.Cathedra.FullName, FacultyId = model.Cathedra.FacultyId };
                    dataServices.Cathedras.Update(cathedraDTO);
                }
                else
                {
                    var oldModel = GetFacultys(model.Cathedra);

                    return View(oldModel);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataCathedra");
        }

        //Видалення кафедри
        // GET: Admin/DeleteCathedra
        public ActionResult DeleteCathedra(int? id)
        {
            try
            {
                CathedraViewModel cathedraViewModel = new CathedraViewModel();
                if (id != null)
                {
                    var cathedra = dataServices.Cathedras.Read(id);
                    if (cathedra != null)
                    {
                        cathedraViewModel.Id = cathedra.Id;
                        cathedraViewModel.Name = cathedra.Name;
                        cathedraViewModel.FullName = cathedra.FullName;
                        cathedraViewModel.FacultyId = cathedra.FacultyId;
                        cathedraViewModel.FacultyName = cathedra.FacultyName;
                    }
                }

                return View(cathedraViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення кафедри
        // POST: Admin/DeleteCathedra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCathedra(CathedraViewModel cathedra)
        {
            try
            {
                if (cathedra != null)
                {
                    CathedraDTO cathedraDTO = new CathedraDTO { Id = cathedra.Id };
                    dataServices.Cathedras.Delete(cathedraDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataCathedra");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }

        private CreateCathedraViewModel GetFacultys(CathedraViewModel cathedra)
        {
            IEnumerable<FacultyDTO> facultyDTO = dataServices.Faculties.ReadAll();

            List<SelectListItem> facultyList = new List<SelectListItem>();

            foreach (var item in facultyDTO)
            {
                facultyList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            CreateCathedraViewModel model = new CreateCathedraViewModel();
            model.Cathedra = cathedra;
            model.FacultyListItem = facultyList;

            return model;
        }
    }
}