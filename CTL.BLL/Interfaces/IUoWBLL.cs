using CTL.BLL.DTO;
using System;

namespace CTL.BLL.Interfaces
{
    public interface IUoWBLL: IDisposable
    {
        IServices<FacultyDTO> Faculties { get; }
        IServices<CathedraDTO> Cathedras { get; }
        IServices<AppointmentDTO> Appointments { get; }
        IServices<DegreeDTO> Degrees { get; }
        IServices<QualificationLevelDTO> QualificationLevels { get; }
        IServices<RankDTO> Ranks { get; }
        IServices<TypeWorkDTO> TypeWorks { get; }
        IServices<SubTypeWorkDTO> SubTypeWorks { get; }
        IServices<YearsCountDTO> YearsCounts { get; }
        IServices<FlowDTO> Flows { get; }
        IServices<GroupDTO> Groups { get; }
        IServices<SubGroupDTO> SubGroups { get; }
        IServices<SubjectDTO> Subjects { get; }
        IServices<SubjectInfoBDTO> SubjectInfoBs { get; }
        IServices<SubjectInfoKDTO> SubjectInfoKs { get; }
        IServices<TeacherInfoDTO> TeacherInfos { get; }
        //IServices<TeacherLoadDTO> TeacherLoads { get; }
        //IServices<TeacherLoadOtherTypeDTO> TeacherLoadOtherTypes { get; }
        //IServices<OtherTypeDTO> OtherTypes { get; }
        //IServices<PaymentDTO> Payments { get; }
        //IServices<PaymentForYearsDTO> PaymentForYears { get; }
    }
}
