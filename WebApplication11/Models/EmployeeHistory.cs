using System;
using System.Collections.Generic;

namespace WebApplication11.Models
{
    public partial class EmployeeHistory
    {
        public int EmployeeHistoryId { get; set; }
        public int YearsAtCompany { get; set; }
        public int YearsInCurrentRole { get; set; }
        public int YearsSinceLastPromotion { get; set; }
        public int YearsWithCurrManager { get; set; }
        public int EnvironmentSatisfaction { get; set; }
        public int RelationshipSatisfaction { get; set; }
        public int StandardHours { get; set; }
        public int StockOptionLevel { get; set; }
        public int TotalWorkingYears { get; set; }
        public int TrainingTimesLastYear { get; set; }
        public int WorkLifeBalance { get; set; }
        public int PerformanceRating { get; set; }
        public int NumCompaniesWorked { get; set; }
        public string Over18 { get; set; }
        public string OverTime { get; set; }
        public string Attrition { get; set; }
        public string BusinessTravel { get; set; }
        public int? EmployeeNumber { get; set; }

        public virtual EmployeeDetail EmployeeNumberNavigation { get; set; }
    }
}
