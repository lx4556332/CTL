using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class QualificationLevelRepository : IRepository<QualificationLevel>
    {
        private CTLDbContext _context;

        public QualificationLevelRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(QualificationLevel item)
        {
            _context.QualificationLevels.Add(item);
        }

        public void Delete(int id)
        {
            QualificationLevel item = _context.QualificationLevels.Find(id);
            if (item != null)
            {
                _context.QualificationLevels.Remove(item);
            }
        }

        public IEnumerable<QualificationLevel> Find(Func<QualificationLevel, bool> predicate)
        {
            return _context.QualificationLevels.Where(predicate).ToList();
        }

        public QualificationLevel Get(int id)
        {
            return _context.QualificationLevels.Find(id);
        }

        public IEnumerable<QualificationLevel> GetAll()
        {
            return _context.QualificationLevels;
        }

        public void Update(QualificationLevel item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
