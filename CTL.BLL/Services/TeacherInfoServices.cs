using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTL.BLL.Services
{
    public class TeacherInfoServices : IServices<TeacherInfoDTO>
    {
        private string _nameTable = "\"Викладачі\"!";
        private IUoW Database { get; set; }

        public TeacherInfoServices(IUoW uow)
        {
            Database = uow;
        }

        public void Create(TeacherInfoDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                var rank = Database.Ranks.GetAll().FirstOrDefault(r => r.Id == item.RankId);
                var appointment = Database.Appointments.GetAll().FirstOrDefault(a => a.Id == item.AppointmentId);
                var degree = Database.Degrees.GetAll().FirstOrDefault(d => d.Id == item.DegreeId);
                var cathedra = Database.Cathedras.GetAll().FirstOrDefault(c => c.Id == item.CathedraId);
               
                TeacherInfo teacherInfo = new TeacherInfo { LastName = item.LastName, Name = item.Name, MiddleName = item.MiddleName, Initials = item.Initials, Allowance = item.Allowance, Rank = rank, Appointment = appointment, Degree = degree, Cathedra = cathedra };

                Database.TeacherInfos.Create(teacherInfo);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка створення нового запису в таблиці " + _nameTable, "");
            }
        }

        public void Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису з таблиці" + _nameTable, "");
                }

                Database.TeacherInfos.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public TeacherInfoDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                var teacherInfo = Database.TeacherInfos.Get(id.Value);

                if (teacherInfo == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                TeacherInfoDTO teacherInfoDTO = new TeacherInfoDTO
                {
                    Id = teacherInfo.Id,
                    LastName = teacherInfo.LastName,
                    Name = teacherInfo.Name,
                    MiddleName = teacherInfo.MiddleName,
                    Initials = teacherInfo.Initials,
                    AppointmentId = teacherInfo.Appointment.Id,
                    AppointmentName = teacherInfo.Appointment.Name,
                    DegreeId = teacherInfo.Degree.Id,
                    DegreeName = teacherInfo.Degree.Name,
                    RankId = teacherInfo.Rank.Id,
                    RankName = teacherInfo.Rank.Name,
                    CathedraId = teacherInfo.Cathedra.Id,
                    CathedraName = teacherInfo.Cathedra.Name,
                    Allowance = teacherInfo.Allowance
                };

                return teacherInfoDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<TeacherInfoDTO> ReadAll()
        {
            try
            {
                var teacherInfos = Database.TeacherInfos.GetAll();

                if (teacherInfos == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<TeacherInfoDTO> teacherInfoDTO = new List<TeacherInfoDTO>();

                foreach (var item in teacherInfos)
                {
                    teacherInfoDTO.Add(new TeacherInfoDTO
                    {
                        Id = item.Id,
                        LastName = item.LastName,
                        Name = item.Name,
                        MiddleName = item.MiddleName,
                        Initials = item.Initials,
                        AppointmentId = item.Appointment.Id,
                        AppointmentName = item.Appointment.Name,
                        DegreeId = item.Degree.Id,
                        DegreeName = item.Degree.Name,
                        RankId = item.Rank.Id,
                        RankName = item.Rank.Name,
                        CathedraId = item.Cathedra.Id,
                        CathedraName = item.Cathedra.Name,
                        Allowance = item.Allowance
                    });
                }

                return teacherInfoDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(TeacherInfoDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var teacherInfo = Database.TeacherInfos.Get(item.Id);

                if (teacherInfo == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                var appointment = Database.Appointments.Get(item.AppointmentId);
                var degree = Database.Degrees.Get(item.DegreeId);
                var rank = Database.Ranks.Get(item.RankId);
                var cathedra = Database.Cathedras.Get(item.CathedraId);

                teacherInfo.LastName = item.LastName;
                teacherInfo.Name = item.Name;
                teacherInfo.MiddleName = item.MiddleName;
                teacherInfo.Initials = item.Initials;
                teacherInfo.Appointment = appointment;
                teacherInfo.Degree = degree;
                teacherInfo.Rank = rank;
                teacherInfo.Cathedra = cathedra;
                teacherInfo.Allowance = item.Allowance;

                Database.TeacherInfos.Update(teacherInfo);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
