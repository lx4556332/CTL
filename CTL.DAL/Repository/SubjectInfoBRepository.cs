using System;
using System.Collections.Generic;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System.Linq;
using System.Data.Entity;

namespace CTL.DAL.Repository
{
    public class SubjectInfoBRepository : IRepository<SubjectInfoB>
    {
        private CTLDbContext _context;

        public SubjectInfoBRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(SubjectInfoB item)
        {
            _context.SubjectInfoBs.Add(item);
        }

        public void Delete(int id)
        {
            SubjectInfoB item = _context.SubjectInfoBs.Find(id);
            if (item != null)
            {
                _context.SubjectInfoBs.Remove(item);
            }
        }

        public IEnumerable<SubjectInfoB> Find(Func<SubjectInfoB, bool> predicate)
        {
            return _context.SubjectInfoBs.Where(predicate).ToList();
        }

        public SubjectInfoB Get(int id)
        {
            return _context.SubjectInfoBs.Find(id);
        }

        public IEnumerable<SubjectInfoB> GetAll()
        {
            return _context.SubjectInfoBs;
        }

        public void Update(SubjectInfoB item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
