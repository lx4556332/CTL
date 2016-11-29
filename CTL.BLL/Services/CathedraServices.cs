using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class CathedraServices : IServices<CathedraDTO>
    {
        private string _nameTable = "\"Кафедра\"!";
        private IUoW Database { get; set; }

        public CathedraServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(CathedraDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }
                var faculty = Database.Faculties.Get(item.FacultyId);

                if (faculty == null)
                {
                    throw new ValidationException("Відсутні дані про факультет ", "");

                }

                Cathedra cathedra = new Cathedra { Name = item.Name, FullName = item.FullName, Faculty = faculty  };

                Database.Cathedras.Create(cathedra);
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
                Database.Cathedras.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
            
        }

        public CathedraDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                var cathedra = Database.Cathedras.Get(id.Value);

                if (cathedra == null)
                {
                    throw new ValidationException("Дані про кафедру не знайдено!", "");
                }

                CathedraDTO cathedraDTO = new CathedraDTO { Id = cathedra.Id, Name = cathedra.Name, FullName = cathedra.FullName, FacultyId = cathedra.Faculty.Id, FacultyName = cathedra.Faculty.Name };

                return cathedraDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
            
        }

        public IEnumerable<CathedraDTO> ReadAll()
        {
            try
            {
                var cathedra =  Database.Cathedras.GetAll();

                if (cathedra == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<CathedraDTO> cathedraDTOs = new List<CathedraDTO>();

                foreach (var item in cathedra)
                {
                    cathedraDTOs.Add(new CathedraDTO { Id = item.Id, Name = item.Name, FullName = item.FullName, FacultyId = item.Faculty.Id, FacultyName = item.Faculty.Name });
                }

                return cathedraDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
            
        }

        public void Update(CathedraDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }
                var cathedra = Database.Cathedras.Get(item.Id);

                if (cathedra == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }
                var faculty = Database.Faculties.Get(item.FacultyId);

                cathedra.Name = item.Name;
                cathedra.FullName = item.FullName;
                cathedra.Faculty = faculty;

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
