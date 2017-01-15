using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataQualificationLevelController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataQualificationLevelController(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список Освітньо-кваліфікаційних рівнів
        // GET: Admin/InputDataQualificationLevel
        public ActionResult Index()
        {
            try
            {
                IEnumerable<QualificationLevelDTO> qualificationLevelDTO = dataServices.QualificationLevels.ReadAll();

                List<QualificationLevelViewModel> qualificationLevelViewModel = new List<QualificationLevelViewModel>();

                foreach (var item in qualificationLevelDTO)
                {
                    qualificationLevelViewModel.Add(new QualificationLevelViewModel { Id = item.Id, Name = item.Name });
                }

                return View(qualificationLevelViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення Освітньо-кваліфікаційного рівню
        // GET: Admin/CreateQualificationLevel
        public ActionResult CreateQualificationLevel()
        {
            return View();
        }

        //Створення Освітньо-кваліфікаційного рівня
        // POST: Admin/CreateQualificationLevel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQualificationLevel(QualificationLevelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var qualificationLevelDTO = new QualificationLevelDTO { Name = model.Name };
                    dataServices.QualificationLevels.Create(qualificationLevelDTO);
                }

                return RedirectToAction("Index", "InputDataQualificationLevel");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        //Редагування Освітньо-кваліфікаційного рівня
        // GET: Admin/EditQualificationLevel
        public ActionResult EditQualificationLevel(int? id)
        {
            try
            {
                QualificationLevelViewModel qualificationLevelViewModel = new QualificationLevelViewModel();
                if (id != null)
                {
                    var qualificationLevel = dataServices.QualificationLevels.Read(id);
                    if (qualificationLevel != null)
                    {
                        qualificationLevelViewModel.Id = qualificationLevel.Id;
                        qualificationLevelViewModel.Name = qualificationLevel.Name;
                    }
                }

                return View(qualificationLevelViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування Освітньо-кваліфікаційного рівня
        // POST: Admin/EditQualificationLevel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQualificationLevel(QualificationLevelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    QualificationLevelDTO qualificationLevelDTO = new QualificationLevelDTO { Id = model.Id, Name = model.Name };
                    dataServices.QualificationLevels.Update(qualificationLevelDTO);
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

            return RedirectToAction("Index", "InputDataQualificationLevel");
        }

        //Видалення Освітньо-кваліфікаційного рівня
        // GET: Admin/DeleteQualificationLevel
        public ActionResult DeleteQualificationLevel(int? id)
        {
            try
            {
                QualificationLevelViewModel qualificationLevelViewModel = new QualificationLevelViewModel();
                if (id != null)
                {
                    var qualificationLevel = dataServices.QualificationLevels.Read(id);
                    if (qualificationLevel != null)
                    {
                        qualificationLevelViewModel.Id = qualificationLevel.Id;
                        qualificationLevelViewModel.Name = qualificationLevel.Name;
                    }
                }

                return View(qualificationLevelViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення Освітньо-кваліфікаційного рівня
        // POST: Admin/DeleteQualificationLevel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteQualificationLevel(QualificationLevelViewModel model)
        {
            try
            {
                if (model != null)
                {
                    QualificationLevelDTO qualificationLevelDTO = new QualificationLevelDTO { Id = model.Id };
                    dataServices.QualificationLevels.Delete(qualificationLevelDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataQualificationLevel");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}