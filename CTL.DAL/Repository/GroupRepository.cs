using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CTL.DAL.Repository
{
    public class GroupRepository : IRepository<Group>
    {
        private CTLDbContext _context;

        public GroupRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Group item)
        {
            _context.Groups.Add(item);
        }

        public void Delete(int id)
        {
            Group item = _context.Groups.Find(id);
            if (item != null)
            {
                _context.Groups.Remove(item);
            }
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return _context.Groups.Where(predicate).ToList();
        }

        public Group Get(int id)
        {
            return _context.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups;
        }

        public void Update(Group item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}