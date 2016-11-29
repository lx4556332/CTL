using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class QualificationLevelServices : IServices<QualificationLevelDTO>
    {
        private string _nameTable = "\"Освітньо-кваліфікаційний рівень\"!";

        private IUoW Database { get; set; }

        public QualificationLevelServices(IUoW uow)
        {
            Database = uow;
        }
        public void Create(QualificationLevelDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                QualificationLevel qualificationLevel = new QualificationLevel { Name = item.Name };

                Database.QualificationLevels.Create(qualificationLevel);
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

                Database.QualificationLevels.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public QualificationLevelDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var qLevel = Database.QualificationLevels.Get(id.Value);

                if (qLevel == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                QualificationLevelDTO qualificationLevelDTO = new QualificationLevelDTO { Id = qLevel.Id, Name = qLevel.Name };

                return qualificationLevelDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<QualificationLevelDTO> ReadAll()
        {
            try
            {
                var qLevels = Database.QualificationLevels.GetAll();

                if (qLevels == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<QualificationLevelDTO> qLevelDTOs = new List<QualificationLevelDTO>();

                foreach (var item in qLevels)
                {
                    qLevelDTOs.Add(new QualificationLevelDTO { Id = item.Id, Name = item.Name });
                }

                return qLevelDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(QualificationLevelDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var qLevel = Database.QualificationLevels.Get(item.Id);

                if (qLevel == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                qLevel.Name = item.Name;

                Database.QualificationLevels.Update(qLevel);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
