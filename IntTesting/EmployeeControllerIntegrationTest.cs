/* <copyright file="IntegrationTest.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/04/2024 12:22:58 PM </date>
 * <summary>Class representing a Employee Controller Test Cases</summary>
 */

using IntegrationTesting;
using IntegrationTesting.Controllers;
using IntegrationTesting.Interfaces;
using IntegrationTesting.Model;

namespace IntTesting
{
    /// <summary>
    /// Integration Test Class
    /// </summary>
    public class EmployeeControllerIntegrationTest
    {
        public IEmployeeService _employeeService;
        public EmployeeController _employeeController;

        #region One time setup of integration test objects
        /// <summary>
        /// One time setup of employee fixture object for integration test
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _employeeService = new EmployeeService(new HttpClient());
            _employeeController = new EmployeeController(_employeeService);
        }
        #endregion

        #region Integration test method
        /// <summary>
        /// ValidateSaveGetEmployee method is integration test - is used to post the employee record to API/Database and later
        /// used using the inserted employeed get the infromation from API/Database to test get employee API call and atlast
        /// used the delete employee record which is inserted 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ValidateSaveGetEmployee()
        {
            Employee employee = new() { Employee_Age = 50, Employee_Name="testIntegration", Employee_Salary=10000 };
            Employee employeeAdded = _employeeController.PostEmployee(employee).Result;
            int EmployeeId = employeeAdded.Id;
            if (employeeAdded == null)
            {
                Assert.Fail("Add Employee service is not recheable"); // Can also be verified for Assert.IsNull()
            }

            Employee getEmployee = _employeeController.GetEmployee(EmployeeId).Result;
            if (getEmployee == null)
            {
                Assert.Fail("Get Employee service is not recheable"); // Can also be verified for Assert.IsNull()
            }

            Assert.That(getEmployee.Id, Is.EqualTo(EmployeeId));

            bool deleteEmployee = _employeeController.DeleteEmployee(EmployeeId).Result;
            if (!deleteEmployee)
            {
                Assert.Fail("delete Employee service is failed/not recheable");
            }

            Assert.That(deleteEmployee, Is.True);
        }
        #endregion
    }
}
