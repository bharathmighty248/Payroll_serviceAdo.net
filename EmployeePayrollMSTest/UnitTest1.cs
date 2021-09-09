using EmployeePayroll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EmployeePayrollMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenEmployee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<Employee> employeeDetails = new List<Employee>();
            employeeDetails.Add(new Employee(Name: "Bharath", Gender: "M", Phone: "9999999999", Address: "Parchur", Department: "HR", Salary: 50000, Startdate: "2021-05-26"));
            employeeDetails.Add(new Employee(Name: "Sriram", Gender: "M", Phone: "9999999999", Address: "Parchur", Department: "Admin", Salary: 50000, Startdate: "2021-04-26"));
            employeeDetails.Add(new Employee(Name: "Nagoor", Gender: "M", Phone: "9999999999", Address: "Parchur", Department: "Sales", Salary: 50000, Startdate: "2021-03-26"));
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.AddEmployeeDetailsWithOutThread(employeeDetails);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration Without Threads: " + (stopDateTime - startDateTime));
        } 
    }
}
