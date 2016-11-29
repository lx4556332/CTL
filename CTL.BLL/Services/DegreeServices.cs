using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class DegreeServices : IServices<DegreeDTO>
    {
        private string _nameTable = "\"Ступінь\"!";

        IUoW Database { get; set; }

        public DegreeServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(DegreeDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                Degree degree = new Degree { Name = item.Name };

                Database.Degrees.Create(degree);
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

                Database.Degrees.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public DegreeDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var degree = Database.Degrees.Get(id.Value);

                if (degree == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                DegreeDTO degreeDTO = new DegreeDTO { Id = degree.Id, Name = degree.Name };

                return degreeDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<DegreeDTO> ReadAll()
        {
            try
            {
                var degrees = Database.Degrees.GetAll();

                if (degrees == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<DegreeDTO> degreeDTOs = new List<DegreeDTO>();

                foreach (var item in degrees)
                {
                    degreeDTOs.Add(new DegreeDTO { Id = item.Id, Name = item.Name });
                }

                return degreeDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(DegreeDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var degree = Database.Degrees.Get(item.Id);

                if (degree == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                degree.Name = item.Name;

                Database.Degrees.Update(degree);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
