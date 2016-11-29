using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.DAL.Entities;
using CTL.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CTL.BLL.Services
{
    public class AppointmentServices : IServices<AppointmentDTO>
    {
        private string _nameTable = "\"Посада\"!";

        IUoW Database { get; set; }

        public AppointmentServices(IUoW uow)
        {
            Database = uow;
        }
        public void Create(AppointmentDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для створення запису в таблиці " + _nameTable, "");
                }

                Appointment appointment = new Appointment { Name = item.Name };

                Database.Appointments.Create(appointment);
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
                    throw new ValidationException("Не встановлено id обраного запису в таблиці" + _nameTable, "");
                }

                Database.Appointments.Delete(id.Value);
                Database.Save();
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка видалення запису з таблиці " + _nameTable, "");
            }
        }

        public AppointmentDTO Read(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                var appointment = Database.Appointments.Get(id.Value);

                if (appointment == null)
                {
                    throw new ValidationException("Дані про посаду не знайдено!", "");
                }

                AppointmentDTO appointmentDTO = new AppointmentDTO { Id = appointment.Id, Name = appointment.Name };

                return appointmentDTO;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання запису з таблиці " + _nameTable, "");
            }
        }

        public IEnumerable<AppointmentDTO> ReadAll()
        {
            try
            {
                var appointment = Database.Appointments.GetAll();

                if (appointment == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();

                foreach (var item in appointment)
                {
                    appointmentDTOs.Add(new AppointmentDTO { Id = item.Id, Name = item.Name });
                }

                return appointmentDTOs;
            }
            catch (Exception)
            {
                throw new ValidationException("Помилка читання записів з таблиці " + _nameTable, "");
            }
        }

        public void Update(AppointmentDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new ValidationException("Відсутні дані для оновлення запису в таблиці " + _nameTable, "");
                }

                var appointment = Database.Appointments.Get(item.Id);

                if (appointment == null)
                {
                    throw new ValidationException("Дані про запис з таблиці" + _nameTable + " не знайдено!", "");
                }

                appointment.Name = item.Name;

                Database.Appointments.Update(appointment);
                Database.Save();

            }
            catch (Exception)
            {
                throw new ValidationException("Помилка оновлення запису в таблиці " + _nameTable, "");
            }
        }
    }
}
