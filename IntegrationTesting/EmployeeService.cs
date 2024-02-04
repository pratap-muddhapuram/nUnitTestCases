/* <copyright file="EmployeeService.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/04/2024 11:39:58 AM </date>
 * <summary>Class representing a Employee Service for CRUD operations</summary>
 */

using IntegrationTesting.Interfaces;
using IntegrationTesting.Model;
using Newtonsoft.Json;
using System.Text;

namespace IntegrationTesting
{
    /// <summary>
    /// Employee Service class for CRUD operation using httpclient(APIs)
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Employee service constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public EmployeeService(HttpClient httpClient) { 
            _httpClient = httpClient;
        }

        #region Delete Employee operation method - to delete the employee record
        /// <summary>
        /// Delete Employee operation
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>Success message</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task IEmployeeService.DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Get Employee operation method - To get particular employee details based on employee id
        /// <summary>
        /// Get Employee method to fetch particular employee using employee id
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>employee object</returns>
        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = null;
            HttpResponseMessage response = await _httpClient.GetAsync("https://dummy.restapiexample.com/api/v1/employee/" + id);
            if (response.IsSuccessStatusCode)
            {
                var ResponseObject = ParseData<EmployeeResponseObject>(response);
                employee = ResponseObject.Result.Data;
            }
            return employee;
        }
        #endregion

        #region Get Employees operation method - To get all employees details
        /// <summary>
        /// Get Employee method to fetch all employees details
        /// </summary>
        /// <returns>List of employee object</returns>
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = null;
            HttpResponseMessage response = await _httpClient.GetAsync("https://dummy.restapiexample.com/api/v1/employees");
            if (response.IsSuccessStatusCode)
            {
                var ResponseObject = ParseData<EmployeesResponseObject>(response);
                employees = ResponseObject.Result.Data;
            }
            return employees;
        }
        #endregion

        #region Post Employee operation method - To Add employee details
        /// <summary>
        /// Add new employee object
        /// </summary>
        /// <param name="employeeObject">employee object</param>
        /// <returns>employee object</returns>
        /// <exception cref="Exception">exception</exception>
        public async Task<Employee> PostEmployee(Employee employeeObject)
        {
            Employee employee = null;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(employeeObject).ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("https://dummy.restapiexample.com/api/v1/create", content);
                if (response.IsSuccessStatusCode)
                {
                    var ResponseObject = ParseData<EmployeeResponseObject>(response);
                    employee = ResponseObject.Result.Data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employee;
        }
        #endregion

        /// <summary>
        /// To parse the data
        /// </summary>
        /// <typeparam name="T">Generic class name</typeparam>
        /// <param name="response">http response message</param>
        /// <returns>Deserialized object</returns>
        private async Task<T> ParseData<T>(HttpResponseMessage response) where T: class
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
