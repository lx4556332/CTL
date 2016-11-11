using System;
using System.Collections.Generic;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System.Data.Entity;

namespace CTL.DAL.Repository
{
    public class RankRepository : IRepository<Rank>
    {
        private CTLDbContext _context;

        public RankRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Rank item)
        {
            _context.Ranks.Add(item);
        }

        public void Delete(int id)
        {
            Rank item = _context.Ranks.Find(id);
            if (item != null)
            {
                _context.Ranks.Remove(item);
            }
        }

        public IEnumerable<Rank> Find(Func<Rank, bool> predicate)
        {
            return _context.Ranks.Where(predicate).ToList();
        }

        public Rank Get(int id)
        {
            return _context.Ranks.Find(id);
        }

        public IEnumerable<Rank> GetAll()
        {
            return _context.Ranks;
        }

        public void Update(Rank item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
