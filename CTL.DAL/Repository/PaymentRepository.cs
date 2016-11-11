using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class PaymentRepository : IRepository<Payment>
    {
        private CTLDbContext _context;

        public PaymentRepository(CTLDbContext context)
        {
            this._context = context; ;
        }

        public void Create(Payment item)
        {
            _context.Payments.Add(item);
        }

        public void Delete(int id)
        {
            Payment item = _context.Payments.Find(id);
            if (item != null)
            {
                _context.Payments.Remove(item);
            }
        }

        public IEnumerable<Payment> Find(Func<Payment, bool> predicate)
        {
            return _context.Payments.Where(predicate).ToList();
        }

        public Payment Get(int id)
        {
            return _context.Payments.Find(id);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments;
        }

        public void Update(Payment item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
