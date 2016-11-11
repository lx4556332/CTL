using System;
using System.Collections.Generic;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System.Data.Entity;

namespace CTL.DAL.Repository
{
    public class PaymentForYearsRepository : IRepository<PaymentForYears>
    {
        private CTLDbContext _context;

        public PaymentForYearsRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(PaymentForYears item)
        {
            _context.PaymentForYearses.Add(item);
        }

        public void Delete(int id)
        {
            PaymentForYears item = _context.PaymentForYearses.Find(id);
            if (item != null)
            {
                _context.PaymentForYearses.Remove(item);
            }
        }

        public IEnumerable<PaymentForYears> Find(Func<PaymentForYears, bool> predicate)
        {
            return _context.PaymentForYearses.Where(predicate).ToList();
        }

        public PaymentForYears Get(int id)
        {
            return _context.PaymentForYearses.Find(id);
        }

        public IEnumerable<PaymentForYears> GetAll()
        {
            return _context.PaymentForYearses;
        }

        public void Update(PaymentForYears item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
