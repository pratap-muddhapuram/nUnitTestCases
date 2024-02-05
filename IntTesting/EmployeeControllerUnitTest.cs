/* <copyright file="EmployeeConrollerTest.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/04/2024 11:39:58 AM </date>
 * <summary>Class representing a Employee Controller Test Cases</summary>
 */

using AutoFixture;
using IntegrationTesting.Controllers;
using IntegrationTesting.Interfaces;
using IntegrationTesting.Model;
using Moq;

namespace IntTesting
{
    /// <summary>
    /// EmployeeControllerTest class
    /// </summary>
    public class EmployeeControllerUnitTest
    {
        #region declaring the private variables for class
        private readonly Fixture _fixture;
        private readonly Mock<IEmployeeService> _employeeServiceMock;
        private EmployeeController _employeeController;
        #endregion

        #region public construct of EmployeeControllerTest
        /// <summary>
        /// Construct of EmployeeControllerTest
        /// </summary>
        public EmployeeControllerUnitTest() {
            _fixture = new Fixture();
            _employeeServiceMock = new Mock<IEmployeeService>();
        }
        #endregion

        #region GetEmployees test method - positive test case
        /// <summary>
        /// Validate the GetEmployees API
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetEmployees()
        {
            var employeeList = _fixture.CreateMany<Employee>(3).ToList();
            _employeeServiceMock.Setup(item => item.GetEmployees()).ReturnsAsync(employeeList);
            _employeeController = new EmployeeController(_employeeServiceMock.Object);

            var employeeApiResults = await _employeeController.GetEmployees();
            Assert.IsNotNull(employeeApiResults);
            Assert.That(employeeApiResults, Is.EqualTo(employeeList));
        }
        #endregion


        #region GetEmployees test method - negative test case
        /// <summary>
        /// Validate the GetEmployees API
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetEmployees_ThrowException()
        {
            _employeeServiceMock.Setup(item => item.GetEmployees()).Throws(new Exception());
            _employeeController = new EmployeeController(_employeeServiceMock.Object);

            var employeeApiResults = (await _employeeController.GetEmployees());
            Assert.IsEmpty(employeeApiResults);
        }
        #endregion

        #region GetEmployee test method accepts the id as parameter
        /// <summary>
        /// Validate the GetEmployees API
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetEmployee()
        {
            var employee = _fixture.Create<Employee>();
            _employeeServiceMock.Setup(item => item.GetEmployee(employee.Id)).ReturnsAsync(employee);
            _employeeController = new EmployeeController(_employeeServiceMock.Object);

            var employeeApiResults = await _employeeController.GetEmployee(employee.Id);
            Assert.IsNotNull(employeeApiResults);
            Assert.That(employeeApiResults, Is.EqualTo(employee));
        }
        #endregion


        #region PostEmployee test method accepts the employee as object parameter
        /// <summary>
        /// Validate the PostEmployee API
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PostEmployee()
        {
            var employee = _fixture.Create<Employee>();
            _employeeServiceMock.Setup(item => item.PostEmployee(It.IsAny<Employee>())).ReturnsAsync(employee);
            _employeeController = new EmployeeController(_employeeServiceMock.Object);

            var employeeApiResults = await _employeeController.PostEmployee(employee);
            Assert.IsNotNull(employeeApiResults);
            Assert.That(employeeApiResults, Is.EqualTo(employee));
        }
        #endregion


        #region PostEmployee test method - negative test case
        /// <summary>
        /// Validate the PostEmployee API
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PostEmployee_ThrowException()
        {
            var employee = _fixture.Create<Employee>();
            _employeeServiceMock.Setup(item => item.PostEmployee(It.IsAny<Employee>())).Throws(new Exception());
            _employeeController = new EmployeeController(_employeeServiceMock.Object);

            var employeeApiResults = (await _employeeController.PostEmployee(employee));
            Assert.That(employeeApiResults, Is.Not.EqualTo(employee));
        }
        #endregion

        #region DeleteEmployee test method accepts the id as parameter
        /// <summary>
        /// Validate the GetEmployees API
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteEmployee()
        {
            var employee = _fixture.Create<Employee>();
            _employeeServiceMock.Setup(item => item.DeleteEmployee(employee.Id)).ReturnsAsync(true);
            _employeeController = new EmployeeController(_employeeServiceMock.Object);

            var employeeApiResults = await _employeeController.DeleteEmployee(employee.Id);
            Assert.IsNotNull(employeeApiResults);
            Assert.That(employeeApiResults, Is.True);
        }
        #endregion

    }
}
