﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    public class Option
    {
        EmployeePayrollOperations operations = new EmployeePayrollOperations();
        public int choice;
        public void CRUDOperation()
        {
            do
            {
                Console.Write("\n1. Retrieve All Records\n" +
                    "0. Exit\n" +
                    "Select One Option: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("________________________________________");
                switch (choice)
                {
                    case 1:
                        operations.RetrieveEmployeeDetails();
                        if ((operations.empList.Count) > 0)
                        {
                            foreach (Employee employee in operations.empList)
                            {
                                Console.WriteLine("Employee Id: " + employee.EmpId);
                                Console.WriteLine("Name: " + employee.Name);
                                Console.WriteLine("Gender: " + employee.Gender);
                                Console.WriteLine("Phone: " + employee.Phone);
                                Console.WriteLine("Address: " + employee.Address);
                                Console.WriteLine("Department: " + employee.Department);
                                Console.WriteLine("Salary: " + employee.Salary);
                                Console.WriteLine("StartDate: " + employee.Startdate);
                                Console.WriteLine("________________________________________\n");
                            }
                        }
                        else
                            Console.WriteLine("-----Data Not Found-----");
                        break;
                    case 0:
                        Console.WriteLine("-----Thankyou-----");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            while (choice != 0);
        }
    }
}