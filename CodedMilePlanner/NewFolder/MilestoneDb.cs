using CodedMilePlanner.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.NewFolder
{
    public class MilestoneDb : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Milestone> Milestones { get; set; }

        public MilestoneDb(DbContextOptions<MilestoneDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

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
}
