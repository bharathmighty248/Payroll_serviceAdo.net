using EmployeePayroll;
using NUnit.Framework;

namespace EmployeePayrollTest
{
    public class Tests
    {
        EmployeePayrollOperations operations = new EmployeePayrollOperations();
        /// <summary>
        /// Test Case For UC-3
        /// </summary>
        [Test]
        public void GivenEmployeePayrollDB_AfterUpdateQuery_ShouldReturnEffectedRows()
        {
            int expected = 1;
            int actual = operations.UpdateEmployeeDetails();
            Assert.AreEqual(expected,actual);
        }
    }
}