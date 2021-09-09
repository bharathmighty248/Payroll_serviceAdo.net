using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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
                string startdate = Console.ReadLine();
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
                            Startdate = Convert.ToString(dataRow["Startdate"])
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
                string date2 = Console.ReadLine();
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
                            Startdate = Convert.ToString(dataRow["Startdate"])
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

        public void AggregateFunctions()
        {
            try
            {
                sqlConnection.Open();
                Console.Write("\n1. Sum\n2. Minimum\n3. Maximum\n4. Average\n5. Count\n" +
                    "Please Select Which Functon You Need: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SqlCommand sqlCommand = new SqlCommand("spSumOfSalaryByGender", sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@Gender", gender);
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Sum: {0}", reader[0]));
                        }
                        break;
                    case 2:
                        SqlCommand sqlCommand1 = new SqlCommand("spMinimumOfSalaryByGender", sqlConnection);
                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender1 = Console.ReadLine();
                        sqlCommand1.Parameters.AddWithValue("@Gender", gender1);
                        SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                        if (reader1.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Minimum: {0}", reader1[0]));
                        }
                        break;
                    case 3:
                        SqlCommand sqlCommand2 = new SqlCommand("spMaximumOfSalaryByGender", sqlConnection);
                        sqlCommand2.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender2 = Console.ReadLine();
                        sqlCommand2.Parameters.AddWithValue("@Gender", gender2);
                        SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                        if (reader2.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Maximum: {0}", reader2[0]));
                        }
                        break;
                    case 4:
                        SqlCommand sqlCommand3 = new SqlCommand("spAverageOfSalaryByGender", sqlConnection);
                        sqlCommand3.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender3 = Console.ReadLine();
                        sqlCommand3.Parameters.AddWithValue("@Gender", gender3);
                        SqlDataReader reader3 = sqlCommand3.ExecuteReader();
                        if (reader3.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Average: {0}", reader3[0]));
                        }
                        break;
                    case 5:
                        SqlCommand sqlCommand4 = new SqlCommand("spCountByGender", sqlConnection);
                        sqlCommand4.CommandType = CommandType.StoredProcedure;
                        Console.Write("Select Analysis By Gender M/F: ");
                        string gender4 = Console.ReadLine();
                        sqlCommand4.Parameters.AddWithValue("@Gender", gender4);
                        SqlDataReader reader4 = sqlCommand4.ExecuteReader();
                        if (reader4.Read())
                        {
                            Console.WriteLine("________________________________________\n");
                            Console.WriteLine(string.Format("Count: {0}", reader4[0]));
                        }
                        break;
                    default:
                        Console.WriteLine("________________________________________\n");
                        Console.WriteLine("-----Invalid Option-----");
                        break;

                }
                
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

        public void AddEmployeeDetailsWithOutThread(List<Employee>employees)
        {
            try
            {
                sqlConnection.Open();
                employees.ForEach(employeeData =>
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployeeDetails", this.sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", employeeData.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", employeeData.Gender);
                    sqlCommand.Parameters.AddWithValue("@Phone", employeeData.Phone);
                    sqlCommand.Parameters.AddWithValue("@Address", employeeData.Address);
                    sqlCommand.Parameters.AddWithValue("@Department", employeeData.Department);
                    sqlCommand.Parameters.AddWithValue("@Salary", employeeData.Salary);
                    sqlCommand.Parameters.AddWithValue("@Startdate", employeeData.Startdate);
                    sqlCommand.ExecuteNonQuery();
                });
                
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
    }
}
