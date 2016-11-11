using System;
using System.Collections.Generic;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System.Data.Entity;

namespace CTL.DAL.Repository
{
    public class FlowRepository : IRepository<Flow>
    {
        private CTLDbContext _context;

        public FlowRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Flow item)
        {
            _context.Flows.Add(item);
        }

        public void Delete(int id)
        {
            Flow item = _context.Flows.Find(id);
            if(item != null)
            {
                _context.Flows.Remove(item);
            }
        }

        public IEnumerable<Flow> Find(Func<Flow, bool> predicate)
        {
            return _context.Flows.Where(predicate).ToList();
        }

        public Flow Get(int id)
        {
            return _context.Flows.Find(id);
        }

        public IEnumerable<Flow> GetAll()
        {
            return _context.Flows;
        }

        public void Update(Flow item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}