using CourseStore.Infra.Data.Sql;
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

            Console.WriteLine("Hello World!");
        }
    }
}
