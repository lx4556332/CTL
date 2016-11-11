using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class DegreeRepository : IRepository<Degree>
    {
        private CTLDbContext _context;

        public DegreeRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Degree item)
        {
            _context.Degrees.Add(item);
        }

        public void Delete(int id)
        {
            Degree item = _context.Degrees.Find(id);
            if (item != null)
            {
                _context.Degrees.Remove(item);
            }
        }

        public IEnumerable<Degree> Find(Func<Degree, bool> predicate)
        {
            return _context.Degrees.Where(predicate).ToList();
        }

        public Degree Get(int id)
        {
            return _context.Degrees.Find(id);
        }

        public IEnumerable<Degree> GetAll()
        {
            return _context.Degrees;
        }

        public void Update(Degree item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
