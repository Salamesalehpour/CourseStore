using CourseStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseStore.Infra.Data.Sql
{
    public class CourseStoreContext : DbContext
    {
        public CourseStoreContext(DbContextOptions<CourseStoreContext> options)
            : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasQueryFilter(c => c.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
