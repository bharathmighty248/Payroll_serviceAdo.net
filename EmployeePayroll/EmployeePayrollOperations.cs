using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll
{
    public class EmployeePayrollOperations
    {
        public List<Employee> empList = new List<Employee>();
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public List<Employee> RetrieveEmployeeDetails()
        {

            SqlCommand sqlCommand = new SqlCommand("spGetAllEmployeeDetails", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                empList.Add(
                    new Employee
                    {
                        EmpId = Convert.ToInt32(dataRow["EmpId"]),
                        Name = Convert.ToString(dataRow["Name"]),
                        Gender = Convert.ToString(dataRow["Gender"]),
                        Phone = Convert.ToString(dataRow["Phone"]),
                        Address = Convert.ToString(dataRow["Address"]),
                        Department = Convert.ToString(dataRow["Department"]),
                        Salary = Convert.ToInt32(dataRow["Salary"]),
                        Startdate = Convert.ToDateTime(dataRow["Startdate"])
                    }
                    );
            }
            return empList;
        }
    }

}
