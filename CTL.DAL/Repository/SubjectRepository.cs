using System;
using System.Collections.Generic;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System.Linq;
using System.Data.Entity;

namespace CTL.DAL.Repository
{
    public class SubjectRepository : IRepository<Subject>
    {
        private CTLDbContext _context;

        public SubjectRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Subject item)
        {
            _context.Subjects.Add(item);
        }

        public void Delete(int id)
        {
            Subject item = _context.Subjects.Find(id);
            if (item != null)
            {
                _context.Subjects.Remove(item);
            }
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            return _context.Subjects.Where(predicate).ToList();
        }

        public Subject Get(int id)
        {
            return _context.Subjects.Find(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects;
        }

        public void Update(Subject item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
