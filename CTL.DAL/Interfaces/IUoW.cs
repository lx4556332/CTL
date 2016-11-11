using System;
using CTL.DAL.Entities;

namespace CTL.DAL.Interfaces
{
    public interface IUoW: IDisposable
    {
        IRepository<Appointment> Appointments { get; }
        IRepository<Cathedra> Cathedras { get; }
        IRepository<Degree> Degrees { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Flow> Flows { get; }
        IRepository<Group> Groups { get; }
        IRepository<OtherType> OtherTypes { get; }
        IRepository<Payment> Payments { get; }
        IRepository<PaymentForYears> PaymentForYearses { get; }
        IRepository<QualificationLevel> QualificationLevels { get; }
        IRepository<Rank> Ranks { get; }
        IRepository<SubGroup> SubGroups { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<SubjectInfoB> SubjectInfoBs { get; }
        IRepository<SubjectInfoK> SubjectInfoKs { get; }
        IRepository<SubTypeWork> SubTypeWorks { get; }
        IRepository<TeacherInfo> TeacherInfos { get; }
        IRepository<TeacherLoad> TeacherLoads { get; }
        IRepository<TeacherLoadOtherType> TeacherLoadOtherTypes { get; }
        IRepository<TypeWork> TypeWorks { get; }
        IRepository<YearsCount> YearsCounts { get; }
        void Save();
    }
}