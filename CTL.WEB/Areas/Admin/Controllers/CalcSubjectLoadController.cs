using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CalcSubjectLoadController : Controller
    {
        private IUoWBLL dataServices;

        public CalcSubjectLoadController(IUoWBLL data)
        {
            dataServices = data;
        }

        // GET: Admin/CalcSubjectLoad
        public ActionResult Index()
        {
            try
            {
                IEnumerable<SubjectDTO> subjectDTO = dataServices.Subjects.ReadAll();
                IEnumerable<SubjectInfoBDTO> subjectInfoBDTO = dataServices.SubjectInfoBs.ReadAll();
                IEnumerable<SubjectInfoKDTO> subjectInfoKDTO = dataServices.SubjectInfoKs.ReadAll();

                List<SubjectDataViewModel> subjectDataViewModelList = new List<SubjectDataViewModel>();
                SubjectDataViewModel subjectDataViewModel;

                foreach (var item in subjectDTO)
                {
                    subjectDataViewModel = new SubjectDataViewModel();

                    var subjectInfoB = subjectInfoBDTO.FirstOrDefault(s => s.Id == item.SubjectInfoBId);
                    var subjectInfoK = subjectInfoKDTO.FirstOrDefault(sK => sK.Id == item.SubjectInfoKId);

                    subjectDataViewModel.SubjectId = item.Id;
                    subjectDataViewModel.Name = item.Name;
                    subjectDataViewModel.ShortName = item.ShortName;
                    subjectDataViewModel.Semestr = item.Semestr;

                    if (subjectInfoB != null)
                    {
                        subjectDataViewModel.SubjectInfoBId = subjectInfoB.Id;
                        subjectDataViewModel.LectionB = subjectInfoB.LectionB;
                        subjectDataViewModel.PracticeB = subjectInfoB.PracticeB;
                        subjectDataViewModel.LabB = subjectInfoB.LabB;
                        subjectDataViewModel.ExamB = subjectInfoB.ExamB;
                        subjectDataViewModel.CreditB = subjectInfoB.CreditB;
                        subjectDataViewModel.TestB = subjectInfoB.TestB;
                        subjectDataViewModel.CourseProjectB = subjectInfoB.CourseProjectB;
                        subjectDataViewModel.CourseWorkB = subjectInfoB.CourseWorkB;
                        subjectDataViewModel.RgrB = subjectInfoB.RgrB;
                        subjectDataViewModel.DkrB = subjectInfoB.DkrB;
                        subjectDataViewModel.SummeryB = subjectInfoB.SummeryB;
                        subjectDataViewModel.ConsultationB = subjectInfoB.ConsultationB;
                        subjectDataViewModel.TotalHoursB = subjectInfoB.TotalHoursB;
                    }

                    if (subjectInfoK != null)
                    {
                        subjectDataViewModel.SubjectInfoKId = subjectInfoK.Id;
                        subjectDataViewModel.LectionK = subjectInfoK.LectionK;
                        subjectDataViewModel.PracticeK = subjectInfoK.PracticeK;
                        subjectDataViewModel.LabK = subjectInfoK.LabK;
                        subjectDataViewModel.ExamK = subjectInfoK.ExamK;
                        subjectDataViewModel.CreditK = subjectInfoK.CreditK;
                        subjectDataViewModel.TestK = subjectInfoK.TestK;
                        subjectDataViewModel.CourseProjectK = subjectInfoK.CourseProjectK;
                        subjectDataViewModel.CourseWorkK = subjectInfoK.CourseWorkK;
                        subjectDataViewModel.RgrK = subjectInfoK.RgrK;
                        subjectDataViewModel.DkrK = subjectInfoK.DkrK;
                        subjectDataViewModel.SummeryK = subjectInfoK.SummeryK;
                        subjectDataViewModel.ConsultationK = subjectInfoK.ConsultationK;
                        subjectDataViewModel.TotalHoursK = subjectInfoK.TotalHoursK;
                    }

                    subjectDataViewModelList.Add(subjectDataViewModel);
                }

                return View(subjectDataViewModelList);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        // GET: Admin/CreateSubjectLoad
        [HttpGet]
        public ActionResult CreateSubjectLoad()
        {
            return View();
        }

        // POST: Admin/CreatSubjectLoad
        [HttpPost]
        public ActionResult CreateSubjectLoad(SubjectDataViewModel model)
        {
            try
            {
                var subjectInfoBDTO = new SubjectInfoBDTO
                {
                    LectionB = model.LectionB,
                    PracticeB = model.PracticeB,
                    LabB = model.LabB,
                    ExamB = model.ExamB,
                    CreditB = model.CreditB,
                    TestB = model.TestB,
                    CourseProjectB = model.CourseProjectB,
                    CourseWorkB = model.CourseWorkB,
                    RgrB = model.RgrB,
                    DkrB = model.DkrB,
                    SummeryB = model.SummeryB,
                    ConsultationB = model.ConsultationB,
                    TotalHoursB = model.TotalHoursB
                };

                dataServices.SubjectInfoBs.Create(subjectInfoBDTO);
                int subjectInfoBId = dataServices.SubjectInfoBs.ReadAll().LastOrDefault().Id;

                var subjectInfoKDTO = new SubjectInfoKDTO
                {
                    LectionK = model.LectionK,
                    PracticeK = model.PracticeK,
                    LabK = model.LabK,
                    ExamK = model.ExamK,
                    CreditK = model.CreditK,
                    TestK = model.TestK,
                    CourseProjectK = model.CourseProjectK,
                    CourseWorkK = model.CourseWorkK,
                    RgrK = model.RgrK,
                    DkrK = model.DkrK,
                    SummeryK = model.SummeryK,
                    ConsultationK = model.ConsultationK,
                    TotalHoursK = model.TotalHoursK
                };

                dataServices.SubjectInfoKs.Create(subjectInfoKDTO);
                int subjectInfoKId = dataServices.SubjectInfoKs.ReadAll().LastOrDefault().Id;

                var subjectDTO = new SubjectDTO
                {
                    Id = model.SubjectId,
                    SubjectInfoBId = subjectInfoBId,
                    SubjectInfoKId = subjectInfoKId,
                    FlowId = model.FlowId
                };

                return RedirectToAction("Index", "CreateSubjectLoad");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }
    }
}