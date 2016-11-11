using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class SubTypeWorkRepository : IRepository<SubTypeWork>
    {
        private CTLDbContext _context;

        public SubTypeWorkRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(SubTypeWork item)
        {
            _context.SubTypeWorks.Add(item);
        }

        public void Delete(int id)
        {
            SubTypeWork item = _context.SubTypeWorks.Find(id);
            if(item != null)
            {
                _context.SubTypeWorks.Remove(item);
            }
        }

        public IEnumerable<SubTypeWork> Find(Func<SubTypeWork, bool> predicate)
        {
            return _context.SubTypeWorks.Where(predicate).ToList();
        }

        public SubTypeWork Get(int id)
        {
            return _context.SubTypeWorks.Find(id);
        }

        public IEnumerable<SubTypeWork> GetAll()
        {
            return _context.SubTypeWorks;
        }

        public void Update(SubTypeWork item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
