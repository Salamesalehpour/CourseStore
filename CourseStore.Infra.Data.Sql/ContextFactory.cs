using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infra.Data.Sql
{
    public class ContextFactory
    {
        public static CourseStoreContext SqlServerCourseStoreContext()
        {
            var builder = new DbContextOptionsBuilder<CourseStoreContext>();
            builder.UseSqlServer("Server=.; Database=CourseStore; Integrated Security= true;");
            return new CourseStoreContext(builder.Options);
        }
    }
}
