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
        DropDownListData dropDownListData;
   
        public InputDataCathedraController(IUoWBLL data)
        {
            dataServices = data;
            dropDownListData = new DropDownListData(data);
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
                ViewBag.FacultyList = dropDownListData.GetFacultyList(0);

                return View();
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
        public ActionResult CreateCathedra(CathedraViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    var cathedraDTO = new CathedraDTO { Name = model.Name, FullName = model.FullName, FacultyId = model.FacultyId };
                    dataServices.Cathedras.Create(cathedraDTO);
                }
                
                return RedirectToAction("Index", "InputDataCathedra");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            ViewBag.FacultyList = dropDownListData.GetFacultyList(model.FacultyId);

            return View(model);
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

                    ViewBag.FacultyList = dropDownListData.GetFacultyList(cathedra.FacultyId);
                }

                return View(cathedraViewModel);
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
        public ActionResult EditCathedra(CathedraViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CathedraDTO cathedraDTO = new CathedraDTO { Id = model.Id, Name = model.Name, FullName = model.FullName, FacultyId = model.FacultyId };
                    dataServices.Cathedras.Update(cathedraDTO);
                }
                else
                {
                    ViewBag.FacultyList = dropDownListData.GetFacultyList(model.FacultyId);

                    return View(model);
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
    }
}