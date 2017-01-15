using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class TypeWorkServices : IServices<TypeWorkDTO>
    {
        private string _nameTable = "\"Види робіт\"!";

        private IUoW Database { get; set; }

        public TypeWorkServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(TypeWorkDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                TypeWork typeWork = new TypeWork { Name = item.Name };

                Database.TypeWorks.Create(typeWork);
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

                Database.TypeWorks.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public TypeWorkDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var typeWork = Database.TypeWorks.Get(id.Value);

                if (typeWork == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                TypeWorkDTO typeWorkDTO = new TypeWorkDTO { Id = typeWork.Id, Name = typeWork.Name };

                return typeWorkDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<TypeWorkDTO> ReadAll()
        {
            try
            {
                var typeWork = Database.TypeWorks.GetAll();

                if (typeWork == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<TypeWorkDTO> typeWorkDTOs = new List<TypeWorkDTO>();

                foreach (var item in typeWork)
                {
                    typeWorkDTOs.Add(new TypeWorkDTO { Id = item.Id, Name = item.Name });
                }

                return typeWorkDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(TypeWorkDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var typeWork = Database.TypeWorks.Get(item.Id);

                if (typeWork == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                typeWork.Name = item.Name;

                Database.TypeWorks.Update(typeWork);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
