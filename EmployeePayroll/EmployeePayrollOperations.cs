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

        public void AddEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spAddEmployeeDetails", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give Name: ");
                string name = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Name", name);
                Console.Write("Give Gender: ");
                string gender = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Gender", gender);
                Console.Write("Give PhoneNumber: ");
                string phone = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Phone", phone);
                Console.Write("Give Address: ");
                string address = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Address", address);
                Console.Write("Give Department: ");
                string department = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Department", department);
                Console.Write("Give Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Salary", salary);
                Console.Write("Give Startdate: ");
                DateTime startdate = Convert.ToDateTime(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Startdate", startdate);

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("-----Employee Added Successfully-----");
                }
                else
                    Console.WriteLine("-----Something Went Wrong-----");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        public List<Employee> RetrieveEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployeeDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);

                empList.Clear();
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
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        public int UpdateEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update Employee Set Salary = @Salary Where Name = @Name", this.sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                
                sqlCommand.Parameters.AddWithValue("@Name", "Terisa");
                
                sqlCommand.Parameters.AddWithValue("@Salary", "3000000");

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                
                return effectedRows;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        public int UpdateEmployeeDetailsWithStoredProcedure()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployeeDetails", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Name", "Terisa");

                sqlCommand.Parameters.AddWithValue("@Salary", "3000000");

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();

                return effectedRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void UpdateEmployeeDetailss()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployeeDetails", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give Name Of Employee You Want to Update Salary: ");
                string name = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Name", name);
                Console.Write("Give New Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Salary", salary);

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("-----Updated Successfully-----");
                }
                else
                    Console.WriteLine("-----Something Went Wrong-----");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void DeleteEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeDetails", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give EmpId To Delete: ");
                int empId = Convert.ToInt32(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("-----Deleted Successfully-----");
                }
                else
                    Console.WriteLine("-----Something Went Wrong-----");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        public List<Employee> RetrieveEmployeeDetailsBetweenDateRange()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployeeBetweenDateRange", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give Date 1: ");
                DateTime date1 = Convert.ToDateTime(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Date1", date1);
                Console.Write("Give Date 2: ");
                DateTime date2 = Convert.ToDateTime(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@Date2", date2);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);

                empList.Clear();
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void DisplayDetails()
        {
            if ((empList.Count) > 0)
            {
                Console.WriteLine("________________________________________\n");
                foreach (Employee employee in empList)
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
        }
    }
}
