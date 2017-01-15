using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class GroupServices : IServices<GroupDTO>
    {
        private string _nameTable = "\"Група\"!";

        private IUoW Database { get; set; }

        public GroupServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(GroupDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                var cathedra = Database.Cathedras.Get(item.CathedraId);

                if (cathedra == null)
                {
                    throw new ValidationException("Відсутні дані про кафедру ", "");
                }

                var qualificationLevel = Database.QualificationLevels.Get(item.QualificationLevelId);

                if (qualificationLevel == null)
                {
                    throw new ValidationException("Відсутні дані про квалафікаційний рівень", "");
                }

                Group group = new Group
                {
                    Name = item.Name,
                    StudentsCountBudget = item.StudentsCountBudget,
                    StudentsCountContract = item.StudentsCountContract,
                    EducationForm = item.EducationForm,
                    EducationType = item.EducationType,
                    Course = item.Course,
                    Cathedra = cathedra,
                    QualificationLevel = qualificationLevel
                    
                };

                Database.Groups.Create(group);
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

                Database.Groups.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public GroupDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var group = Database.Groups.Get(id.Value);

                if (group == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                GroupDTO groupDTO = new GroupDTO
                {
                    Id = group.Id,
                    Name = group.Name,
                    StudentsCountBudget = group.StudentsCountBudget,
                    StudentsCountContract = group.StudentsCountContract,
                    EducationForm = group.EducationForm,
                    EducationType = group.EducationType,
                    Course = group.Course,
                    QualificationLevelId = group.QualificationLevel.Id,
                    QualificationLevelName = group.QualificationLevel.Name,
                    CathedraId = group.Cathedra.Id,
                    CathedraName = group.Cathedra.Name
                };

                return groupDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<GroupDTO> ReadAll()
        {
            try
            {
                var groups = Database.Groups.GetAll();

                if (groups == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<GroupDTO> groupDTOs = new List<GroupDTO>();

                foreach (var item in groups)
                {
                    groupDTOs.Add(new GroupDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        StudentsCountBudget = item.StudentsCountBudget,
                        StudentsCountContract = item.StudentsCountContract,
                        EducationForm = item.EducationForm,
                        EducationType = item.EducationType,
                        Course = item.Course,
                        QualificationLevelId = item.QualificationLevel.Id,
                        QualificationLevelName = item.QualificationLevel.Name,
                        CathedraId = item.Cathedra.Id,
                        CathedraName = item.Cathedra.Name
                    });
                }

                return groupDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(GroupDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var group = Database.Groups.Get(item.Id);

                if (group == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                var cathedra = Database.Cathedras.Get(item.CathedraId);

                if (cathedra == null)
                {
                    throw new ValidationException("Відсутні дані про кафедру ", "");
                }

                var qualificationLevel = Database.QualificationLevels.Get(item.QualificationLevelId);

                if (qualificationLevel == null)
                {
                    throw new ValidationException("Відсутні дані про квалафікаційний рівень", "");
                }

                group.Name = item.Name;
                group.StudentsCountBudget = item.StudentsCountBudget;
                group.StudentsCountContract = item.StudentsCountContract;
                group.EducationForm = item.EducationForm;
                group.EducationType = item.EducationType;
                group.Course = item.Course;
                group.Cathedra = cathedra;
                group.QualificationLevel = qualificationLevel;

                Database.Cathedras.Update(cathedra);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
