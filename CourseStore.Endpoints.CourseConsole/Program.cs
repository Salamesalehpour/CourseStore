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

            //var teachers = ctx.Teachers.OrderBy(t => t.FullName).Where(t => t.FirstName.Contains("reza")).ToList();

            var course = ctx.Courses.FirstOrDefault();

            Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

            //course.Title = "Java";

            ctx.Entry(course).Property(c => c.Title).CurrentValue = "Java";

            Console.WriteLine("-----------------------------------");

            //ctx.ChangeTracker.DetectChanges();

            Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

            Console.WriteLine("Hello World!");
        }
    }
}
