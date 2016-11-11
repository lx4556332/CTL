using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class TeacherInfoRepository : IRepository<TeacherInfo>
    {
        private CTLDbContext _context;

        public TeacherInfoRepository(CTLDbContext context)
        {
            this._context = context;
        }

        public void Create(TeacherInfo item)
        {
            _context.TeacherInfos.Add(item);
        }

        public void Delete(int id)
        {
            TeacherInfo item = _context.TeacherInfos.Find(id);
            if(item != null)
            {
                _context.TeacherInfos.Remove(item);
            }
        }

        public IEnumerable<TeacherInfo> Find(Func<TeacherInfo, bool> predicate)
        {
            return _context.TeacherInfos.Where(predicate).ToList();
        }

        public TeacherInfo Get(int id)
        {
            return _context.TeacherInfos.Find(id);
        }

        public IEnumerable<TeacherInfo> GetAll()
        {
            return _context.TeacherInfos;
        }

        public void Update(TeacherInfo item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
