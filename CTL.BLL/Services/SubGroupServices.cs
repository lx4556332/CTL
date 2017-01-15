using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class SubGroupServices : IServices<SubGroupDTO>
    {
        private string _nameTable = "\"Підгрупа\"!";

        private IUoW Database { get; set; }

        public SubGroupServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(SubGroupDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                var flow = Database.Flows.Get(item.FlowId);

                if (flow == null)
                {
                    throw new ValidationException("Відсутні дані про потік", "");
                }

                SubGroup subGroup = new SubGroup { Name = item.Name, CountStudent = item.CountStudent, Flow = flow };

                Database.SubGroups.Create(subGroup);
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

                Database.SubGroups.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public SubGroupDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var subGroup = Database.SubGroups.Get(id.Value);

                if (subGroup == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                SubGroupDTO subGroupDTO = new SubGroupDTO { Id = subGroup.Id, Name = subGroup.Name, CountStudent = subGroup.CountStudent };

                return subGroupDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<SubGroupDTO> ReadAll()
        {
            try
            {
                var subGroups = Database.SubGroups.GetAll();

                if (subGroups == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<SubGroupDTO> subGroupDTOs = new List<SubGroupDTO>();

                foreach (var item in subGroups)
                {
                    subGroupDTOs.Add(new SubGroupDTO { Id = item.Id, Name = item.Name, CountStudent = item.CountStudent });
                }

                return subGroupDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(SubGroupDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var subGroup = Database.SubGroups.Get(item.Id);

                if (subGroup == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                subGroup.Name = item.Name;
                subGroup.CountStudent = item.CountStudent;

                Database.SubGroups.Update(subGroup);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
