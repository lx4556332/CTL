using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class CathedraRepository : IRepository<Cathedra>
    {
        private CTLDbContext _context;

        public CathedraRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Cathedra item)
        {
            _context.Cathedras.Add(item);
        }

        public void Delete(int id)
        {
            Cathedra item = _context.Cathedras.Find(id);
            if (item != null)
            {
                _context.Cathedras.Remove(item);
            }
        }

        public IEnumerable<Cathedra> Find(Func<Cathedra, bool> predicate)
        {
            return _context.Cathedras.Where(predicate).ToList();
        }

        public Cathedra Get(int id)
        {
            return _context.Cathedras.Find(id);
        }

        public IEnumerable<Cathedra> GetAll()
        {
            return _context.Cathedras;
        }

        public void Update(Cathedra item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}