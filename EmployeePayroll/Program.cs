using System;
using System.Collections.Generic;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Employee Payroll Problem");
            Option option = new Option();
            option.CRUDOperation();
        }
    }
}
