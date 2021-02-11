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

            var employee = new Employee
            {
                Name = "Salam",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Name = "Zenver"
                    },
                    new Employee
                    {
                        Name = "Barin"
                    }
                }
            };

            context.Employees.Add(employee);

            context.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}
