/* <copyright file="UserContext.cs" company="">
 * Copyright (c) 2024 All Rights Reserved
 * </copyright>
 * <author>Pratap Muddhapuram</author>
 * <date>02/06/2024 14:22:58 PM </date>
 * <summary>Class representing a User DB context</summary>
 */

using Microsoft.EntityFrameworkCore;

namespace ContextAPI.Models
{
    /// <summary>
    /// UserContext - User DB context
    /// </summary>
    public class UserContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Repos\NetCore\Demo.db");
        }
    }
}
