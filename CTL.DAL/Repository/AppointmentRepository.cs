using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private CTLDbContext _context;

        public AppointmentRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(Appointment item)
        {
            _context.Appointments.Add(item);
        }

        public void Delete(int id)
        {
            Appointment item = _context.Appointments.Find(id);
            if (item != null)
            {
                _context.Appointments.Remove(item); 
            }
        }

        public IEnumerable<Appointment> Find(Func<Appointment, bool> predicate)
        {
            return _context.Appointments.Where(predicate).ToList();
        }

        public Appointment Get(int id)
        {
            return _context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments;
        }

        public void Update(Appointment item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}