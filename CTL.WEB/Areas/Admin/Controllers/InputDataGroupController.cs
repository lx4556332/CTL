using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataGroupController : Controller
    {
        private IUoWBLL dataServices;
        DropDownListData dropDownListData;

        public InputDataGroupController(IUoWBLL data)
        {
            dataServices = data;
            dropDownListData = new DropDownListData(data);
        }

        //Список груп
        // GET: Admin/InputDataGroup
        public ActionResult Index()
        {
            try
            {
                IEnumerable<GroupDTO> groupDTO = dataServices.Groups.ReadAll();

                List<GroupViewModel> groupViewModel = new List<GroupViewModel>();

                foreach (var item in groupDTO)
                {
                    groupViewModel.Add(new GroupViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        StudentsCountBudget = item.StudentsCountBudget,
                        StudentsCountContract = item.StudentsCountContract,
                        StudentsCountTotal = item.StudentsCountBudget + item.StudentsCountContract,
                        EducationType = item.EducationType,
                        EducationForm = item.EducationForm,
                        Course = item.Course,
                        QualificationLevelName = item.QualificationLevelName,
                        CathedraName = item.CathedraName
                    });
                }

                return View(groupViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення групи
        // GET: Admin/CreateGroup
        public ActionResult CreateGroup()
        {
            try
            {
                ViewBag.QualificationLevelList = dropDownListData.GetQualificationLevelList(0);
                ViewBag.CathedraList = dropDownListData.GetCathedraList(0);
                ViewBag.CourseList = dropDownListData.GetCourseList(0);
                ViewBag.EducationTypeList = dropDownListData.GetEducationTypeList("");
                ViewBag.EducationFormList = dropDownListData.GetEducationFormList("");

                return View();
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення групи
        // POST: Admin/CreateGroup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup(GroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var groupDTO = new GroupDTO
                    {
                        Name = model.Name,
                        StudentsCountBudget = model.StudentsCountBudget,
                        StudentsCountContract = model.StudentsCountContract,
                        EducationType = model.EducationType,
                        EducationForm = model.EducationForm,
                        Course = model.Course,
                        QualificationLevelId = model.QualificationLevelId,
                        CathedraId = model.CathedraId,
                    };

                    dataServices.Groups.Create(groupDTO);
                }

                return RedirectToAction("Index", "InputDataGroup");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            ViewBag.QualificationLevelList = dropDownListData.GetQualificationLevelList(model.QualificationLevelId);
            ViewBag.CathedraList = dropDownListData.GetCathedraList(model.CathedraId);
            ViewBag.CourseList = dropDownListData.GetCourseList(model.Course);
            ViewBag.EducationTypeList = dropDownListData.GetEducationTypeList(model.EducationType);
            ViewBag.EducationFormList = dropDownListData.GetEducationFormList(model.EducationForm);

            return View(model);
        }

        //Редагування групи
        // GET: Admin/EditGroup
        public ActionResult EditGroup(int? id)
        {
            try
            {
                GroupViewModel groupViewModel = new GroupViewModel();
                if (id != null)
                {
                    var group = dataServices.Groups.Read(id);
                    if (group != null)
                    {
                        groupViewModel.Id = group.Id;
                        groupViewModel.Name = group.Name;
                        groupViewModel.StudentsCountBudget = group.StudentsCountBudget;
                        groupViewModel.StudentsCountContract = group.StudentsCountContract;

                        ViewBag.QualificationLevelList = dropDownListData.GetQualificationLevelList(group.QualificationLevelId);
                        ViewBag.CathedraList = dropDownListData.GetCathedraList(group.CathedraId);
                        ViewBag.CourseList = dropDownListData.GetCourseList(group.Course);
                        ViewBag.EducationTypeList = dropDownListData.GetEducationTypeList(group.EducationType);
                        ViewBag.EducationFormList = dropDownListData.GetEducationFormList(group.EducationForm);
                    }
                }

                return View(groupViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування групи
        // POST: Admin/EditGroup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGroup(GroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GroupDTO groupDTO = new GroupDTO
                    {
                        Id = model.Id,
                        Name = model.Name,
                        StudentsCountBudget = model.StudentsCountBudget,
                        StudentsCountContract = model.StudentsCountContract,
                        EducationType = model.EducationType,
                        EducationForm = model.EducationForm,
                        Course = model.Course,
                        QualificationLevelId = Int32.Parse(model.QualificationLevelName),
                        CathedraId = Int32.Parse(model.CathedraName),
                    };

                    dataServices.Groups.Update(groupDTO);
                }
                else
                {
                    ViewBag.QualificationLevelList = dropDownListData.GetQualificationLevelList(model.QualificationLevelId);
                    ViewBag.CathedraList = dropDownListData.GetCathedraList(model.CathedraId);
                    ViewBag.CourseList = dropDownListData.GetCourseList(model.Course);
                    ViewBag.EducationTypeList = dropDownListData.GetEducationTypeList(model.EducationType);
                    ViewBag.EducationFormList = dropDownListData.GetEducationFormList(model.EducationForm);

                    return View(model);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataGroup");
        }

        //Видалення групи
        // GET: Admin/DeleteGroup
        public ActionResult DeleteGroup(int? id)
        {
            try
            {
                GroupViewModel groupViewModel = new GroupViewModel();
                if (id != null)
                {
                    var group = dataServices.Groups.Read(id);
                    if (group != null)
                    {
                        groupViewModel.Id = group.Id;
                        groupViewModel.Name = group.Name;
                    }
                }

                return View(groupViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення групи
        // POST: Admin/DeleteGroup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGroup(GroupViewModel model)
        {
            try
            {
                if (model != null)
                {
                    GroupDTO groupDTO = new GroupDTO { Id = model.Id };
                    dataServices.Groups.Delete(groupDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataGroup");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }        
    }
}