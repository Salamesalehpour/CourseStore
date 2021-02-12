using CourseStore.Core.Domain;
using CourseStore.Infra.Data.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseStore.Endpoints.CourseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = ContextFactory.SqlServerCourseStoreContext();

            QueryRepository.AddToParent();

            var parentQuery = context.Parents.Include(p => p.Child1s).Include(p => p.Child2s).Include(p => p.Child3s).AsQueryable();

            var parentQueryString = parentQuery.ToQueryString();

            var res = parentQuery.ToList();


            Console.WriteLine("Hello World!");
        }
    }
}
