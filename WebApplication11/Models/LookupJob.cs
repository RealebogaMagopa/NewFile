using System;
using System.Collections.Generic;

namespace WebApplication11.Models
{
    public partial class LookupJob
    {
        public string EmployeeNumber { get; set; }
        public int JobRoleCode { get; set; }
        public string Department { get; set; }
        public string JobInvolvement { get; set; }
        public string JobLevel { get; set; }
        public string JobSatisfaction { get; set; }
    }
}
