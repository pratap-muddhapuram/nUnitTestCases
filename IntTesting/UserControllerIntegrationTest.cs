/* <copyright file="UserControllerIntegrationTest.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/06/2024 14:22:58 PM </date>
 * <summary>Class representing a User Controller Integration Test Cases</summary>
 */

using ContextAPI.DAL;
using ContextAPI.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace EmployeeAPITestProject
{
    public class UserControllerIntegrationTest
    {
        public IDALLayer _dalLayer;

        #region One time setup of integration test objects
        /// <summary>
        /// One time setup of user fixture object for integration test
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dalLayer = new DALLayer(new ContextAPI.Models.UserContext());
        }
        #endregion

        #region Integration Test - Validate Db context created user with API get user
        /// <summary>
        /// ValidateUserDbContextwithAPI - create user using Db context and valiate the create user with
        /// GetUser API call to check the integration test and atlast clean the test data.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ValidateUserDbContextwithAPI()
        {
            UserModel user = new() { Id = 0, UserName = "TestInt", Email = "TestInt@Test.com", Name = "TestInt" };
            UserModel actualUser = _dalLayer.AddUser(user);
            int userId = actualUser.Id;
            if (user.Id == 0)
            {
                Assert.Fail("Add User is Failed");
                Assert.That(userId, Is.EqualTo(0));
            }

            string webAPIUrl = "https://localhost:7160/User/GetUser?userId="; // This has to replace to actual uri or url(WebAPI)
            string apiUrl = webAPIUrl + userId;
            HttpClient _client = new HttpClient();
            var response = await _client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var userInfo = JsonConvert.DeserializeObject<UserModel>(content);

                Assert.That(actualUser.Id, Is.EqualTo(userInfo?.Id));
                Assert.That(actualUser.Name, Is.EqualTo(userInfo?.Name));
                Assert.That(actualUser.Email, Is.EqualTo(userInfo?.Email));
                Assert.That(actualUser.UserName, Is.EqualTo(userInfo?.UserName));
            }

            bool _deleteUser = DeleteUser(userId, _dalLayer);
            Assert.That(_deleteUser, Is.True);
        }
        #endregion


        #region Integration test method
        /// <summary>
        /// ValidateUserControllerTests method is integration test - is used to add the user record to Db Context and later
        /// used using the inserted user id get the infromation from Db Context to test get user API call and atlast
        /// used the delete user record which is inserted 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ValidateUserControllerTests()
        {
            // clean the test data 
            int testUserId = 35; // Need to remove hardcoded. This value can be determined at pre-deployment failed test script.
            if (testUserId > 0)
            {
                bool _cleanDeleteEmployee = DeleteUser(testUserId, _dalLayer);
                Assert.That(_cleanDeleteEmployee, Is.True);
            }

            UserModel user = new() { Id = 0, UserName = "TestInt", Email = "TestInt@Test.com", Name="TestInt" };
            UserModel userAdded = _dalLayer.AddUser(user);
            int userId = userAdded.Id;
            if (user.Id == 0)
            {
                Assert.Fail("Add User is Failed");
                Assert.That(userId, Is.EqualTo(0));
            }

            Assert.That(userAdded.Email, Is.EqualTo(user.Email));
            Assert.That(userAdded.Name, Is.EqualTo(user.Name));
            Assert.That(userAdded.UserName, Is.EqualTo(user.UserName));

            UserModel getUser = _dalLayer.GetUser(userId);
            if (getUser.UserName == null)
            {
                Assert.Fail("Get User service is Failed"); 
                Assert.IsNull(getUser.Email);
                Assert.IsNull(getUser.UserName);
                Assert.IsNull(getUser.Name);

                bool deleteUser = DeleteUser(userId, _dalLayer);
                Assert.That(deleteUser, Is.True);
            }

            Assert.That(getUser.Email, Is.EqualTo(user.Email));
            Assert.That(getUser.Name, Is.EqualTo(user.Name));
            Assert.That(getUser.UserName, Is.EqualTo(user.UserName));

            bool _deleteUser = DeleteUser(userId, _dalLayer);
            Assert.That(_deleteUser, Is.True);
        }
        #endregion

        #region Delete Employee Method
        /// <summary>
        /// Delete Employee - Used to delete the employee record  while inserting the integration test data
        /// </summary>
        /// <param name="EmployeeId">Employee Id</param>
        /// <param name="employeeController">Employee Controller Object</param>
        /// <returns></returns>
        private static bool DeleteUser(int userId, IDALLayer dalLayer)
        {
            var deleteUser = dalLayer.DeleteUser(userId);
            if (!deleteUser)
            {
                Assert.That(deleteUser, Is.False);
            }

            return deleteUser;
        }
        #endregion
    }
}
