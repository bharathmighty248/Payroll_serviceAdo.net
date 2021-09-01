using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll
{
    public class EmployeePayrollOperations
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }

}
