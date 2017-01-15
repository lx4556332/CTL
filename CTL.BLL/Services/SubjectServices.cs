using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class SubjectServices : IServices<SubjectDTO>
    {
        private string _nameTable = "\"Дисципліна\"!";

        private IUoW Database { get; set; }

        public SubjectServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(SubjectDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                Subject subject = new Subject { Name = item.Name, ShortName = item.ShortName, Semestr = item.Semestr };

                Database.Subjects.Create(subject);
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
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                Database.Subjects.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public SubjectDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                var subject = Database.Subjects.Get(id.Value);

                if (subject == null)
                {
                    throw new ValidationException("Дані про посаду не знайдено!", "");
                }

                SubjectDTO subjectDTO = new SubjectDTO();

                subjectDTO.Id = subject.Id;
                subjectDTO.Name = subject.Name;
                subjectDTO.ShortName = subject.ShortName;
                subjectDTO.Semestr = subject.Semestr;

                if (subject.SubjectInfoB == null)
                {
                    subjectDTO.SubjectInfoBId = null;
                }
                else
                {
                    subjectDTO.SubjectInfoBId = subject.SubjectInfoB.Id;
                }

                if (subject.SubjectInfoK == null)
                {
                    subjectDTO.SubjectInfoKId = null;
                }
                else
                {
                    subjectDTO.SubjectInfoKId = subject.SubjectInfoK.Id;
                }

                if (subject.Flow == null)
                {
                    subjectDTO.FlowId = null;
                }
                else
                {
                    subjectDTO.FlowId = subject.Flow.Id;
                    subjectDTO.FlowName = subject.Flow.Name;
                }
                return subjectDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<SubjectDTO> ReadAll()
        {
            try
            {
                var subjects = Database.Subjects.GetAll();

                if (subjects == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<SubjectDTO> subjectsDTOs = new List<SubjectDTO>();

                foreach (var item in subjects)
                {
                    SubjectDTO subjectDTO = new SubjectDTO();

                    subjectDTO.Id = item.Id;
                    subjectDTO.Name = item.Name;
                    subjectDTO.ShortName = item.ShortName;
                    subjectDTO.Semestr = item.Semestr;

                    if (item.SubjectInfoB == null)
                    {
                        subjectDTO.SubjectInfoBId = null;
                    }
                    else
                    {
                        subjectDTO.SubjectInfoBId = item.SubjectInfoB.Id;
                    }

                    if (item.SubjectInfoK == null)
                    {
                        subjectDTO.SubjectInfoKId = null;
                    }
                    else
                    {
                        subjectDTO.SubjectInfoKId = item.SubjectInfoK.Id;
                    }

                    if (item.Flow == null)
                    {
                        subjectDTO.FlowId = null;
                    }
                    else
                    {
                        subjectDTO.FlowId = item.Flow.Id;
                        subjectDTO.FlowName = item.Flow.Name;
                    }

                    subjectsDTOs.Add(subjectDTO);
                }

                return subjectsDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(SubjectDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var subject = Database.Subjects.Get(item.Id);

                if (subject == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

               

                subject.Name = item.Name;
                subject.ShortName = item.ShortName;
                subject.Semestr = item.Semestr;

                if (item.SubjectInfoBId != null)
                {
                    subject.SubjectInfoB = Database.SubjectInfoBs.Get(item.SubjectInfoBId.Value);
                }

                if (item.SubjectInfoKId != null)
                {
                    subject.SubjectInfoK = Database.SubjectInfoKs.Get(item.SubjectInfoKId.Value);
                }

                if (item.FlowId != null)
                {
                    subject.Flow = Database.Flows.Get(item.FlowId.Value);
                }


                Database.Subjects.Update(subject);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
