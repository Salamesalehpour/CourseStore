using Microsoft.EntityFrameworkCore.Design;

namespace CourseStore.Infra.Data.Sql
{
    public class CourseDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CourseStoreContext>
    {
        public CourseStoreContext CreateDbContext(string[] args)
        {
            return ContextFactory.SqlServerCourseStoreContext();
        }
    }
}
