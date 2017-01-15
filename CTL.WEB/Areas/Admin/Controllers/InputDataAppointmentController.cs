using CTL.BLL.DTO;
using CTL.BLL.Infrastructure;
using CTL.BLL.Interfaces;
using CTL.WEB.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class InputDataAppointmentController : Controller
    {
        private IUoWBLL dataServices;

        public InputDataAppointmentController(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список посад
        // GET: Admin/InputDataAppointment
        public ActionResult Index()
        {
            try
            {
                IEnumerable<AppointmentDTO> appointmentDTO = dataServices.Appointments.ReadAll();

                List<AppointmentViewModel> appointmentViewModel = new List<AppointmentViewModel>();

                foreach (var item in appointmentDTO)
                {
                    appointmentViewModel.Add(new AppointmentViewModel { Id = item.Id, Name = item.Name, FullName = item.FullName });
                }

                return View(appointmentViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Створення посади
        // GET: Admin/CreateAppointment
        public ActionResult CreateAppointment()
        {
            return View();
        }

        //Створення посади
        // POST: Admin/CreateAppointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppointment(AppointmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appointmentDTO = new AppointmentDTO { Name = model.Name, FullName = model.FullName };
                    dataServices.Appointments.Create(appointmentDTO);
                }

                return RedirectToAction("Index", "InputDataAppointment");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Message, ex.Property);
            }

            return View(model);
        }

        //Редагування посади
        // GET: Admin/EditAppointment
        public ActionResult EditAppointment(int? id)
        {
            try
            {
                AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
                if (id != null)
                {
                    var appointment = dataServices.Appointments.Read(id);
                    if (appointment != null)
                    {
                        appointmentViewModel.Id = appointment.Id;
                        appointmentViewModel.Name = appointment.Name;
                        appointmentViewModel.FullName = appointment.FullName;
                    }
                }

                return View(appointmentViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Редагування посади
        // POST: Admin/EditAppointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment(AppointmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO { Id = model.Id, Name = model.Name, FullName = model.FullName };
                    dataServices.Appointments.Update(appointmentDTO);
                }
                else
                {
                    return View(model);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataAppointment");
        }

        //Видалення посади
        // GET: Admin/DeleteAppointment
        public ActionResult DeleteAppointment(int? id)
        {
            try
            {
                AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
                if (id != null)
                {
                    var appointment = dataServices.Appointments.Read(id);
                    if (appointment != null)
                    {
                        appointmentViewModel.Id = appointment.Id;
                        appointmentViewModel.Name = appointment.Name;
                        appointmentViewModel.FullName = appointment.FullName;
                    }
                }

                return View(appointmentViewModel);
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }
        }

        //Видалення посади
        // POST: Admin/DeleteAppointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppointment(AppointmentViewModel model)
        {
            try
            {
                if (model != null)
                {
                    AppointmentDTO appointmentDTO = new AppointmentDTO { Id = model.Id };
                    dataServices.Appointments.Delete(appointmentDTO.Id);
                }
            }
            catch (ValidationException ex)
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml", ex);
            }

            return RedirectToAction("Index", "InputDataAppointment");
        }

        protected override void Dispose(bool disposing)
        {
            dataServices.Dispose();
            base.Dispose(disposing);
        }
    }
}