using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class SubjectInfoKServices : IServices<SubjectInfoKDTO>
    {
        private string _nameTable = "\"Навантаження на дисципліну (Контракт)\"!";

        private IUoW Database { get; set; }

        public SubjectInfoKServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(SubjectInfoKDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                SubjectInfoK subjectInfoK = new SubjectInfoK
                {
                    LectionK = item.LectionK,
                    PracticeK = item.PracticeK,
                    LabK = item.LabK,
                    ExamK = item.ExamK,
                    CreditK = item.CreditK,
                    TestK = item.TestK,
                    CourseProjectK = item.CourseProjectK,
                    CourseWorkK = item.CourseWorkK,
                    RgrK = item.RgrK,
                    DkrK = item.DkrK,
                    SummeryK = item.SummeryK,
                    ConsultationK = item.ConsultationK,
                    TotalHoursK = item.TotalHoursK
                };

                Database.SubjectInfoKs.Create(subjectInfoK);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка створення нового запису в таблиці " + _nameTable, "");
            }
        }

        public void Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису з таблиці" + _nameTable, "");
                }

                Database.SubjectInfoKs.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public SubjectInfoKDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var subjectInfoK = Database.SubjectInfoKs.Get(id.Value);

                if (subjectInfoK == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                SubjectInfoKDTO subjectInfoKDTO = new SubjectInfoKDTO
                {
                    Id = subjectInfoK.Id,
                    LectionK = subjectInfoK.LectionK,
                    PracticeK = subjectInfoK.PracticeK,
                    LabK = subjectInfoK.LabK,
                    ExamK = subjectInfoK.ExamK,
                    CreditK = subjectInfoK.CreditK,
                    TestK = subjectInfoK.TestK,
                    CourseProjectK = subjectInfoK.CourseProjectK,
                    CourseWorkK = subjectInfoK.CourseWorkK,
                    RgrK = subjectInfoK.RgrK,
                    DkrK = subjectInfoK.DkrK,
                    SummeryK = subjectInfoK.SummeryK,
                    ConsultationK = subjectInfoK.ConsultationK,
                    TotalHoursK = subjectInfoK.TotalHoursK
                };

                return subjectInfoKDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<SubjectInfoKDTO> ReadAll()
        {
            try
            {
                var subjectInfoKs = Database.SubjectInfoKs.GetAll();

                if (subjectInfoKs == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<SubjectInfoKDTO> subjectInfoKDTO = new List<SubjectInfoKDTO>();

                foreach (var item in subjectInfoKs)
                {
                    subjectInfoKDTO.Add(new SubjectInfoKDTO
                    {
                        Id = item.Id,
                        LectionK = item.LectionK,
                        PracticeK = item.PracticeK,
                        LabK = item.LabK,
                        ExamK = item.ExamK,
                        CreditK = item.CreditK,
                        TestK = item.TestK,
                        CourseProjectK = item.CourseProjectK,
                        CourseWorkK = item.CourseWorkK,
                        RgrK = item.RgrK,
                        DkrK = item.DkrK,
                        SummeryK = item.SummeryK,
                        ConsultationK = item.ConsultationK,
                        TotalHoursK = item.TotalHoursK
                    });
                }

                return subjectInfoKDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(SubjectInfoKDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var subjectInfoK = Database.SubjectInfoKs.Get(item.Id);

                if (subjectInfoK == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                subjectInfoK.LectionK = item.LectionK;
                subjectInfoK.PracticeK = item.PracticeK;
                subjectInfoK.LabK = item.LabK;
                subjectInfoK.ExamK = item.ExamK;
                subjectInfoK.CreditK = item.CreditK;
                subjectInfoK.TestK = item.TestK;
                subjectInfoK.CourseProjectK = item.CourseProjectK;
                subjectInfoK.CourseWorkK = item.CourseWorkK;
                subjectInfoK.RgrK = item.RgrK;
                subjectInfoK.DkrK = item.DkrK;
                subjectInfoK.SummeryK = item.SummeryK;
                subjectInfoK.ConsultationK = item.ConsultationK;
                subjectInfoK.TotalHoursK = item.TotalHoursK;

                Database.SubjectInfoKs.Update(subjectInfoK);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
