using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class YearsCountServices : IServices<YearsCountDTO>
    {
        private string _nameTable = "\"Кількість років\"!";

        private IUoW Database { get; set; }

        public YearsCountServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(YearsCountDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                YearsCount yearsCount = new YearsCount { Name = item.Name };

                Database.YearsCounts.Create(yearsCount);
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

                Database.YearsCounts.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public YearsCountDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var yearsCount = Database.YearsCounts.Get(id.Value);

                if (yearsCount == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                YearsCountDTO yearsCountDTO = new YearsCountDTO { Id = yearsCount.Id, Name = yearsCount.Name };

                return yearsCountDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<YearsCountDTO> ReadAll()
        {
            try
            {
                var yearsCounts = Database.YearsCounts.GetAll();

                if (yearsCounts == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<YearsCountDTO> yearsCountDTOs = new List<YearsCountDTO>();

                foreach (var item in yearsCounts)
                {
                    yearsCountDTOs.Add(new YearsCountDTO { Id = item.Id, Name = item.Name });
                }

                return yearsCountDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(YearsCountDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var yearsCount = Database.YearsCounts.Get(item.Id);

                if (yearsCount == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                yearsCount.Name = item.Name;

                Database.YearsCounts.Update(yearsCount);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
