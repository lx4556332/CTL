using System;
using System.Collections.Generic;
using CTL.DAL.Interfaces;
using CTL.DAL.Entities;
using System.Linq;
using System.Data.Entity;

namespace CTL.DAL.Repository
{
    public class FacultyRepository : IRepository<Faculty>
    {
        private CTLDbContext _context;

        public FacultyRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Faculty item)
        {
            _context.Faculties.Add(item);
        }

        public void Delete(int id)
        {
            Faculty item = _context.Faculties.Find(id);
            if (item != null)
            {
                _context.Faculties.Remove(item);
            }
        }

        public IEnumerable<Faculty> Find(Func<Faculty, bool> predicate)
        {
            return _context.Faculties.Where(predicate).ToList();
        }

        public Faculty Get(int id)
        {
            return _context.Faculties.Find(id);
        }

        public IEnumerable<Faculty> GetAll()
        {
            return _context.Faculties;
        }

        public void Update(Faculty item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
