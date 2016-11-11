using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class YearsCountRepository : IRepository<YearsCount>
    {
        private CTLDbContext _context;

        public YearsCountRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(YearsCount item)
        {
            _context.YearsCounts.Add(item);
        }

        public void Delete(int id)
        {
            YearsCount item = _context.YearsCounts.Find(id);
            if (item != null)
            {
                _context.YearsCounts.Find(item);
            }
        }

        public IEnumerable<YearsCount> Find(Func<YearsCount, bool> predicate)
        {
            return _context.YearsCounts.Where(predicate).ToList();
        }

        public YearsCount Get(int id)
        {
            return _context.YearsCounts.Find(id);
        }

        public IEnumerable<YearsCount> GetAll()
        {
            return _context.YearsCounts;
        }

        public void Update(YearsCount item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
