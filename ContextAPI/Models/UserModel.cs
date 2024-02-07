/* <copyright file="UserModel.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/06/2024 14:22:58 PM </date>
 * <summary>Class representing a User Model</summary>
 */

namespace ContextAPI.Models
{
    /// <summary>
    /// UserModel class
    /// </summary>
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public string UserName { get; set; }
    }
}
