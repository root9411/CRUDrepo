using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeProject.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpDOB { get; set; }
        public string JoiningDate { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }

        public string Name
        {
            get { return $"{EmpFirstName} {EmpLastName}"; }

        }

    }
}