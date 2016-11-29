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

    }
}
