using System;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;

namespace CTL.DAL.Repository
{
    public class UoW :IUoW
    {
        private bool disposed = false;

        private CTLDbContext _context;
        private AppointmentRepository appointmentRepository;
        private CathedraRepository cathedraRepository;
        private DegreeRepository degreeRepository;
        private FacultyRepository facultyRepository;
        private FlowRepository flowRepository;
        private GroupRepository groupRepository;
        private OtherTypeRepository otherTypeRepository;
        private PaymentRepository paymentRepository;
        private PaymentForYearsRepository paymentForYearsRepository;
        private QualificationLevelRepository qualificationLevelRepository;
        private RankRepository rankRepository;
        private SubGroupRepository subGroupRepository;
        private SubjectInfoBRepository subjectInfoBRepository;
        private SubjectInfoKRepository subjectInfoKRepository;
        private SubjectRepository subjectRepository;
        private SubTypeWorkRepository subTypeWorkRepository;
        private TeacherInfoRepository teacherInfoRepository;
        private TeacherLoadOtherTypeRepository teacherLoadOtherTypeRepository;
        private TeacherLoadRepository teacherLoadRepository;
        private TypeWorkRepository typeWorkRepository;
        private YearsCountRepository yearsCountRepository;

        public UoW(string connectionString)
        {
            this._context = new CTLDbContext(connectionString);
        }

        public IRepository<Appointment> Appointments
        {
            get
            {
                if (appointmentRepository == null)
                {
                    appointmentRepository = new AppointmentRepository(_context);
                }
                return appointmentRepository;
            }
        }

        public IRepository<Cathedra> Cathedras
        {
            get
            {
                if (cathedraRepository == null)
                {
                    cathedraRepository = new CathedraRepository(_context);
                }
                return cathedraRepository;
            }
        }

        public IRepository<Degree> Degrees
        {
            get
            {
                if (degreeRepository == null)
                {
                    degreeRepository = new DegreeRepository(_context);
                }
                return degreeRepository;
            }
        }

        public IRepository<Faculty> Faculties
        {
            get
            {
                if (facultyRepository == null)
                {
                    facultyRepository = new FacultyRepository(_context);
                }
                return facultyRepository;
            }
        }

        public IRepository<Flow> Flows
        {
            get
            {
                if (flowRepository == null)
                {
                    flowRepository = new FlowRepository(_context);
                }
                return flowRepository;
            }
        }

        public IRepository<Group> Groups
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GroupRepository(_context);
                }
                return groupRepository;
            }
        }

        public IRepository<OtherType> OtherTypes
        {
            get
            {
                if (otherTypeRepository == null)
                {
                    otherTypeRepository = new OtherTypeRepository(_context);
                }
                return otherTypeRepository;
            }
        }

        public IRepository<Payment> Payments
        {
            get
            {
                if (paymentRepository == null)
                {
                    paymentRepository = new PaymentRepository(_context);
                }
                return paymentRepository;
            }
        }

        public IRepository<PaymentForYears> PaymentForYearses
        {
            get
            {
                if (paymentForYearsRepository == null)
                {
                    paymentForYearsRepository = new PaymentForYearsRepository(_context);
                }
                return paymentForYearsRepository;
            }
        }

        public IRepository<QualificationLevel> QualificationLevels
        {
            get
            {
                if (qualificationLevelRepository == null)
                {
                    qualificationLevelRepository = new QualificationLevelRepository(_context);
                }
                return qualificationLevelRepository;
            }
        }

        public IRepository<Rank> Ranks
        {
            get
            {
                if (rankRepository == null)
                {
                    rankRepository = new RankRepository(_context);
                }
                return rankRepository;
            }
        }

        public IRepository<SubGroup> SubGroups
        {
            get
            {
                if (subGroupRepository == null)
                {
                    subGroupRepository = new SubGroupRepository(_context);
                }
                return subGroupRepository;
            }
        }

        public IRepository<Subject> Subjects
        {
            get
            {
                if (subjectRepository == null)
                {
                    subjectRepository = new SubjectRepository(_context);
                }
                return subjectRepository;
            }
        }

        public IRepository<SubjectInfoB> SubjectInfoBs
        {
            get
            {
                if (subjectInfoBRepository == null)
                {
                    subjectInfoBRepository = new SubjectInfoBRepository(_context);
                }
                return subjectInfoBRepository;
            }
        }

        public IRepository<SubjectInfoK> SubjectInfoKs
        {
            get
            {
                if (subjectInfoKRepository == null)
                {
                    subjectInfoKRepository = new SubjectInfoKRepository(_context);
                }
                return subjectInfoKRepository;
            }
        }

        public IRepository<SubTypeWork> SubTypeWorks
        {
            get
            {
                if (subTypeWorkRepository == null)
                {
                    subTypeWorkRepository = new SubTypeWorkRepository(_context);
                }
                return subTypeWorkRepository;
            }
        }

        public IRepository<TeacherInfo> TeacherInfos
        {
            get
            {
                if (teacherInfoRepository == null)
                {
                    teacherInfoRepository = new TeacherInfoRepository(_context);
                }
                return teacherInfoRepository;
            }
        }

        public IRepository<TeacherLoad> TeacherLoads
        {
            get
            {
                if (teacherLoadRepository ==null)
                {
                    teacherLoadRepository = new TeacherLoadRepository(_context);
                }
                return teacherLoadRepository;
            }
        }

        public IRepository<TeacherLoadOtherType> TeacherLoadOtherTypes
        {
            get
            {
                if (teacherLoadOtherTypeRepository == null)
                {
                    teacherLoadOtherTypeRepository = new TeacherLoadOtherTypeRepository(_context);
                }
                return teacherLoadOtherTypeRepository;
            }
        }

        public IRepository<TypeWork> TypeWorks
        {
            get
            {
                if (typeWorkRepository == null)
                {
                    typeWorkRepository = new TypeWorkRepository(_context);
                }
                return typeWorkRepository;
            }
        }

        public IRepository<YearsCount> YearsCounts
        {
            get
            {
                if (yearsCountRepository == null)
                {
                    yearsCountRepository = new YearsCountRepository(_context);
                }
                return yearsCountRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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