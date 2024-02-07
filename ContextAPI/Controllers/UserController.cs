/* <copyright file="UserController.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/06/2024 14:22:58 PM </date>
 * <summary>Class representing a User Controller</summary>
 */

using ContextAPI.DAL;
using ContextAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContextAPI.Controllers
{
    /// <summary>
    /// UserController - using Db Context
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        #region Declaration of private variables section of the class
        private readonly IDALLayer _dalLayer;
        #endregion

        #region Construction is declared
        /// <summary>
        /// UserController  - Constructor
        /// </summary>
        /// <param name="dALLayer"></param>
        public UserController(IDALLayer dALLayer)
        {
            _dalLayer = dALLayer;
        }
        #endregion

        #region Add user - adding user to the Db
        /// <summary>
        /// Add Users - Adding user to the Db
        /// </summary>
        /// <param name="user">user model object</param>
        /// <returns>user model object json</returns>
        [HttpPost]
        public IActionResult AddUsers(UserModel user)
        {
            return Ok(_dalLayer.AddUser(user));
        }
        #endregion

        #region GetUsers - Get all users from the Db
        /// <summary>
        /// GetUsers - Get all users in the Db
        /// </summary>
        /// <returns>list of users</returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dalLayer.GetUsers());
        }
        #endregion

        #region GetUser - Get particular user info of given user id
        /// <summary>
        /// GetUser - Get the user details of given user id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>user object</returns>
        [HttpGet]
        public IActionResult GetUser(int userId)
        {
           return Ok(_dalLayer.GetUser(userId));
        }
        #endregion

        #region DeleteUser - Delete the user based on user id
        /// <summary>
        /// DeleteUser - delete the user based on user id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>bool is success or not</returns>
        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            return Ok(_dalLayer.DeleteUser(userId));
        }
        #endregion
    }
}
