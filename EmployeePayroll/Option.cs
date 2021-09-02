using System;
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
                Console.Write("\n1. Add Employee Payroll Data\n" +
                    "2. Retrieve All Records\n" +
                    "3. Update Employee Payroll Data\n" +
                    "4. Delete Employee Details\n" +
                    "5. Retrieve All Employee Payroll Data Between Date Range\n" +
                    "0. Exit\n" +
                    "Select One Option: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        operations.AddEmployeeDetails();
                        break;
                    case 2:
                        operations.RetrieveEmployeeDetails();
                        operations.DisplayDetails();
                        break;
                    case 3:
                        operations.UpdateEmployeeDetailss();
                        break;
                    case 4:
                        operations.DeleteEmployeeDetails();
                        break;
                    case 5:
                        operations.RetrieveEmployeeDetailsBetweenDateRange();
                        operations.DisplayDetails();
                        break;
                    case 0:
                        Console.WriteLine("________________________________________\n");
                        Console.WriteLine("-----Thankyou-----");
                        break;
                    default:
                        Console.WriteLine("________________________________________\n");
                        Console.WriteLine("-----Invalid Option-----");
                        break;
                }
            }
            while (choice != 0);
        }
    }
}
