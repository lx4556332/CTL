﻿namespace CTL.WEB.Areas.Admin.Models
{
    public class SubjectDataViewModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Semestr { get; set; }
        public int FlowId { get; set; }
        public string FlowName { get; set; }


        public int SubjectInfoBId { get; set; }
        public int LectionB { get; set; }
        public int PracticeB { get; set; }
        public int LabB { get; set; }
        public double ExamB { get; set; }
        public double CreditB { get; set; }
        public double TestB { get; set; }
        public int CourseProjectB { get; set; }
        public int CourseWorkB { get; set; }
        public double RgrB { get; set; }
        public double DkrB { get; set; }
        public double SummeryB { get; set; }
        public double ConsultationB { get; set; }
        public double TotalHoursB { get; set; }

        public int SubjectInfoKId { get; set; }
        public int LectionK { get; set; }
        public int PracticeK { get; set; }
        public int LabK { get; set; }
        public double ExamK { get; set; }
        public double CreditK { get; set; }
        public double TestK { get; set; }
        public int CourseProjectK { get; set; }
        public int CourseWorkK { get; set; }
        public double RgrK { get; set; }
        public double DkrK { get; set; }
        public double SummeryK { get; set; }
        public double ConsultationK { get; set; }
        public double TotalHoursK { get; set; }


    }
}