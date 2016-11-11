using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class SubjectInfoKRepository : IRepository<SubjectInfoK>
    {
        private CTLDbContext _context;

        public SubjectInfoKRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(SubjectInfoK item)
        {
            _context.SubjectInfoKs.Add(item);
        }

        public void Delete(int id)
        {
            SubjectInfoK item = _context.SubjectInfoKs.Find(id);
            if (item != null)
            {
                _context.SubjectInfoKs.Remove(item);
            }
        }

        public IEnumerable<SubjectInfoK> Find(Func<SubjectInfoK, bool> predicate)
        {
            return _context.SubjectInfoKs.Where(predicate).ToList();
        }

        public SubjectInfoK Get(int id)
        {
            return _context.SubjectInfoKs.Find(id);
        }

        public IEnumerable<SubjectInfoK> GetAll()
        {
            return _context.SubjectInfoKs;
        }

        public void Update(SubjectInfoK item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
