﻿using CodedMilePlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Database
{
    /// <summary>
    /// Database class that defines the tables required for the application and provide
    /// methods for database interaction 
    /// </summary>
    public class MilestoneDb : IdentityDbContext<User>
    {
        /// <summary>
        /// Table that contains Project information
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Table that contains Milestone information
        /// </summary>
        public DbSet<Milestone> Milestones { get; set; }

        public DbSet<UserAuthorisationToken> User_Auth_Tokens { get; set; }

        /// <summary>
        /// Empty constructor that initialises the database
        /// </summary>
        /// <param name="options"></param>
        public MilestoneDb(DbContextOptions<MilestoneDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

    /// <summary>
    /// Class that will actually create the MilestoneDb using the connection string specified
    /// in appsettings.json
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<MilestoneDb>
    {
        public MilestoneDb CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MilestoneDb>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
              //Get correct root path
              .SetBasePath(Directory.GetCurrentDirectory().ToString())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new MilestoneDb(builder.Options);
        }

        
    }

    public static class MilestoneExtensions
    {
        public static void SeedRoles(this MilestoneDb _db, RoleManager<IdentityRole> roleManager)
        {
            seedRoles(roleManager);
        }

        public static void seedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;

            }
        }
    }
}
