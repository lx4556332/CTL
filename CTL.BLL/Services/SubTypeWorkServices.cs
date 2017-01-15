using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class SubTypeWorkServices : IServices<SubTypeWorkDTO>
    {
        private string _nameTable = "\"Під вид робіт\"!";

        private IUoW Database { get; set; }

        public SubTypeWorkServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(SubTypeWorkDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                SubTypeWork subTypeWork = new SubTypeWork { Name = item.Name };

                Database.SubTypeWorks.Create(subTypeWork);
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

                Database.SubTypeWorks.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public SubTypeWorkDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var subTypeWork = Database.SubTypeWorks.Get(id.Value);

                if (subTypeWork == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                SubTypeWorkDTO subTypeWorkDTO = new SubTypeWorkDTO { Id = subTypeWork.Id, Name = subTypeWork.Name };

                return subTypeWorkDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<SubTypeWorkDTO> ReadAll()
        {
            try
            {
                var subTypeWorks = Database.SubTypeWorks.GetAll();

                if (subTypeWorks == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<SubTypeWorkDTO> subTypeWorkDTOs = new List<SubTypeWorkDTO>();

                foreach (var item in subTypeWorks)
                {
                    subTypeWorkDTOs.Add(new SubTypeWorkDTO { Id = item.Id, Name = item.Name });
                }

                return subTypeWorkDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(SubTypeWorkDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var subTypeWork = Database.SubTypeWorks.Get(item.Id);

                if (subTypeWork == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                subTypeWork.Name = item.Name;

                Database.SubTypeWorks.Update(subTypeWork);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
