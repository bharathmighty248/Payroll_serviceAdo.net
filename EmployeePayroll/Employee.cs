using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public DateTime Startdate { get; set; }
    }
}
