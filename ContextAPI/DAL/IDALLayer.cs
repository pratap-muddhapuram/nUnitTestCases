using ContextAPI.Models;
/* <copyright file="IDAlLayer.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/06/2024 14:22:58 PM </date>
 * <summary>Interface representing a Database access layer</summary>
 */

namespace ContextAPI.DAL
{
    /// <summary>
    /// Data access layer Interface
    /// </summary>
    public interface IDALLayer
    {
        /// <summary>
        /// GetUser - get user info
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserModel> GetUsers();
        /// <summary>
        /// GetUsers - get all users info
        /// </summary>
        /// <returns>list of users</returns>
        public UserModel GetUser(int id);
        /// <summary>
        /// AddUser - Adding the user
        /// </summary>
        /// <param name="user">user object</param>
        /// <returns>user object</returns>
        public UserModel AddUser(UserModel user);
        /// <summary>
        /// DeleteUser - Delete the user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>bool is success or not</returns>
        public bool DeleteUser(int id);
    }
}
