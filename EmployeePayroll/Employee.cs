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
        public string Startdate { get; set; }

        public Employee(string Name, string Gender, string Phone, string Address, string Department, int Salary, string Startdate)
        {
            this.Name = Name;
            this.Gender = Gender;
            this.Phone = Phone;
            this.Address = Address;
            this.Department = Department;
            this.Salary = Salary;
            this.Startdate = Startdate;
        }

        public Employee()
        {

        }
    }
}
