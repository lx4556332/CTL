using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataTypeWorkController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataTypeWorkController(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список видів робіт
        // GET: Admin/InputDataTypeWork
        public ActionResult Index()
        {
            try
            {
                IEnumerable<TypeWorkDTO> typeWorkDTO = dataServices.TypeWorks.ReadAll();

                List<TypeWorkViewModel> typeWorkViewModel = new List<TypeWorkViewModel>();

                foreach (var item in typeWorkDTO)
                {
                    typeWorkViewModel.Add(new TypeWorkViewModel { Id = item.Id, Name = item.Name });
                }

                return View(typeWorkViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення виду роботи
        // GET: Admin/CreateTypeWork
        public ActionResult CreateTypeWork()
        {
            return View();
        }

        //Створення виду роботи
        // POST: Admin/CreateTypeWork
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTypeWork(TypeWorkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var typeWorkDTO = new TypeWorkDTO { Name = model.Name };
                    dataServices.TypeWorks.Create(typeWorkDTO);
                }

                return RedirectToAction("Index", "InputDataTypeWork");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        //Редагування виду роботи
        // GET: Admin/EditTypeWork
        public ActionResult EditTypeWork(int? id)
        {
            try
            {
                TypeWorkViewModel typeWorkViewModel = new TypeWorkViewModel();
                if (id != null)
                {
                    var typeWork = dataServices.TypeWorks.Read(id);
                    if (typeWork != null)
                    {
                        typeWorkViewModel.Id = typeWork.Id;
                        typeWorkViewModel.Name = typeWork.Name;
                    }
                }

                return View(typeWorkViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування виду роботи
        // POST: Admin/EditTypeWork
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTypeWork(TypeWorkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TypeWorkDTO typeWorkDTO = new TypeWorkDTO { Id = model.Id, Name = model.Name };
                    dataServices.TypeWorks.Update(typeWorkDTO);
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

            return RedirectToAction("Index", "InputDataTypeWork");
        }

        //Видалення виду роботи
        // GET: Admin/DeleteTypeWork
        public ActionResult DeleteTypeWork(int? id)
        {
            try
            {
                TypeWorkViewModel typeWorkViewModel = new TypeWorkViewModel();
                if (id != null)
                {
                    var typeWork = dataServices.TypeWorks.Read(id);
                    if (typeWork != null)
                    {
                        typeWorkViewModel.Id = typeWork.Id;
                        typeWorkViewModel.Name = typeWork.Name;
                    }
                }

                return View(typeWorkViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення виду роботи
        // POST: Admin/DeleteTypeWork
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTypeWork(TypeWorkViewModel model)
        {
            try
            {
                if (model != null)
                {
                    TypeWorkDTO typeWorkDTO = new TypeWorkDTO { Id = model.Id };
                    dataServices.TypeWorks.Delete(typeWorkDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataTypeWork");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}