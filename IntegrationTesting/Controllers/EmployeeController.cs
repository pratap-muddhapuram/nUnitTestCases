/* <copyright file="EmployeeController.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/04/2024 11:39:58 AM </date>
 * <summary>Class representing a Employee controller</summary>
 */

using IntegrationTesting.Interfaces;
using IntegrationTesting.Model;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTesting.Controllers
{
    /// <summary>
    /// EmployeeController - Http APIs
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        /// <summary>
        /// Employee Controller constructor
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #region GetEmployees API - to get all employee details
        /// <summary>
        /// GetEmployees API - to get all employees details
        /// </summary>
        /// <returns>list of employees</returns>
        [HttpGet, Route("GetEmployees")]
        public Task<List<Employee>> GetEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployees();
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // ToDo : This needs to replace with Ilogger log
                return Task.Run(() => new List<Employee>());
            }
        }
        #endregion

        #region GetEmployee API - to get employee details based on employee id
        /// <summary>
        /// GetEmployee API - to get particular employee details based on employee id
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>Employee object</returns>
        [HttpGet, Route("GetEmployee/{id}")]
        public Task<Employee> GetEmployee(int id)
        {
            Task<Employee> employee = _employeeService.GetEmployee(id);
            return employee;
        }
        #endregion

        #region PostEmployee API - to add employee to the resource
        /// <summary>
        /// PostEmployee API - to add employee object to the resource
        /// </summary>
        /// <param name="employee">employee object</param>
        /// <returns>employee object</returns>
        [HttpPost, Route("PostEmployee")]
        public Task<Employee> PostEmployee([FromBody] Employee employee)
        {
            try
            {
                Task<Employee> employeeAdded = _employeeService.PostEmployee(employee);
                return employeeAdded;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // ToDo : This needs to replace with Ilogger log
                return Task.Run(() => new Employee());
            }
        }
        #endregion
    }
}