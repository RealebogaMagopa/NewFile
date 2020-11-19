using System;
using System.Collections.Generic;

namespace WebApplication11.Models
{
    public partial class Cost
    {
        public int CostId { get; set; }
        public int? EmployeeNumber { get; set; }
        public int HourlyRate { get; set; }
        public int DailyRate { get; set; }
        public int MonthlyIncome { get; set; }
        public int MonthlyRate { get; set; }
        public int PercentSalaryHike { get; set; }

        public virtual EmployeeDetail EmployeeNumberNavigation { get; set; }
    }
}
