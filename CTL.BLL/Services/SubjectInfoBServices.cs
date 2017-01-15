using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class SubjectInfoBServices : IServices<SubjectInfoBDTO>
    {
        private string _nameTable = "\"Навантаження на дисципліну (Бюджет)\"!";

        private IUoW Database { get; set; }

        public SubjectInfoBServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(SubjectInfoBDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                SubjectInfoB subjectInfoB = new SubjectInfoB
                {
                    LectionB = item.LectionB,
                    PracticeB = item.PracticeB,
                    LabB = item.LabB,
                    ExamB = item.ExamB,
                    CreditB = item.CreditB,
                    TestB = item.TestB,
                    CourseProjectB = item.CourseProjectB,
                    CourseWorkB = item.CourseWorkB,
                    RgrB = item.RgrB,
                    DkrB = item.DkrB,
                    SummeryB = item.SummeryB,
                    ConsultationB = item.ConsultationB,
                    TotalHoursB = item.TotalHoursB
                };

                Database.SubjectInfoBs.Create(subjectInfoB);
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

                Database.SubjectInfoBs.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public SubjectInfoBDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var subjectInfoB = Database.SubjectInfoBs.Get(id.Value);

                if (subjectInfoB == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                SubjectInfoBDTO subjectInfoBDTO = new SubjectInfoBDTO
                {
                    Id = subjectInfoB.Id,
                    LectionB = subjectInfoB.LectionB,
                    PracticeB = subjectInfoB.PracticeB,
                    LabB = subjectInfoB.LabB,
                    ExamB = subjectInfoB.ExamB,
                    CreditB = subjectInfoB.CreditB,
                    TestB = subjectInfoB.TestB,
                    CourseProjectB = subjectInfoB.CourseProjectB,
                    CourseWorkB = subjectInfoB.CourseWorkB,
                    RgrB = subjectInfoB.RgrB,
                    DkrB = subjectInfoB.DkrB,
                    SummeryB = subjectInfoB.SummeryB,
                    ConsultationB = subjectInfoB.ConsultationB,
                    TotalHoursB = subjectInfoB.TotalHoursB
                };

                return subjectInfoBDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<SubjectInfoBDTO> ReadAll()
        {
            try
            {
                var subjectInfoBs = Database.SubjectInfoBs.GetAll();

                if (subjectInfoBs == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<SubjectInfoBDTO> subjectInfoBDTO = new List<SubjectInfoBDTO>();

                foreach (var item in subjectInfoBs)
                {
                    subjectInfoBDTO.Add(new SubjectInfoBDTO
                    {
                        Id = item.Id,
                        LectionB = item.LectionB,
                        PracticeB = item.PracticeB,
                        LabB = item.LabB,
                        ExamB = item.ExamB,
                        CreditB = item.CreditB,
                        TestB = item.TestB,
                        CourseProjectB = item.CourseProjectB,
                        CourseWorkB = item.CourseWorkB,
                        RgrB = item.RgrB,
                        DkrB = item.DkrB,
                        SummeryB = item.SummeryB,
                        ConsultationB = item.ConsultationB,
                        TotalHoursB = item.TotalHoursB
                    });
                }

                return subjectInfoBDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(SubjectInfoBDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var subjectInfoB = Database.SubjectInfoBs.Get(item.Id);

                if (subjectInfoB == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                subjectInfoB.LectionB = item.LectionB;
                subjectInfoB.PracticeB = item.PracticeB;
                subjectInfoB.LabB = item.LabB;
                subjectInfoB.ExamB = item.ExamB;
                subjectInfoB.CreditB = item.CreditB;
                subjectInfoB.TestB = item.TestB;
                subjectInfoB.CourseProjectB = item.CourseProjectB;
                subjectInfoB.CourseWorkB = item.CourseWorkB;
                subjectInfoB.RgrB = item.RgrB;
                subjectInfoB.DkrB = item.DkrB;
                subjectInfoB.SummeryB = item.SummeryB;
                subjectInfoB.ConsultationB = item.ConsultationB;
                subjectInfoB.TotalHoursB = item.TotalHoursB;

                Database.SubjectInfoBs.Update(subjectInfoB);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
