using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CTL.DAL.Repository
{
    public class OtherTypeRepository : IRepository<OtherType>
    {
        private CTLDbContext _context;

        public OtherTypeRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(OtherType item)
        {
            _context.OtherTypes.Add(item);
        }

        public void Delete(int id)
        {
            OtherType item = _context.OtherTypes.Find(id);
            if(item != null)
            {
                _context.OtherTypes.Remove(item);
            }
        }

        public IEnumerable<OtherType> Find(Func<OtherType, bool> predicate)
        {
            return _context.OtherTypes.Where(predicate).ToList();
        }

        public OtherType Get(int id)
        {
            return _context.OtherTypes.Find(id);
        }

        public IEnumerable<OtherType> GetAll()
        {
            return _context.OtherTypes;
        }

        public void Update(OtherType item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
