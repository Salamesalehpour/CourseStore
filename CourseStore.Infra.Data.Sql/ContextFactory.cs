using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace CourseStore.Infra.Data.Sql
{
    public class ContextFactory
    {

        public static CourseStoreContext SqlServerCourseStoreContext()
        {
            var builder = new DbContextOptionsBuilder<CourseStoreContext>();

            builder.UseSqlServer("Server=.; Database=CourseStore; Integrated Security= true;")
                .LogTo(Console.WriteLine, LogLevel.Information);

            return new CourseStoreContext(builder.Options);
        }
    }
}
