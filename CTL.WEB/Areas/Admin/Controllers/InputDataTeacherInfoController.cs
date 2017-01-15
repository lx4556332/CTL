using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    public class InputDataTeacherInfoController : Controller
    {
        private IUoWBLL dataServices;
        DropDownListData dropDownListData;

        public InputDataTeacherInfoController(IUoWBLL data)
        {
            dataServices = data;
            dropDownListData = new DropDownListData(data);
        }

        //список викладачів
        // GET: Admin/InputDataTeacherInfo
        public ActionResult Index()
        {
            try
            {
                IEnumerable<TeacherInfoDTO> teacherInfoDTO = dataServices.TeacherInfos.ReadAll();

                List<TeacherInfoViewModel> teacherInfoViewModel = new List<TeacherInfoViewModel>();

                foreach (var item in teacherInfoDTO)
                {
                    teacherInfoViewModel.Add(new TeacherInfoViewModel
                    {
                        Id = item.Id,
                        LastName = item.LastName,
                        Name = item.Name,
                        MiddleName = item.MiddleName,
                        Initials = item.Initials,
                        Allowance = item.Allowance,
                        RankName = item.RankName,
                        AppointmentName = item.AppointmentName,
                        DegreeName = item.DegreeName,
                        CathedraName = item.CathedraName
                    });
                }

                return View(teacherInfoViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення викладача
        // GET: Admin/CreateTeacherInfo
        public ActionResult CreateTeacherInfo()
        {
            try
            {
                ViewBag.AppointmentList = dropDownListData.GetAppointmentList(0);
                ViewBag.DegreeList = dropDownListData.GetDegreeList(0);
                ViewBag.RankList = dropDownListData.GetRankList(0);
                ViewBag.CathedraList = dropDownListData.GetCathedraList(0);

                return View();
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення викладача
        // POST: Admin/CreateTeacherInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTeacherInfo(TeacherInfoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var teacherInfoDTO = new TeacherInfoDTO
                    {
                        LastName = model.LastName,
                        Name = model.Name,
                        MiddleName = model.MiddleName,
                        Initials = model.Initials,
                        AppointmentId = model.AppointmentId,
                        DegreeId = model.DegreeId,
                        RankId = model.RankId,
                        CathedraId = model.CathedraId,
                        Allowance = model.Allowance
                    };

                    dataServices.TeacherInfos.Create(teacherInfoDTO);
                }

                return RedirectToAction("Index", "InputDataTeacherInfo");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            ViewBag.AppointmentList = dropDownListData.GetAppointmentList(model.AppointmentId);
            ViewBag.DegreeList = dropDownListData.GetDegreeList(model.DegreeId);
            ViewBag.RankList = dropDownListData.GetRankList(model.RankId);
            ViewBag.CathedraList = dropDownListData.GetCathedraList(model.CathedraId);

            return View(model);
        }

        //Редагування викладача
        // GET: Admin/EditTeacherInfo
        public ActionResult EditTeacherInfo(int? id)
        {
            try
            {
                TeacherInfoViewModel teacherInfoViewModel = new TeacherInfoViewModel();
                if (id != null)
                {
                    var teacherInfo = dataServices.TeacherInfos.Read(id);
                    if (teacherInfo != null)
                    {
                        teacherInfoViewModel.Id = teacherInfo.Id;
                        teacherInfoViewModel.LastName = teacherInfo.LastName;
                        teacherInfoViewModel.Name = teacherInfo.Name;
                        teacherInfoViewModel.MiddleName = teacherInfo.MiddleName;
                        teacherInfoViewModel.Initials = teacherInfo.Initials;
                        teacherInfoViewModel.Allowance = teacherInfo.Allowance;

                        ViewBag.AppointmentList = dropDownListData.GetAppointmentList(teacherInfo.AppointmentId);
                        ViewBag.DegreeList = dropDownListData.GetDegreeList(teacherInfo.DegreeId);
                        ViewBag.RankList = dropDownListData.GetRankList(teacherInfo.RankId);
                        ViewBag.CathedraList = dropDownListData.GetCathedraList(teacherInfo.CathedraId);

                    }
                }

                return View(teacherInfoViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування викладача
        // POST: Admin/EditTeacherInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeacherInfo(TeacherInfoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TeacherInfoDTO teacherInfoDTO = new TeacherInfoDTO
                    {
                        Id = model.Id,
                        LastName = model.LastName,
                        Name = model.Name,
                        MiddleName = model.MiddleName,
                        Initials = model.Initials,
                        Allowance = model.Allowance,
                        AppointmentId = Int32.Parse(model.AppointmentName),
                        DegreeId = Int32.Parse(model.DegreeName),
                        RankId = Int32.Parse(model.RankName),
                        CathedraId = Int32.Parse(model.CathedraName)
                    };

                    dataServices.TeacherInfos.Update(teacherInfoDTO);
                }
                else
                {
                    ViewBag.AppointmentList = dropDownListData.GetAppointmentList(model.AppointmentId);
                    ViewBag.DegreeList = dropDownListData.GetDegreeList(model.DegreeId);
                    ViewBag.RankList = dropDownListData.GetRankList(model.RankId);
                    ViewBag.CathedraList = dropDownListData.GetCathedraList(model.CathedraId);

                    return View(model);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataTeacherInfo");
        }

        //Видалення викладача
        // GET: Admin/DeleteTeacherInfo
        public ActionResult DeleteTeacherInfo(int? id)
        {
            try
            {
                TeacherInfoViewModel teacherInfoViewModel = new TeacherInfoViewModel();
                if (id != null)
                {
                    var teacherInfo = dataServices.TeacherInfos.Read(id);
                    if (teacherInfo != null)
                    {
                        teacherInfoViewModel.Id = teacherInfo.Id;
                        teacherInfoViewModel.LastName = teacherInfo.LastName;
                        teacherInfoViewModel.Name = teacherInfo.Name;
                        teacherInfoViewModel.MiddleName = teacherInfo.MiddleName;
                        teacherInfoViewModel.Initials = teacherInfo.Initials;
                    }
                }

                return View(teacherInfoViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення викладача
        // POST: Admin/DeleteTeacherInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeacherInfo(TeacherInfoViewModel model)
        {
            try
            {
                if (model != null)
                {
                    TeacherInfoDTO teacherInfoDTO = new TeacherInfoDTO { Id = model.Id };
                    dataServices.TeacherInfos.Delete(teacherInfoDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataTeacherInfo");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}