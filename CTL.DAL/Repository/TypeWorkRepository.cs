using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class TypeWorkRepository : IRepository<TypeWork>
    {
        private CTLDbContext _context;

        public TypeWorkRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(TypeWork item)
        {
            _context.TypeWorks.Add(item);
        }

        public void Delete(int id)
        {
            TypeWork item = _context.TypeWorks.Find(id);
            if (item != null)
            {
                _context.TypeWorks.Remove(item);
            }
        }

        public IEnumerable<TypeWork> Find(Func<TypeWork, bool> predicate)
        {
            return _context.TypeWorks.Where(predicate).ToList();
        }

        public TypeWork Get(int id)
        {
            return _context.TypeWorks.Find(id);
        }

        public IEnumerable<TypeWork> GetAll()
        {
            return _context.TypeWorks;
        }

        public void Update(TypeWork item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
