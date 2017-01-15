using System.Data.Entity;
using CTL.DAL.Entities;

namespace CTL.DAL
{
    public class CTLDbContext : DbContext
    {
        static CTLDbContext()
        {
            //Database.SetInitializer<CTLDbContext>(new DropCreateDatabaseAlways<CTLDbContext>());

            Database.SetInitializer<CTLDbContext>(new DropCreateDatabaseIfModelChanges<CTLDbContext>());
        }

        public CTLDbContext(string connectionString) : base(connectionString)
        {
            
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cathedra> Cathedras { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Flow> Flows { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<OtherType> OtherTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentForYears> PaymentForYearses { get; set; }
        public virtual DbSet<QualificationLevel> QualificationLevels { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<SubGroup> SubGroups { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectInfoB> SubjectInfoBs { get; set; }
        public virtual DbSet<SubjectInfoK> SubjectInfoKs { get; set; }
        public virtual DbSet<SubTypeWork> SubTypeWorks { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfos { get; set; }
        public virtual DbSet<TeacherLoad> TeacherLoads { get; set; }
        public virtual DbSet<TeacherLoadOtherType> TeacherLoadOtherTypes { get; set; }
        public virtual DbSet<TypeWork> TypeWorks { get; set; }
        public virtual DbSet<YearsCount> YearsCounts { get; set; }
    }
}
