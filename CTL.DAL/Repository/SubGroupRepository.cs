using System;
using System.Collections.Generic;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System.Linq;
using System.Data.Entity;

namespace CTL.DAL.Repository
{
    public class SubGroupRepository : IRepository<SubGroup>
    {
        private CTLDbContext _context;

        public SubGroupRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(SubGroup item)
        {
            _context.SubGroups.Add(item);
        }

        public void Delete(int id)
        {
            SubGroup item = _context.SubGroups.Find(id);
            if (item != null)
            {
                _context.SubGroups.Remove(item);
            }
        }

        public IEnumerable<SubGroup> Find(Func<SubGroup, bool> predicate)
        {
            return _context.SubGroups.Where(predicate).ToList();
        }

        public SubGroup Get(int id)
        {
            return _context.SubGroups.Find(id);
        }

        public IEnumerable<SubGroup> GetAll()
        {
            return _context.SubGroups;
        }

        public void Update(SubGroup item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
