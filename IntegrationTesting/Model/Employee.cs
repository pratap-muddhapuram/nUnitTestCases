/* <copyright file="Employee.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/04/2024 11:39:58 AM </date>
 * <summary>Class representing a Employee Model</summary>
 */

namespace IntegrationTesting.Model
{
    /// <summary>
    /// Employee 
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Employee_Name { get; set; }
        public int Employee_Salary { get; set; }
        public int Employee_Age { get; set; }
        public string Profile_Image { get; set; }

    }

    /// <summary>
    /// EmployeesResponseObject
    /// </summary>
    public class EmployeesResponseObject
    {
        public string Status { get; set; }
        public List<Employee> Data { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// EmployeeResponseObject
    /// </summary>
    public class EmployeeResponseObject
    {
        public string Status { get; set; }
        public Employee Data { get; set; }
        public string Message { get; set; }
    }

    public class EmployeeDeleteResponseObject
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
