/* <copyright file="DalLayer.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/06/2024 14:22:58 PM </date>
 * <summary>Class representing a Database access layer</summary>
 */

using ContextAPI.Models;

namespace ContextAPI.DAL
{
    /// <summary>
    /// DALLayer - DB access layer
    /// </summary>
    public class DALLayer : IDALLayer
    {
        #region Declaration of private variables section of the class
        private readonly UserContext _userContext;
        #endregion

        #region Declaration of constructor
        /// <summary>
        /// DALLayer  - Constructor
        /// </summary>
        /// <param name="userContext"></param>
        public DALLayer(UserContext userContext)
        {
            _userContext = userContext;
        }
        #endregion

        #region GetUser - get user info
        /// <summary>
        /// GetUser - get user info
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserModel GetUser(int userId)
        {
            return _userContext.Users.FirstOrDefault(item => item.Id == userId);
        }
        #endregion

        #region GetUser - get all users info
        /// <summary>
        /// GetUsers - get all users info
        /// </summary>
        /// <returns>list of users</returns>
        public List<UserModel> GetUsers()
        {
            return _userContext.Users.ToList();
        }
        #endregion

        #region - Adding user
        /// <summary>
        /// AddUser - Adding the user
        /// </summary>
        /// <param name="user">user object</param>
        /// <returns>user object</returns>
        public UserModel AddUser(UserModel user)
        {
            if (user.Id == 0)
            {
                _userContext.Add(user);
            }
            _userContext.SaveChanges();
            return user;
        }
        #endregion

        #region Deleting the user
        /// <summary>
        /// DeleteUser - Delete the user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>bool is success or not</returns>
        public bool DeleteUser(int userId)
        {
            UserModel userDetails = _userContext.Users.FirstOrDefault(item => item.Id == userId);
            if (userDetails != null)
            {
                _userContext.Users.Remove(userDetails);
                _userContext.SaveChanges();
                return _userContext.Users.Where(item => item.Id == userId).Count() > 0 ? false : true;
            }
            return false;
        }
        #endregion
    }
}
