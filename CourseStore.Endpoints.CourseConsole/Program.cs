using CourseStore.Core.Domain;
using CourseStore.Infra.Data.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CourseStore.Endpoints.CourseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = ContextFactory.SqlServerCourseStoreContext();

            //Soft Delete

            var course = ctx.Courses.SingleOrDefault(c => c.Id == 2);

            course.IsDeleted = true;

            ctx.SaveChanges();

            var courses = ctx.Courses.IgnoreQueryFilters().ToList();

            Console.WriteLine("Hello World!");
        }
    }
}
