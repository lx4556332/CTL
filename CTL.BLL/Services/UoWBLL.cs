using System;
using CTL.BLL.DTO;
using CTL.BLL.Interfaces;
using CTL.DAL.Interfaces;
using CTL.DAL.Repository;

namespace CTL.BLL.Services
{
    public class UoWBLL : IUoWBLL
    {
        private bool disposed = false;

        private IUoW _uow;

        private FacultyServices facultyServices;
        private CathedraServices cathedraServices;
        private AppointmentServices appointmentServices;
        private DegreeServices degreeServices;
        private QualificationLevelServices qualificationLevelServices;
        private RankServices rankServices;

        public UoWBLL(string connectionString)
        {
            _uow = new UoW(connectionString);
        }

        public IServices<FacultyDTO> Faculties
        {
            get
            {
                if (facultyServices == null)
                {
                    facultyServices = new FacultyServices(_uow);
                }
                return facultyServices;
            }
        }

        public IServices<CathedraDTO> Cathedras
        {
            get
            {
                if (cathedraServices == null)
                {
                    cathedraServices = new CathedraServices(_uow);
                }
                return cathedraServices;
            }
        }

        public IServices<AppointmentDTO> Appointments
        {
            get
            {
                if (appointmentServices == null)
                {
                    appointmentServices = new AppointmentServices(_uow);
                }
                return appointmentServices;
            }
        }

        public IServices<DegreeDTO> Degrees
        {
            get
            {
                if (degreeServices == null)
                {
                    degreeServices = new DegreeServices(_uow);
                }
                return degreeServices;
            }
        }

        public IServices<QualificationLevelDTO> QualificationLevels
        {
            get
            {
                if (qualificationLevelServices == null)
                {
                    qualificationLevelServices = new QualificationLevelServices(_uow);
                }
                return qualificationLevelServices;
            }
        }

        public IServices<RankDTO> Ranks
        {
            get
            {
                if (rankServices == null)
                {
                    rankServices = new RankServices(_uow);
                }
                return rankServices;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
