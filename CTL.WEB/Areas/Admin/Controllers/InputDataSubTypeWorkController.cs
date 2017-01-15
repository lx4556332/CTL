using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataSubTypeWorkController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataSubTypeWorkController(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список під видів робіт
        // GET: Admin/InputDataSubTypeWork
        public ActionResult Index()
        {
            try
            {
                IEnumerable<SubTypeWorkDTO> subTypeWorkDTO = dataServices.SubTypeWorks.ReadAll();

                List<SubTypeWorkViewModel> subTypeWorkViewModel = new List<SubTypeWorkViewModel>();

                foreach (var item in subTypeWorkDTO)
                {
                    subTypeWorkViewModel.Add(new SubTypeWorkViewModel { Id = item.Id, Name = item.Name });
                }

                return View(subTypeWorkViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення під виду роботи
        // GET: Admin/CreateSubTypeWork
        public ActionResult CreateSubTypeWork()
        {
            return View();
        }

        //Створення під виду роботи
        // POST: Admin/CreateSubTypeWork
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubTypeWork(SubTypeWorkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subTypeWorkDTO = new SubTypeWorkDTO { Name = model.Name };
                    dataServices.SubTypeWorks.Create(subTypeWorkDTO);
                }

                return RedirectToAction("Index", "InputDataSubTypeWork");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        //Редагування під виду роботи
        // GET: Admin/EditSubTypeWork
        public ActionResult EditSubTypeWork(int? id)
        {
            try
            {
                SubTypeWorkViewModel subTypeWorkViewModel = new SubTypeWorkViewModel();
                if (id != null)
                {
                    var subTypeWork = dataServices.SubTypeWorks.Read(id);
                    if (subTypeWork != null)
                    {
                        subTypeWorkViewModel.Id = subTypeWork.Id;
                        subTypeWorkViewModel.Name = subTypeWork.Name;
                    }
                }

                return View(subTypeWorkViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування під виду роботи
        // POST: Admin/EditSubTypeWork
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubTypeWork(SubTypeWorkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubTypeWorkDTO subTypeWorkDTO = new SubTypeWorkDTO { Id = model.Id, Name = model.Name };
                    dataServices.SubTypeWorks.Update(subTypeWorkDTO);
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

            return RedirectToAction("Index", "InputDataSubTypeWork");
        }

        //Видалення під виду роботи
        // GET: Admin/DeleteSubTypeWork
        public ActionResult DeleteSubTypeWork(int? id)
        {
            try
            {
                SubTypeWorkViewModel subTypeWorkViewModel = new SubTypeWorkViewModel();
                if (id != null)
                {
                    var subTypeWork = dataServices.SubTypeWorks.Read(id);
                    if (subTypeWork != null)
                    {
                        subTypeWorkViewModel.Id = subTypeWork.Id;
                        subTypeWorkViewModel.Name = subTypeWork.Name;
                    }
                }

                return View(subTypeWorkViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення під виду роботи
        // POST: Admin/DeleteSubTypeWork
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubTypeWork(SubTypeWorkViewModel model)
        {
            try
            {
                if (model != null)
                {
                    SubTypeWorkDTO subTypeWorkDTO = new SubTypeWorkDTO { Id = model.Id };
                    dataServices.SubTypeWorks.Delete(subTypeWorkDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataSubTypeWork");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}