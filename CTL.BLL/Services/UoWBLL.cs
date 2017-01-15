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
        private TypeWorkServices typeWorkServices;
        private SubTypeWorkServices subTypeWorkServices;
        private YearsCountServices yearsCountServices;
        private FlowServices flowServices;
        private GroupServices groupServices;
        private SubGroupServices subGroupServices;
        private SubjectServices subjectServices;
        private TeacherInfoServices teacherInfoServices;
        private SubjectInfoBServices subjectInfoBServices;
        private SubjectInfoKServices subjectInfoKServices;

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

        public IServices<TypeWorkDTO> TypeWorks
        {
            get
            {
                if (typeWorkServices == null)
                {
                    typeWorkServices = new TypeWorkServices(_uow);
                }
                return typeWorkServices;
            }
        }

        public IServices<SubTypeWorkDTO> SubTypeWorks
        {
            get
            {
                if (subTypeWorkServices == null)
                {
                    subTypeWorkServices = new SubTypeWorkServices(_uow);
                }
                return subTypeWorkServices;
            }
        }

        public IServices<YearsCountDTO> YearsCounts
        {
            get
            {
                if (yearsCountServices == null)
                {
                    yearsCountServices = new YearsCountServices(_uow);
                }
                return yearsCountServices;
            }
        }

        public IServices<FlowDTO> Flows
        {
            get
            {
                if (flowServices == null)
                {
                    flowServices = new FlowServices(_uow);
                }
                return flowServices;
            }
        }

        public IServices<GroupDTO> Groups
        {
            get
            {
                if (groupServices == null)
                {
                    groupServices = new GroupServices(_uow);
                }
                return groupServices;
            }
        }

        public IServices<SubGroupDTO> SubGroups
        {
            get
            {
                if (subGroupServices == null)
                {
                    subGroupServices = new SubGroupServices(_uow);
                }
                return subGroupServices;
            }
        }

        public IServices<SubjectDTO> Subjects
        {
            get
            {
                if (subjectServices == null)
                {
                    subjectServices = new SubjectServices(_uow);
                }
                return subjectServices;
            }
        }

        public IServices<TeacherInfoDTO> TeacherInfos
        {
            get
            {
                if (teacherInfoServices == null)
                {
                    teacherInfoServices = new TeacherInfoServices(_uow);
                }
                return teacherInfoServices;
            }
        }

        public IServices<SubjectInfoBDTO> SubjectInfoBs
        {
            get
            {
                if (subjectInfoBServices == null)
                {
                    subjectInfoBServices = new SubjectInfoBServices(_uow);
                }
                return subjectInfoBServices;
            }
        }

        public IServices<SubjectInfoKDTO> SubjectInfoKs
        {
            get
            {
                if (subjectInfoKServices == null)
                {
                    subjectInfoKServices = new SubjectInfoKServices(_uow);
                }
                return subjectInfoKServices;
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
