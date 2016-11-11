using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class TeacherLoadRepository : IRepository<TeacherLoad>
    {
        private CTLDbContext _context;

        public TeacherLoadRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(TeacherLoad item)
        {
            _context.TeacherLoads.Add(item);
        }

        public void Delete(int id)
        {
            TeacherLoad item = _context.TeacherLoads.Find(id);
            if(item != null)
            {
                _context.TeacherLoads.Remove(item);
            }
        }

        public IEnumerable<TeacherLoad> Find(Func<TeacherLoad, bool> predicate)
        {
            return _context.TeacherLoads.Where(predicate).ToList();
        }

        public TeacherLoad Get(int id)
        {
            return _context.TeacherLoads.Find(id);
        }

        public IEnumerable<TeacherLoad> GetAll()
        {
            return _context.TeacherLoads;
        }

        public void Update(TeacherLoad item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
