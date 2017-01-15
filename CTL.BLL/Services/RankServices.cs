using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class RankServices : IServices<RankDTO>
    {
        private string _nameTable = "\"Звання\"!";

        private IUoW Database { get; set; }

        public RankServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(RankDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                Rank rank = new Rank { Name = item.Name, FullName = item.FullName };

                Database.Ranks.Create(rank);
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

                Database.Ranks.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public RankDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var rank = Database.Ranks.Get(id.Value);

                if (rank == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                RankDTO rankDTO = new RankDTO { Id = rank.Id, Name = rank.Name, FullName = rank.FullName };

                return rankDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<RankDTO> ReadAll()
        {
            try
            {
                var ranks = Database.Ranks.GetAll();

                if (ranks == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<RankDTO> rankDTOs = new List<RankDTO>();

                foreach (var item in ranks)
                {
                    rankDTOs.Add(new RankDTO { Id = item.Id, Name = item.Name, FullName = item.FullName });
                }

                return rankDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(RankDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var rank = Database.Ranks.Get(item.Id);

                if (rank == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                rank.Name = item.Name;
                rank.FullName = item.FullName;

                Database.Ranks.Update(rank);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
