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

            var course = new Course { Title = "Java", Price = 100, Description = "Java for .Net Developers" };

            ctx.Courses.Add(course);

            Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

            ctx.SaveChanges();

            Console.WriteLine(ctx.ChangeTracker.DebugView.LongView);

            Console.WriteLine("Hello World!");
        }
    }
}
