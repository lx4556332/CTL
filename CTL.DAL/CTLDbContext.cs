using System.Data.Entity;
using CTL.DAL.Entities;

namespace CTL.DAL
{
    public class CTLDbContext : DbContext
    {
        //static CTLDbContext()
        //{
        //    Database.SetInitializer<CTLDbConext>()
        //}

        public CTLDbContext(string connectionString) : base(connectionString)
        {
            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cathedra> Cathedras { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<OtherType> OtherTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentForYears> PaymentForYearses { get; set; }
        public DbSet<QualificationLevel> QualificationLevels { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectInfoB> SubjectInfoBs { get; set; }
        public DbSet<SubjectInfoK> SubjectInfoKs { get; set; }
        public DbSet<SubTypeWork> SubTypeWorks { get; set; }
        public DbSet<TeacherInfo> TeacherInfos { get; set; }
        public DbSet<TeacherLoad> TeacherLoads { get; set; }
        public DbSet<TeacherLoadOtherType> TeacherLoadOtherTypes { get; set; }
        public DbSet<TypeWork> TypeWorks { get; set; }
        public DbSet<YearsCount> YearsCounts { get; set; }

    }
}
