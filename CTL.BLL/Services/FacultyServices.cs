using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class FacultyServices : IServices<FacultyDTO>
    {
        private string _nameTable = "\"Факультет\"!";

        private IUoW Database { get; set; }

        public FacultyServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(FacultyDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                Faculty faculty = new Faculty { Name = item.Name, FullName = item.FullName };
                
                Database.Faculties.Create(faculty);
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

                Database.Faculties.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }      
        }

        public FacultyDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var faculty = Database.Faculties.Get(id.Value);

                if (faculty == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                FacultyDTO facultyDTO = new FacultyDTO {  Id = faculty.Id, Name = faculty.Name, FullName = faculty.FullName };

                return facultyDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }       
        }

        public IEnumerable<FacultyDTO> ReadAll()
        {        
            try
            {
                var faculties = Database.Faculties.GetAll();

                if (faculties == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<FacultyDTO> facultyDTOs = new List<FacultyDTO>();

                foreach (var item in faculties)
                {
                    facultyDTOs.Add(new FacultyDTO { Id = item.Id, Name = item.Name, FullName = item.FullName });
                }

                return facultyDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }        
        }

        public void Update(FacultyDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable,  "");
                }

                var faculty = Database.Faculties.Get(item.Id);

                if (faculty == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                faculty.Name = item.Name;
                faculty.FullName = item.FullName;

                Database.Faculties.Update(faculty);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }      
        }
    }
}
