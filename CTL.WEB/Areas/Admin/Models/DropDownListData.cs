using CTL.BLL.DTO;
using CTL.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Models
{
    public class DropDownListData
    {
        private IUoWBLL dataServices;

        public DropDownListData(IUoWBLL data)
        {
            dataServices = data;
        }

        //Список ОКР
        public List<SelectListItem> GetQualificationLevelList(int id)
        {
            IEnumerable<QualificationLevelDTO> qualificationLevelDTO = dataServices.QualificationLevels.ReadAll();

            List<SelectListItem> qualificationLevelList = new List<SelectListItem>();

            foreach (var item in qualificationLevelDTO)
            {
                qualificationLevelList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name, Selected = (id == item.Id) ? true : false });
            }

            return qualificationLevelList;
        }

        //Список кафедр
        public List<SelectListItem> GetCathedraList(int id)
        {
            IEnumerable<CathedraDTO> cathedraDTO = dataServices.Cathedras.ReadAll();

            List<SelectListItem> cathedraList = new List<SelectListItem>();

            foreach (var item in cathedraDTO)
            {
                cathedraList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name, Selected = (id == item.Id) ? true : false });
            }

            return cathedraList;
        }

        //Список курсів
        public List<SelectListItem> GetCourseList(int course)
        {
            Dictionary<int, string> courses = new Dictionary<int, string>();
            courses.Add(1, "1");
            courses.Add(2, "2");
            courses.Add(3, "3");
            courses.Add(4, "4");
            courses.Add(5, "5");
            courses.Add(6, "6");

            List<SelectListItem> courseList = new List<SelectListItem>();

            foreach (var item in courses)
            {
                courseList.Add(new SelectListItem { Value = item.Key.ToString(), Text = item.Value, Selected = (course == item.Key) ? true : false });
            }

            return courseList;
        }

        //Список типів навчань
        public List<SelectListItem> GetEducationTypeList(string eduTypeName)
        {
            Dictionary<string, string> educationType = new Dictionary<string, string>();
            educationType.Add("Бюджет", "Бюджет");
            educationType.Add("Контракт", "Контракт");

            List<SelectListItem> educationTypeList = new List<SelectListItem>();

            foreach (var item in educationType)
            {
                educationTypeList.Add(new SelectListItem { Value = item.Key, Text = item.Value, Selected = (eduTypeName == item.Value) ? true : false });
            }

            return educationTypeList;
        }

        //Список форм навчань
        public List<SelectListItem> GetEducationFormList(string eduFormName)
        {
            Dictionary<string, string> educationForm = new Dictionary<string, string>();
            educationForm.Add("Денна", "Денна");
            educationForm.Add("Заочна", "Заочна");
            

            List<SelectListItem> educationFormList = new List<SelectListItem>();

            foreach (var item in educationForm)
            {
                educationFormList.Add(new SelectListItem { Value = item.Key, Text = item.Value, Selected = (eduFormName == item.Value) ? true : false });
            }

            return educationFormList;
        }

        //Список факульетів
        public List<SelectListItem> GetFacultyList(int id)
        {
            IEnumerable<FacultyDTO> facultyDTO = dataServices.Faculties.ReadAll();

            List<SelectListItem> facultyList = new List<SelectListItem>();

            foreach (var item in facultyDTO)
            {
                facultyList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name, Selected = (id == item.Id) ? true : false });
            }

            return facultyList;
        }

        //Список семестрів
        public List<SelectListItem> GetSemestr(int semestr)
        {
            Dictionary<int, string> semestrs = new Dictionary<int, string>();
            semestrs.Add(1, "1");
            semestrs.Add(2, "2");

            List<SelectListItem> semestrList = new List<SelectListItem>();

            foreach (var item in semestrs)
            {
                semestrList.Add(new SelectListItem { Value = item.Key.ToString(), Text = item.Value, Selected = (semestr == item.Key) ? true : false });
            }

            return semestrList;
        }

        //Список посад
        public List<SelectListItem> GetAppointmentList(int id)
        {
            IEnumerable<AppointmentDTO> appointmentDTO = dataServices.Appointments.ReadAll();

            List<SelectListItem> appointmentList = new List<SelectListItem>();

            foreach (var item in appointmentDTO)
            {
                appointmentList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FullName, Selected = (id == item.Id) ? true : false });
            }

            return appointmentList;
        }

        //Список ступенів
        public List<SelectListItem> GetDegreeList(int id)
        {
            IEnumerable<DegreeDTO> degreeDTO = dataServices.Degrees.ReadAll();

            List<SelectListItem> degreeList = new List<SelectListItem>();

            foreach (var item in degreeDTO)
            {
                degreeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FullName, Selected = (id == item.Id) ? true : false });
            }

            return degreeList;
        }

        //Список звань
        public List<SelectListItem> GetRankList(int id)
        {
            IEnumerable<RankDTO> rankDTO = dataServices.Ranks.ReadAll();

            List<SelectListItem> rankList = new List<SelectListItem>();

            foreach (var item in rankDTO)
            {
                rankList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FullName, Selected = (id == item.Id) ? true : false });
            }

            return rankList;
        }

    }
}