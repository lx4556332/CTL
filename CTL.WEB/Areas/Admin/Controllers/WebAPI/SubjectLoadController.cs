using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CTL.WEB.Areas.Admin.Controllers.WebAPI
{
    [Authorize(Roles = "admin")]
    public class SubjectLoadController : ApiController
    {
        private IUoWBLL dataServices;

        public SubjectLoadController(IUoWBLL data)
        {
            dataServices = data;
        }

        // GET: api/SubjectLoad
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SubjectLoad/5
        public SubjectDataViewModel Get(int? id)
        {
            SubjectDataViewModel subjectDataViewModel = new SubjectDataViewModel();

            if (id != null)
            {
                var subject = dataServices.Subjects.Read(id);
                if (subject != null)
                {
                    subjectDataViewModel.SubjectId = subject.Id;
                    subjectDataViewModel.Name = subject.Name;
                    subjectDataViewModel.ShortName = subject.ShortName;
                    subjectDataViewModel.Semestr = subject.Semestr;
                }

                if (subject.SubjectInfoBId != null)
                {
                    var subjectInfoB = dataServices.SubjectInfoBs.Read(subject.SubjectInfoBId);
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
                }

                if (subject.SubjectInfoKId != null)
                {
                    var subjectInfoK = dataServices.SubjectInfoKs.Read(subject.SubjectInfoKId);
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
                }
            }

            return subjectDataViewModel;
        }

        // POST: api/SubjectLoad
        public SubjectDataViewModel Post([FromBody]HoursToCalculateViewModel model)
        {

            SubjectDataViewModel subjectDataViewModel = new SubjectDataViewModel();

            subjectDataViewModel = CalculateB(model, subjectDataViewModel);
            subjectDataViewModel = CalculateK(model, subjectDataViewModel);

            return subjectDataViewModel;
        }

        // PUT: api/SubjectLoad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SubjectLoad/5
        public void Delete(int id)
        {
        }

        private SubjectDataViewModel CalculateB(HoursToCalculateViewModel model, SubjectDataViewModel subjectDataViewModel) {

            int tempStudCountB = model.StudCountB;

            int lectionV = 0;
            if (model.Flow.EducationType == "Бюджет")
            {
                lectionV = model.Lection;
            }

            int practiceV = model.Practice * model.SubGroupPractB;
            int labV = model.Lab * model.SubGroupLabB;
            double examV = 0.33 * model.Exam * tempStudCountB;
            examV = Math.Round(examV, 2);

            int tempCreditV = model.Credit;
            int tempAcademB = model.AcademB;

            double creditV = 2 * tempAcademB * tempCreditV;
            creditV = Math.Round(creditV, 2);


            double testV = 0.25 * model.Test * tempStudCountB;
            int courseProjectV = model.CourseProject * tempStudCountB;
            int courseWorkV = model.CourseWork * tempStudCountB;
            double rgrV = 0.5 * model.Rgr * tempStudCountB;
            double dkrV = 0.33 * model.Dkr * tempStudCountB;
            double summeryV = 0.25 * model.Summery * tempStudCountB;

            double consultationV = 0;
            if (model.Flow.EducationForm == "Денна")
            {
                consultationV = 2 * model.Exam * tempAcademB + 0.06 * model.AmountHours * (tempStudCountB) / 25;
            }
            else if (model.Flow.EducationForm == "Заочна")
            {
                consultationV = 2 * model.Exam * tempAcademB + 0.12 * model.AmountHours * (tempStudCountB) / 25;
            }

            consultationV = Math.Round(consultationV, 2);

            double totalHoursV = lectionV + practiceV + labV + examV + creditV + testV + courseProjectV + courseWorkV + rgrV + dkrV + summeryV + consultationV;
            totalHoursV = Math.Round(totalHoursV, 2);

            subjectDataViewModel.LectionB = lectionV;
            subjectDataViewModel.PracticeB = practiceV;
            subjectDataViewModel.LabB = labV;
            subjectDataViewModel.ExamB = examV;
            subjectDataViewModel.CreditB = creditV;
            subjectDataViewModel.TestB = testV;
            subjectDataViewModel.CourseProjectB = courseProjectV;
            subjectDataViewModel.CourseWorkB = courseWorkV;
            subjectDataViewModel.RgrB = rgrV;
            subjectDataViewModel.DkrB = dkrV;
            subjectDataViewModel.SummeryB = summeryV;
            subjectDataViewModel.ConsultationB = consultationV;
            subjectDataViewModel.TotalHoursB = totalHoursV;

            return subjectDataViewModel;
        }

        private SubjectDataViewModel CalculateK(HoursToCalculateViewModel model, SubjectDataViewModel subjectDataViewModel)
        {
            int tempStudCountK = model.StudCountK;

            int lectionV = 0;
            if (model.Flow.EducationType == "Контракт")
            {
                lectionV = model.Lection;
            }

            int practiceV = model.Practice * model.SubGroupPractK;
            int labV = model.Lab * model.SubGroupLabK;
            double examV = 0.33 * model.Exam * tempStudCountK;
            examV = Math.Round(examV, 2);

            int tempCreditV = model.Credit;
            int tempAcademK = model.AcademK;

            double creditV = 2 * tempAcademK * tempCreditV;
            creditV = Math.Round(creditV, 2);

            double testV = 0.25 * model.Test * tempStudCountK;
            int courseProjectV = model.CourseProject * tempStudCountK;
            int courseWorkV = model.CourseWork * tempStudCountK;
            double rgrV = 0.5 * model.Rgr * tempStudCountK;
            double dkrV = 0.33 * model.Dkr * tempStudCountK;
            double summeryV = 0.25 * model.Summery * tempStudCountK;

            double consultationV = 0;
            if (model.Flow.EducationForm == "Денна")
            {
                consultationV = 2 * model.Exam * tempAcademK + 0.06 * model.AmountHours * (tempStudCountK) / 25;
            }
            else if (model.Flow.EducationForm == "Заочна")
            {
                consultationV = 2 * model.Exam * tempAcademK + 0.12 * model.AmountHours * (tempStudCountK) / 25;
            }

            consultationV = Math.Round(consultationV, 2);

            double totalHoursV = lectionV + practiceV + labV + examV + creditV + testV + courseProjectV + courseWorkV + rgrV + dkrV + summeryV + consultationV;
            totalHoursV = Math.Round(totalHoursV, 2);

            subjectDataViewModel.LectionK = lectionV;
            subjectDataViewModel.PracticeK = practiceV;
            subjectDataViewModel.LabK = labV;
            subjectDataViewModel.ExamK = examV;
            subjectDataViewModel.CreditK = creditV;
            subjectDataViewModel.TestK = testV;
            subjectDataViewModel.CourseProjectK = courseProjectV;
            subjectDataViewModel.CourseWorkK = courseWorkV;
            subjectDataViewModel.RgrK = rgrV;
            subjectDataViewModel.DkrK = dkrV;
            subjectDataViewModel.SummeryK = summeryV;
            subjectDataViewModel.ConsultationK = consultationV;
            subjectDataViewModel.TotalHoursK = totalHoursV;


            return subjectDataViewModel;
        }
    }
}
