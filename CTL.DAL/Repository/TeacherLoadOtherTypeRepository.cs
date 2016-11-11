using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class TeacherLoadOtherTypeRepository : IRepository<TeacherLoadOtherType>
    {
        private CTLDbContext _context;

        public TeacherLoadOtherTypeRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(TeacherLoadOtherType item)
        {
            _context.TeacherLoadOtherTypes.Add(item);
        }

        public void Delete(int id)
        {
            TeacherLoadOtherType item = _context.TeacherLoadOtherTypes.Find(id);
            if(item != null)
            {
                _context.TeacherLoadOtherTypes.Remove(item);
            }
        }

        public IEnumerable<TeacherLoadOtherType> Find(Func<TeacherLoadOtherType, bool> predicate)
        {
            return _context.TeacherLoadOtherTypes.Where(predicate).ToList();
        }

        public TeacherLoadOtherType Get(int id)
        {
            return _context.TeacherLoadOtherTypes.Find(id);
        }

        public IEnumerable<TeacherLoadOtherType> GetAll()
        {
            return _context.TeacherLoadOtherTypes;
        }

        public void Update(TeacherLoadOtherType item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
