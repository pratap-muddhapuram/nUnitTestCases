using IntegrationTesting.Model;
/* <copyright file="IEmployeeService.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/04/2024 11:39:58 AM </date>
 * <summary>The below representing a Employeeservice Interface</summary>
 */

namespace IntegrationTesting.Interfaces
{
    /// <summary>
    /// Employee Service Interface
    /// </summary>
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> PostEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
