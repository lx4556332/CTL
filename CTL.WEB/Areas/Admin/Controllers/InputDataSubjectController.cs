using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataSubjectController : Controller
    {
        private IUoWBLL dataServices;
        DropDownListData dropDownListData;

        public InputDataSubjectController(IUoWBLL data)
        {
            dataServices = data;
            dropDownListData = new DropDownListData(data);
        }

        //Список дисциплін
        // GET: Admin/InputDataSubject
        public ActionResult Index()
        {
            try
            {
                IEnumerable<SubjectDTO> subjectDTO = dataServices.Subjects.ReadAll();

                List<SubjectViewModel> subjectViewModel = new List<SubjectViewModel>();

                foreach (var item in subjectDTO)
                {
                    subjectViewModel.Add(new SubjectViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ShortName = item.ShortName,
                        Semestr = item.Semestr,
                        FlowName = item.FlowName,
                        SubjectInfoBId = item.SubjectInfoBId,
                        SubjectInfoKId = item.SubjectInfoKId
                    });
                }

                return View(subjectViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення дисципліни
        // GET: Admin/CreateSubject
        public ActionResult CreateSubject()
        {
            try
            {
                ViewBag.SemestrList = dropDownListData.GetSemestr(0);

                return View();
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення дисципліни
        // POST: Admin/CreateSubject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject(SubjectViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var subjectDTO = new SubjectDTO
                    {
                        Name = model.Name,
                        ShortName = model.ShortName,
                        Semestr = model.Semestr,
                    };

                    dataServices.Subjects.Create(subjectDTO);
                }

                return RedirectToAction("Index", "InputDataSubject");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            ViewBag.SemestrList = dropDownListData.GetSemestr(model.Semestr);

            return View(model);
        }

        //Редагування дисципліни
        // GET: Admin/EditSubject
        public ActionResult EditSubject(int? id)
        {
            try
            {
                SubjectViewModel subjectViewModel = new SubjectViewModel();
                if (id != null)
                {
                    var subject = dataServices.Subjects.Read(id);
                    if (subject != null)
                    {
                        subjectViewModel.Id = subject.Id;
                        subjectViewModel.Name = subject.Name;
                        subjectViewModel.ShortName = subject.ShortName;

                        ViewBag.SemestrList = dropDownListData.GetSemestr(subject.Semestr);
                    }
                }

                return View(subjectViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування дисципліни
        // POST: Admin/Editsubject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubject(SubjectViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubjectDTO subjectDTO = new SubjectDTO
                    {
                        Id = model.Id,
                        Name = model.Name,
                        ShortName = model.ShortName,
                        Semestr = model.Semestr
                    };

                    dataServices.Subjects.Update(subjectDTO);
                }
                else
                {
                    ViewBag.SemestrList = dropDownListData.GetSemestr(model.Semestr);

                    return View(model);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataSubject");
        }

        //Видалення дисципліни
        // GET: Admin/DeleteSubject
        public ActionResult DeleteSubject(int? id)
        {
            try
            {
                SubjectViewModel subjectViewModel = new SubjectViewModel();
                if (id != null)
                {
                    var subject = dataServices.Subjects.Read(id);
                    if (subject != null)
                    {
                        subjectViewModel.Id = subject.Id;
                        subjectViewModel.Name = subject.Name;
                        subjectViewModel.ShortName = subject.ShortName;
                    }
                }

                return View(subjectViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення дисципліни
        // POST: Admin/DeleteSubject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubject(SubjectViewModel model)
        {
            try
            {
                if (model != null)
                {
                    SubjectDTO subjectDTO = new SubjectDTO { Id = model.Id };
                    dataServices.Subjects.Delete(subjectDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataSubject");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}